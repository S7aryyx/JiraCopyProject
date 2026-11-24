namespace JiraCopyProject.WinForms.Forms
{
    partial class FiltersForm
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
            this.tabControlFilters = new System.Windows.Forms.TabControl();
            this.tpSearchText = new System.Windows.Forms.TabPage();
            this.dgvSearchResult = new System.Windows.Forms.DataGridView();
            this.btnSearchText = new System.Windows.Forms.Button();
            this.txtSearchQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.tpByStatus = new System.Windows.Forms.TabPage();
            this.dgvByStatus = new System.Windows.Forms.DataGridView();
            this.btnFilterByStatus = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tpOverdue = new System.Windows.Forms.TabPage();
            this.dgvOverdue = new System.Windows.Forms.DataGridView();
            this.btnShowOverdue = new System.Windows.Forms.Button();
            this.tabControlFilters.SuspendLayout();
            this.tpSearchText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
            this.tpByStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByStatus)).BeginInit();
            this.tpOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlFilters
            // 
            this.tabControlFilters.Controls.Add(this.tpSearchText);
            this.tabControlFilters.Controls.Add(this.tpByStatus);
            this.tabControlFilters.Controls.Add(this.tpOverdue);
            this.tabControlFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFilters.Location = new System.Drawing.Point(0, 0);
            this.tabControlFilters.Name = "tabControlFilters";
            this.tabControlFilters.SelectedIndex = 0;
            this.tabControlFilters.Size = new System.Drawing.Size(844, 491);
            this.tabControlFilters.TabIndex = 0;
            // 
            // tpSearchText
            // 
            this.tpSearchText.Controls.Add(this.dgvSearchResult);
            this.tpSearchText.Controls.Add(this.btnSearchText);
            this.tpSearchText.Controls.Add(this.txtSearchQuery);
            this.tpSearchText.Controls.Add(this.lblQuery);
            this.tpSearchText.Location = new System.Drawing.Point(4, 29);
            this.tpSearchText.Name = "tpSearchText";
            this.tpSearchText.Padding = new System.Windows.Forms.Padding(3);
            this.tpSearchText.Size = new System.Drawing.Size(836, 458);
            this.tpSearchText.TabIndex = 0;
            this.tpSearchText.Text = "Поиск по тексту";
            this.tpSearchText.UseVisualStyleBackColor = true;
            // 
            // dgvSearchResult
            // 
            this.dgvSearchResult.AllowUserToAddRows = false;
            this.dgvSearchResult.AllowUserToDeleteRows = false;
            this.dgvSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResult.Location = new System.Drawing.Point(20, 100);
            this.dgvSearchResult.Name = "dgvSearchResult";
            this.dgvSearchResult.ReadOnly = true;
            this.dgvSearchResult.RowHeadersWidth = 62;
            this.dgvSearchResult.RowTemplate.Height = 28;
            this.dgvSearchResult.Size = new System.Drawing.Size(796, 330);
            this.dgvSearchResult.TabIndex = 3;
            // 
            // btnSearchText
            // 
            this.btnSearchText.Location = new System.Drawing.Point(646, 40);
            this.btnSearchText.Name = "btnSearchText";
            this.btnSearchText.Size = new System.Drawing.Size(150, 30);
            this.btnSearchText.TabIndex = 2;
            this.btnSearchText.Text = "Искать";
            this.btnSearchText.UseVisualStyleBackColor = true;
            this.btnSearchText.Click += new System.EventHandler(this.btnSearchText_Click);
            // 
            // txtSearchQuery
            // 
            this.txtSearchQuery.Location = new System.Drawing.Point(180, 41);
            this.txtSearchQuery.Name = "txtSearchQuery";
            this.txtSearchQuery.Size = new System.Drawing.Size(420, 26);
            this.txtSearchQuery.TabIndex = 1;
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(20, 44);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(154, 20);
            this.lblQuery.TabIndex = 0;
            this.lblQuery.Text = "Поисковый запрос:";
            // 
            // tpByStatus
            // 
            this.tpByStatus.Controls.Add(this.dgvByStatus);
            this.tpByStatus.Controls.Add(this.btnFilterByStatus);
            this.tpByStatus.Controls.Add(this.cmbStatus);
            this.tpByStatus.Controls.Add(this.lblStatus);
            this.tpByStatus.Location = new System.Drawing.Point(4, 29);
            this.tpByStatus.Name = "tpByStatus";
            this.tpByStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpByStatus.Size = new System.Drawing.Size(836, 458);
            this.tpByStatus.TabIndex = 1;
            this.tpByStatus.Text = "По статусу";
            this.tpByStatus.UseVisualStyleBackColor = true;
            // 
            // dgvByStatus
            // 
            this.dgvByStatus.AllowUserToAddRows = false;
            this.dgvByStatus.AllowUserToDeleteRows = false;
            this.dgvByStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvByStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByStatus.Location = new System.Drawing.Point(20, 100);
            this.dgvByStatus.Name = "dgvByStatus";
            this.dgvByStatus.ReadOnly = true;
            this.dgvByStatus.RowHeadersWidth = 62;
            this.dgvByStatus.RowTemplate.Height = 28;
            this.dgvByStatus.Size = new System.Drawing.Size(796, 330);
            this.dgvByStatus.TabIndex = 3;
            // 
            // btnFilterByStatus
            // 
            this.btnFilterByStatus.Location = new System.Drawing.Point(646, 40);
            this.btnFilterByStatus.Name = "btnFilterByStatus";
            this.btnFilterByStatus.Size = new System.Drawing.Size(150, 30);
            this.btnFilterByStatus.TabIndex = 2;
            this.btnFilterByStatus.Text = "Показать";
            this.btnFilterByStatus.UseVisualStyleBackColor = true;
            this.btnFilterByStatus.Click += new System.EventHandler(this.btnFilterByStatus_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(180, 40);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(420, 28);
            this.cmbStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(110, 43);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 20);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Статус:";
            // 
            // tpOverdue
            // 
            this.tpOverdue.Controls.Add(this.dgvOverdue);
            this.tpOverdue.Controls.Add(this.btnShowOverdue);
            this.tpOverdue.Location = new System.Drawing.Point(4, 29);
            this.tpOverdue.Name = "tpOverdue";
            this.tpOverdue.Size = new System.Drawing.Size(836, 458);
            this.tpOverdue.TabIndex = 2;
            this.tpOverdue.Text = "Просроченные";
            this.tpOverdue.UseVisualStyleBackColor = true;
            // 
            // dgvOverdue
            // 
            this.dgvOverdue.AllowUserToAddRows = false;
            this.dgvOverdue.AllowUserToDeleteRows = false;
            this.dgvOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdue.Location = new System.Drawing.Point(20, 100);
            this.dgvOverdue.Name = "dgvOverdue";
            this.dgvOverdue.ReadOnly = true;
            this.dgvOverdue.RowHeadersWidth = 62;
            this.dgvOverdue.RowTemplate.Height = 28;
            this.dgvOverdue.Size = new System.Drawing.Size(796, 330);
            this.dgvOverdue.TabIndex = 3;
            // 
            // btnShowOverdue
            // 
            this.btnShowOverdue.Location = new System.Drawing.Point(333, 40);
            this.btnShowOverdue.Name = "btnShowOverdue";
            this.btnShowOverdue.Size = new System.Drawing.Size(150, 30);
            this.btnShowOverdue.TabIndex = 2;
            this.btnShowOverdue.Text = "Показать";
            this.btnShowOverdue.UseVisualStyleBackColor = true;
            this.btnShowOverdue.Click += new System.EventHandler(this.btnShowOverdue_Click);
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 491);
            this.Controls.Add(this.tabControlFilters);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FiltersForm";
            this.Text = "Фильтры и поиск";
            this.tabControlFilters.ResumeLayout(false);
            this.tpSearchText.ResumeLayout(false);
            this.tpSearchText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
            this.tpByStatus.ResumeLayout(false);
            this.tpByStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByStatus)).EndInit();
            this.tpOverdue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlFilters;
        private System.Windows.Forms.TabPage tpSearchText;
        private System.Windows.Forms.TabPage tpByStatus;
        private System.Windows.Forms.TabPage tpOverdue;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.Button btnSearchText;
        private System.Windows.Forms.TextBox txtSearchQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.DataGridView dgvByStatus;
        private System.Windows.Forms.Button btnFilterByStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvOverdue;
        private System.Windows.Forms.Button btnShowOverdue;
    }
}