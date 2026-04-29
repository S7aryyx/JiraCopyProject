namespace JiraCopyProject.WinForms.Forms
{
    partial class CopySubtaskForm
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
            this.gbCopy = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.chkCopySubtasks = new System.Windows.Forms.CheckBox();
            this.lblCopyTaskId = new System.Windows.Forms.Label();
            this.txtCopyTaskId = new System.Windows.Forms.TextBox();
            this.gbSubtask = new System.Windows.Forms.GroupBox();
            this.btnCreateSubtask = new System.Windows.Forms.Button();
            this.cmbSubAssignee = new System.Windows.Forms.ComboBox();
            this.lblSubAssignee = new System.Windows.Forms.Label();
            this.dtpSubDue = new System.Windows.Forms.DateTimePicker();
            this.lblSubDue = new System.Windows.Forms.Label();
            this.txtSubDesc = new System.Windows.Forms.TextBox();
            this.lblSubDesc = new System.Windows.Forms.Label();
            this.txtSubTitle = new System.Windows.Forms.TextBox();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.txtParentId = new System.Windows.Forms.TextBox();
            this.lblParentId = new System.Windows.Forms.Label();
            this.gbTree = new System.Windows.Forms.GroupBox();
            this.btnShowTree = new System.Windows.Forms.Button();
            this.txtRootTaskId = new System.Windows.Forms.TextBox();
            this.lblRootTaskId = new System.Windows.Forms.Label();
            this.treeSubtasks = new System.Windows.Forms.TreeView();
            this.gbCopy.SuspendLayout();
            this.gbSubtask.SuspendLayout();
            this.gbTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCopy
            // 
            this.gbCopy.Controls.Add(this.btnCopy);
            this.gbCopy.Controls.Add(this.chkCopySubtasks);
            this.gbCopy.Controls.Add(this.lblCopyTaskId);
            this.gbCopy.Controls.Add(this.txtCopyTaskId);
            this.gbCopy.Location = new System.Drawing.Point(12, 12);
            this.gbCopy.Name = "gbCopy";
            this.gbCopy.Size = new System.Drawing.Size(300, 100);
            this.gbCopy.TabIndex = 0;
            this.gbCopy.TabStop = false;
            this.gbCopy.Text = "Копирование задачи";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(200, 65);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Копировать";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // chkCopySubtasks
            // 
            this.chkCopySubtasks.AutoSize = true;
            this.chkCopySubtasks.Location = new System.Drawing.Point(6, 68);
            this.chkCopySubtasks.Name = "chkCopySubtasks";
            this.chkCopySubtasks.Size = new System.Drawing.Size(132, 17);
            this.chkCopySubtasks.TabIndex = 2;
            this.chkCopySubtasks.Text = "Копировать подзадачи";
            this.chkCopySubtasks.UseVisualStyleBackColor = true;
            // 
            // lblCopyTaskId
            // 
            this.lblCopyTaskId.AutoSize = true;
            this.lblCopyTaskId.Location = new System.Drawing.Point(6, 28);
            this.lblCopyTaskId.Name = "lblCopyTaskId";
            this.lblCopyTaskId.Size = new System.Drawing.Size(65, 13);
            this.lblCopyTaskId.TabIndex = 1;
            this.lblCopyTaskId.Text = "ID задачи:";
            // 
            // txtCopyTaskId
            // 
            this.txtCopyTaskId.Location = new System.Drawing.Point(77, 25);
            this.txtCopyTaskId.Name = "txtCopyTaskId";
            this.txtCopyTaskId.Size = new System.Drawing.Size(100, 20);
            this.txtCopyTaskId.TabIndex = 0;
            // 
            // gbSubtask
            // 
            this.gbSubtask.Controls.Add(this.btnCreateSubtask);
            this.gbSubtask.Controls.Add(this.cmbSubAssignee);
            this.gbSubtask.Controls.Add(this.lblSubAssignee);
            this.gbSubtask.Controls.Add(this.dtpSubDue);
            this.gbSubtask.Controls.Add(this.lblSubDue);
            this.gbSubtask.Controls.Add(this.txtSubDesc);
            this.gbSubtask.Controls.Add(this.lblSubDesc);
            this.gbSubtask.Controls.Add(this.txtSubTitle);
            this.gbSubtask.Controls.Add(this.lblSubTitle);
            this.gbSubtask.Controls.Add(this.txtParentId);
            this.gbSubtask.Controls.Add(this.lblParentId);
            this.gbSubtask.Location = new System.Drawing.Point(12, 118);
            this.gbSubtask.Name = "gbSubtask";
            this.gbSubtask.Size = new System.Drawing.Size(300, 280);
            this.gbSubtask.TabIndex = 1;
            this.gbSubtask.TabStop = false;
            this.gbSubtask.Text = "Создание подзадачи";
            // 
            // btnCreateSubtask
            // 
            this.btnCreateSubtask.Location = new System.Drawing.Point(200, 245);
            this.btnCreateSubtask.Name = "btnCreateSubtask";
            this.btnCreateSubtask.Size = new System.Drawing.Size(90, 23);
            this.btnCreateSubtask.TabIndex = 10;
            this.btnCreateSubtask.Text = "Создать";
            this.btnCreateSubtask.UseVisualStyleBackColor = true;
            this.btnCreateSubtask.Click += new System.EventHandler(this.btnCreateSubtask_Click);
            // 
            // cmbSubAssignee
            // 
            this.cmbSubAssignee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubAssignee.FormattingEnabled = true;
            this.cmbSubAssignee.Location = new System.Drawing.Point(77, 210);
            this.cmbSubAssignee.Name = "cmbSubAssignee";
            this.cmbSubAssignee.Size = new System.Drawing.Size(200, 21);
            this.cmbSubAssignee.TabIndex = 9;
            // 
            // lblSubAssignee
            // 
            this.lblSubAssignee.AutoSize = true;
            this.lblSubAssignee.Location = new System.Drawing.Point(6, 213);
            this.lblSubAssignee.Name = "lblSubAssignee";
            this.lblSubAssignee.Size = new System.Drawing.Size(65, 13);
            this.lblSubAssignee.TabIndex = 8;
            this.lblSubAssignee.Text = "Исполнитель:";
            // 
            // dtpSubDue
            // 
            this.dtpSubDue.CustomFormat = "yyyy-MM-dd";
            this.dtpSubDue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSubDue.Location = new System.Drawing.Point(77, 180);
            this.dtpSubDue.Name = "dtpSubDue";
            this.dtpSubDue.Size = new System.Drawing.Size(120, 20);
            this.dtpSubDue.TabIndex = 7;
            // 
            // lblSubDue
            // 
            this.lblSubDue.AutoSize = true;
            this.lblSubDue.Location = new System.Drawing.Point(6, 183);
            this.lblSubDue.Name = "lblSubDue";
            this.lblSubDue.Size = new System.Drawing.Size(36, 13);
            this.lblSubDue.TabIndex = 6;
            this.lblSubDue.Text = "Срок:";
            // 
            // txtSubDesc
            // 
            this.txtSubDesc.Location = new System.Drawing.Point(77, 105);
            this.txtSubDesc.Multiline = true;
            this.txtSubDesc.Name = "txtSubDesc";
            this.txtSubDesc.Size = new System.Drawing.Size(200, 65);
            this.txtSubDesc.TabIndex = 5;
            // 
            // lblSubDesc
            // 
            this.lblSubDesc.AutoSize = true;
            this.lblSubDesc.Location = new System.Drawing.Point(6, 108);
            this.lblSubDesc.Name = "lblSubDesc";
            this.lblSubDesc.Size = new System.Drawing.Size(60, 13);
            this.lblSubDesc.TabIndex = 4;
            this.lblSubDesc.Text = "Описание:";
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Location = new System.Drawing.Point(77, 75);
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Size = new System.Drawing.Size(200, 20);
            this.txtSubTitle.TabIndex = 3;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(6, 78);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(60, 13);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Название:";
            // 
            // txtParentId
            // 
            this.txtParentId.Location = new System.Drawing.Point(77, 45);
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.Size = new System.Drawing.Size(100, 20);
            this.txtParentId.TabIndex = 1;
            // 
            // lblParentId
            // 
            this.lblParentId.AutoSize = true;
            this.lblParentId.Location = new System.Drawing.Point(6, 48);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(72, 13);
            this.lblParentId.TabIndex = 0;
            this.lblParentId.Text = "ID родителя:";
            // 
            // gbTree
            // 
            this.gbTree.Controls.Add(this.btnShowTree);
            this.gbTree.Controls.Add(this.txtRootTaskId);
            this.gbTree.Controls.Add(this.lblRootTaskId);
            this.gbTree.Controls.Add(this.treeSubtasks);
            this.gbTree.Location = new System.Drawing.Point(318, 12);
            this.gbTree.Name = "gbTree";
            this.gbTree.Size = new System.Drawing.Size(400, 386);
            this.gbTree.TabIndex = 2;
            this.gbTree.TabStop = false;
            this.gbTree.Text = "Дерево подзадач";
            // 
            // btnShowTree
            // 
            this.btnShowTree.Location = new System.Drawing.Point(200, 25);
            this.btnShowTree.Name = "btnShowTree";
            this.btnShowTree.Size = new System.Drawing.Size(90, 23);
            this.btnShowTree.TabIndex = 4;
            this.btnShowTree.Text = "Показать";
            this.btnShowTree.UseVisualStyleBackColor = true;
            this.btnShowTree.Click += new System.EventHandler(this.btnShowTree_Click);
            // 
            // txtRootTaskId
            // 
            this.txtRootTaskId.Location = new System.Drawing.Point(90, 27);
            this.txtRootTaskId.Name = "txtRootTaskId";
            this.txtRootTaskId.Size = new System.Drawing.Size(100, 20);
            this.txtRootTaskId.TabIndex = 3;
            // 
            // lblRootTaskId
            // 
            this.lblRootTaskId.AutoSize = true;
            this.lblRootTaskId.Location = new System.Drawing.Point(6, 30);
            this.lblRootTaskId.Name = "lblRootTaskId";
            this.lblRootTaskId.Size = new System.Drawing.Size(78, 13);
            this.lblRootTaskId.TabIndex = 2;
            this.lblRootTaskId.Text = "ID корневой:";
            // 
            // treeSubtasks
            // 
            this.treeSubtasks.Location = new System.Drawing.Point(9, 55);
            this.treeSubtasks.Name = "treeSubtasks";
            this.treeSubtasks.Size = new System.Drawing.Size(380, 320);
            this.treeSubtasks.TabIndex = 1;
            // 
            // CopySubtaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.gbTree);
            this.Controls.Add(this.gbSubtask);
            this.Controls.Add(this.gbCopy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopySubtaskForm";
            this.Text = "Копирование и подзадачи";
            this.gbCopy.ResumeLayout(false);
            this.gbCopy.PerformLayout();
            this.gbSubtask.ResumeLayout(false);
            this.gbSubtask.PerformLayout();
            this.gbTree.ResumeLayout(false);
            this.gbTree.PerformLayout();
            this.ResumeLayout(false);
        }

        // Элементы управления (объявления)
        private System.Windows.Forms.GroupBox gbCopy;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckBox chkCopySubtasks;
        private System.Windows.Forms.Label lblCopyTaskId;
        private System.Windows.Forms.TextBox txtCopyTaskId;
        private System.Windows.Forms.GroupBox gbSubtask;
        private System.Windows.Forms.Button btnCreateSubtask;
        private System.Windows.Forms.ComboBox cmbSubAssignee;
        private System.Windows.Forms.Label lblSubAssignee;
        private System.Windows.Forms.DateTimePicker dtpSubDue;
        private System.Windows.Forms.Label lblSubDue;
        private System.Windows.Forms.TextBox txtSubDesc;
        private System.Windows.Forms.Label lblSubDesc;
        private System.Windows.Forms.TextBox txtSubTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.TextBox txtParentId;
        private System.Windows.Forms.Label lblParentId;
        private System.Windows.Forms.GroupBox gbTree;
        private System.Windows.Forms.Button btnShowTree;
        private System.Windows.Forms.TextBox txtRootTaskId;
        private System.Windows.Forms.Label lblRootTaskId;
        private System.Windows.Forms.TreeView treeSubtasks;
    }
}