namespace ReadCity
{
    partial class Authorization
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
            authorizationButton = new Button();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            labelLogin = new Label();
            labelPassword = new Label();
            labelAuth = new Label();
            SuspendLayout();
            // 
            // authorizationButton
            // 
            authorizationButton.BackColor = Color.SteelBlue;
            authorizationButton.Location = new Point(89, 264);
            authorizationButton.Margin = new Padding(0);
            authorizationButton.Name = "authorizationButton";
            authorizationButton.Size = new Size(300, 50);
            authorizationButton.TabIndex = 0;
            authorizationButton.Text = "Войти";
            authorizationButton.UseVisualStyleBackColor = false;
            authorizationButton.Click += authorizationButton_Click;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(89, 124);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(300, 23);
            textBoxLogin.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(89, 204);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(300, 23);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 15F);
            labelLogin.Location = new Point(89, 93);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(69, 28);
            labelLogin.TabIndex = 3;
            labelLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 15F);
            labelPassword.Location = new Point(89, 173);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(81, 28);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Пароль";
            // 
            // labelAuth
            // 
            labelAuth.AutoSize = true;
            labelAuth.Font = new Font("Segoe UI", 25F);
            labelAuth.Location = new Point(121, 23);
            labelAuth.Name = "labelAuth";
            labelAuth.Size = new Size(223, 46);
            labelAuth.TabIndex = 5;
            labelAuth.Text = "Авторизация";
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(labelAuth);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(authorizationButton);
            Name = "Authorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button authorizationButton;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Label labelLogin;
        private Label labelPassword;
        private Label labelAuth;
    }
}