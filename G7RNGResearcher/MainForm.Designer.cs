namespace G7RNGResearcher
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.B_Disable = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.ListBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.BP = new System.Windows.Forms.TextBox();
            this.B_Sort = new System.Windows.Forms.Button();
            this.BP2 = new System.Windows.Forms.CheckBox();
            this.BP7 = new System.Windows.Forms.CheckBox();
            this.BP3 = new System.Windows.Forms.CheckBox();
            this.BP6 = new System.Windows.Forms.CheckBox();
            this.BP5 = new System.Windows.Forms.CheckBox();
            this.BP8 = new System.Windows.Forms.CheckBox();
            this.BP9 = new System.Windows.Forms.CheckBox();
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
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(401, 22);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 10;
            this.DGV.Size = new System.Drawing.Size(455, 343);
            this.DGV.TabIndex = 123;
            // 
            // B_Disable
            // 
            this.B_Disable.Location = new System.Drawing.Point(110, 65);
            this.B_Disable.Name = "B_Disable";
            this.B_Disable.Size = new System.Drawing.Size(99, 25);
            this.B_Disable.TabIndex = 130;
            this.B_Disable.Text = "Disable/Continue";
            this.B_Disable.UseVisualStyleBackColor = true;
            this.B_Disable.Click += new System.EventHandler(this.B_Disable_Click);
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Log.FormattingEnabled = true;
            this.Log.Location = new System.Drawing.Point(11, 163);
            this.Log.Margin = new System.Windows.Forms.Padding(2);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(385, 199);
            this.Log.TabIndex = 131;
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(215, 65);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(67, 25);
            this.B_Clear.TabIndex = 132;
            this.B_Clear.Text = "Clear Log";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // BP
            // 
            this.BP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BP.Location = new System.Drawing.Point(11, 65);
            this.BP.Name = "BP";
            this.BP.Size = new System.Drawing.Size(81, 22);
            this.BP.TabIndex = 134;
            this.BP.Text = "0x0000000";
            // 
            // B_Sort
            // 
            this.B_Sort.Location = new System.Drawing.Point(288, 65);
            this.B_Sort.Name = "B_Sort";
            this.B_Sort.Size = new System.Drawing.Size(69, 25);
            this.B_Sort.TabIndex = 135;
            this.B_Sort.Text = "Sort";
            this.B_Sort.UseVisualStyleBackColor = true;
            this.B_Sort.Click += new System.EventHandler(this.B_Sort_Click);
            // 
            // BP2
            // 
            this.BP2.AutoSize = true;
            this.BP2.Location = new System.Drawing.Point(12, 107);
            this.BP2.Name = "BP2";
            this.BP2.Size = new System.Drawing.Size(65, 17);
            this.BP2.TabIndex = 136;
            this.BP2.Text = "2 - RNG";
            this.BP2.UseVisualStyleBackColor = true;
            this.BP2.CheckedChanged += new System.EventHandler(this.BP2_CheckedChanged);
            // 
            // BP7
            // 
            this.BP7.AutoSize = true;
            this.BP7.Location = new System.Drawing.Point(298, 107);
            this.BP7.Name = "BP7";
            this.BP7.Size = new System.Drawing.Size(71, 17);
            this.BP7.TabIndex = 137;
            this.BP7.Text = "7 - Dialog";
            this.BP7.UseVisualStyleBackColor = true;
            this.BP7.CheckedChanged += new System.EventHandler(this.BP7_CheckedChanged);
            // 
            // BP3
            // 
            this.BP3.AutoSize = true;
            this.BP3.Location = new System.Drawing.Point(73, 107);
            this.BP3.Name = "BP3";
            this.BP3.Size = new System.Drawing.Size(75, 17);
            this.BP3.TabIndex = 137;
            this.BP3.Text = "3/4 - Blink";
            this.BP3.UseVisualStyleBackColor = true;
            this.BP3.CheckedChanged += new System.EventHandler(this.BP3_CheckedChanged);
            // 
            // BP6
            // 
            this.BP6.AutoSize = true;
            this.BP6.Location = new System.Drawing.Point(215, 107);
            this.BP6.Name = "BP6";
            this.BP6.Size = new System.Drawing.Size(84, 17);
            this.BP6.TabIndex = 138;
            this.BP6.Text = "6 - PKMGen";
            this.BP6.UseVisualStyleBackColor = true;
            this.BP6.CheckedChanged += new System.EventHandler(this.BP6_CheckedChanged);
            // 
            // BP5
            // 
            this.BP5.AutoSize = true;
            this.BP5.Location = new System.Drawing.Point(150, 107);
            this.BP5.Name = "BP5";
            this.BP5.Size = new System.Drawing.Size(65, 17);
            this.BP5.TabIndex = 139;
            this.BP5.Text = "5 - Sync";
            this.BP5.UseVisualStyleBackColor = true;
            this.BP5.CheckedChanged += new System.EventHandler(this.BP5_CheckedChanged);
            // 
            // BP8
            // 
            this.BP8.AutoSize = true;
            this.BP8.Location = new System.Drawing.Point(12, 139);
            this.BP8.Name = "BP8";
            this.BP8.Size = new System.Drawing.Size(63, 17);
            this.BP8.TabIndex = 140;
            this.BP8.Text = "8 - SOS";
            this.BP8.UseVisualStyleBackColor = true;
            this.BP8.CheckedChanged += new System.EventHandler(this.BP8_CheckedChanged);
            // 
            // BP9
            // 
            this.BP9.AutoSize = true;
            this.BP9.Location = new System.Drawing.Point(81, 139);
            this.BP9.Name = "BP9";
            this.BP9.Size = new System.Drawing.Size(61, 17);
            this.BP9.TabIndex = 141;
            this.BP9.Text = "9 - Tiny";
            this.BP9.UseVisualStyleBackColor = true;
            this.BP9.CheckedChanged += new System.EventHandler(this.BP9_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 384);
            this.Controls.Add(this.BP9);
            this.Controls.Add(this.BP7);
            this.Controls.Add(this.BP8);
            this.Controls.Add(this.BP5);
            this.Controls.Add(this.BP6);
            this.Controls.Add(this.BP3);
            this.Controls.Add(this.BP2);
            this.Controls.Add(this.B_Sort);
            this.Controls.Add(this.BP);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.B_Disable);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.B_Disconnect);
            this.Controls.Add(this.B_Connect);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.IP);
            this.Name = "MainForm";
            this.Text = "Gen7 RNG Reseacher @wwwwwwzx";
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
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button B_Disable;
        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.TextBox BP;
        private System.Windows.Forms.Button B_Sort;
        private System.Windows.Forms.CheckBox BP2;
        private System.Windows.Forms.CheckBox BP7;
        private System.Windows.Forms.CheckBox BP3;
        private System.Windows.Forms.CheckBox BP6;
        private System.Windows.Forms.CheckBox BP5;
        private System.Windows.Forms.CheckBox BP8;
        private System.Windows.Forms.CheckBox BP9;
    }
}

