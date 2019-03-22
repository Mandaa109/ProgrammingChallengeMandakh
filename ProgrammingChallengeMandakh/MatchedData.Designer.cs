namespace ProgrammingChallengeMandakh
{
    partial class MatchedData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOurData = new System.Windows.Forms.Button();
            this.textBox_ourDataPath = new System.Windows.Forms.TextBox();
            this.btnTheirData = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCombine = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnOurData
            // 
            this.btnOurData.Location = new System.Drawing.Point(45, 40);
            this.btnOurData.Name = "btnOurData";
            this.btnOurData.Size = new System.Drawing.Size(150, 56);
            this.btnOurData.TabIndex = 0;
            this.btnOurData.Text = "Choose Our data";
            this.btnOurData.UseVisualStyleBackColor = true;
            this.btnOurData.Click += new System.EventHandler(this.ourDataBtn_Click);
            // 
            // textBox_ourDataPath
            // 
            this.textBox_ourDataPath.Location = new System.Drawing.Point(210, 57);
            this.textBox_ourDataPath.Name = "textBox_ourDataPath";
            this.textBox_ourDataPath.ReadOnly = true;
            this.textBox_ourDataPath.Size = new System.Drawing.Size(478, 22);
            this.textBox_ourDataPath.TabIndex = 1;
            // 
            // btnTheirData
            // 
            this.btnTheirData.Location = new System.Drawing.Point(45, 110);
            this.btnTheirData.Name = "btnTheirData";
            this.btnTheirData.Size = new System.Drawing.Size(150, 49);
            this.btnTheirData.TabIndex = 3;
            this.btnTheirData.Text = "Choose Their data";
            this.btnTheirData.UseVisualStyleBackColor = true;
            this.btnTheirData.Click += new System.EventHandler(this.btnTheirData_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(210, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(478, 22);
            this.textBox1.TabIndex = 4;
            // 
            // btnCombine
            // 
            this.btnCombine.Location = new System.Drawing.Point(45, 176);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(150, 52);
            this.btnCombine.TabIndex = 6;
            this.btnCombine.Text = "Combine data and Export";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(210, 189);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(478, 23);
            this.progressBar.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(207, 236);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 17);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Processing...0%";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 286);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCombine);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnTheirData);
            this.Controls.Add(this.textBox_ourDataPath);
            this.Controls.Add(this.btnOurData);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Liquidus Back-End programming Challenge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOurData;
        private System.Windows.Forms.TextBox textBox_ourDataPath;
        private System.Windows.Forms.Button btnTheirData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

