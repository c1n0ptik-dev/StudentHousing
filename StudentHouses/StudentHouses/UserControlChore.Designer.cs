namespace StudentHouses
{
    partial class UserControlChore
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChoreDone = new System.Windows.Forms.Button();
            this.ChoreText = new System.Windows.Forms.TextBox();
            this.ChoreTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChoreDone
            // 
            this.ChoreDone.Location = new System.Drawing.Point(9, 100);
            this.ChoreDone.Name = "ChoreDone";
            this.ChoreDone.Size = new System.Drawing.Size(272, 23);
            this.ChoreDone.TabIndex = 8;
            this.ChoreDone.Text = "Done!";
            this.ChoreDone.UseVisualStyleBackColor = true;
            this.ChoreDone.Click += new System.EventHandler(this.ChoreDone_Click);
            // 
            // ChoreText
            // 
            this.ChoreText.Location = new System.Drawing.Point(9, 36);
            this.ChoreText.Multiline = true;
            this.ChoreText.Name = "ChoreText";
            this.ChoreText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChoreText.Size = new System.Drawing.Size(272, 57);
            this.ChoreText.TabIndex = 7;
            // 
            // ChoreTitle
            // 
            this.ChoreTitle.AutoSize = true;
            this.ChoreTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ChoreTitle.Location = new System.Drawing.Point(5, 7);
            this.ChoreTitle.Name = "ChoreTitle";
            this.ChoreTitle.Size = new System.Drawing.Size(51, 20);
            this.ChoreTitle.TabIndex = 6;
            this.ChoreTitle.Text = "label1";
            // 
            // UserControlChore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ChoreDone);
            this.Controls.Add(this.ChoreText);
            this.Controls.Add(this.ChoreTitle);
            this.Name = "UserControlChore";
            this.Size = new System.Drawing.Size(287, 130);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChoreDone;
        private System.Windows.Forms.TextBox ChoreText;
        private System.Windows.Forms.Label ChoreTitle;
    }
}
