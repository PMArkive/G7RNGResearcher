namespace G7ModelResearch
{
    partial class MainForm
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
            ntrclient?.disconnect();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NTR_Timer = new System.Windows.Forms.Timer(this.components);
            this.B_Disconnect = new System.Windows.Forms.Button();
            this.B_Connect = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.B_run = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.B_Disable = new System.Windows.Forms.Button();
            this.B_Enable = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.ListBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_Resume = new System.Windows.Forms.Button();
            this.BP = new System.Windows.Forms.TextBox();
            this.B_Sort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // NTR_Timer
            // 
            this.NTR_Timer.Interval = 10;
            this.NTR_Timer.Tick += new System.EventHandler(this.NTR_Timer_Tick);
            // 
            // B_Disconnect
            // 
            this.B_Disconnect.Enabled = false;
            this.B_Disconnect.Location = new System.Drawing.Point(406, 34);
            this.B_Disconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Disconnect.Name = "B_Disconnect";
            this.B_Disconnect.Size = new System.Drawing.Size(104, 38);
            this.B_Disconnect.TabIndex = 121;
            this.B_Disconnect.Text = "Disconnect";
            this.B_Disconnect.UseVisualStyleBackColor = true;
            this.B_Disconnect.Click += new System.EventHandler(this.B_Disconnect_Click);
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(266, 34);
            this.B_Connect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(104, 38);
            this.B_Connect.TabIndex = 120;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 43);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 20);
            this.label18.TabIndex = 119;
            this.label18.Text = "IP";
            // 
            // IP
            // 
            this.IP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(58, 37);
            this.IP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(151, 22);
            this.IP.TabIndex = 118;
            this.IP.Text = "192.168.0.1";
            // 
            // B_run
            // 
            this.B_run.Location = new System.Drawing.Point(132, 152);
            this.B_run.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_run.Name = "B_run";
            this.B_run.Size = new System.Drawing.Size(104, 38);
            this.B_run.TabIndex = 122;
            this.B_run.Text = "Run";
            this.B_run.UseVisualStyleBackColor = true;
            this.B_run.Click += new System.EventHandler(this.B_run_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(536, 34);
            this.DGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 10;
            this.DGV.Size = new System.Drawing.Size(573, 508);
            this.DGV.TabIndex = 123;
            // 
            // B_Disable
            // 
            this.B_Disable.Location = new System.Drawing.Point(252, 100);
            this.B_Disable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Disable.Name = "B_Disable";
            this.B_Disable.Size = new System.Drawing.Size(148, 38);
            this.B_Disable.TabIndex = 130;
            this.B_Disable.Text = "Disable/Continue";
            this.B_Disable.UseVisualStyleBackColor = true;
            this.B_Disable.Click += new System.EventHandler(this.B_Disable_Click);
            // 
            // B_Enable
            // 
            this.B_Enable.Location = new System.Drawing.Point(160, 100);
            this.B_Enable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Enable.Name = "B_Enable";
            this.B_Enable.Size = new System.Drawing.Size(75, 38);
            this.B_Enable.TabIndex = 129;
            this.B_Enable.Text = "Enable";
            this.B_Enable.UseVisualStyleBackColor = true;
            this.B_Enable.Click += new System.EventHandler(this.B_Enable_Click);
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Log.FormattingEnabled = true;
            this.Log.ItemHeight = 20;
            this.Log.Location = new System.Drawing.Point(16, 215);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(508, 324);
            this.Log.TabIndex = 131;
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(410, 100);
            this.B_Clear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(100, 38);
            this.B_Clear.TabIndex = 132;
            this.B_Clear.Text = "Clear Log";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // B_Resume
            // 
            this.B_Resume.Location = new System.Drawing.Point(252, 152);
            this.B_Resume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Resume.Name = "B_Resume";
            this.B_Resume.Size = new System.Drawing.Size(117, 38);
            this.B_Resume.TabIndex = 133;
            this.B_Resume.Text = "Resume";
            this.B_Resume.UseVisualStyleBackColor = true;
            this.B_Resume.Click += new System.EventHandler(this.B_Resume_Click);
            // 
            // BP
            // 
            this.BP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BP.Location = new System.Drawing.Point(16, 100);
            this.BP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BP.Name = "BP";
            this.BP.Size = new System.Drawing.Size(120, 22);
            this.BP.TabIndex = 134;
            this.BP.Text = "0x0000000";
            // 
            // B_Sort
            // 
            this.B_Sort.Location = new System.Drawing.Point(389, 152);
            this.B_Sort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B_Sort.Name = "B_Sort";
            this.B_Sort.Size = new System.Drawing.Size(104, 38);
            this.B_Sort.TabIndex = 135;
            this.B_Sort.Text = "Sort";
            this.B_Sort.UseVisualStyleBackColor = true;
            this.B_Sort.Click += new System.EventHandler(this.B_Sort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 571);
            this.Controls.Add(this.B_Sort);
            this.Controls.Add(this.BP);
            this.Controls.Add(this.B_Resume);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.B_Disable);
            this.Controls.Add(this.B_Enable);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.B_run);
            this.Controls.Add(this.B_Disconnect);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.IP);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "G7ModelResearch";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer NTR_Timer;
        private System.Windows.Forms.Button B_Disconnect;
        private System.Windows.Forms.Button B_Connect;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Button B_run;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button B_Disable;
        private System.Windows.Forms.Button B_Enable;
        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Button B_Resume;
        private System.Windows.Forms.TextBox BP;
        private System.Windows.Forms.Button B_Sort;
    }
}

