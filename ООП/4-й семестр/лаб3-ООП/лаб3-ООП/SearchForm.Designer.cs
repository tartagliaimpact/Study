namespace лаб3_ООП
{
    partial class SearchForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.ClearRes = new System.Windows.Forms.Button();
            this.SaveRes = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchGridView1 = new System.Windows.Forms.DataGridView();
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
            this.IndxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdressCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadRes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SearchGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(22, 53);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(141, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ClearRes
            // 
            this.ClearRes.Location = new System.Drawing.Point(22, 82);
            this.ClearRes.Name = "ClearRes";
            this.ClearRes.Size = new System.Drawing.Size(141, 23);
            this.ClearRes.TabIndex = 3;
            this.ClearRes.Text = "Очистить результаты";
            this.ClearRes.UseVisualStyleBackColor = true;
            this.ClearRes.Click += new System.EventHandler(this.ClearRes_Click);
            // 
            // SaveRes
            // 
            this.SaveRes.Location = new System.Drawing.Point(22, 111);
            this.SaveRes.Name = "SaveRes";
            this.SaveRes.Size = new System.Drawing.Size(141, 23);
            this.SaveRes.TabIndex = 4;
            this.SaveRes.Text = "Сохранить результаты";
            this.SaveRes.UseVisualStyleBackColor = true;
            this.SaveRes.Click += new System.EventHandler(this.SaveRes_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(22, 24);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(141, 23);
            this.SearchBox.TabIndex = 5;
            // 
            // SearchGridView1
            // 
            this.SearchGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.IndxCol,
            this.AdressCol,
            this.CostCol});
            this.SearchGridView1.Location = new System.Drawing.Point(22, 170);
            this.SearchGridView1.Name = "SearchGridView1";
            this.SearchGridView1.RowTemplate.Height = 25;
            this.SearchGridView1.Size = new System.Drawing.Size(1586, 256);
            this.SearchGridView1.TabIndex = 6;
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
            // IndxCol
            // 
            this.IndxCol.HeaderText = "Индекс";
            this.IndxCol.Name = "IndxCol";
            this.IndxCol.ReadOnly = true;
            // 
            // AdressCol
            // 
            this.AdressCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AdressCol.HeaderText = "Адресс";
            this.AdressCol.Name = "AdressCol";
            this.AdressCol.ReadOnly = true;
            this.AdressCol.Width = 71;
            // 
            // CostCol
            // 
            this.CostCol.HeaderText = "Цена";
            this.CostCol.Name = "CostCol";
            this.CostCol.ReadOnly = true;
            // 
            // ReadRes
            // 
            this.ReadRes.Location = new System.Drawing.Point(22, 140);
            this.ReadRes.Name = "ReadRes";
            this.ReadRes.Size = new System.Drawing.Size(141, 23);
            this.ReadRes.TabIndex = 7;
            this.ReadRes.Text = "Прочитать из файла";
            this.ReadRes.UseVisualStyleBackColor = true;
            this.ReadRes.Click += new System.EventHandler(this.ReadRes_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 438);
            this.Controls.Add(this.ReadRes);
            this.Controls.Add(this.SearchGridView1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SaveRes);
            this.Controls.Add(this.ClearRes);
            this.Controls.Add(this.SearchButton);
            this.Name = "SearchForm";
            this.Text = "Поиск";
            ((System.ComponentModel.ISupportInitialize)(this.SearchGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button SearchButton;
        private Button ClearRes;
        private Button SaveRes;
        private TextBox SearchBox;
        private DataGridView SearchGridView1;
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
        private DataGridViewTextBoxColumn IndxCol;
        private DataGridViewTextBoxColumn AdressCol;
        private DataGridViewTextBoxColumn CostCol;
        private Button ReadRes;
    }
}