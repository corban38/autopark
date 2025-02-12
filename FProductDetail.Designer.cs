namespace autopark
{
    partial class FProductDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.cbMeasureUnits = new System.Windows.Forms.ComboBox();
            this.cbBrands = new System.Windows.Forms.ComboBox();
            this.tbProductDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ед. изм.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Производитель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Комментарии";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(101, 2);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(100, 20);
            this.tbTitle.TabIndex = 5;
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(101, 28);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(100, 20);
            this.tbCount.TabIndex = 6;
            // 
            // cbMeasureUnits
            // 
            this.cbMeasureUnits.FormattingEnabled = true;
            this.cbMeasureUnits.Location = new System.Drawing.Point(101, 54);
            this.cbMeasureUnits.Name = "cbMeasureUnits";
            this.cbMeasureUnits.Size = new System.Drawing.Size(121, 21);
            this.cbMeasureUnits.TabIndex = 7;
            // 
            // cbBrands
            // 
            this.cbBrands.FormattingEnabled = true;
            this.cbBrands.Location = new System.Drawing.Point(101, 81);
            this.cbBrands.Name = "cbBrands";
            this.cbBrands.Size = new System.Drawing.Size(121, 21);
            this.cbBrands.TabIndex = 8;
            // 
            // tbProductDescription
            // 
            this.tbProductDescription.Location = new System.Drawing.Point(15, 123);
            this.tbProductDescription.Name = "tbProductDescription";
            this.tbProductDescription.Size = new System.Drawing.Size(207, 20);
            this.tbProductDescription.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbProductDescription);
            this.Controls.Add(this.cbBrands);
            this.Controls.Add(this.cbMeasureUnits);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FProductDetail";
            this.Text = "FProductDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox tbTitle;
        public System.Windows.Forms.TextBox tbCount;
        public System.Windows.Forms.ComboBox cbMeasureUnits;
        public System.Windows.Forms.ComboBox cbBrands;
        public System.Windows.Forms.TextBox tbProductDescription;
    }
}