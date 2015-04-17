namespace Communication.Interface.Implementation.Panel
{
    partial class SerialPortPanel
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
            this.StopBitText = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ParityText = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SerialPortText = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DataBitText = new System.Windows.Forms.ComboBox();
            this.BaudRateText = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutPanel1.Controls.Add(this.StopBitText, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ParityText, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SerialPortText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DataBitText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BaudRateText, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 130);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StopBitText
            // 
            this.StopBitText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopBitText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBitText.FormattingEnabled = true;
            this.StopBitText.Items.AddRange(new object[] {
            "One",
            "Two",
            "OnePointFive"});
            this.StopBitText.Location = new System.Drawing.Point(74, 107);
            this.StopBitText.Name = "StopBitText";
            this.StopBitText.Size = new System.Drawing.Size(183, 20);
            this.StopBitText.TabIndex = 14;
            this.StopBitText.SelectedIndexChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 26);
            this.label7.TabIndex = 18;
            this.label7.Text = "Stop:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "Port:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ParityText
            // 
            this.ParityText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParityText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityText.FormattingEnabled = true;
            this.ParityText.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.ParityText.Location = new System.Drawing.Point(74, 81);
            this.ParityText.Name = "ParityText";
            this.ParityText.Size = new System.Drawing.Size(183, 20);
            this.ParityText.TabIndex = 17;
            this.ParityText.SelectedIndexChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 26);
            this.label6.TabIndex = 20;
            this.label6.Text = "Parity:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SerialPortText
            // 
            this.SerialPortText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SerialPortText.FormattingEnabled = true;
            this.SerialPortText.Location = new System.Drawing.Point(74, 3);
            this.SerialPortText.Name = "SerialPortText";
            this.SerialPortText.Size = new System.Drawing.Size(183, 20);
            this.SerialPortText.TabIndex = 15;
            this.SerialPortText.Text = "COM1";
            this.SerialPortText.SelectedIndexChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data Bits:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 26);
            this.label4.TabIndex = 22;
            this.label4.Text = "Baud Rate:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataBitText
            // 
            this.DataBitText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataBitText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBitText.FormattingEnabled = true;
            this.DataBitText.Items.AddRange(new object[] {
            "7",
            "8"});
            this.DataBitText.Location = new System.Drawing.Point(74, 55);
            this.DataBitText.Name = "DataBitText";
            this.DataBitText.Size = new System.Drawing.Size(183, 20);
            this.DataBitText.TabIndex = 13;
            this.DataBitText.SelectedIndexChanged += new System.EventHandler(this.ConfigChange);
            // 
            // BaudRateText
            // 
            this.BaudRateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaudRateText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRateText.FormattingEnabled = true;
            this.BaudRateText.Items.AddRange(new object[] {
            "75",
            "150",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.BaudRateText.Location = new System.Drawing.Point(74, 29);
            this.BaudRateText.Name = "BaudRateText";
            this.BaudRateText.Size = new System.Drawing.Size(183, 20);
            this.BaudRateText.TabIndex = 16;
            this.BaudRateText.SelectedIndexChanged += new System.EventHandler(this.ConfigChange);
            // 
            // SerialPortPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SerialPortPanel";
            this.Size = new System.Drawing.Size(260, 139);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox StopBitText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ParityText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SerialPortText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DataBitText;
        private System.Windows.Forms.ComboBox BaudRateText;

    }
}
