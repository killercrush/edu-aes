namespace zi_rgr
{
    partial class frmMain
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnCopyToInput = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.ofdEncryptFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdDecryptFile = new System.Windows.Forms.OpenFileDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbModeCBC = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lIV = new System.Windows.Forms.Label();
            this.tbIV = new System.Windows.Forms.TextBox();
            this.btnGenerateIV = new System.Windows.Forms.Button();
            this.cbOutputToBase64 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInput.Location = new System.Drawing.Point(3, 16);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInput.Size = new System.Drawing.Size(1004, 228);
            this.tbInput.TabIndex = 0;
            this.tbInput.Text = "abcdefghijklmnop";
            // 
            // tbOutput
            // 
            this.tbOutput.BackColor = System.Drawing.Color.White;
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOutput.Location = new System.Drawing.Point(3, 16);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(1004, 195);
            this.tbOutput.TabIndex = 1;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 38);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(123, 23);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Зашифровать текст";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(63, 6);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(393, 20);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Text = "dfzgsertg";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(12, 67);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(123, 23);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Расшифровать текст";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnCopyToInput
            // 
            this.btnCopyToInput.Location = new System.Drawing.Point(142, 67);
            this.btnCopyToInput.Name = "btnCopyToInput";
            this.btnCopyToInput.Size = new System.Drawing.Size(157, 23);
            this.btnCopyToInput.TabIndex = 6;
            this.btnCopyToInput.Text = "Копировать Вывод в Ввод";
            this.btnCopyToInput.UseVisualStyleBackColor = true;
            this.btnCopyToInput.Click += new System.EventHandler(this.btnCopyToInput_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 96);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 465);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbInput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1010, 214);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вывод";
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.Location = new System.Drawing.Point(330, 37);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(126, 23);
            this.btnEncryptFile.TabIndex = 9;
            this.btnEncryptFile.Text = "Зашифровать файл";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.Location = new System.Drawing.Point(330, 67);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(126, 23);
            this.btnDecryptFile.TabIndex = 10;
            this.btnDecryptFile.Text = "Расшифровать файл";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // ofdEncryptFile
            // 
            this.ofdEncryptFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdEncryptFile_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Пароль";
            // 
            // ofdDecryptFile
            // 
            this.ofdDecryptFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDecryptFile_FileOk);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ECB";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbModeCBC
            // 
            this.rbModeCBC.AutoSize = true;
            this.rbModeCBC.Location = new System.Drawing.Point(16, 64);
            this.rbModeCBC.Name = "rbModeCBC";
            this.rbModeCBC.Size = new System.Drawing.Size(46, 17);
            this.rbModeCBC.TabIndex = 13;
            this.rbModeCBC.Text = "CBC";
            this.rbModeCBC.UseVisualStyleBackColor = true;
            this.rbModeCBC.CheckedChanged += new System.EventHandler(this.rbModeCBC_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.rbModeCBC);
            this.groupBox3.Location = new System.Drawing.Point(462, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(82, 84);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Режим";
            // 
            // lIV
            // 
            this.lIV.AutoSize = true;
            this.lIV.Location = new System.Drawing.Point(550, 72);
            this.lIV.Name = "lIV";
            this.lIV.Size = new System.Drawing.Size(17, 13);
            this.lIV.TabIndex = 15;
            this.lIV.Text = "IV";
            this.lIV.Visible = false;
            // 
            // tbIV
            // 
            this.tbIV.BackColor = System.Drawing.Color.White;
            this.tbIV.Location = new System.Drawing.Point(573, 69);
            this.tbIV.Name = "tbIV";
            this.tbIV.ReadOnly = true;
            this.tbIV.Size = new System.Drawing.Size(339, 20);
            this.tbIV.TabIndex = 16;
            this.tbIV.Visible = false;
            // 
            // btnGenerateIV
            // 
            this.btnGenerateIV.Location = new System.Drawing.Point(918, 67);
            this.btnGenerateIV.Name = "btnGenerateIV";
            this.btnGenerateIV.Size = new System.Drawing.Size(89, 23);
            this.btnGenerateIV.TabIndex = 17;
            this.btnGenerateIV.Text = "Генерировать";
            this.btnGenerateIV.UseVisualStyleBackColor = true;
            this.btnGenerateIV.Visible = false;
            this.btnGenerateIV.Click += new System.EventHandler(this.btnGenerateIV_Click);
            // 
            // cbOutputToBase64
            // 
            this.cbOutputToBase64.AutoSize = true;
            this.cbOutputToBase64.Checked = true;
            this.cbOutputToBase64.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOutputToBase64.Location = new System.Drawing.Point(142, 40);
            this.cbOutputToBase64.Name = "cbOutputToBase64";
            this.cbOutputToBase64.Size = new System.Drawing.Size(124, 17);
            this.cbOutputToBase64.TabIndex = 18;
            this.cbOutputToBase64.Text = "Выводить в Base64";
            this.cbOutputToBase64.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.cbOutputToBase64);
            this.Controls.Add(this.btnGenerateIV);
            this.Controls.Add(this.tbIV);
            this.Controls.Add(this.lIV);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDecryptFile);
            this.Controls.Add(this.btnEncryptFile);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCopyToInput);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "frmMain";
            this.Text = "РГР Защита информации, реализация алгоритма AES";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnCopyToInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.OpenFileDialog ofdEncryptFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdDecryptFile;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbModeCBC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lIV;
        private System.Windows.Forms.TextBox tbIV;
        private System.Windows.Forms.Button btnGenerateIV;
        private System.Windows.Forms.CheckBox cbOutputToBase64;
    }
}

