namespace лаб1_ООП
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
            this.Height_ = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.Female = new System.Windows.Forms.RadioButton();
            this.Male = new System.Windows.Forms.RadioButton();
            this.Bust = new System.Windows.Forms.TextBox();
            this.Waist = new System.Windows.Forms.TextBox();
            this.Hip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Clr = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.EU_Result = new System.Windows.Forms.TextBox();
            this.RusBel_Result = new System.Windows.Forms.TextBox();
            this.USA_Result = new System.Windows.Forms.TextBox();
            this.UK_Result = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Height_
            // 
            this.Height_.Location = new System.Drawing.Point(178, 87);
            this.Height_.Name = "Height_";
            this.Height_.Size = new System.Drawing.Size(100, 23);
            this.Height_.TabIndex = 1;
            this.Height_.Text = "";
            this.Height_.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(226, 283);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(85, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Рассчитать";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Female
            // 
            this.Female.AutoSize = true;
            this.Female.Location = new System.Drawing.Point(178, 47);
            this.Female.Name = "Female";
            this.Female.Size = new System.Drawing.Size(75, 19);
            this.Female.TabIndex = 2;
            this.Female.Text = "Женский";
            this.Female.UseVisualStyleBackColor = true;
            this.Female.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Male
            // 
            this.Male.AutoSize = true;
            this.Male.Location = new System.Drawing.Point(288, 47);
            this.Male.Name = "Male";
            this.Male.Size = new System.Drawing.Size(77, 19);
            this.Male.TabIndex = 3;
            this.Male.Text = "Мужской";
            this.Male.UseVisualStyleBackColor = true;
            this.Male.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Bust
            // 
            this.Bust.Location = new System.Drawing.Point(178, 136);
            this.Bust.Name = "Bust";
            this.Bust.Size = new System.Drawing.Size(100, 23);
            this.Bust.TabIndex = 4;
            this.Bust.Text = "";
            this.Bust.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Waist
            // 
            this.Waist.Location = new System.Drawing.Point(178, 178);
            this.Waist.Name = "Waist";
            this.Waist.Size = new System.Drawing.Size(100, 23);
            this.Waist.TabIndex = 5;
            this.Waist.Text = "";
            // 
            // Hip
            // 
            this.Hip.Location = new System.Drawing.Point(178, 223);
            this.Hip.Name = "Hip";
            this.Hip.Size = new System.Drawing.Size(100, 23);
            this.Hip.TabIndex = 6;
            this.Hip.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Рост:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Обхват груди:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Обхват талии:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Обхват бёдер:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Пол:";
            // 
            // Clr
            // 
            this.Clr.Location = new System.Drawing.Point(370, 283);
            this.Clr.Name = "Clr";
            this.Clr.Size = new System.Drawing.Size(89, 24);
            this.Clr.TabIndex = 16;
            this.Clr.Text = "Очистить всё";
            this.Clr.UseVisualStyleBackColor = true;
            this.Clr.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Европа";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Россия/Беларусь";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "США";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(425, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Великобритания";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(571, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 15);
            this.label12.TabIndex = 27;
            this.label12.Text = "Размер";
            // 
            // EU_Result
            // 
            this.EU_Result.Location = new System.Drawing.Point(571, 87);
            this.EU_Result.Name = "EU_Result";
            this.EU_Result.Size = new System.Drawing.Size(100, 23);
            this.EU_Result.TabIndex = 28;
            // 
            // RusBel_Result
            // 
            this.RusBel_Result.Location = new System.Drawing.Point(571, 136);
            this.RusBel_Result.Name = "RusBel_Result";
            this.RusBel_Result.Size = new System.Drawing.Size(100, 23);
            this.RusBel_Result.TabIndex = 29;
            // 
            // USA_Result
            // 
            this.USA_Result.Location = new System.Drawing.Point(571, 183);
            this.USA_Result.Name = "USA_Result";
            this.USA_Result.Size = new System.Drawing.Size(100, 23);
            this.USA_Result.TabIndex = 30;
            // 
            // UK_Result
            // 
            this.UK_Result.Location = new System.Drawing.Point(571, 228);
            this.UK_Result.Name = "UK_Result";
            this.UK_Result.Size = new System.Drawing.Size(100, 23);
            this.UK_Result.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(136, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 15);
            this.label13.TabIndex = 32;
            this.label13.Text = "Данные";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(506, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 15);
            this.label14.TabIndex = 33;
            this.label14.Text = " Результат";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "см";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(289, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 15);
            this.label11.TabIndex = 35;
            this.label11.Text = "см";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(289, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 36;
            this.label15.Text = "см";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(289, 231);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 15);
            this.label16.TabIndex = 37;
            this.label16.Text = "см";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 321);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.UK_Result);
            this.Controls.Add(this.USA_Result);
            this.Controls.Add(this.RusBel_Result);
            this.Controls.Add(this.EU_Result);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Clr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hip);
            this.Controls.Add(this.Waist);
            this.Controls.Add(this.Bust);
            this.Controls.Add(this.Male);
            this.Controls.Add(this.Female);
            this.Controls.Add(this.Height_);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Калькулятор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox Height_;
        private Button Start;
        private RadioButton Female;
        private RadioButton Male;
        private TextBox Bust;
        private TextBox Waist;
        private TextBox Hip;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button Clr;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label12;
        private TextBox EU_Result;
        private TextBox RusBel_Result;
        private TextBox USA_Result;
        private TextBox UK_Result;
        private Label label13;
        private Label label14;
        private Label label6;
        private Label label11;
        private Label label15;
        private Label label16;
    }
}

