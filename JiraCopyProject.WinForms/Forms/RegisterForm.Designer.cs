namespace JiraCopyProject.WinForms.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            txtPosition = new TextBox();
            btnRegister = new Button();
            lblResult = new Label();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(12, 12);
            txtLogin.Name = "txtLogin";
            txtLogin.PlaceholderText = "Логин";
            txtLogin.Size = new Size(170, 23);
            txtLogin.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 41);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Пароль";
            txtPassword.Size = new Size(170, 23);
            txtPassword.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 70);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(170, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(12, 99);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "ФИО";
            txtFullName.Size = new Size(170, 23);
            txtFullName.TabIndex = 3;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(12, 128);
            txtPosition.Name = "txtPosition";
            txtPosition.PlaceholderText = "Должность (Необязательно)";
            txtPosition.Size = new Size(170, 23);
            txtPosition.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(12, 415);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(85, 25);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Регистрация";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.ForeColor = Color.Red;
            lblResult.Location = new Point(12, 397);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(40, 15);
            lblResult.TabIndex = 6;
            lblResult.Text = "label1";
            lblResult.Visible = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(btnRegister);
            Controls.Add(txtPosition);
            Controls.Add(txtFullName);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private TextBox txtPosition;
        private Button btnRegister;
        private Label lblResult;
    }
}