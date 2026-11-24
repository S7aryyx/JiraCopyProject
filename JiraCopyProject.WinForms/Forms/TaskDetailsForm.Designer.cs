namespace JiraCopyProject.WinForms.Forms
{
    partial class TaskDetailsForm
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
            lblId = new Label();
            lblIdValue = new Label();
            lblTitle = new Label();
            lblTitleValue = new Label();
            lblDesc = new Label();
            txtDescription = new TextBox();
            lblDueDate = new Label();
            lblDueDateValue = new Label();
            lblStatus = new Label();
            lblStatusValue = new Label();
            lblCreator = new Label();
            lblCreatorValue = new Label();
            lblAssignee = new Label();
            lblAssigneeValue = new Label();
            gbSubtasks = new GroupBox();
            dgvSubtasks = new DataGridView();
            btnClose = new Button();
            gbSubtasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubtasks).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(10, 11);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // lblIdValue
            // 
            lblIdValue.AutoSize = true;
            lblIdValue.Location = new Point(88, 11);
            lblIdValue.Name = "lblIdValue";
            lblIdValue.Size = new Size(0, 15);
            lblIdValue.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(62, 15);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Название:";
            // 
            // lblTitleValue
            // 
            lblTitleValue.AutoSize = true;
            lblTitleValue.Location = new Point(88, 34);
            lblTitleValue.Name = "lblTitleValue";
            lblTitleValue.Size = new Size(0, 15);
            lblTitleValue.TabIndex = 3;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Location = new Point(10, 56);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(65, 15);
            lblDesc.TabIndex = 4;
            lblDesc.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(84, 56);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(350, 61);
            txtDescription.TabIndex = 5;
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(10, 124);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(38, 15);
            lblDueDate.TabIndex = 6;
            lblDueDate.Text = "Срок:";
            // 
            // lblDueDateValue
            // 
            lblDueDateValue.AutoSize = true;
            lblDueDateValue.Location = new Point(88, 124);
            lblDueDateValue.Name = "lblDueDateValue";
            lblDueDateValue.Size = new Size(0, 15);
            lblDueDateValue.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 146);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(46, 15);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Статус:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Location = new Point(88, 146);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(0, 15);
            lblStatusValue.TabIndex = 9;
            // 
            // lblCreator
            // 
            lblCreator.AutoSize = true;
            lblCreator.Location = new Point(10, 169);
            lblCreator.Name = "lblCreator";
            lblCreator.Size = new Size(66, 15);
            lblCreator.TabIndex = 10;
            lblCreator.Text = "Создатель:";
            // 
            // lblCreatorValue
            // 
            lblCreatorValue.AutoSize = true;
            lblCreatorValue.Location = new Point(88, 169);
            lblCreatorValue.Name = "lblCreatorValue";
            lblCreatorValue.Size = new Size(0, 15);
            lblCreatorValue.TabIndex = 11;
            // 
            // lblAssignee
            // 
            lblAssignee.AutoSize = true;
            lblAssignee.Location = new Point(10, 191);
            lblAssignee.Name = "lblAssignee";
            lblAssignee.Size = new Size(84, 15);
            lblAssignee.TabIndex = 12;
            lblAssignee.Text = "Исполнитель:";
            // 
            // lblAssigneeValue
            // 
            lblAssigneeValue.AutoSize = true;
            lblAssigneeValue.Location = new Point(88, 191);
            lblAssigneeValue.Name = "lblAssigneeValue";
            lblAssigneeValue.Size = new Size(0, 15);
            lblAssigneeValue.TabIndex = 13;
            // 
            // gbSubtasks
            // 
            gbSubtasks.Controls.Add(dgvSubtasks);
            gbSubtasks.Location = new Point(10, 218);
            gbSubtasks.Margin = new Padding(3, 2, 3, 2);
            gbSubtasks.Name = "gbSubtasks";
            gbSubtasks.Padding = new Padding(3, 2, 3, 2);
            gbSubtasks.Size = new Size(427, 150);
            gbSubtasks.TabIndex = 14;
            gbSubtasks.TabStop = false;
            gbSubtasks.Text = "Подзадачи";
            // 
            // dgvSubtasks
            // 
            dgvSubtasks.AllowUserToAddRows = false;
            dgvSubtasks.AllowUserToDeleteRows = false;
            dgvSubtasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubtasks.Dock = DockStyle.Fill;
            dgvSubtasks.Location = new Point(3, 18);
            dgvSubtasks.Margin = new Padding(3, 2, 3, 2);
            dgvSubtasks.Name = "dgvSubtasks";
            dgvSubtasks.ReadOnly = true;
            dgvSubtasks.RowHeadersVisible = false;
            dgvSubtasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubtasks.Size = new Size(421, 130);
            dgvSubtasks.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(359, 375);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(79, 22);
            btnClose.TabIndex = 15;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // TaskDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 407);
            Controls.Add(btnClose);
            Controls.Add(gbSubtasks);
            Controls.Add(lblAssigneeValue);
            Controls.Add(lblAssignee);
            Controls.Add(lblCreatorValue);
            Controls.Add(lblCreator);
            Controls.Add(lblStatusValue);
            Controls.Add(lblStatus);
            Controls.Add(lblDueDateValue);
            Controls.Add(lblDueDate);
            Controls.Add(txtDescription);
            Controls.Add(lblDesc);
            Controls.Add(lblTitleValue);
            Controls.Add(lblTitle);
            Controls.Add(lblIdValue);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TaskDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Детали задачи";
            gbSubtasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubtasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblIdValue;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTitleValue;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDueDateValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblCreatorValue;
        private System.Windows.Forms.Label lblAssignee;
        private System.Windows.Forms.Label lblAssigneeValue;
        private System.Windows.Forms.GroupBox gbSubtasks;
        private System.Windows.Forms.DataGridView dgvSubtasks;
        private System.Windows.Forms.Button btnClose;
    }
}