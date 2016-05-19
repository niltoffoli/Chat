namespace ChatProdan
{
    partial class FrmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.rdbAusente = new System.Windows.Forms.RadioButton();
            this.rdbOcupado = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.GroupStatus = new System.Windows.Forms.GroupBox();
            this.rdbOnline = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileImg = new System.Windows.Forms.OpenFileDialog();
            this.pictboxUser = new System.Windows.Forms.PictureBox();
            this.GroupStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(27, 45);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(177, 23);
            this.txtUsername.TabIndex = 0;
            // 
            // rdbAusente
            // 
            this.rdbAusente.AutoSize = true;
            this.rdbAusente.Location = new System.Drawing.Point(6, 52);
            this.rdbAusente.Name = "rdbAusente";
            this.rdbAusente.Size = new System.Drawing.Size(67, 17);
            this.rdbAusente.TabIndex = 2;
            this.rdbAusente.TabStop = true;
            this.rdbAusente.Tag = "ausente";
            this.rdbAusente.Text = "Ausente";
            this.rdbAusente.UseVisualStyleBackColor = true;
            // 
            // rdbOcupado
            // 
            this.rdbOcupado.AutoSize = true;
            this.rdbOcupado.Location = new System.Drawing.Point(6, 76);
            this.rdbOcupado.Name = "rdbOcupado";
            this.rdbOcupado.Size = new System.Drawing.Size(73, 17);
            this.rdbOcupado.TabIndex = 3;
            this.rdbOcupado.TabStop = true;
            this.rdbOcupado.Tag = "ocupado";
            this.rdbOcupado.Text = "Ocupado";
            this.rdbOcupado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuário";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(272, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // GroupStatus
            // 
            this.GroupStatus.Controls.Add(this.rdbAusente);
            this.GroupStatus.Controls.Add(this.rdbOnline);
            this.GroupStatus.Controls.Add(this.rdbOcupado);
            this.GroupStatus.Location = new System.Drawing.Point(27, 83);
            this.GroupStatus.Name = "GroupStatus";
            this.GroupStatus.Size = new System.Drawing.Size(177, 108);
            this.GroupStatus.TabIndex = 7;
            this.GroupStatus.TabStop = false;
            this.GroupStatus.Text = "Status";
            // 
            // rdbOnline
            // 
            this.rdbOnline.AutoSize = true;
            this.rdbOnline.Location = new System.Drawing.Point(6, 28);
            this.rdbOnline.Name = "rdbOnline";
            this.rdbOnline.Size = new System.Drawing.Size(79, 17);
            this.rdbOnline.TabIndex = 1;
            this.rdbOnline.TabStop = true;
            this.rdbOnline.Tag = "online";
            this.rdbOnline.Text = "Disponível";
            this.rdbOnline.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Imagem";
            // 
            // openFileImg
            // 
            this.openFileImg.DefaultExt = "jpg";
            this.openFileImg.Filter = "Jpeg|*.jpg";
            this.openFileImg.FilterIndex = 2;
            // 
            // pictboxUser
            // 
            this.pictboxUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictboxUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictboxUser.Location = new System.Drawing.Point(226, 45);
            this.pictboxUser.Name = "pictboxUser";
            this.pictboxUser.Size = new System.Drawing.Size(146, 146);
            this.pictboxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictboxUser.TabIndex = 8;
            this.pictboxUser.TabStop = false;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 264);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictboxUser);
            this.Controls.Add(this.GroupStatus);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuário";
            this.GroupStatus.ResumeLayout(false);
            this.GroupStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.RadioButton rdbOnline;
        private System.Windows.Forms.RadioButton rdbAusente;
        private System.Windows.Forms.RadioButton rdbOcupado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox GroupStatus;
        private System.Windows.Forms.PictureBox pictboxUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileImg;
    }
}