namespace Communication.Interface.Implementation.Panel
{
    partial class IpPortPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.TelnetPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TelnetIP = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TelnetPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TelnetIP, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 54);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 27);
            this.label10.TabIndex = 3;
            this.label10.Text = "Port:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TelnetPort
            // 
            this.TelnetPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TelnetPort.Location = new System.Drawing.Point(80, 30);
            this.TelnetPort.Name = "TelnetPort";
            this.TelnetPort.Size = new System.Drawing.Size(128, 21);
            this.TelnetPort.TabIndex = 23;
            this.TelnetPort.Text = "23";
            this.TelnetPort.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 27);
            this.label9.TabIndex = 3;
            this.label9.Text = "IP Address:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TelnetIP
            // 
            this.TelnetIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TelnetIP.Location = new System.Drawing.Point(80, 3);
            this.TelnetIP.Name = "TelnetIP";
            this.TelnetIP.Size = new System.Drawing.Size(128, 21);
            this.TelnetIP.TabIndex = 2;
            this.TelnetIP.Text = "192.168.1.100";
            this.TelnetIP.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // IpPortPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IpPortPanel";
            this.Size = new System.Drawing.Size(211, 74);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TelnetIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TelnetPort;
        private System.Windows.Forms.Label label10;


    }
}
