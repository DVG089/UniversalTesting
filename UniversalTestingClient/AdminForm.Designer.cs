namespace UniversalTestingClient
{
    partial class AdminForm
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
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.pSearchUsers = new System.Windows.Forms.Panel();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.rbLogin = new System.Windows.Forms.RadioButton();
            this.rbAllUsers = new System.Windows.Forms.RadioButton();
            this.btnChangeActing = new System.Windows.Forms.Button();
            this.btnChangeRole = new System.Windows.Forms.Button();
            this.btnOutputUsers = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.gbQuestions = new System.Windows.Forms.GroupBox();
            this.pSearchQuestion = new System.Windows.Forms.Panel();
            this.btnOutputQuestions = new System.Windows.Forms.Button();
            this.pFilter = new System.Windows.Forms.Panel();
            this.cbxFilterActing = new System.Windows.Forms.CheckBox();
            this.cbxFilterSubject = new System.Windows.Forms.CheckBox();
            this.cbxFilterLevelDifficulty = new System.Windows.Forms.CheckBox();
            this.nudQuestionNumber = new System.Windows.Forms.NumericUpDown();
            this.rbQuestionsByFilter = new System.Windows.Forms.RadioButton();
            this.rbQuestionByNumber = new System.Windows.Forms.RadioButton();
            this.rbAllQuestions = new System.Windows.Forms.RadioButton();
            this.pQuestionList = new System.Windows.Forms.Panel();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.lblListNumberQuestion = new System.Windows.Forms.Label();
            this.nudListNumberQuestion = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbEditQuestion = new System.Windows.Forms.RadioButton();
            this.rbAddQuestion = new System.Windows.Forms.RadioButton();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.pQuestion = new System.Windows.Forms.Panel();
            this.lblResponse = new System.Windows.Forms.Label();
            this.nudResponse = new System.Windows.Forms.NumericUpDown();
            this.lblOption3 = new System.Windows.Forms.Label();
            this.lblOption4 = new System.Windows.Forms.Label();
            this.lblOption2 = new System.Windows.Forms.Label();
            this.lblOption1 = new System.Windows.Forms.Label();
            this.rtbxOption4 = new System.Windows.Forms.RichTextBox();
            this.rtbxOption3 = new System.Windows.Forms.RichTextBox();
            this.rtbxOption2 = new System.Windows.Forms.RichTextBox();
            this.rtbxOption1 = new System.Windows.Forms.RichTextBox();
            this.lblTextQuestion = new System.Windows.Forms.Label();
            this.rtbxTextQuestion = new System.Windows.Forms.RichTextBox();
            this.cbxActing = new System.Windows.Forms.CheckBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblLevelDifficutly = new System.Windows.Forms.Label();
            this.cmbLevelDifficulty = new System.Windows.Forms.ComboBox();
            this.lblNumberQuestion = new System.Windows.Forms.Label();
            this.tbxNumberQuestion = new System.Windows.Forms.TextBox();
            this.btnUserMode = new System.Windows.Forms.Button();
            this.gbUsers.SuspendLayout();
            this.pSearchUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.gbQuestions.SuspendLayout();
            this.pSearchQuestion.SuspendLayout();
            this.pFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuestionNumber)).BeginInit();
            this.pQuestionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudListNumberQuestion)).BeginInit();
            this.panel1.SuspendLayout();
            this.pQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudResponse)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.pSearchUsers);
            this.gbUsers.Controls.Add(this.btnChangeActing);
            this.gbUsers.Controls.Add(this.btnChangeRole);
            this.gbUsers.Controls.Add(this.btnOutputUsers);
            this.gbUsers.Controls.Add(this.dgvUsers);
            this.gbUsers.Location = new System.Drawing.Point(1, 1);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(323, 393);
            this.gbUsers.TabIndex = 0;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Пользователи";
            // 
            // pSearchUsers
            // 
            this.pSearchUsers.Controls.Add(this.tbxLogin);
            this.pSearchUsers.Controls.Add(this.rbLogin);
            this.pSearchUsers.Controls.Add(this.rbAllUsers);
            this.pSearchUsers.Location = new System.Drawing.Point(11, 20);
            this.pSearchUsers.Name = "pSearchUsers";
            this.pSearchUsers.Size = new System.Drawing.Size(188, 44);
            this.pSearchUsers.TabIndex = 4;
            // 
            // tbxLogin
            // 
            this.tbxLogin.Enabled = false;
            this.tbxLogin.Location = new System.Drawing.Point(59, 21);
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(123, 20);
            this.tbxLogin.TabIndex = 5;
            // 
            // rbLogin
            // 
            this.rbLogin.AutoSize = true;
            this.rbLogin.Location = new System.Drawing.Point(3, 21);
            this.rbLogin.Name = "rbLogin";
            this.rbLogin.Size = new System.Drawing.Size(56, 17);
            this.rbLogin.TabIndex = 4;
            this.rbLogin.Text = "Логин";
            this.rbLogin.UseVisualStyleBackColor = true;
            // 
            // rbAllUsers
            // 
            this.rbAllUsers.AutoSize = true;
            this.rbAllUsers.Checked = true;
            this.rbAllUsers.Location = new System.Drawing.Point(3, 3);
            this.rbAllUsers.Name = "rbAllUsers";
            this.rbAllUsers.Size = new System.Drawing.Size(118, 17);
            this.rbAllUsers.TabIndex = 3;
            this.rbAllUsers.TabStop = true;
            this.rbAllUsers.Text = "Все пользователи";
            this.rbAllUsers.UseVisualStyleBackColor = true;
            // 
            // btnChangeActing
            // 
            this.btnChangeActing.Location = new System.Drawing.Point(176, 361);
            this.btnChangeActing.Name = "btnChangeActing";
            this.btnChangeActing.Size = new System.Drawing.Size(134, 23);
            this.btnChangeActing.TabIndex = 3;
            this.btnChangeActing.Text = "Изменить активность";
            this.btnChangeActing.UseVisualStyleBackColor = true;
            // 
            // btnChangeRole
            // 
            this.btnChangeRole.Location = new System.Drawing.Point(10, 361);
            this.btnChangeRole.Name = "btnChangeRole";
            this.btnChangeRole.Size = new System.Drawing.Size(134, 23);
            this.btnChangeRole.TabIndex = 2;
            this.btnChangeRole.Text = "Изменить роль";
            this.btnChangeRole.UseVisualStyleBackColor = true;
            // 
            // btnOutputUsers
            // 
            this.btnOutputUsers.Location = new System.Drawing.Point(225, 41);
            this.btnOutputUsers.Name = "btnOutputUsers";
            this.btnOutputUsers.Size = new System.Drawing.Size(75, 23);
            this.btnOutputUsers.TabIndex = 1;
            this.btnOutputUsers.Text = "Найти";
            this.btnOutputUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(10, 70);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(300, 285);
            this.dgvUsers.TabIndex = 0;
            // 
            // gbQuestions
            // 
            this.gbQuestions.Controls.Add(this.pSearchQuestion);
            this.gbQuestions.Controls.Add(this.pQuestionList);
            this.gbQuestions.Controls.Add(this.panel1);
            this.gbQuestions.Controls.Add(this.btnAddQuestion);
            this.gbQuestions.Controls.Add(this.pQuestion);
            this.gbQuestions.Location = new System.Drawing.Point(330, 1);
            this.gbQuestions.Name = "gbQuestions";
            this.gbQuestions.Size = new System.Drawing.Size(738, 393);
            this.gbQuestions.TabIndex = 1;
            this.gbQuestions.TabStop = false;
            this.gbQuestions.Text = "Вопросы";
            // 
            // pSearchQuestion
            // 
            this.pSearchQuestion.Controls.Add(this.btnOutputQuestions);
            this.pSearchQuestion.Controls.Add(this.pFilter);
            this.pSearchQuestion.Controls.Add(this.nudQuestionNumber);
            this.pSearchQuestion.Controls.Add(this.rbQuestionsByFilter);
            this.pSearchQuestion.Controls.Add(this.rbQuestionByNumber);
            this.pSearchQuestion.Controls.Add(this.rbAllQuestions);
            this.pSearchQuestion.Enabled = false;
            this.pSearchQuestion.Location = new System.Drawing.Point(517, 65);
            this.pSearchQuestion.Name = "pSearchQuestion";
            this.pSearchQuestion.Size = new System.Drawing.Size(196, 163);
            this.pSearchQuestion.TabIndex = 5;
            // 
            // btnOutputQuestions
            // 
            this.btnOutputQuestions.Location = new System.Drawing.Point(113, 137);
            this.btnOutputQuestions.Name = "btnOutputQuestions";
            this.btnOutputQuestions.Size = new System.Drawing.Size(75, 23);
            this.btnOutputQuestions.TabIndex = 23;
            this.btnOutputQuestions.Text = "Найти";
            this.btnOutputQuestions.UseVisualStyleBackColor = true;
            // 
            // pFilter
            // 
            this.pFilter.Controls.Add(this.cbxFilterActing);
            this.pFilter.Controls.Add(this.cbxFilterSubject);
            this.pFilter.Controls.Add(this.cbxFilterLevelDifficulty);
            this.pFilter.Enabled = false;
            this.pFilter.Location = new System.Drawing.Point(27, 66);
            this.pFilter.Name = "pFilter";
            this.pFilter.Size = new System.Drawing.Size(133, 65);
            this.pFilter.TabIndex = 22;
            // 
            // cbxFilterActing
            // 
            this.cbxFilterActing.AutoSize = true;
            this.cbxFilterActing.Location = new System.Drawing.Point(3, 41);
            this.cbxFilterActing.Name = "cbxFilterActing";
            this.cbxFilterActing.Size = new System.Drawing.Size(85, 17);
            this.cbxFilterActing.TabIndex = 2;
            this.cbxFilterActing.Text = "Активность";
            this.cbxFilterActing.UseVisualStyleBackColor = true;
            // 
            // cbxFilterSubject
            // 
            this.cbxFilterSubject.AutoSize = true;
            this.cbxFilterSubject.Location = new System.Drawing.Point(3, 22);
            this.cbxFilterSubject.Name = "cbxFilterSubject";
            this.cbxFilterSubject.Size = new System.Drawing.Size(71, 17);
            this.cbxFilterSubject.TabIndex = 1;
            this.cbxFilterSubject.Text = "Предмет";
            this.cbxFilterSubject.UseVisualStyleBackColor = true;
            // 
            // cbxFilterLevelDifficulty
            // 
            this.cbxFilterLevelDifficulty.AutoSize = true;
            this.cbxFilterLevelDifficulty.Location = new System.Drawing.Point(3, 3);
            this.cbxFilterLevelDifficulty.Name = "cbxFilterLevelDifficulty";
            this.cbxFilterLevelDifficulty.Size = new System.Drawing.Size(128, 17);
            this.cbxFilterLevelDifficulty.TabIndex = 0;
            this.cbxFilterLevelDifficulty.Text = "Уровень сложности";
            this.cbxFilterLevelDifficulty.UseVisualStyleBackColor = true;
            // 
            // nudQuestionNumber
            // 
            this.nudQuestionNumber.Enabled = false;
            this.nudQuestionNumber.Location = new System.Drawing.Point(68, 24);
            this.nudQuestionNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudQuestionNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuestionNumber.Name = "nudQuestionNumber";
            this.nudQuestionNumber.Size = new System.Drawing.Size(120, 20);
            this.nudQuestionNumber.TabIndex = 21;
            this.nudQuestionNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbQuestionsByFilter
            // 
            this.rbQuestionsByFilter.AutoSize = true;
            this.rbQuestionsByFilter.Location = new System.Drawing.Point(3, 43);
            this.rbQuestionsByFilter.Name = "rbQuestionsByFilter";
            this.rbQuestionsByFilter.Size = new System.Drawing.Size(65, 17);
            this.rbQuestionsByFilter.TabIndex = 20;
            this.rbQuestionsByFilter.Text = "Фильтр";
            this.rbQuestionsByFilter.UseVisualStyleBackColor = true;
            // 
            // rbQuestionByNumber
            // 
            this.rbQuestionByNumber.AutoSize = true;
            this.rbQuestionByNumber.Location = new System.Drawing.Point(3, 24);
            this.rbQuestionByNumber.Name = "rbQuestionByNumber";
            this.rbQuestionByNumber.Size = new System.Drawing.Size(59, 17);
            this.rbQuestionByNumber.TabIndex = 19;
            this.rbQuestionByNumber.Text = "Номер";
            this.rbQuestionByNumber.UseVisualStyleBackColor = true;
            // 
            // rbAllQuestions
            // 
            this.rbAllQuestions.AutoSize = true;
            this.rbAllQuestions.Checked = true;
            this.rbAllQuestions.Location = new System.Drawing.Point(3, 5);
            this.rbAllQuestions.Name = "rbAllQuestions";
            this.rbAllQuestions.Size = new System.Drawing.Size(91, 17);
            this.rbAllQuestions.TabIndex = 18;
            this.rbAllQuestions.TabStop = true;
            this.rbAllQuestions.Text = "Все вопросы";
            this.rbAllQuestions.UseVisualStyleBackColor = true;
            // 
            // pQuestionList
            // 
            this.pQuestionList.Controls.Add(this.btnEditQuestion);
            this.pQuestionList.Controls.Add(this.lblListNumberQuestion);
            this.pQuestionList.Controls.Add(this.nudListNumberQuestion);
            this.pQuestionList.Enabled = false;
            this.pQuestionList.Location = new System.Drawing.Point(132, 361);
            this.pQuestionList.Name = "pQuestionList";
            this.pQuestionList.Size = new System.Drawing.Size(219, 23);
            this.pQuestionList.TabIndex = 4;
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.Location = new System.Drawing.Point(125, 0);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(94, 23);
            this.btnEditQuestion.TabIndex = 2;
            this.btnEditQuestion.Text = "Редактировать";
            this.btnEditQuestion.UseVisualStyleBackColor = true;
            // 
            // lblListNumberQuestion
            // 
            this.lblListNumberQuestion.AutoSize = true;
            this.lblListNumberQuestion.Location = new System.Drawing.Point(65, 5);
            this.lblListNumberQuestion.Name = "lblListNumberQuestion";
            this.lblListNumberQuestion.Size = new System.Drawing.Size(28, 13);
            this.lblListNumberQuestion.TabIndex = 1;
            this.lblListNumberQuestion.Text = "из 0";
            // 
            // nudListNumberQuestion
            // 
            this.nudListNumberQuestion.Location = new System.Drawing.Point(3, 3);
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
            this.nudListNumberQuestion.TabIndex = 0;
            this.nudListNumberQuestion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbEditQuestion);
            this.panel1.Controls.Add(this.rbAddQuestion);
            this.panel1.Location = new System.Drawing.Point(500, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 44);
            this.panel1.TabIndex = 3;
            // 
            // rbEditQuestion
            // 
            this.rbEditQuestion.AutoSize = true;
            this.rbEditQuestion.Location = new System.Drawing.Point(3, 21);
            this.rbEditQuestion.Name = "rbEditQuestion";
            this.rbEditQuestion.Size = new System.Drawing.Size(154, 17);
            this.rbEditQuestion.TabIndex = 1;
            this.rbEditQuestion.Text = "Редактирование вопроса";
            this.rbEditQuestion.UseVisualStyleBackColor = true;
            // 
            // rbAddQuestion
            // 
            this.rbAddQuestion.AutoSize = true;
            this.rbAddQuestion.Checked = true;
            this.rbAddQuestion.Location = new System.Drawing.Point(3, 3);
            this.rbAddQuestion.Name = "rbAddQuestion";
            this.rbAddQuestion.Size = new System.Drawing.Size(133, 17);
            this.rbAddQuestion.TabIndex = 0;
            this.rbAddQuestion.TabStop = true;
            this.rbAddQuestion.Text = "Добавление вопроса";
            this.rbAddQuestion.UseVisualStyleBackColor = true;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(419, 361);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnAddQuestion.TabIndex = 2;
            this.btnAddQuestion.Text = "Добавить";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            // 
            // pQuestion
            // 
            this.pQuestion.Controls.Add(this.lblResponse);
            this.pQuestion.Controls.Add(this.nudResponse);
            this.pQuestion.Controls.Add(this.lblOption3);
            this.pQuestion.Controls.Add(this.lblOption4);
            this.pQuestion.Controls.Add(this.lblOption2);
            this.pQuestion.Controls.Add(this.lblOption1);
            this.pQuestion.Controls.Add(this.rtbxOption4);
            this.pQuestion.Controls.Add(this.rtbxOption3);
            this.pQuestion.Controls.Add(this.rtbxOption2);
            this.pQuestion.Controls.Add(this.rtbxOption1);
            this.pQuestion.Controls.Add(this.lblTextQuestion);
            this.pQuestion.Controls.Add(this.rtbxTextQuestion);
            this.pQuestion.Controls.Add(this.cbxActing);
            this.pQuestion.Controls.Add(this.lblSubject);
            this.pQuestion.Controls.Add(this.cmbSubject);
            this.pQuestion.Controls.Add(this.lblLevelDifficutly);
            this.pQuestion.Controls.Add(this.cmbLevelDifficulty);
            this.pQuestion.Controls.Add(this.lblNumberQuestion);
            this.pQuestion.Controls.Add(this.tbxNumberQuestion);
            this.pQuestion.Location = new System.Drawing.Point(6, 19);
            this.pQuestion.Name = "pQuestion";
            this.pQuestion.Size = new System.Drawing.Size(488, 336);
            this.pQuestion.TabIndex = 0;
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(428, 231);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(37, 13);
            this.lblResponse.TabIndex = 17;
            this.lblResponse.Text = "Ответ";
            // 
            // nudResponse
            // 
            this.nudResponse.Location = new System.Drawing.Point(431, 247);
            this.nudResponse.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudResponse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudResponse.Name = "nudResponse";
            this.nudResponse.Size = new System.Drawing.Size(42, 20);
            this.nudResponse.TabIndex = 16;
            this.nudResponse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblOption3
            // 
            this.lblOption3.AutoSize = true;
            this.lblOption3.Location = new System.Drawing.Point(6, 276);
            this.lblOption3.Name = "lblOption3";
            this.lblOption3.Size = new System.Drawing.Size(16, 13);
            this.lblOption3.TabIndex = 15;
            this.lblOption3.Text = "3)";
            // 
            // lblOption4
            // 
            this.lblOption4.AutoSize = true;
            this.lblOption4.Location = new System.Drawing.Point(215, 276);
            this.lblOption4.Name = "lblOption4";
            this.lblOption4.Size = new System.Drawing.Size(16, 13);
            this.lblOption4.TabIndex = 14;
            this.lblOption4.Text = "4)";
            // 
            // lblOption2
            // 
            this.lblOption2.AutoSize = true;
            this.lblOption2.Location = new System.Drawing.Point(215, 218);
            this.lblOption2.Name = "lblOption2";
            this.lblOption2.Size = new System.Drawing.Size(16, 13);
            this.lblOption2.TabIndex = 13;
            this.lblOption2.Text = "2)";
            // 
            // lblOption1
            // 
            this.lblOption1.AutoSize = true;
            this.lblOption1.Location = new System.Drawing.Point(6, 218);
            this.lblOption1.Name = "lblOption1";
            this.lblOption1.Size = new System.Drawing.Size(16, 13);
            this.lblOption1.TabIndex = 12;
            this.lblOption1.Text = "1)";
            // 
            // rtbxOption4
            // 
            this.rtbxOption4.Location = new System.Drawing.Point(237, 273);
            this.rtbxOption4.Name = "rtbxOption4";
            this.rtbxOption4.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption4.TabIndex = 11;
            this.rtbxOption4.Text = "";
            // 
            // rtbxOption3
            // 
            this.rtbxOption3.Location = new System.Drawing.Point(28, 273);
            this.rtbxOption3.Name = "rtbxOption3";
            this.rtbxOption3.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption3.TabIndex = 10;
            this.rtbxOption3.Text = "";
            // 
            // rtbxOption2
            // 
            this.rtbxOption2.Location = new System.Drawing.Point(237, 215);
            this.rtbxOption2.Name = "rtbxOption2";
            this.rtbxOption2.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption2.TabIndex = 9;
            this.rtbxOption2.Text = "";
            // 
            // rtbxOption1
            // 
            this.rtbxOption1.Location = new System.Drawing.Point(28, 215);
            this.rtbxOption1.Name = "rtbxOption1";
            this.rtbxOption1.Size = new System.Drawing.Size(178, 52);
            this.rtbxOption1.TabIndex = 8;
            this.rtbxOption1.Text = "";
            // 
            // lblTextQuestion
            // 
            this.lblTextQuestion.AutoSize = true;
            this.lblTextQuestion.Location = new System.Drawing.Point(156, 46);
            this.lblTextQuestion.Name = "lblTextQuestion";
            this.lblTextQuestion.Size = new System.Drawing.Size(82, 13);
            this.lblTextQuestion.TabIndex = 7;
            this.lblTextQuestion.Text = "Текст вопроса";
            // 
            // rtbxTextQuestion
            // 
            this.rtbxTextQuestion.Location = new System.Drawing.Point(6, 62);
            this.rtbxTextQuestion.Name = "rtbxTextQuestion";
            this.rtbxTextQuestion.Size = new System.Drawing.Size(476, 147);
            this.rtbxTextQuestion.TabIndex = 1;
            this.rtbxTextQuestion.Text = "";
            // 
            // cbxActing
            // 
            this.cbxActing.AutoSize = true;
            this.cbxActing.Checked = true;
            this.cbxActing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxActing.Enabled = false;
            this.cbxActing.Location = new System.Drawing.Point(330, 19);
            this.cbxActing.Name = "cbxActing";
            this.cbxActing.Size = new System.Drawing.Size(85, 17);
            this.cbxActing.TabIndex = 6;
            this.cbxActing.Text = "Активность";
            this.cbxActing.UseVisualStyleBackColor = true;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(211, 4);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(52, 13);
            this.lblSubject.TabIndex = 5;
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
            this.cmbSubject.Location = new System.Drawing.Point(187, 18);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(121, 21);
            this.cmbSubject.TabIndex = 4;
            // 
            // lblLevelDifficutly
            // 
            this.lblLevelDifficutly.AutoSize = true;
            this.lblLevelDifficutly.Location = new System.Drawing.Point(72, 4);
            this.lblLevelDifficutly.Name = "lblLevelDifficutly";
            this.lblLevelDifficutly.Size = new System.Drawing.Size(109, 13);
            this.lblLevelDifficutly.TabIndex = 3;
            this.lblLevelDifficutly.Text = "Уровень сложности";
            // 
            // cmbLevelDifficulty
            // 
            this.cmbLevelDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevelDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLevelDifficulty.FormattingEnabled = true;
            this.cmbLevelDifficulty.Items.AddRange(new object[] {
            "Легкий",
            "Средний",
            "Сложный"});
            this.cmbLevelDifficulty.Location = new System.Drawing.Point(72, 18);
            this.cmbLevelDifficulty.Name = "cmbLevelDifficulty";
            this.cmbLevelDifficulty.Size = new System.Drawing.Size(109, 21);
            this.cmbLevelDifficulty.TabIndex = 2;
            // 
            // lblNumberQuestion
            // 
            this.lblNumberQuestion.AutoSize = true;
            this.lblNumberQuestion.Location = new System.Drawing.Point(3, 4);
            this.lblNumberQuestion.Name = "lblNumberQuestion";
            this.lblNumberQuestion.Size = new System.Drawing.Size(63, 13);
            this.lblNumberQuestion.TabIndex = 1;
            this.lblNumberQuestion.Text = "№ вопроса";
            // 
            // tbxNumberQuestion
            // 
            this.tbxNumberQuestion.Location = new System.Drawing.Point(3, 19);
            this.tbxNumberQuestion.Name = "tbxNumberQuestion";
            this.tbxNumberQuestion.ReadOnly = true;
            this.tbxNumberQuestion.Size = new System.Drawing.Size(63, 20);
            this.tbxNumberQuestion.TabIndex = 0;
            // 
            // btnUserMode
            // 
            this.btnUserMode.Location = new System.Drawing.Point(929, 400);
            this.btnUserMode.Name = "btnUserMode";
            this.btnUserMode.Size = new System.Drawing.Size(128, 23);
            this.btnUserMode.TabIndex = 2;
            this.btnUserMode.Text = "Режим пользователя";
            this.btnUserMode.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 432);
            this.Controls.Add(this.btnUserMode);
            this.Controls.Add(this.gbQuestions);
            this.Controls.Add(this.gbUsers);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniversalTestingAdmin";
            this.gbUsers.ResumeLayout(false);
            this.pSearchUsers.ResumeLayout(false);
            this.pSearchUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.gbQuestions.ResumeLayout(false);
            this.pSearchQuestion.ResumeLayout(false);
            this.pSearchQuestion.PerformLayout();
            this.pFilter.ResumeLayout(false);
            this.pFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuestionNumber)).EndInit();
            this.pQuestionList.ResumeLayout(false);
            this.pQuestionList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudListNumberQuestion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pQuestion.ResumeLayout(false);
            this.pQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudResponse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.Panel pSearchUsers;
        private System.Windows.Forms.RadioButton rbLogin;
        private System.Windows.Forms.RadioButton rbAllUsers;
        private System.Windows.Forms.Button btnOutputUsers;
        public System.Windows.Forms.TextBox tbxLogin;
        public System.Windows.Forms.DataGridView dgvUsers;
        public System.Windows.Forms.Button btnChangeActing;
        public System.Windows.Forms.Button btnChangeRole;
        private System.Windows.Forms.GroupBox gbQuestions;
        private System.Windows.Forms.Panel pQuestion;
        private System.Windows.Forms.Label lblNumberQuestion;
        private System.Windows.Forms.Label lblLevelDifficutly;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTextQuestion;
        private System.Windows.Forms.Label lblOption3;
        private System.Windows.Forms.Label lblOption4;
        private System.Windows.Forms.Label lblOption2;
        private System.Windows.Forms.Label lblOption1;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbEditQuestion;
        private System.Windows.Forms.RadioButton rbAddQuestion;
        public System.Windows.Forms.TextBox tbxNumberQuestion;
        public System.Windows.Forms.ComboBox cmbSubject;
        public System.Windows.Forms.ComboBox cmbLevelDifficulty;
        public System.Windows.Forms.CheckBox cbxActing;
        public System.Windows.Forms.RichTextBox rtbxOption2;
        public System.Windows.Forms.RichTextBox rtbxOption1;
        public System.Windows.Forms.RichTextBox rtbxTextQuestion;
        public System.Windows.Forms.RichTextBox rtbxOption4;
        public System.Windows.Forms.RichTextBox rtbxOption3;
        public System.Windows.Forms.NumericUpDown nudResponse;
        private System.Windows.Forms.Panel pQuestionList;
        private System.Windows.Forms.NumericUpDown nudListNumberQuestion;
        private System.Windows.Forms.Button btnEditQuestion;
        private System.Windows.Forms.Label lblListNumberQuestion;
        private System.Windows.Forms.Panel pSearchQuestion;
        private System.Windows.Forms.RadioButton rbQuestionsByFilter;
        private System.Windows.Forms.RadioButton rbQuestionByNumber;
        private System.Windows.Forms.RadioButton rbAllQuestions;
        private System.Windows.Forms.Button btnOutputQuestions;
        private System.Windows.Forms.Panel pFilter;
        public System.Windows.Forms.NumericUpDown nudQuestionNumber;
        public System.Windows.Forms.CheckBox cbxFilterActing;
        public System.Windows.Forms.CheckBox cbxFilterSubject;
        public System.Windows.Forms.CheckBox cbxFilterLevelDifficulty;
        private System.Windows.Forms.Button btnUserMode;
    }
}