using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ProgrammingChallengeMandakh
{
    public partial class MatchedData : Form
    {
        #region [FormLoad]
        public MatchedData()
        {
            InitializeComponent();
        }

        #endregion

        #region [Declaration - Variable]
        OpenFileDialog ofd = new OpenFileDialog();
        DataTable dtOur;
        DataTable dtTheir;
        DataParameter _inputParameter;
        struct DataParameter
        {
            public string FileName { get; set; }
        }
        public bool isSuccessfullySaved { get; set; } = false;
        #endregion

        #region [Events - Button]
        private void ourDataBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox_ourDataPath.Text = ofd.FileName;
                BindDataCSVOurData(this.textBox_ourDataPath.Text);
            }
        }

        private void btnTheirData_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName;
                BindDataCSVTheirData(this.textBox1.Text);
            }
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _inputParameter.FileName = sfd.FileName;
                    progressBar.Minimum = 0;
                    progressBar.Value = 0;
                    backgroundWorker.RunWorkerAsync(_inputParameter);
                }
            }
        }
        #endregion

        #region [Custom defined methods]
        private void BindDataCSVOurData(string filePath)
        {
            dtOur = new DataTable();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');

                    foreach (string headerWord in headerLabels)
                    {
                        dtOur.Columns.Add(new DataColumn(headerWord));
                    }

                    for (int r = 1; r < lines.Length; r++)
                    {
                        string[] dataWords = lines[r].Split(',');
                        DataRow dr = dtOur.NewRow();
                        int columnIndex = 0;
                        foreach (string headerWord in headerLabels)
                        {
                            dr[headerWord] = dataWords[columnIndex++];
                        }
                        dtOur.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            
        }

        private void BindDataCSVTheirData(string filePath)
        {
            dtTheir = new DataTable();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');

                    foreach (string headerWord in headerLabels)
                    {
                        dtTheir.Columns.Add(new DataColumn(headerWord));
                    }

                    dtTheir.Columns.Add(new DataColumn("TrackingID"));

                    for (int r = 1; r < lines.Length; r++)
                    {
                        string[] dataWords = lines[r].Split(',');
                        DataRow dr = dtTheir.NewRow();
                        int columnIndex = 0;
                        foreach (string headerWord in headerLabels)
                        {
                            dr[headerWord] = dataWords[columnIndex++];
                            if (headerWord.ToUpper() == "CREATIVE")
                            {
                                Regex regex = new Regex(@"_BL");
                                Match match = regex.Match(dataWords[columnIndex - 1]);
                                if (match.Success)
                                {
                                    if (dr["Creative"].ToString().Length > 20)
                                    {
                                        string str = dr["Creative"].ToString()
                                        .Substring(dr["Creative"].ToString().Length - 20);
                                        dr["TrackingId"] = str.Substring(str.IndexOf("_BL"));
                                    }
                                }
                            }
                        }
                        dtTheir.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
           
        }

        #endregion

        #region [Events - BackgroundWorker]
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            isSuccessfullySaved = false;
            try
            {
                // I put Our data and Their data into 2 datatables and now I use LINQ to join tables
                // and variable results contain matched data
                var results = from table1 in dtTheir.AsEnumerable()
                              join table2 in dtOur.AsEnumerable() on table1["TrackingID"] equals table2["TrackingID"]
                              select new
                              {
                                  ID = table2[0],
                                  Name = table2[1],
                                  TrackingID = table2[2],
                                  Creative = table1[0],
                                  Clicks = table1[1],
                                  Impressions = table1[2],
                                  DateStamp = table1[3],
                              };


                //This next section retrieve all data from results table and export to CSV file
                string fileName = ((DataParameter)e.Argument).FileName;
                int index = 1;
                int process = results.Count();
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6}",
                        "ID", "Name", "Tracking ID", "Creative", "Clicks", "Impressions", "DateStamp"));
                    if (!backgroundWorker.CancellationPending)
                    {
                        foreach (var item in results)
                        {
                            backgroundWorker.ReportProgress(index++ * 100 / process);
                            sb.AppendLine(String.Format("{0},{1},{2},{3},{4},{5},{6}",
                                item.ID, item.Name, item.TrackingID, item.Creative, item.Clicks, item.Impressions, item.DateStamp));
                        }
                    }
                    sw.Write(sb.ToString());
                    isSuccessfullySaved = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);   
            }
           
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblStatus.Text = string.Format("Processing...{0}%", e.ProgressPercentage);
            progressBar.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(100);
            if (isSuccessfullySaved)
                lblStatus.Text = "Your data has been successfully exported!";
            else
                lblStatus.Text = "Please check your files and try again!";
        }
        #endregion
    }
}
