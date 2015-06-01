namespace FirstPartKursov
{
    partial class InputMessages
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главноеОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.почтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.написатьНовоеСообщениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входящиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контактыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перераспределениеТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бонусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.почтаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.всеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_allmess = new System.Windows.Forms.ListBox();
            this.tabControlMessages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox_providers = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox_filials = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.путиСохраненияДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControlMessages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главноеОкноToolStripMenuItem,
            this.почтаToolStripMenuItem,
            this.бДToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.бонусToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главноеОкноToolStripMenuItem
            // 
            this.главноеОкноToolStripMenuItem.Name = "главноеОкноToolStripMenuItem";
            this.главноеОкноToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.главноеОкноToolStripMenuItem.Text = "Главное окно";
            this.главноеОкноToolStripMenuItem.Click += new System.EventHandler(this.главноеОкноToolStripMenuItem_Click);
            // 
            // почтаToolStripMenuItem
            // 
            this.почтаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.написатьНовоеСообщениеToolStripMenuItem,
            this.входящиеToolStripMenuItem,
            this.контактыToolStripMenuItem});
            this.почтаToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.почтаToolStripMenuItem.Name = "почтаToolStripMenuItem";
            this.почтаToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.почтаToolStripMenuItem.Text = "Почта";
            // 
            // написатьНовоеСообщениеToolStripMenuItem
            // 
            this.написатьНовоеСообщениеToolStripMenuItem.Name = "написатьНовоеСообщениеToolStripMenuItem";
            this.написатьНовоеСообщениеToolStripMenuItem.Size = new System.Drawing.Size(296, 24);
            this.написатьНовоеСообщениеToolStripMenuItem.Text = "Написать новое сообщение";
            this.написатьНовоеСообщениеToolStripMenuItem.Click += new System.EventHandler(this.написатьНовоеСообщениеToolStripMenuItem_Click_1);
            // 
            // входящиеToolStripMenuItem
            // 
            this.входящиеToolStripMenuItem.Name = "входящиеToolStripMenuItem";
            this.входящиеToolStripMenuItem.Size = new System.Drawing.Size(296, 24);
            this.входящиеToolStripMenuItem.Text = "Входящие";
            this.входящиеToolStripMenuItem.Click += new System.EventHandler(this.входящиеToolStripMenuItem_Click);
            // 
            // контактыToolStripMenuItem
            // 
            this.контактыToolStripMenuItem.Name = "контактыToolStripMenuItem";
            this.контактыToolStripMenuItem.Size = new System.Drawing.Size(296, 24);
            this.контактыToolStripMenuItem.Text = "Контакты";
            this.контактыToolStripMenuItem.Click += new System.EventHandler(this.контактыToolStripMenuItem_Click_1);
            // 
            // бДToolStripMenuItem
            // 
            this.бДToolStripMenuItem.Name = "бДToolStripMenuItem";
            this.бДToolStripMenuItem.Size = new System.Drawing.Size(41, 24);
            this.бДToolStripMenuItem.Text = "БД";
            this.бДToolStripMenuItem.Click += new System.EventHandler(this.бДToolStripMenuItem_Click_1);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перераспределениеТоваровToolStripMenuItem,
            this.заказТоваровToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // перераспределениеТоваровToolStripMenuItem
            // 
            this.перераспределениеТоваровToolStripMenuItem.Name = "перераспределениеТоваровToolStripMenuItem";
            this.перераспределениеТоваровToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.перераспределениеТоваровToolStripMenuItem.Text = "Перераспределение товаров";
            this.перераспределениеТоваровToolStripMenuItem.Click += new System.EventHandler(this.перераспределениеТоваровToolStripMenuItem_Click_1);
            // 
            // заказТоваровToolStripMenuItem
            // 
            this.заказТоваровToolStripMenuItem.Name = "заказТоваровToolStripMenuItem";
            this.заказТоваровToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.заказТоваровToolStripMenuItem.Text = "Заказ товаров";
            this.заказТоваровToolStripMenuItem.Click += new System.EventHandler(this.заказТоваровToolStripMenuItem_Click_1);
            // 
            // бонусToolStripMenuItem
            // 
            this.бонусToolStripMenuItem.Name = "бонусToolStripMenuItem";
            this.бонусToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.бонусToolStripMenuItem.Text = "Бонус";
            this.бонусToolStripMenuItem.Click += new System.EventHandler(this.бонусToolStripMenuItem_Click_1);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.почтаToolStripMenuItem1,
            this.путиСохраненияДокументовToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // почтаToolStripMenuItem1
            // 
            this.почтаToolStripMenuItem1.Name = "почтаToolStripMenuItem1";
            this.почтаToolStripMenuItem1.Size = new System.Drawing.Size(300, 24);
            this.почтаToolStripMenuItem1.Text = "Почта";
            this.почтаToolStripMenuItem1.Click += new System.EventHandler(this.почтаToolStripMenuItem1_Click_1);
            // 
            // всеToolStripMenuItem
            // 
            this.всеToolStripMenuItem.Name = "всеToolStripMenuItem";
            this.всеToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // listBox_allmess
            // 
            this.listBox_allmess.FormattingEnabled = true;
            this.listBox_allmess.ItemHeight = 17;
            this.listBox_allmess.Location = new System.Drawing.Point(6, 6);
            this.listBox_allmess.Name = "listBox_allmess";
            this.listBox_allmess.Size = new System.Drawing.Size(837, 514);
            this.listBox_allmess.TabIndex = 2;
            this.listBox_allmess.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_allmess_MouseDoubleClick);
            // 
            // tabControlMessages
            // 
            this.tabControlMessages.Controls.Add(this.tabPage1);
            this.tabControlMessages.Controls.Add(this.tabPage2);
            this.tabControlMessages.Controls.Add(this.tabPage3);
            this.tabControlMessages.Location = new System.Drawing.Point(13, 48);
            this.tabControlMessages.Name = "tabControlMessages";
            this.tabControlMessages.SelectedIndex = 0;
            this.tabControlMessages.Size = new System.Drawing.Size(857, 581);
            this.tabControlMessages.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_allmess);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(849, 551);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Все";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_providers);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(849, 551);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Поставщики";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox_providers
            // 
            this.listBox_providers.FormattingEnabled = true;
            this.listBox_providers.ItemHeight = 17;
            this.listBox_providers.Location = new System.Drawing.Point(7, 7);
            this.listBox_providers.Name = "listBox_providers";
            this.listBox_providers.Size = new System.Drawing.Size(836, 514);
            this.listBox_providers.TabIndex = 0;
            this.listBox_providers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_providers_MouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox_filials);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(849, 551);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Филиалы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox_filials
            // 
            this.listBox_filials.FormattingEnabled = true;
            this.listBox_filials.ItemHeight = 17;
            this.listBox_filials.Location = new System.Drawing.Point(7, 4);
            this.listBox_filials.Name = "listBox_filials";
            this.listBox_filials.Size = new System.Drawing.Size(836, 514);
            this.listBox_filials.TabIndex = 0;
            this.listBox_filials.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_filials_MouseDoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // путиСохраненияДокументовToolStripMenuItem
            // 
            this.путиСохраненияДокументовToolStripMenuItem.Name = "путиСохраненияДокументовToolStripMenuItem";
            this.путиСохраненияДокументовToolStripMenuItem.Size = new System.Drawing.Size(300, 24);
            this.путиСохраненияДокументовToolStripMenuItem.Text = "Пути сохранения документов";
            this.путиСохраненияДокументовToolStripMenuItem.Click += new System.EventHandler(this.путиСохраненияДокументовToolStripMenuItem_Click);
            // 
            // InputMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(882, 641);
            this.Controls.Add(this.tabControlMessages);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Входящие сообщения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputMessages_FormClosing);
            this.Load += new System.EventHandler(this.InputMessages_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlMessages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem почтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem написатьНовоеСообщениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem входящиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контактыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перераспределениеТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бонусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem почтаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem главноеОкноToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox_allmess;
        private System.Windows.Forms.TabControl tabControlMessages;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox_providers;
        private System.Windows.Forms.ListBox listBox_filials;
        private System.Windows.Forms.Timer timer1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem путиСохраненияДокументовToolStripMenuItem;
    }
}