namespace JiraCopyProject.WinForms.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.задачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиЗадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЗадачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назначитьЗадачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.команднаяЗадачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьПодзадачиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.командыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеКомандамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПользователейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расширенныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тегиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserInfo = new System.Windows.Forms.ToolStripStatusLabel();

            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.задачиToolStripMenuItem,
                this.командыToolStripMenuItem,
                this.расширенныеToolStripMenuItem,
                this.статистикаToolStripMenuItem,
                this.выйтиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // задачиToolStripMenuItem
            // 
            this.задачиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.моиЗадачиToolStripMenuItem,
                this.создатьЗадачуToolStripMenuItem,
                this.назначитьЗадачуToolStripMenuItem,
                this.команднаяЗадачаToolStripMenuItem,
                this.копироватьПодзадачиToolStripMenuItem});
            this.задачиToolStripMenuItem.Name = "задачиToolStripMenuItem";
            this.задачиToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.задачиToolStripMenuItem.Text = "Задачи";
            // 
            // моиЗадачиToolStripMenuItem
            // 
            this.моиЗадачиToolStripMenuItem.Name = "моиЗадачиToolStripMenuItem";
            this.моиЗадачиToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.моиЗадачиToolStripMenuItem.Text = "Мои задачи";
            this.моиЗадачиToolStripMenuItem.Click += new System.EventHandler(this.моиЗадачиToolStripMenuItem_Click);
            // 
            // создатьЗадачуToolStripMenuItem
            // 
            this.создатьЗадачуToolStripMenuItem.Name = "создатьЗадачуToolStripMenuItem";
            this.создатьЗадачуToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.создатьЗадачуToolStripMenuItem.Text = "Создать задачу";
            this.создатьЗадачуToolStripMenuItem.Click += new System.EventHandler(this.создатьЗадачуToolStripMenuItem_Click);
            // 
            // назначитьЗадачуToolStripMenuItem
            // 
            this.назначитьЗадачуToolStripMenuItem.Name = "назначитьЗадачуToolStripMenuItem";
            this.назначитьЗадачуToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.назначитьЗадачуToolStripMenuItem.Text = "Назначить задачу";
            this.назначитьЗадачуToolStripMenuItem.Click += new System.EventHandler(this.назначитьЗадачуToolStripMenuItem_Click);
            // 
            // команднаяЗадачаToolStripMenuItem
            // 
            this.команднаяЗадачаToolStripMenuItem.Name = "команднаяЗадачаToolStripMenuItem";
            this.команднаяЗадачаToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.команднаяЗадачаToolStripMenuItem.Text = "Создать командную задачу";
            this.команднаяЗадачаToolStripMenuItem.Click += new System.EventHandler(this.команднаяЗадачаToolStripMenuItem_Click);
            // 
            // копироватьПодзадачиToolStripMenuItem
            // 
            this.копироватьПодзадачиToolStripMenuItem.Name = "копироватьПодзадачиToolStripMenuItem";
            this.копироватьПодзадачиToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.копироватьПодзадачиToolStripMenuItem.Text = "Копировать / Подзадачи";
            this.копироватьПодзадачиToolStripMenuItem.Click += new System.EventHandler(this.копироватьПодзадачиToolStripMenuItem_Click);
            // 
            // командыToolStripMenuItem
            // 
            this.командыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.управлениеКомандамиToolStripMenuItem,
                this.списокПользователейToolStripMenuItem});
            this.командыToolStripMenuItem.Name = "командыToolStripMenuItem";
            this.командыToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.командыToolStripMenuItem.Text = "Команды";
            // 
            // управлениеКомандамиToolStripMenuItem
            // 
            this.управлениеКомандамиToolStripMenuItem.Name = "управлениеКомандамиToolStripMenuItem";
            this.управлениеКомандамиToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.управлениеКомандамиToolStripMenuItem.Text = "Управление командами";
            this.управлениеКомандамиToolStripMenuItem.Click += new System.EventHandler(this.управлениеКомандамиToolStripMenuItem_Click);
            // 
            // списокПользователейToolStripMenuItem
            // 
            this.списокПользователейToolStripMenuItem.Name = "списокПользователейToolStripMenuItem";
            this.списокПользователейToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.списокПользователейToolStripMenuItem.Text = "Список пользователей";
            this.списокПользователейToolStripMenuItem.Click += new System.EventHandler(this.списокПользователейToolStripMenuItem_Click);
            // 
            // расширенныеToolStripMenuItem
            // 
            this.расширенныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.тегиToolStripMenuItem,
                this.фильтрыToolStripMenuItem,
                this.историяToolStripMenuItem});
            this.расширенныеToolStripMenuItem.Name = "расширенныеToolStripMenuItem";
            this.расширенныеToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.расширенныеToolStripMenuItem.Text = "Расширенные";
            // 
            // тегиToolStripMenuItem
            // 
            this.тегиToolStripMenuItem.Name = "тегиToolStripMenuItem";
            this.тегиToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.тегиToolStripMenuItem.Text = "Теги";
            this.тегиToolStripMenuItem.Click += new System.EventHandler(this.тегиToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            this.фильтрыToolStripMenuItem.Click += new System.EventHandler(this.фильтрыToolStripMenuItem_Click);
            // 
            // историяToolStripMenuItem
            // 
            this.историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            this.историяToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.историяToolStripMenuItem.Text = "История";
            this.историяToolStripMenuItem.Click += new System.EventHandler(this.историяToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            this.статистикаToolStripMenuItem.Click += new System.EventHandler(this.статистикаToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblUserInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Jira Copy Project";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem задачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиЗадачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьЗадачуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назначитьЗадачуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem команднаяЗадачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьПодзадачиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem командыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеКомандамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПользователейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расширенныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тегиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem историяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserInfo;
    }
}