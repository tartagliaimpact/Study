namespace лаб2_ООП
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.XMLWrite = new System.Windows.Forms.Button();
            this.XMLRead = new System.Windows.Forms.Button();
            this.AddAp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.footgtb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colkomnud = new System.Windows.Forms.NumericUpDown();
            this.floorNuD = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.clearb = new System.Windows.Forms.Button();
            this.FootageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomcolcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KitchenCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ButhCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ToiletCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Basecol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BalconyCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.YofBCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FloorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdressCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colkomnud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorNuD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FootageCol,
            this.roomcolcol,
            this.KitchenCol,
            this.ButhCol,
            this.ToiletCol,
            this.Basecol,
            this.BalconyCol,
            this.YofBCol,
            this.MTCol,
            this.FloorCol,
            this.AdressCol});
            this.dataGridView1.Location = new System.Drawing.Point(183, 296);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1463, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // XMLWrite
            // 
            this.XMLWrite.Location = new System.Drawing.Point(24, 500);
            this.XMLWrite.Name = "XMLWrite";
            this.XMLWrite.Size = new System.Drawing.Size(140, 23);
            this.XMLWrite.TabIndex = 1;
            this.XMLWrite.Text = "Записать в XML";
            this.XMLWrite.UseVisualStyleBackColor = true;
            this.XMLWrite.Click += new System.EventHandler(this.XMLWrite_Click);
            // 
            // XMLRead
            // 
            this.XMLRead.Location = new System.Drawing.Point(24, 529);
            this.XMLRead.Name = "XMLRead";
            this.XMLRead.Size = new System.Drawing.Size(140, 23);
            this.XMLRead.TabIndex = 2;
            this.XMLRead.Text = "Прочитать из XML";
            this.XMLRead.UseVisualStyleBackColor = true;
            this.XMLRead.Click += new System.EventHandler(this.XMLRead_Click);
            // 
            // AddAp
            // 
            this.AddAp.Location = new System.Drawing.Point(23, 442);
            this.AddAp.Name = "AddAp";
            this.AddAp.Size = new System.Drawing.Size(140, 23);
            this.AddAp.TabIndex = 5;
            this.AddAp.Text = "Добавить";
            this.AddAp.UseVisualStyleBackColor = true;
            this.AddAp.Click += new System.EventHandler(this.AddAp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Метраж";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Количество комнат";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Тип Материала";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Этаж";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Год постройки";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(208, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Характеристики";
            // 
            // footgtb
            // 
            this.footgtb.Location = new System.Drawing.Point(208, 36);
            this.footgtb.Name = "footgtb";
            this.footgtb.Size = new System.Drawing.Size(120, 23);
            this.footgtb.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(898, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Адресс";
            // 
            // colkomnud
            // 
            this.colkomnud.Location = new System.Drawing.Point(208, 71);
            this.colkomnud.Name = "colkomnud";
            this.colkomnud.Size = new System.Drawing.Size(120, 23);
            this.colkomnud.TabIndex = 23;
            // 
            // floorNuD
            // 
            this.floorNuD.Location = new System.Drawing.Point(208, 109);
            this.floorNuD.Name = "floorNuD";
            this.floorNuD.Size = new System.Drawing.Size(120, 23);
            this.floorNuD.TabIndex = 24;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(207, 148);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 25;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(207, 195);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 26;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(399, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 19);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Кухня";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(399, 78);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 19);
            this.checkBox2.TabIndex = 28;
            this.checkBox2.Text = "Ванна";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(399, 113);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(62, 19);
            this.checkBox3.TabIndex = 29;
            this.checkBox3.Text = "Туалет";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(399, 155);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(67, 19);
            this.checkBox4.TabIndex = 30;
            this.checkBox4.Text = "Подвал";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(399, 191);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 19);
            this.checkBox5.TabIndex = 31;
            this.checkBox5.Text = "Балкон";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(790, 35);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 32;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(790, 71);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(674, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Страна";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(674, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Город";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(674, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "Район";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(674, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Улица";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(674, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 38;
            this.label13.Text = "Дом";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(994, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 39;
            this.label14.Text = "Корпус";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(994, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 15);
            this.label15.TabIndex = 40;
            this.label15.Text = "Номер квартиры";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(790, 111);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 23);
            this.comboBox5.TabIndex = 41;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(790, 151);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 23);
            this.comboBox6.TabIndex = 42;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(790, 192);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 23);
            this.comboBox7.TabIndex = 43;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1143, 109);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(227, 45);
            this.trackBar1.TabIndex = 45;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1226, 148);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 15);
            this.label16.TabIndex = 46;
            this.label16.Text = "Номер:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1226, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "Номер:";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(1143, 36);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(227, 23);
            this.hScrollBar2.TabIndex = 47;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // clearb
            // 
            this.clearb.Location = new System.Drawing.Point(23, 471);
            this.clearb.Name = "clearb";
            this.clearb.Size = new System.Drawing.Size(140, 23);
            this.clearb.TabIndex = 48;
            this.clearb.Text = "Очистить поля ввода";
            this.clearb.UseVisualStyleBackColor = true;
            this.clearb.Click += new System.EventHandler(this.clearb_Click);
            // 
            // FootageCol
            // 
            this.FootageCol.HeaderText = "Метраж";
            this.FootageCol.Name = "FootageCol";
            this.FootageCol.ReadOnly = true;
            // 
            // roomcolcol
            // 
            this.roomcolcol.HeaderText = "Количество комнат";
            this.roomcolcol.Name = "roomcolcol";
            this.roomcolcol.ReadOnly = true;
            // 
            // KitchenCol
            // 
            this.KitchenCol.HeaderText = "Кухня";
            this.KitchenCol.Name = "KitchenCol";
            this.KitchenCol.ReadOnly = true;
            this.KitchenCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KitchenCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ButhCol
            // 
            this.ButhCol.HeaderText = "Ванна";
            this.ButhCol.Name = "ButhCol";
            this.ButhCol.ReadOnly = true;
            this.ButhCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ButhCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ToiletCol
            // 
            this.ToiletCol.HeaderText = "Туалет";
            this.ToiletCol.Name = "ToiletCol";
            this.ToiletCol.ReadOnly = true;
            this.ToiletCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ToiletCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Basecol
            // 
            this.Basecol.HeaderText = "Подвал";
            this.Basecol.Name = "Basecol";
            this.Basecol.ReadOnly = true;
            this.Basecol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Basecol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BalconyCol
            // 
            this.BalconyCol.HeaderText = "Балкон";
            this.BalconyCol.Name = "BalconyCol";
            this.BalconyCol.ReadOnly = true;
            this.BalconyCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BalconyCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // YofBCol
            // 
            this.YofBCol.HeaderText = "Год постройки";
            this.YofBCol.Name = "YofBCol";
            this.YofBCol.ReadOnly = true;
            // 
            // MTCol
            // 
            this.MTCol.HeaderText = "Тип материала";
            this.MTCol.Name = "MTCol";
            this.MTCol.ReadOnly = true;
            // 
            // FloorCol
            // 
            this.FloorCol.HeaderText = "Этаж";
            this.FloorCol.Name = "FloorCol";
            this.FloorCol.ReadOnly = true;
            // 
            // AdressCol
            // 
            this.AdressCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AdressCol.HeaderText = "Адресс";
            this.AdressCol.Name = "AdressCol";
            this.AdressCol.ReadOnly = true;
            this.AdressCol.Width = 71;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1658, 577);
            this.Controls.Add(this.clearb);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.floorNuD);
            this.Controls.Add(this.colkomnud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.footgtb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddAp);
            this.Controls.Add(this.XMLRead);
            this.Controls.Add(this.XMLWrite);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colkomnud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorNuD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button XMLWrite;
        private Button XMLRead;
        private Button AddAp;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox footgtb;
        private Label label3;
        private NumericUpDown colkomnud;
        private NumericUpDown floorNuD;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label13;
        private Label label14;
        private Label label15;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private ComboBox comboBox7;
        private TrackBar trackBar1;
        private Label label16;
        private HScrollBar hScrollBar1;
        private Label label17;
        private HScrollBar hScrollBar2;
        private Button clearb;
        private DataGridViewTextBoxColumn FootageCol;
        private DataGridViewTextBoxColumn roomcolcol;
        private DataGridViewCheckBoxColumn KitchenCol;
        private DataGridViewCheckBoxColumn ButhCol;
        private DataGridViewCheckBoxColumn ToiletCol;
        private DataGridViewCheckBoxColumn Basecol;
        private DataGridViewCheckBoxColumn BalconyCol;
        private DataGridViewTextBoxColumn YofBCol;
        private DataGridViewTextBoxColumn MTCol;
        private DataGridViewTextBoxColumn FloorCol;
        private DataGridViewTextBoxColumn AdressCol;
    }
}