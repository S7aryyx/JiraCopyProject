namespace JiraCopyProject.WinForms.Forms
{
    partial class UserStatsForm
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
            lblTotal = new Label();
            lblTotalValue = new Label();
            lblCompleted = new Label();
            lblCompletedValue = new Label();
            lblOverdue = new Label();
            lblOverdueValue = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 10F);
            lblTotal.Location = new Point(26, 28);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(92, 17);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Всего задач:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblTotalValue.Location = new Point(140, 28);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(17, 17);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "0";
            // 
            // lblCompleted
            // 
            lblCompleted.AutoSize = true;
            lblCompleted.Font = new Font("Microsoft Sans Serif", 10F);
            lblCompleted.Location = new Point(26, 66);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(87, 17);
            lblCompleted.TabIndex = 2;
            lblCompleted.Text = "Выполнено:";
            // 
            // lblCompletedValue
            // 
            lblCompletedValue.AutoSize = true;
            lblCompletedValue.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblCompletedValue.Location = new Point(140, 66);
            lblCompletedValue.Name = "lblCompletedValue";
            lblCompletedValue.Size = new Size(17, 17);
            lblCompletedValue.TabIndex = 3;
            lblCompletedValue.Text = "0";
            // 
            // lblOverdue
            // 
            lblOverdue.AutoSize = true;
            lblOverdue.Font = new Font("Microsoft Sans Serif", 10F);
            lblOverdue.Location = new Point(26, 103);
            lblOverdue.Name = "lblOverdue";
            lblOverdue.Size = new Size(93, 17);
            lblOverdue.TabIndex = 4;
            lblOverdue.Text = "Просрочено:";
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.AutoSize = true;
            lblOverdueValue.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblOverdueValue.Location = new Point(140, 103);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(17, 17);
            lblOverdueValue.TabIndex = 5;
            lblOverdueValue.Text = "0";
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(70, 150);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 28);
            btnClose.TabIndex = 6;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // UserStatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(228, 206);
            Controls.Add(btnClose);
            Controls.Add(lblOverdueValue);
            Controls.Add(lblOverdue);
            Controls.Add(lblCompletedValue);
            Controls.Add(lblCompleted);
            Controls.Add(lblTotalValue);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserStatsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Моя статистика";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblCompletedValue;
        private System.Windows.Forms.Label lblOverdue;
        private System.Windows.Forms.Label lblOverdueValue;
        private System.Windows.Forms.Button btnClose;
    }
}