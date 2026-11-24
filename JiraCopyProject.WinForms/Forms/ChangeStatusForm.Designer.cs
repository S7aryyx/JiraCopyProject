namespace JiraCopyProject.WinForms.Forms
{
    partial class ChangeStatusForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNewStatus;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;

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
            lblNewStatus = new Label();
            cmbNewStatus = new ComboBox();
            lblReason = new Label();
            txtReason = new TextBox();
            btnChange = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblNewStatus
            // 
            lblNewStatus.AutoSize = true;
            lblNewStatus.Location = new Point(20, 20);
            lblNewStatus.Name = "lblNewStatus";
            lblNewStatus.Size = new Size(85, 15);
            lblNewStatus.TabIndex = 0;
            lblNewStatus.Text = "Новый статус:";
            // 
            // cmbNewStatus
            // 
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.FormattingEnabled = true;
            cmbNewStatus.Location = new Point(138, 17);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(200, 23);
            cmbNewStatus.TabIndex = 1;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(20, 55);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(123, 15);
            lblReason.TabIndex = 2;
            lblReason.Text = "Причина изменения:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(138, 52);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(200, 23);
            txtReason.TabIndex = 3;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(120, 90);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(90, 30);
            btnChange.TabIndex = 4;
            btnChange.Text = "Изменить";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(220, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ChangeStatusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 140);
            Controls.Add(btnCancel);
            Controls.Add(btnChange);
            Controls.Add(txtReason);
            Controls.Add(lblReason);
            Controls.Add(cmbNewStatus);
            Controls.Add(lblNewStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangeStatusForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Изменение статуса задачи";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}