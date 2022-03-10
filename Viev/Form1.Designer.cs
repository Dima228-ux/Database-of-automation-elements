namespace Database_of_automation_elements
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewElectricalEquipment = new System.Windows.Forms.DataGridView();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.pictureBoxPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxCharacterisrics = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElectricalEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewElectricalEquipment
            // 
            this.dataGridViewElectricalEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewElectricalEquipment.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewElectricalEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewElectricalEquipment.Location = new System.Drawing.Point(-4, 52);
            this.dataGridViewElectricalEquipment.Name = "dataGridViewElectricalEquipment";
            this.dataGridViewElectricalEquipment.Size = new System.Drawing.Size(861, 184);
            this.dataGridViewElectricalEquipment.TabIndex = 0;
            this.dataGridViewElectricalEquipment.SelectionChanged += new System.EventHandler(this.dataGridViewElectricalEquipment_SelectionChanged);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Items.AddRange(new object[] {
            "Свето техника",
            "Низковольтное оборудование",
            "Компенсация реактивной мощности",
            "Шкафы, боксы и аксессуары",
            "Системы для прокладки кабеля",
            "Элекстроустановочные изделия и аксессуары",
            "Силовые разъемы",
            "Вентиляторы и Аксессуары ",
            "Инструменты",
            "Монтажные иделия "});
            this.comboBoxCategories.Location = new System.Drawing.Point(2, 25);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(246, 21);
            this.comboBoxCategories.TabIndex = 1;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategories_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(254, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(595, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(572, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(277, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(2, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(277, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(286, 242);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(277, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonDeleteElectricalEquipment_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxTitle.Location = new System.Drawing.Point(2, 298);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(184, 20);
            this.textBoxTitle.TabIndex = 6;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBoxDescription.Location = new System.Drawing.Point(2, 341);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(184, 297);
            this.richTextBoxDescription.TabIndex = 7;
            this.richTextBoxDescription.Text = "";
            // 
            // pictureBoxPicture
            // 
            this.pictureBoxPicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBoxPicture.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPicture.Location = new System.Drawing.Point(515, 341);
            this.pictureBoxPicture.Name = "pictureBoxPicture";
            this.pictureBoxPicture.Size = new System.Drawing.Size(350, 297);
            this.pictureBoxPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPicture.TabIndex = 8;
            this.pictureBoxPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Навание";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Описание";
            // 
            // richTextBoxCharacterisrics
            // 
            this.richTextBoxCharacterisrics.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.richTextBoxCharacterisrics.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBoxCharacterisrics.Location = new System.Drawing.Point(192, 341);
            this.richTextBoxCharacterisrics.Name = "richTextBoxCharacterisrics";
            this.richTextBoxCharacterisrics.ReadOnly = true;
            this.richTextBoxCharacterisrics.Size = new System.Drawing.Size(317, 297);
            this.richTextBoxCharacterisrics.TabIndex = 11;
            this.richTextBoxCharacterisrics.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(192, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Характеристики";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Разделы";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(504, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Фото";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(869, 647);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxCharacterisrics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPicture);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.dataGridViewElectricalEquipment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(793, 548);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElectricalEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewElectricalEquipment;
        public System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox textBoxTitle;
        public System.Windows.Forms.RichTextBox richTextBoxDescription;
        public System.Windows.Forms.PictureBox pictureBoxPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox richTextBoxCharacterisrics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

