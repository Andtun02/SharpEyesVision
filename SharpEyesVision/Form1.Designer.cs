namespace SharpEyesVision
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.displayBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.minNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.templateBox = new System.Windows.Forms.PictureBox();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openCBD = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbdBox = new System.Windows.Forms.PictureBox();
            this.scoreNum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbdBox)).BeginInit();
            this.SuspendLayout();
            // 
            // displayBox
            // 
            this.displayBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.displayBox.Location = new System.Drawing.Point(12, 12);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(1024, 695);
            this.displayBox.TabIndex = 0;
            this.displayBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scoreNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.maxNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.minNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.templateBox);
            this.groupBox1.Location = new System.Drawing.Point(1043, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 269);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "匹配设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = " 得分阈值";
            // 
            // maxNum
            // 
            this.maxNum.Location = new System.Drawing.Point(6, 242);
            this.maxNum.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.maxNum.Name = "maxNum";
            this.maxNum.Size = new System.Drawing.Size(125, 27);
            this.maxNum.TabIndex = 11;
            this.maxNum.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "最大检测角度";
            // 
            // minNum
            // 
            this.minNum.Location = new System.Drawing.Point(6, 182);
            this.minNum.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.minNum.Name = "minNum";
            this.minNum.Size = new System.Drawing.Size(125, 27);
            this.minNum.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "最小检测角度";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(229, 118);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(125, 27);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "间隔延迟(ms)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择模板";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // templateBox
            // 
            this.templateBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.templateBox.Location = new System.Drawing.Point(6, 26);
            this.templateBox.Name = "templateBox";
            this.templateBox.Size = new System.Drawing.Size(217, 119);
            this.templateBox.TabIndex = 3;
            this.templateBox.TabStop = false;
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(6, 26);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(126, 28);
            this.cbDevices.TabIndex = 4;
            this.cbDevices.SelectionChangeCommitted += new System.EventHandler(this.cbDevices_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.openCBD);
            this.groupBox2.Controls.Add(this.cbDevices);
            this.groupBox2.Location = new System.Drawing.Point(1266, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 119);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "摄像头设置";
            // 
            // openCBD
            // 
            this.openCBD.Location = new System.Drawing.Point(6, 60);
            this.openCBD.Name = "openCBD";
            this.openCBD.Size = new System.Drawing.Size(125, 29);
            this.openCBD.TabIndex = 5;
            this.openCBD.Text = "打开相机";
            this.openCBD.UseVisualStyleBackColor = true;
            this.openCBD.Click += new System.EventHandler(this.openCBD_Click);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.logBox.Location = new System.Drawing.Point(6, 26);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(348, 297);
            this.logBox.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logBox);
            this.groupBox3.Location = new System.Drawing.Point(1043, 489);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 218);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(1049, 412);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(360, 71);
            this.button2.TabIndex = 8;
            this.button2.Text = "运行";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbdBox
            // 
            this.cbdBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbdBox.Location = new System.Drawing.Point(1049, 12);
            this.cbdBox.Name = "cbdBox";
            this.cbdBox.Size = new System.Drawing.Size(217, 119);
            this.cbdBox.TabIndex = 9;
            this.cbdBox.TabStop = false;
            // 
            // scoreNum
            // 
            this.scoreNum.Location = new System.Drawing.Point(152, 182);
            this.scoreNum.Name = "scoreNum";
            this.scoreNum.Size = new System.Drawing.Size(125, 27);
            this.scoreNum.TabIndex = 13;
            this.scoreNum.Text = "0.7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 718);
            this.Controls.Add(this.cbdBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.displayBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbdBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox displayBox;
        private GroupBox groupBox1;
        private PictureBox templateBox;
        private ComboBox cbDevices;
        private GroupBox groupBox2;
        private Button openCBD;
        private TextBox logBox;
        private GroupBox groupBox3;
        private Button button2;
        private Button button1;
        private PictureBox cbdBox;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown maxNum;
        private Label label3;
        private NumericUpDown minNum;
        private Label label2;
        private Label label4;
        private TextBox scoreNum;
    }
}