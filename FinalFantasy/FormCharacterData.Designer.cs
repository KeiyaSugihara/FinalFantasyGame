namespace FinalFantasy
{
    partial class FormCharacterData
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
            this.components = new System.ComponentModel.Container();
            this.buttonCharacter = new System.Windows.Forms.Button();
            this.listBoxCharacter = new System.Windows.Forms.ListBox();
            this.labelCharacter = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelAdventure = new System.Windows.Forms.Label();
            this.buttonAdventure = new System.Windows.Forms.Button();
            this.labelEnemy = new System.Windows.Forms.Label();
            this.buttonFight = new System.Windows.Forms.Button();
            this.labelCraudo = new System.Windows.Forms.Label();
            this.labelTifa = new System.Windows.Forms.Label();
            this.labelEaris = new System.Windows.Forms.Label();
            this.labelBarrett = new System.Windows.Forms.Label();
            this.pictureBoxEnemy = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnemy2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCharacter
            // 
            this.buttonCharacter.BackColor = System.Drawing.Color.Silver;
            this.buttonCharacter.Location = new System.Drawing.Point(63, 289);
            this.buttonCharacter.Name = "buttonCharacter";
            this.buttonCharacter.Size = new System.Drawing.Size(75, 23);
            this.buttonCharacter.TabIndex = 0;
            this.buttonCharacter.TabStop = false;
            this.buttonCharacter.Text = "キャラクター";
            this.buttonCharacter.UseVisualStyleBackColor = false;
            this.buttonCharacter.Click += new System.EventHandler(this.buttonCharacter_Click);
            // 
            // listBoxCharacter
            // 
            this.listBoxCharacter.BackColor = System.Drawing.Color.Gray;
            this.listBoxCharacter.FormattingEnabled = true;
            this.listBoxCharacter.ItemHeight = 12;
            this.listBoxCharacter.Items.AddRange(new object[] {
            "・クラウド",
            "・ティファ",
            "・エアリス",
            "・バレット"});
            this.listBoxCharacter.Location = new System.Drawing.Point(12, 21);
            this.listBoxCharacter.Name = "listBoxCharacter";
            this.listBoxCharacter.Size = new System.Drawing.Size(182, 64);
            this.listBoxCharacter.TabIndex = 1;
            this.listBoxCharacter.Visible = false;
            // 
            // labelCharacter
            // 
            this.labelCharacter.BackColor = System.Drawing.Color.Gray;
            this.labelCharacter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCharacter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCharacter.Location = new System.Drawing.Point(12, 88);
            this.labelCharacter.Name = "labelCharacter";
            this.labelCharacter.Size = new System.Drawing.Size(182, 187);
            this.labelCharacter.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // labelAdventure
            // 
            this.labelAdventure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAdventure.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelAdventure.Location = new System.Drawing.Point(283, 489);
            this.labelAdventure.Name = "labelAdventure";
            this.labelAdventure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelAdventure.Size = new System.Drawing.Size(430, 37);
            this.labelAdventure.TabIndex = 3;
            this.labelAdventure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAdventure
            // 
            this.buttonAdventure.BackColor = System.Drawing.Color.Silver;
            this.buttonAdventure.Enabled = false;
            this.buttonAdventure.Location = new System.Drawing.Point(63, 349);
            this.buttonAdventure.Name = "buttonAdventure";
            this.buttonAdventure.Size = new System.Drawing.Size(75, 23);
            this.buttonAdventure.TabIndex = 4;
            this.buttonAdventure.Text = "冒険に出る";
            this.buttonAdventure.UseVisualStyleBackColor = false;
            this.buttonAdventure.Visible = false;
            this.buttonAdventure.Click += new System.EventHandler(this.buttonAdventure_Click);
            // 
            // labelEnemy
            // 
            this.labelEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEnemy.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEnemy.Location = new System.Drawing.Point(283, 21);
            this.labelEnemy.Name = "labelEnemy";
            this.labelEnemy.Size = new System.Drawing.Size(430, 223);
            this.labelEnemy.TabIndex = 5;
            this.labelEnemy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonFight
            // 
            this.buttonFight.Location = new System.Drawing.Point(63, 320);
            this.buttonFight.Name = "buttonFight";
            this.buttonFight.Size = new System.Drawing.Size(75, 23);
            this.buttonFight.TabIndex = 6;
            this.buttonFight.Text = "攻撃";
            this.buttonFight.UseVisualStyleBackColor = true;
            this.buttonFight.Visible = false;
            this.buttonFight.Click += new System.EventHandler(this.buttonFight_Click);
            // 
            // labelCraudo
            // 
            this.labelCraudo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCraudo.Location = new System.Drawing.Point(283, 526);
            this.labelCraudo.Name = "labelCraudo";
            this.labelCraudo.Size = new System.Drawing.Size(110, 119);
            this.labelCraudo.TabIndex = 7;
            this.labelCraudo.Text = "クラウド";
            // 
            // labelTifa
            // 
            this.labelTifa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTifa.Location = new System.Drawing.Point(390, 526);
            this.labelTifa.Name = "labelTifa";
            this.labelTifa.Size = new System.Drawing.Size(110, 119);
            this.labelTifa.TabIndex = 8;
            this.labelTifa.Text = "ティファ";
            // 
            // labelEaris
            // 
            this.labelEaris.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEaris.Location = new System.Drawing.Point(496, 526);
            this.labelEaris.Name = "labelEaris";
            this.labelEaris.Size = new System.Drawing.Size(110, 119);
            this.labelEaris.TabIndex = 9;
            this.labelEaris.Text = "エアリス";
            // 
            // labelBarrett
            // 
            this.labelBarrett.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBarrett.Location = new System.Drawing.Point(603, 526);
            this.labelBarrett.Name = "labelBarrett";
            this.labelBarrett.Size = new System.Drawing.Size(110, 119);
            this.labelBarrett.TabIndex = 10;
            this.labelBarrett.Text = "バレット";
            // 
            // pictureBoxEnemy
            // 
            this.pictureBoxEnemy.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxEnemy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxEnemy.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pictureBoxEnemy.ErrorImage = null;
            this.pictureBoxEnemy.Location = new System.Drawing.Point(283, 48);
            this.pictureBoxEnemy.Name = "pictureBoxEnemy";
            this.pictureBoxEnemy.Size = new System.Drawing.Size(430, 247);
            this.pictureBoxEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEnemy.TabIndex = 11;
            this.pictureBoxEnemy.TabStop = false;
            this.pictureBoxEnemy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEnemy_MouseClick);
            // 
            // pictureBoxEnemy2
            // 
            this.pictureBoxEnemy2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxEnemy2.Location = new System.Drawing.Point(283, 301);
            this.pictureBoxEnemy2.Name = "pictureBoxEnemy2";
            this.pictureBoxEnemy2.Size = new System.Drawing.Size(430, 194);
            this.pictureBoxEnemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEnemy2.TabIndex = 12;
            this.pictureBoxEnemy2.TabStop = false;
            // 
            // FormCharacterData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::FinalFantasy.Properties.Resources.Title03d;
            this.ClientSize = new System.Drawing.Size(734, 658);
            this.Controls.Add(this.pictureBoxEnemy2);
            this.Controls.Add(this.buttonAdventure);
            this.Controls.Add(this.buttonFight);
            this.Controls.Add(this.labelCraudo);
            this.Controls.Add(this.labelCharacter);
            this.Controls.Add(this.pictureBoxEnemy);
            this.Controls.Add(this.listBoxCharacter);
            this.Controls.Add(this.labelEnemy);
            this.Controls.Add(this.buttonCharacter);
            this.Controls.Add(this.labelAdventure);
            this.Controls.Add(this.labelTifa);
            this.Controls.Add(this.labelBarrett);
            this.Controls.Add(this.labelEaris);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "FormCharacterData";
            this.Text = "FinalFantasy";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCharacterData_FormClosed);
            this.Load += new System.EventHandler(this.FormCharacterData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCharacterData_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCharacter;
        private System.Windows.Forms.ListBox listBoxCharacter;
        private System.Windows.Forms.Label labelCharacter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelAdventure;
        private System.Windows.Forms.Button buttonAdventure;
        private System.Windows.Forms.Label labelEnemy;
        private System.Windows.Forms.Button buttonFight;
        private System.Windows.Forms.Label labelCraudo;
        private System.Windows.Forms.Label labelTifa;
        private System.Windows.Forms.Label labelEaris;
        private System.Windows.Forms.Label labelBarrett;
        private System.Windows.Forms.PictureBox pictureBoxEnemy;
        private System.Windows.Forms.PictureBox pictureBoxEnemy2;
    }
}