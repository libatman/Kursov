namespace FirstPartKursov
{
    partial class TheMessage
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
            this.button_Answer = new System.Windows.Forms.Button();
            this.label_From = new System.Windows.Forms.Label();
            this.button_Back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Body = new System.Windows.Forms.Label();
            this.label_Subject = new System.Windows.Forms.Label();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.textBox_Subject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Answer
            // 
            this.button_Answer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_Answer.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Answer.Location = new System.Drawing.Point(683, 594);
            this.button_Answer.Name = "button_Answer";
            this.button_Answer.Size = new System.Drawing.Size(187, 35);
            this.button_Answer.TabIndex = 15;
            this.button_Answer.Text = "Ответить";
            this.button_Answer.UseVisualStyleBackColor = false;
            this.button_Answer.Click += new System.EventHandler(this.button_Answer_Click);
            // 
            // label_From
            // 
            this.label_From.AutoSize = true;
            this.label_From.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_From.Location = new System.Drawing.Point(33, 58);
            this.label_From.Name = "label_From";
            this.label_From.Size = new System.Drawing.Size(13, 19);
            this.label_From.TabIndex = 14;
            this.label_From.Text = ".";
            // 
            // button_Back
            // 
            this.button_Back.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_Back.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Back.Location = new System.Drawing.Point(763, 20);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(116, 40);
            this.button_Back.TabIndex = 13;
            this.button_Back.Text = "Назад";
            this.button_Back.UseVisualStyleBackColor = false;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Отправитель: ";
            // 
            // label_Body
            // 
            this.label_Body.AutoSize = true;
            this.label_Body.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Body.Location = new System.Drawing.Point(252, 143);
            this.label_Body.Name = "label_Body";
            this.label_Body.Size = new System.Drawing.Size(108, 20);
            this.label_Body.TabIndex = 11;
            this.label_Body.Text = "Сообщение:";
            // 
            // label_Subject
            // 
            this.label_Subject.AutoSize = true;
            this.label_Subject.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Subject.Location = new System.Drawing.Point(252, 85);
            this.label_Subject.Name = "label_Subject";
            this.label_Subject.Size = new System.Drawing.Size(51, 20);
            this.label_Subject.TabIndex = 10;
            this.label_Subject.Text = "Тема:";
            // 
            // textBox_Body
            // 
            this.textBox_Body.Location = new System.Drawing.Point(256, 170);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.Size = new System.Drawing.Size(614, 408);
            this.textBox_Body.TabIndex = 9;
            this.textBox_Body.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox_Subject
            // 
            this.textBox_Subject.Location = new System.Drawing.Point(256, 112);
            this.textBox_Subject.Name = "textBox_Subject";
            this.textBox_Subject.Size = new System.Drawing.Size(614, 23);
            this.textBox_Subject.TabIndex = 8;
            this.textBox_Subject.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // TheMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 641);
            this.Controls.Add(this.button_Answer);
            this.Controls.Add(this.label_From);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Body);
            this.Controls.Add(this.label_Subject);
            this.Controls.Add(this.textBox_Body);
            this.Controls.Add(this.textBox_Subject);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TheMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщение";
            this.Load += new System.EventHandler(this.TheMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Answer;
        private System.Windows.Forms.Label label_From;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_Body;
        private System.Windows.Forms.Label label_Subject;
        private System.Windows.Forms.TextBox textBox_Body;
        private System.Windows.Forms.TextBox textBox_Subject;
    }
}