namespace JiraCopyProject.WinForms.Forms
{
    partial class MyTasksForm
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
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnComments = new System.Windows.Forms.Button();
            this.btnTags = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();

            // dgvTasks
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(12, 12);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.Size = new System.Drawing.Size(776, 269);
            this.dgvTasks.TabIndex = 0;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(12, 296);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnChangeStatus
            this.btnChangeStatus.Location = new System.Drawing.Point(128, 296);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(110, 23);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Изменить статус";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);

            // btnViewDetails
            this.btnViewDetails.Location = new System.Drawing.Point(244, 296);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(110, 23);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "Детали";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(360, 296);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnComments
            this.btnComments.Location = new System.Drawing.Point(128, 325);
            this.btnComments.Name = "btnComments";
            this.btnComments.Size = new System.Drawing.Size(110, 23);
            this.btnComments.TabIndex = 5;
            this.btnComments.Text = "Комментарии";
            this.btnComments.UseVisualStyleBackColor = true;
            this.btnComments.Click += new System.EventHandler(this.btnComments_Click);

            // btnTags
            this.btnTags.Location = new System.Drawing.Point(244, 325);
            this.btnTags.Name = "btnTags";
            this.btnTags.Size = new System.Drawing.Size(110, 23);
            this.btnTags.TabIndex = 6;
            this.btnTags.Text = "Теги";
            this.btnTags.UseVisualStyleBackColor = true;
            this.btnTags.Click += new System.EventHandler(this.btnTags_Click);

            // btnHistory
            this.btnHistory.Location = new System.Drawing.Point(360, 325);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(110, 23);
            this.btnHistory.TabIndex = 7;
            this.btnHistory.Text = "История";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(678, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // MyTasksForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnComments);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvTasks);
            this.Name = "MyTasksForm";
            this.Text = "Мои задачи";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
        }

        
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnComments;
        private System.Windows.Forms.Button btnTags;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnClose;
    }
}