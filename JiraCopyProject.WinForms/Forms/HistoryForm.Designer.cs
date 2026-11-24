namespace JiraCopyProject.WinForms.Forms
{
    partial class HistoryForm
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
            this.lblTaskId = new System.Windows.Forms.Label();
            this.txtTaskId = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tabHistory = new System.Windows.Forms.TabControl();
            this.tpStatus = new System.Windows.Forms.TabPage();
            this.dgvStatusHistory = new System.Windows.Forms.DataGridView();
            this.tpDeadline = new System.Windows.Forms.TabPage();
            this.dgvDeadlineHistory = new System.Windows.Forms.DataGridView();
            this.tabHistory.SuspendLayout();
            this.tpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusHistory)).BeginInit();
            this.tpDeadline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadlineHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaskId
            // 
            this.lblTaskId.AutoSize = true;
            this.lblTaskId.Location = new System.Drawing.Point(12, 15);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(70, 17);
            this.lblTaskId.TabIndex = 0;
            this.lblTaskId.Text = "ID задачи:";
            // 
            // txtTaskId
            // 
            this.txtTaskId.Location = new System.Drawing.Point(88, 12);
            this.txtTaskId.Name = "txtTaskId";
            this.txtTaskId.Size = new System.Drawing.Size(100, 22);
            this.txtTaskId.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(194, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 25);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tabHistory
            // 
            this.tabHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabHistory.Controls.Add(this.tpStatus);
            this.tabHistory.Controls.Add(this.tpDeadline);
            this.tabHistory.Location = new System.Drawing.Point(12, 50);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.SelectedIndex = 0;
            this.tabHistory.Size = new System.Drawing.Size(776, 388);
            this.tabHistory.TabIndex = 3;
            // 
            // tpStatus
            // 
            this.tpStatus.Controls.Add(this.dgvStatusHistory);
            this.tpStatus.Location = new System.Drawing.Point(4, 25);
            this.tpStatus.Name = "tpStatus";
            this.tpStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatus.Size = new System.Drawing.Size(768, 359);
            this.tpStatus.TabIndex = 0;
            this.tpStatus.Text = "История статусов";
            this.tpStatus.UseVisualStyleBackColor = true;
            // 
            // dgvStatusHistory
            // 
            this.dgvStatusHistory.AllowUserToAddRows = false;
            this.dgvStatusHistory.AllowUserToDeleteRows = false;
            this.dgvStatusHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatusHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatusHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusHistory.Location = new System.Drawing.Point(6, 6);
            this.dgvStatusHistory.Name = "dgvStatusHistory";
            this.dgvStatusHistory.ReadOnly = true;
            this.dgvStatusHistory.RowHeadersWidth = 51;
            this.dgvStatusHistory.RowTemplate.Height = 24;
            this.dgvStatusHistory.Size = new System.Drawing.Size(756, 347);
            this.dgvStatusHistory.TabIndex = 0;
            // 
            // tpDeadline
            // 
            this.tpDeadline.Controls.Add(this.dgvDeadlineHistory);
            this.tpDeadline.Location = new System.Drawing.Point(4, 25);
            this.tpDeadline.Name = "tpDeadline";
            this.tpDeadline.Padding = new System.Windows.Forms.Padding(3);
            this.tpDeadline.Size = new System.Drawing.Size(768, 359);
            this.tpDeadline.TabIndex = 1;
            this.tpDeadline.Text = "История дедлайнов";
            this.tpDeadline.UseVisualStyleBackColor = true;
            // 
            // dgvDeadlineHistory
            // 
            this.dgvDeadlineHistory.AllowUserToAddRows = false;
            this.dgvDeadlineHistory.AllowUserToDeleteRows = false;
            this.dgvDeadlineHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeadlineHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeadlineHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeadlineHistory.Location = new System.Drawing.Point(6, 6);
            this.dgvDeadlineHistory.Name = "dgvDeadlineHistory";
            this.dgvDeadlineHistory.ReadOnly = true;
            this.dgvDeadlineHistory.RowHeadersWidth = 51;
            this.dgvDeadlineHistory.RowTemplate.Height = 24;
            this.dgvDeadlineHistory.Size = new System.Drawing.Size(756, 347);
            this.dgvDeadlineHistory.TabIndex = 1;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabHistory);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtTaskId);
            this.Controls.Add(this.lblTaskId);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "HistoryForm";
            this.Text = "История изменений";
            this.tabHistory.ResumeLayout(false);
            this.tpStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusHistory)).EndInit();
            this.tpDeadline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadlineHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTaskId;
        private System.Windows.Forms.TextBox txtTaskId;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabControl tabHistory;
        private System.Windows.Forms.TabPage tpStatus;
        private System.Windows.Forms.TabPage tpDeadline;
        private System.Windows.Forms.DataGridView dgvStatusHistory;
        private System.Windows.Forms.DataGridView dgvDeadlineHistory;
    }
}