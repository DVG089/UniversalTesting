namespace UniversalTestingClient
{
    partial class UserAuthenticationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnEntrance = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(61, 39);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(169, 20);
            this.tbLogin.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(61, 89);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(169, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnEntrance
            // 
            this.btnEntrance.Location = new System.Drawing.Point(61, 136);
            this.btnEntrance.Name = "btnEntrance";
            this.btnEntrance.Size = new System.Drawing.Size(75, 23);
            this.btnEntrance.TabIndex = 2;
            this.btnEntrance.Text = "Вход";
            this.btnEntrance.UseVisualStyleBackColor = true;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(145, 136);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(85, 23);
            this.btnRegistration.TabIndex = 3;
            this.btnRegistration.Text = "Регистрация";
            this.btnRegistration.UseVisualStyleBackColor = true;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(58, 23);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 13);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(58, 73);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(45, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль";
            // 
            // UserAuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 194);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnEntrance);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.MaximumSize = new System.Drawing.Size(304, 233);
            this.MinimumSize = new System.Drawing.Size(304, 233);
            this.Name = "UserAuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аутенфикация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbLogin;
        public System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnEntrance;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
    }
}

