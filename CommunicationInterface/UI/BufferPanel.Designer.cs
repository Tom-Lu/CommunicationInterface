namespace Communication.Interface.UI
{
    partial class BufferPanel
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
            this.BufferDefaultBtn = new System.Windows.Forms.Button();
            this.ReadBufferSize = new System.Windows.Forms.TextBox();
            this.BufferConfigCheck = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GlobalBufferSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.BufferDefaultBtn, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ReadBufferSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BufferConfigCheck, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.GlobalBufferSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 105);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BufferDefaultBtn
            // 
            this.BufferDefaultBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.BufferDefaultBtn.Enabled = false;
            this.BufferDefaultBtn.Location = new System.Drawing.Point(196, 79);
            this.BufferDefaultBtn.Name = "BufferDefaultBtn";
            this.BufferDefaultBtn.Size = new System.Drawing.Size(75, 23);
            this.BufferDefaultBtn.TabIndex = 9;
            this.BufferDefaultBtn.Text = "Default";
            this.BufferDefaultBtn.UseVisualStyleBackColor = true;
            this.BufferDefaultBtn.Click += new System.EventHandler(this.BufferDefaultBtn_Click);
            // 
            // ReadBufferSize
            // 
            this.ReadBufferSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadBufferSize.Enabled = false;
            this.ReadBufferSize.Location = new System.Drawing.Point(98, 52);
            this.ReadBufferSize.Name = "ReadBufferSize";
            this.ReadBufferSize.Size = new System.Drawing.Size(173, 21);
            this.ReadBufferSize.TabIndex = 7;
            this.ReadBufferSize.Text = "4096";
            this.ReadBufferSize.TextChanged += new System.EventHandler(this.BufferSize_TextChanged);
            // 
            // BufferConfigCheck
            // 
            this.BufferConfigCheck.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.BufferConfigCheck, 2);
            this.BufferConfigCheck.Location = new System.Drawing.Point(3, 3);
            this.BufferConfigCheck.Name = "BufferConfigCheck";
            this.BufferConfigCheck.Size = new System.Drawing.Size(168, 16);
            this.BufferConfigCheck.TabIndex = 4;
            this.BufferConfigCheck.Text = "Config Buffer Size(Byte)";
            this.BufferConfigCheck.UseVisualStyleBackColor = true;
            this.BufferConfigCheck.CheckedChanged += new System.EventHandler(this.BufferConfigCheck_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 27);
            this.label11.TabIndex = 6;
            this.label11.Text = "Read Buffer:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GlobalBufferSize
            // 
            this.GlobalBufferSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GlobalBufferSize.Enabled = false;
            this.GlobalBufferSize.Location = new System.Drawing.Point(98, 25);
            this.GlobalBufferSize.Name = "GlobalBufferSize";
            this.GlobalBufferSize.Size = new System.Drawing.Size(173, 21);
            this.GlobalBufferSize.TabIndex = 8;
            this.GlobalBufferSize.Text = "40960";
            this.GlobalBufferSize.TextChanged += new System.EventHandler(this.BufferSize_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 27);
            this.label8.TabIndex = 5;
            this.label8.Text = "Global Buffer:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BufferPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BufferPanel";
            this.Size = new System.Drawing.Size(274, 113);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BufferDefaultBtn;
        private System.Windows.Forms.TextBox ReadBufferSize;
        private System.Windows.Forms.CheckBox BufferConfigCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox GlobalBufferSize;
        private System.Windows.Forms.Label label8;


    }
}
