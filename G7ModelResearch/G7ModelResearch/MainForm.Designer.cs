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
            this.B_Disconnect.Location = new System.Drawing.Point(271, 22);
            this.B_Disconnect.Name = "B_Disconnect";
            this.B_Disconnect.Size = new System.Drawing.Size(69, 25);
            this.B_Disconnect.TabIndex = 121;
            this.B_Disconnect.Text = "Disconnect";
            this.B_Disconnect.UseVisualStyleBackColor = true;
            this.B_Disconnect.Click += new System.EventHandler(this.B_Disconnect_Click);
            // 
            // B_Connect
            // 
            this.B_Connect.Location = new System.Drawing.Point(177, 22);
            this.B_Connect.Name = "B_Connect";
            this.B_Connect.Size = new System.Drawing.Size(69, 25);
            this.B_Connect.TabIndex = 120;
            this.B_Connect.Text = "Connect";
            this.B_Connect.UseVisualStyleBackColor = true;
            this.B_Connect.Click += new System.EventHandler(this.B_Connect_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 13);
            this.label18.TabIndex = 119;
            this.label18.Text = "IP";
            // 
            // IP
            // 
            this.IP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(39, 24);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(102, 22);
            this.IP.TabIndex = 118;
            this.IP.Text = "192.168.0.1";
            // 
            // B_run
            // 
            this.B_run.Location = new System.Drawing.Point(19, 65);
            this.B_run.Name = "B_run";
            this.B_run.Size = new System.Drawing.Size(69, 25);
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
            this.DGV.Location = new System.Drawing.Point(357, 22);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 10;
            this.DGV.Size = new System.Drawing.Size(382, 330);
            this.DGV.TabIndex = 123;
            // 
            // B_Disable
            // 
            this.B_Disable.Location = new System.Drawing.Point(168, 65);
            this.B_Disable.Name = "B_Disable";
            this.B_Disable.Size = new System.Drawing.Size(99, 25);
            this.B_Disable.TabIndex = 130;
            this.B_Disable.Text = "Disable/Continue";
            this.B_Disable.UseVisualStyleBackColor = true;
            this.B_Disable.Click += new System.EventHandler(this.B_Disable_Click);
            // 
            // B_Enable
            // 
            this.B_Enable.Location = new System.Drawing.Point(107, 65);
            this.B_Enable.Name = "B_Enable";
            this.B_Enable.Size = new System.Drawing.Size(50, 25);
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
            this.Log.Location = new System.Drawing.Point(11, 114);
            this.Log.Margin = new System.Windows.Forms.Padding(2);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(340, 238);
            this.Log.TabIndex = 131;
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(273, 65);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(67, 25);
            this.B_Clear.TabIndex = 132;
            this.B_Clear.Text = "Clear Log";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 371);
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
    }
}

