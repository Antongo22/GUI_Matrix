namespace GUI_Matrix
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
            this.textBoxMatrixStart = new System.Windows.Forms.TextBox();
            this.textBoxMatrixEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCulc = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxMult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxMatrixStart
            // 
            this.textBoxMatrixStart.Location = new System.Drawing.Point(63, 10);
            this.textBoxMatrixStart.Name = "textBoxMatrixStart";
            this.textBoxMatrixStart.Size = new System.Drawing.Size(29, 20);
            this.textBoxMatrixStart.TabIndex = 0;
            this.textBoxMatrixStart.TextChanged += new System.EventHandler(this.textBoxMatrixStart_TextChanged);
            // 
            // textBoxMatrixEnd
            // 
            this.textBoxMatrixEnd.Location = new System.Drawing.Point(116, 10);
            this.textBoxMatrixEnd.Name = "textBoxMatrixEnd";
            this.textBoxMatrixEnd.Size = new System.Drawing.Size(29, 20);
            this.textBoxMatrixEnd.TabIndex = 1;
            this.textBoxMatrixEnd.TextChanged += new System.EventHandler(this.textBoxMatrixEnd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Матрица";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "на";
            // 
            // buttonCulc
            // 
            this.buttonCulc.Location = new System.Drawing.Point(897, 426);
            this.buttonCulc.Name = "buttonCulc";
            this.buttonCulc.Size = new System.Drawing.Size(75, 23);
            this.buttonCulc.TabIndex = 4;
            this.buttonCulc.Text = "Вычислить";
            this.buttonCulc.UseVisualStyleBackColor = true;
            this.buttonCulc.Visible = false;
            this.buttonCulc.Click += new System.EventHandler(this.buttonCulc_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Оприделитель",
            "Крамер",
            "Обратная матрица",
            "Умножение на число"});
            this.comboBox1.Location = new System.Drawing.Point(851, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "Оприделитель";
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxMult
            // 
            this.textBoxMult.Location = new System.Drawing.Point(928, 34);
            this.textBoxMult.Name = "textBoxMult";
            this.textBoxMult.Size = new System.Drawing.Size(44, 20);
            this.textBoxMult.TabIndex = 6;
            this.textBoxMult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.textBoxMult);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonCulc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMatrixEnd);
            this.Controls.Add(this.textBoxMatrixStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "Form1";
            this.Text = "Matrix";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMatrixStart;
        private System.Windows.Forms.TextBox textBoxMatrixEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCulc;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxMult;
    }
}

