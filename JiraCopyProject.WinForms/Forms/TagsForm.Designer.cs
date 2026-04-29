namespace JiraCopyProject.WinForms.Forms
{
    partial class TagsForm
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
            this.tabControlTags = new System.Windows.Forms.TabControl();
            this.tpCreate = new System.Windows.Forms.TabPage();
            this.btnCreateTag = new System.Windows.Forms.Button();
            this.txtTagColor = new System.Windows.Forms.TextBox();
            this.lblTagColor = new System.Windows.Forms.Label();
            this.txtTagName = new System.Windows.Forms.TextBox();
            this.lblTagName = new System.Windows.Forms.Label();
            this.tpAssign = new System.Windows.Forms.TabPage();
            this.btnAssignTag = new System.Windows.Forms.Button();
            this.cmbTagAssign = new System.Windows.Forms.ComboBox();
            this.lblTagAssign = new System.Windows.Forms.Label();
            this.txtTaskIdAssign = new System.Windows.Forms.TextBox();
            this.lblTaskIdAssign = new System.Windows.Forms.Label();
            this.tpTaskTags = new System.Windows.Forms.TabPage();
            this.dgvTaskTags = new System.Windows.Forms.DataGridView();
            this.btnShowTaskTags = new System.Windows.Forms.Button();
            this.txtTaskIdView = new System.Windows.Forms.TextBox();
            this.lblTaskIdView = new System.Windows.Forms.Label();
            this.tpSearchByTag = new System.Windows.Forms.TabPage();
            this.dgvTasksByTag = new System.Windows.Forms.DataGridView();
            this.btnSearchByTag = new System.Windows.Forms.Button();
            this.cmbTagSearch = new System.Windows.Forms.ComboBox();
            this.lblTagSearch = new System.Windows.Forms.Label();
            this.tabControlTags.SuspendLayout();
            this.tpCreate.SuspendLayout();
            this.tpAssign.SuspendLayout();
            this.tpTaskTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskTags)).BeginInit();
            this.tpSearchByTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksByTag)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlTags
            // 
            this.tabControlTags.Controls.Add(this.tpCreate);
            this.tabControlTags.Controls.Add(this.tpAssign);
            this.tabControlTags.Controls.Add(this.tpTaskTags);
            this.tabControlTags.Controls.Add(this.tpSearchByTag);
            this.tabControlTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTags.Location = new System.Drawing.Point(0, 0);
            this.tabControlTags.Name = "tabControlTags";
            this.tabControlTags.SelectedIndex = 0;
            this.tabControlTags.Size = new System.Drawing.Size(744, 461);
            this.tabControlTags.TabIndex = 0;
            // 
            // tpCreate
            // 
            this.tpCreate.Controls.Add(this.btnCreateTag);
            this.tpCreate.Controls.Add(this.txtTagColor);
            this.tpCreate.Controls.Add(this.lblTagColor);
            this.tpCreate.Controls.Add(this.txtTagName);
            this.tpCreate.Controls.Add(this.lblTagName);
            this.tpCreate.Location = new System.Drawing.Point(4, 29);
            this.tpCreate.Name = "tpCreate";
            this.tpCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreate.Size = new System.Drawing.Size(736, 428);
            this.tpCreate.TabIndex = 0;
            this.tpCreate.Text = "Создать тег";
            this.tpCreate.UseVisualStyleBackColor = true;
            // 
            // btnCreateTag
            // 
            this.btnCreateTag.Location = new System.Drawing.Point(270, 167);
            this.btnCreateTag.Name = "btnCreateTag";
            this.btnCreateTag.Size = new System.Drawing.Size(150, 30);
            this.btnCreateTag.TabIndex = 4;
            this.btnCreateTag.Text = "Создать";
            this.btnCreateTag.UseVisualStyleBackColor = true;
            this.btnCreateTag.Click += new System.EventHandler(this.btnCreateTag_Click);
            // 
            // txtTagColor
            // 
            this.txtTagColor.Location = new System.Drawing.Point(198, 104);
            this.txtTagColor.Name = "txtTagColor";
            this.txtTagColor.Size = new System.Drawing.Size(222, 26);
            this.txtTagColor.TabIndex = 3;
            // 
            // lblTagColor
            // 
            this.lblTagColor.AutoSize = true;
            this.lblTagColor.Location = new System.Drawing.Point(72, 107);
            this.lblTagColor.Name = "lblTagColor";
            this.lblTagColor.Size = new System.Drawing.Size(104, 20);
            this.lblTagColor.TabIndex = 2;
            this.lblTagColor.Text = "Цвет (#HEX):";
            // 
            // txtTagName
            // 
            this.txtTagName.Location = new System.Drawing.Point(198, 50);
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(222, 26);
            this.txtTagName.TabIndex = 1;
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Location = new System.Drawing.Point(110, 53);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(66, 20);
            this.lblTagName.TabIndex = 0;
            this.lblTagName.Text = "Название:";
            // 
            // tpAssign
            // 
            this.tpAssign.Controls.Add(this.btnAssignTag);
            this.tpAssign.Controls.Add(this.cmbTagAssign);
            this.tpAssign.Controls.Add(this.lblTagAssign);
            this.tpAssign.Controls.Add(this.txtTaskIdAssign);
            this.tpAssign.Controls.Add(this.lblTaskIdAssign);
            this.tpAssign.Location = new System.Drawing.Point(4, 29);
            this.tpAssign.Name = "tpAssign";
            this.tpAssign.Padding = new System.Windows.Forms.Padding(3);
            this.tpAssign.Size = new System.Drawing.Size(736, 428);
            this.tpAssign.TabIndex = 1;
            this.tpAssign.Text = "Назначить тег";
            this.tpAssign.UseVisualStyleBackColor = true;
            // 
            // btnAssignTag
            // 
            this.btnAssignTag.Location = new System.Drawing.Point(278, 178);
            this.btnAssignTag.Name = "btnAssignTag";
            this.btnAssignTag.Size = new System.Drawing.Size(150, 30);
            this.btnAssignTag.TabIndex = 4;
            this.btnAssignTag.Text = "Назначить";
            this.btnAssignTag.UseVisualStyleBackColor = true;
            this.btnAssignTag.Click += new System.EventHandler(this.btnAssignTag_Click);
            // 
            // cmbTagAssign
            // 
            this.cmbTagAssign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTagAssign.FormattingEnabled = true;
            this.cmbTagAssign.Location = new System.Drawing.Point(198, 118);
            this.cmbTagAssign.Name = "cmbTagAssign";
            this.cmbTagAssign.Size = new System.Drawing.Size(230, 28);
            this.cmbTagAssign.TabIndex = 3;
            // 
            // lblTagAssign
            // 
            this.lblTagAssign.AutoSize = true;
            this.lblTagAssign.Location = new System.Drawing.Point(122, 121);
            this.lblTagAssign.Name = "lblTagAssign";
            this.lblTagAssign.Size = new System.Drawing.Size(45, 20);
            this.lblTagAssign.TabIndex = 2;
            this.lblTagAssign.Text = "Тег:";
            // 
            // txtTaskIdAssign
            // 
            this.txtTaskIdAssign.Location = new System.Drawing.Point(198, 58);
            this.txtTaskIdAssign.Name = "txtTaskIdAssign";
            this.txtTaskIdAssign.Size = new System.Drawing.Size(230, 26);
            this.txtTaskIdAssign.TabIndex = 1;
            // 
            // lblTaskIdAssign
            // 
            this.lblTaskIdAssign.AutoSize = true;
            this.lblTaskIdAssign.Location = new System.Drawing.Point(86, 61);
            this.lblTaskIdAssign.Name = "lblTaskIdAssign";
            this.lblTaskIdAssign.Size = new System.Drawing.Size(89, 20);
            this.lblTaskIdAssign.TabIndex = 0;
            this.lblTaskIdAssign.Text = "ID задачи:";
            // 
            // tpTaskTags
            // 
            this.tpTaskTags.Controls.Add(this.dgvTaskTags);
            this.tpTaskTags.Controls.Add(this.btnShowTaskTags);
            this.tpTaskTags.Controls.Add(this.txtTaskIdView);
            this.tpTaskTags.Controls.Add(this.lblTaskIdView);
            this.tpTaskTags.Location = new System.Drawing.Point(4, 29);
            this.tpTaskTags.Name = "tpTaskTags";
            this.tpTaskTags.Size = new System.Drawing.Size(736, 428);
            this.tpTaskTags.TabIndex = 2;
            this.tpTaskTags.Text = "Теги задачи";
            this.tpTaskTags.UseVisualStyleBackColor = true;
            // 
            // dgvTaskTags
            // 
            this.dgvTaskTags.AllowUserToAddRows = false;
            this.dgvTaskTags.AllowUserToDeleteRows = false;
            this.dgvTaskTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaskTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskTags.Location = new System.Drawing.Point(31, 130);
            this.dgvTaskTags.Name = "dgvTaskTags";
            this.dgvTaskTags.ReadOnly = true;
            this.dgvTaskTags.RowHeadersWidth = 62;
            this.dgvTaskTags.RowTemplate.Height = 28;
            this.dgvTaskTags.Size = new System.Drawing.Size(670, 270);
            this.dgvTaskTags.TabIndex = 3;
            // 
            // btnShowTaskTags
            // 
            this.btnShowTaskTags.Location = new System.Drawing.Point(531, 56);
            this.btnShowTaskTags.Name = "btnShowTaskTags";
            this.btnShowTaskTags.Size = new System.Drawing.Size(150, 30);
            this.btnShowTaskTags.TabIndex = 2;
            this.btnShowTaskTags.Text = "Показать теги";
            this.btnShowTaskTags.UseVisualStyleBackColor = true;
            this.btnShowTaskTags.Click += new System.EventHandler(this.btnShowTaskTags_Click);
            // 
            // txtTaskIdView
            // 
            this.txtTaskIdView.Location = new System.Drawing.Point(187, 58);
            this.txtTaskIdView.Name = "txtTaskIdView";
            this.txtTaskIdView.Size = new System.Drawing.Size(300, 26);
            this.txtTaskIdView.TabIndex = 1;
            // 
            // lblTaskIdView
            // 
            this.lblTaskIdView.AutoSize = true;
            this.lblTaskIdView.Location = new System.Drawing.Point(27, 61);
            this.lblTaskIdView.Name = "lblTaskIdView";
            this.lblTaskIdView.Size = new System.Drawing.Size(89, 20);
            this.lblTaskIdView.TabIndex = 0;
            this.lblTaskIdView.Text = "ID задачи:";
            // 
            // tpSearchByTag
            // 
            this.tpSearchByTag.Controls.Add(this.dgvTasksByTag);
            this.tpSearchByTag.Controls.Add(this.btnSearchByTag);
            this.tpSearchByTag.Controls.Add(this.cmbTagSearch);
            this.tpSearchByTag.Controls.Add(this.lblTagSearch);
            this.tpSearchByTag.Location = new System.Drawing.Point(4, 29);
            this.tpSearchByTag.Name = "tpSearchByTag";
            this.tpSearchByTag.Size = new System.Drawing.Size(736, 428);
            this.tpSearchByTag.TabIndex = 3;
            this.tpSearchByTag.Text = "Поиск по тегу";
            this.tpSearchByTag.UseVisualStyleBackColor = true;
            // 
            // dgvTasksByTag
            // 
            this.dgvTasksByTag.AllowUserToAddRows = false;
            this.dgvTasksByTag.AllowUserToDeleteRows = false;
            this.dgvTasksByTag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasksByTag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasksByTag.Location = new System.Drawing.Point(31, 130);
            this.dgvTasksByTag.Name = "dgvTasksByTag";
            this.dgvTasksByTag.ReadOnly = true;
            this.dgvTasksByTag.RowHeadersWidth = 62;
            this.dgvTasksByTag.RowTemplate.Height = 28;
            this.dgvTasksByTag.Size = new System.Drawing.Size(670, 270);
            this.dgvTasksByTag.TabIndex = 4;
            // 
            // btnSearchByTag
            // 
            this.btnSearchByTag.Location = new System.Drawing.Point(531, 56);
            this.btnSearchByTag.Name = "btnSearchByTag";
            this.btnSearchByTag.Size = new System.Drawing.Size(150, 30);
            this.btnSearchByTag.TabIndex = 3;
            this.btnSearchByTag.Text = "Поиск";
            this.btnSearchByTag.UseVisualStyleBackColor = true;
            this.btnSearchByTag.Click += new System.EventHandler(this.btnSearchByTag_Click);
            // 
            // cmbTagSearch
            // 
            this.cmbTagSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTagSearch.FormattingEnabled = true;
            this.cmbTagSearch.Location = new System.Drawing.Point(187, 56);
            this.cmbTagSearch.Name = "cmbTagSearch";
            this.cmbTagSearch.Size = new System.Drawing.Size(300, 28);
            this.cmbTagSearch.TabIndex = 2;
            // 
            // lblTagSearch
            // 
            this.lblTagSearch.AutoSize = true;
            this.lblTagSearch.Location = new System.Drawing.Point(80, 59);
            this.lblTagSearch.Name = "lblTagSearch";
            this.lblTagSearch.Size = new System.Drawing.Size(45, 20);
            this.lblTagSearch.TabIndex = 0;
            this.lblTagSearch.Text = "Тег:";
            // 
            // TagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 461);
            this.Controls.Add(this.tabControlTags);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "TagsForm";
            this.Text = "Управление тегами";
            this.tabControlTags.ResumeLayout(false);
            this.tpCreate.ResumeLayout(false);
            this.tpCreate.PerformLayout();
            this.tpAssign.ResumeLayout(false);
            this.tpAssign.PerformLayout();
            this.tpTaskTags.ResumeLayout(false);
            this.tpTaskTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskTags)).EndInit();
            this.tpSearchByTag.ResumeLayout(false);
            this.tpSearchByTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksByTag)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlTags;
        private System.Windows.Forms.TabPage tpCreate;
        private System.Windows.Forms.TabPage tpAssign;
        private System.Windows.Forms.TabPage tpTaskTags;
        private System.Windows.Forms.TabPage tpSearchByTag;
        private System.Windows.Forms.Button btnCreateTag;
        private System.Windows.Forms.TextBox txtTagColor;
        private System.Windows.Forms.Label lblTagColor;
        private System.Windows.Forms.TextBox txtTagName;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.Button btnAssignTag;
        private System.Windows.Forms.ComboBox cmbTagAssign;
        private System.Windows.Forms.Label lblTagAssign;
        private System.Windows.Forms.TextBox txtTaskIdAssign;
        private System.Windows.Forms.Label lblTaskIdAssign;
        private System.Windows.Forms.DataGridView dgvTaskTags;
        private System.Windows.Forms.Button btnShowTaskTags;
        private System.Windows.Forms.TextBox txtTaskIdView;
        private System.Windows.Forms.Label lblTaskIdView;
        private System.Windows.Forms.DataGridView dgvTasksByTag;
        private System.Windows.Forms.Button btnSearchByTag;
        private System.Windows.Forms.ComboBox cmbTagSearch;
        private System.Windows.Forms.Label lblTagSearch;
    }
}