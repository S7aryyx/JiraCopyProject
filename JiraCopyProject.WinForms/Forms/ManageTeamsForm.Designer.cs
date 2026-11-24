namespace JiraCopyProject.WinForms.Forms
{
    partial class ManageTeamsForm
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
            this.dgvTeams = new System.Windows.Forms.DataGridView();
            this.btnCreateTeam = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnShowMembers = new System.Windows.Forms.Button();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            this.btnTransferLead = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).BeginInit();
            this.SuspendLayout();

            // dgvTeams
            this.dgvTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeams.Location = new System.Drawing.Point(12, 12);
            this.dgvTeams.Name = "dgvTeams";
            this.dgvTeams.Size = new System.Drawing.Size(776, 269);
            this.dgvTeams.TabIndex = 0;

            // btnCreateTeam
            this.btnCreateTeam.Location = new System.Drawing.Point(12, 296);
            this.btnCreateTeam.Name = "btnCreateTeam";
            this.btnCreateTeam.Size = new System.Drawing.Size(145, 23);
            this.btnCreateTeam.TabIndex = 1;
            this.btnCreateTeam.Text = "Создать команду";
            this.btnCreateTeam.UseVisualStyleBackColor = true;
            this.btnCreateTeam.Click += new System.EventHandler(this.btnCreateTeam_Click);

            // btnAddUser
            this.btnAddUser.Location = new System.Drawing.Point(165, 296);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(145, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Добавить пользователя";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // btnShowMembers
            this.btnShowMembers.Location = new System.Drawing.Point(316, 296);
            this.btnShowMembers.Name = "btnShowMembers";
            this.btnShowMembers.Size = new System.Drawing.Size(145, 23);
            this.btnShowMembers.TabIndex = 3;
            this.btnShowMembers.Text = "Участники";
            this.btnShowMembers.UseVisualStyleBackColor = true;
            this.btnShowMembers.Click += new System.EventHandler(this.btnShowMembers_Click);

            // btnDeleteTeam
            this.btnDeleteTeam.Location = new System.Drawing.Point(467, 296);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(145, 23);
            this.btnDeleteTeam.TabIndex = 4;
            this.btnDeleteTeam.Text = "Удалить команду";
            this.btnDeleteTeam.UseVisualStyleBackColor = true;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);

            // btnTransferLead
            this.btnTransferLead.Location = new System.Drawing.Point(618, 296);
            this.btnTransferLead.Name = "btnTransferLead";
            this.btnTransferLead.Size = new System.Drawing.Size(145, 23);
            this.btnTransferLead.TabIndex = 5;
            this.btnTransferLead.Text = "Передать лидерство";
            this.btnTransferLead.UseVisualStyleBackColor = true;
            this.btnTransferLead.Click += new System.EventHandler(this.btnTransferLead_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(12, 415);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(145, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(643, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ManageTeamsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnTransferLead);
            this.Controls.Add(this.btnDeleteTeam);
            this.Controls.Add(this.btnShowMembers);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnCreateTeam);
            this.Controls.Add(this.dgvTeams);
            this.Name = "ManageTeamsForm";
            this.Text = "Управление командами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeams)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.Button btnCreateTeam;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnShowMembers;
        private System.Windows.Forms.Button btnDeleteTeam;
        private System.Windows.Forms.Button btnTransferLead;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}