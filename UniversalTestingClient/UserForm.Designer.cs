namespace UniversalTestingClient
{
    partial class UserForm
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
            this.btnAdminMode = new System.Windows.Forms.Button();
            this.pGetTest = new System.Windows.Forms.Panel();
            this.btnOutputTest = new System.Windows.Forms.Button();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.pAnswerList = new System.Windows.Forms.Panel();
            this.rbtAnswer4 = new System.Windows.Forms.RadioButton();
            this.rbtAnswer2 = new System.Windows.Forms.RadioButton();
            this.rbtAnswer3 = new System.Windows.Forms.RadioButton();
            this.rbtAnswer1 = new System.Windows.Forms.RadioButton();
            this.btnTestComplete = new System.Windows.Forms.Button();
            this.lblListNumberQuestion = new System.Windows.Forms.Label();
            this.nudListNumberQuestion = new System.Windows.Forms.NumericUpDown();
            this.rtbxOption4 = new System.Windows.Forms.RichTextBox();
            this.rtbxOption3 = new System.Windows.Forms.RichTextBox();
            this.rtbxOption2 = new System.Windows.Forms.RichTextBox();
            this.rtbxOption1 = new System.Windows.Forms.RichTextBox();
            this.lblTextQuestion = new System.Windows.Forms.Label();
            this.rtbxTextQuestion = new System.Windows.Forms.RichTextBox();
            this.lblLevelDifficutly = new System.Windows.Forms.Label();
            this.cmbLevelDifficulty = new System.Windows.Forms.ComboBox();
            this.lblNumberQuestion = new System.Windows.Forms.Label();
            this.tbxNumberQuestion = new System.Windows.Forms.TextBox();
            this.pGetTest.SuspendLayout();
            this.pAnswerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudListNumberQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdminMode
            // 
            this.btnAdminMode.Location = new System.Drawing.Point(362, 429);
            this.btnAdminMode.Name = "btnAdminMode";
            this.btnAdminMode.Size = new System.Drawing.Size(139, 23);
            this.btnAdminMode.TabIndex = 0;
            this.btnAdminMode.Text = "Режим администратора";
            this.btnAdminMode.UseVisualStyleBackColor = true;
            this.btnAdminMode.Visible = false;
            // 
            // pGetTest
            // 
            this.pGetTest.Controls.Add(this.btnOutputTest);
            this.pGetTest.Controls.Add(this.lblSubject);
            this.pGetTest.Controls.Add(this.cmbSubject);
            this.pGetTest.Location = new System.Drawing.Point(124, 3);
            this.pGetTest.Name = "pGetTest";
            this.pGetTest.Size = new System.Drawing.Size(261, 45);
            this.pGetTest.TabIndex = 1;
            // 
            // btnOutputTest
            // 
            this.btnOutputTest.Location = new System.Drawing.Point(156, 19);
            this.btnOutputTest.Name = "btnOutputTest";
            this.btnOutputTest.Size = new System.Drawing.Size(92, 23);
            this.btnOutputTest.TabIndex = 8;
            this.btnOutputTest.Text = "Получить тест";
            this.btnOutputTest.UseVisualStyleBackColor = true;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(46, 6);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(52, 13);
            this.lblSubject.TabIndex = 7;
            this.lblSubject.Text = "Предмет";
            // 
            // cmbSubject
            // 
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Items.AddRange(new object[] {
            "Физика",
            "Математика",
            "Информатика",
            "Русский язык"});
            this.cmbSubject.Location = new System.Drawing.Point(14, 21);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(121, 21);
            this.cmbSubject.TabIndex = 6;
            // 
            // pAnswerList
            // 
            this.pAnswerList.Controls.Add(this.rbtAnswer4);
            this.pAnswerList.Controls.Add(this.rbtAnswer2);
            this.pAnswerList.Controls.Add(this.rbtAnswer3);
            this.pAnswerList.Controls.Add(this.rbtAnswer1);
            this.pAnswerList.Controls.Add(this.btnTestComplete);
            this.pAnswerList.Controls.Add(this.lblListNumberQuestion);
            this.pAnswerList.Controls.Add(this.nudListNumberQuestion);
            this.pAnswerList.Controls.Add(this.rtbxOption4);
            this.pAnswerList.Controls.Add(this.rtbxOption3);
            this.pAnswerList.Controls.Add(this.rtbxOption2);
            this.pAnswerList.Controls.Add(this.rtbxOption1);
            this.pAnswerList.Controls.Add(this.lblTextQuestion);
            this.pAnswerList.Controls.Add(this.rtbxTextQuestion);
            this.pAnswerList.Controls.Add(this.lblLevelDifficutly);
            this.pAnswerList.Controls.Add(this.cmbLevelDifficulty);
            this.pAnswerList.Controls.Add(this.lblNumberQuestion);
            this.pAnswerList.Controls.Add(this.tbxNumberQuestion);
            this.pAnswerList.Enabled = false;
            this.pAnswerList.Location = new System.Drawing.Point(12, 54);
            this.pAnswerList.Name = "pAnswerList";
            this.pAnswerList.Size = new System.Drawing.Size(489, 369);
            this.pAnswerList.TabIndex = 2;
            // 
            // rbtAnswer4
            // 
            this.rbtAnswer4.AutoSize = true;
            this.rbtAnswer4.Location = new System.Drawing.Point(238, 297);
            this.rbtAnswer4.Name = "rbtAnswer4";
            this.rbtAnswer4.Size = new System.Drawing.Size(34, 17);
            this.rbtAnswer4.TabIndex = 24;
            this.rbtAnswer4.TabStop = true;
            this.rbtAnswer4.Text = "4)";
            this.rbtAnswer4.UseVisualStyleBackColor = true;
            // 
            // rbtAnswer2
            // 
            this.rbtAnswer2.AutoSize = true;
            this.rbtAnswer2.Location = new System.Drawing.Point(238, 233);
            this.rbtAnswer2.Name = "rbtAnswer2";
            this.rbtAnswer2.Size = new System.Drawing.Size(34, 17);
            this.rbtAnswer2.TabIndex = 23;
            this.rbtAnswer2.TabStop = true;
            this.rbtAnswer2.Text = "2)";
            this.rbtAnswer2.UseVisualStyleBackColor = true;
            // 
            // rbtAnswer3
            // 
            this.rbtAnswer3.AutoSize = true;
            this.rbtAnswer3.Location = new System.Drawing.Point(6, 297);
            this.rbtAnswer3.Name = "rbtAnswer3";
            this.rbtAnswer3.Size = new System.Drawing.Size(34, 17);
            this.rbtAnswer3.TabIndex = 22;
            this.rbtAnswer3.TabStop = true;
            this.rbtAnswer3.Text = "3)";
            this.rbtAnswer3.UseVisualStyleBackColor = true;
            // 
            // rbtAnswer1
            // 
            this.rbtAnswer1.AutoSize = true;
            this.rbtAnswer1.Location = new System.Drawing.Point(6, 233);
            this.rbtAnswer1.Name = "rbtAnswer1";
            this.rbtAnswer1.Size = new System.Drawing.Size(34, 17);
            this.rbtAnswer1.TabIndex = 21;
            this.rbtAnswer1.TabStop = true;
            this.rbtAnswer1.Text = "1)";
            this.rbtAnswer1.UseVisualStyleBackColor = true;
            // 
            // btnTestComplete
            // 
            this.btnTestComplete.Location = new System.Drawing.Point(377, 341);
            this.btnTestComplete.Name = "btnTestComplete";
            this.btnTestComplete.Size = new System.Drawing.Size(109, 23);
            this.btnTestComplete.TabIndex = 20;
            this.btnTestComplete.Text = "Завершить тест";
            this.btnTestComplete.UseVisualStyleBackColor = true;
            // 
            // lblListNumberQuestion
            // 
            this.lblListNumberQuestion.AutoSize = true;
            this.lblListNumberQuestion.Location = new System.Drawing.Point(244, 341);
            this.lblListNumberQuestion.Name = "lblListNumberQuestion";
            this.lblListNumberQuestion.Size = new System.Drawing.Size(28, 13);
            this.lblListNumberQuestion.TabIndex = 19;
            this.lblListNumberQuestion.Text = "из 0";
            // 
            // nudListNumberQuestion
            // 
            this.nudListNumberQuestion.Location = new System.Drawing.Point(182, 339);
            this.nudListNumberQuestion.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudListNumberQuestion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudListNumberQuestion.Name = "nudListNumberQuestion";
            this.nudListNumberQuestion.Size = new System.Drawing.Size(56, 20);
            this.nudListNumberQuestion.TabIndex = 18;
            this.nudListNumberQuestion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rtbxOption4
            // 
            this.rtbxOption4.BackColor = System.Drawing.SystemColors.Window;
            this.rtbxOption4.Location = new System.Drawing.Point(278, 278);
            this.rtbxOption4.Name = "rtbxOption4";
            this.rtbxOption4.ReadOnly = true;
            this.rtbxOption4.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption4.TabIndex = 17;
            this.rtbxOption4.Text = "";
            // 
            // rtbxOption3
            // 
            this.rtbxOption3.BackColor = System.Drawing.SystemColors.Window;
            this.rtbxOption3.Location = new System.Drawing.Point(46, 278);
            this.rtbxOption3.Name = "rtbxOption3";
            this.rtbxOption3.ReadOnly = true;
            this.rtbxOption3.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption3.TabIndex = 16;
            this.rtbxOption3.Text = "";
            // 
            // rtbxOption2
            // 
            this.rtbxOption2.BackColor = System.Drawing.SystemColors.Window;
            this.rtbxOption2.Location = new System.Drawing.Point(278, 220);
            this.rtbxOption2.Name = "rtbxOption2";
            this.rtbxOption2.ReadOnly = true;
            this.rtbxOption2.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption2.TabIndex = 15;
            this.rtbxOption2.Text = "";
            // 
            // rtbxOption1
            // 
            this.rtbxOption1.BackColor = System.Drawing.SystemColors.Window;
            this.rtbxOption1.Location = new System.Drawing.Point(46, 220);
            this.rtbxOption1.Name = "rtbxOption1";
            this.rtbxOption1.ReadOnly = true;
            this.rtbxOption1.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption1.TabIndex = 14;
            this.rtbxOption1.Text = "";
            // 
            // lblTextQuestion
            // 
            this.lblTextQuestion.AutoSize = true;
            this.lblTextQuestion.Location = new System.Drawing.Point(156, 51);
            this.lblTextQuestion.Name = "lblTextQuestion";
            this.lblTextQuestion.Size = new System.Drawing.Size(82, 13);
            this.lblTextQuestion.TabIndex = 13;
            this.lblTextQuestion.Text = "Текст вопроса";
            // 
            // rtbxTextQuestion
            // 
            this.rtbxTextQuestion.BackColor = System.Drawing.SystemColors.Window;
            this.rtbxTextQuestion.Location = new System.Drawing.Point(6, 67);
            this.rtbxTextQuestion.Name = "rtbxTextQuestion";
            this.rtbxTextQuestion.ReadOnly = true;
            this.rtbxTextQuestion.Size = new System.Drawing.Size(476, 147);
            this.rtbxTextQuestion.TabIndex = 12;
            this.rtbxTextQuestion.Text = "";
            // 
            // lblLevelDifficutly
            // 
            this.lblLevelDifficutly.AutoSize = true;
            this.lblLevelDifficutly.Location = new System.Drawing.Point(192, 10);
            this.lblLevelDifficutly.Name = "lblLevelDifficutly";
            this.lblLevelDifficutly.Size = new System.Drawing.Size(109, 13);
            this.lblLevelDifficutly.TabIndex = 7;
            this.lblLevelDifficutly.Text = "Уровень сложности";
            // 
            // cmbLevelDifficulty
            // 
            this.cmbLevelDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbLevelDifficulty.FormattingEnabled = true;
            this.cmbLevelDifficulty.Items.AddRange(new object[] {
            "Легкий",
            "Средний",
            "Сложный"});
            this.cmbLevelDifficulty.Location = new System.Drawing.Point(192, 24);
            this.cmbLevelDifficulty.Name = "cmbLevelDifficulty";
            this.cmbLevelDifficulty.Size = new System.Drawing.Size(109, 21);
            this.cmbLevelDifficulty.TabIndex = 6;
            // 
            // lblNumberQuestion
            // 
            this.lblNumberQuestion.AutoSize = true;
            this.lblNumberQuestion.Location = new System.Drawing.Point(123, 10);
            this.lblNumberQuestion.Name = "lblNumberQuestion";
            this.lblNumberQuestion.Size = new System.Drawing.Size(63, 13);
            this.lblNumberQuestion.TabIndex = 5;
            this.lblNumberQuestion.Text = "№ вопроса";
            // 
            // tbxNumberQuestion
            // 
            this.tbxNumberQuestion.BackColor = System.Drawing.SystemColors.Window;
            this.tbxNumberQuestion.Location = new System.Drawing.Point(123, 25);
            this.tbxNumberQuestion.Name = "tbxNumberQuestion";
            this.tbxNumberQuestion.ReadOnly = true;
            this.tbxNumberQuestion.Size = new System.Drawing.Size(63, 20);
            this.tbxNumberQuestion.TabIndex = 4;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 455);
            this.Controls.Add(this.pAnswerList);
            this.Controls.Add(this.pGetTest);
            this.Controls.Add(this.btnAdminMode);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniversalTesting";
            this.pGetTest.ResumeLayout(false);
            this.pGetTest.PerformLayout();
            this.pAnswerList.ResumeLayout(false);
            this.pAnswerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudListNumberQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnAdminMode;
        private System.Windows.Forms.Panel pGetTest;
        private System.Windows.Forms.Label lblSubject;
        public System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Button btnOutputTest;
        private System.Windows.Forms.Panel pAnswerList;
        private System.Windows.Forms.Label lblLevelDifficutly;
        public System.Windows.Forms.ComboBox cmbLevelDifficulty;
        private System.Windows.Forms.Label lblNumberQuestion;
        public System.Windows.Forms.TextBox tbxNumberQuestion;
        public System.Windows.Forms.RichTextBox rtbxOption4;
        public System.Windows.Forms.RichTextBox rtbxOption3;
        public System.Windows.Forms.RichTextBox rtbxOption2;
        public System.Windows.Forms.RichTextBox rtbxOption1;
        private System.Windows.Forms.Label lblTextQuestion;
        public System.Windows.Forms.RichTextBox rtbxTextQuestion;
        private System.Windows.Forms.Label lblListNumberQuestion;
        private System.Windows.Forms.NumericUpDown nudListNumberQuestion;
        private System.Windows.Forms.RadioButton rbtAnswer4;
        private System.Windows.Forms.RadioButton rbtAnswer2;
        private System.Windows.Forms.RadioButton rbtAnswer3;
        private System.Windows.Forms.RadioButton rbtAnswer1;
        private System.Windows.Forms.Button btnTestComplete;
    }
}