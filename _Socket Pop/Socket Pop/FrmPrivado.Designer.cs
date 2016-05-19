namespace ChatProdan
{
    partial class FrmPrivado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrivado));
            this.rtbPrivChat = new System.Windows.Forms.RichTextBox();
            this.rtbPrivEnvia = new System.Windows.Forms.RichTextBox();
            this.btnEmo = new System.Windows.Forms.Button();
            this.typetxt = new System.Windows.Forms.Label();
            this.typePic = new System.Windows.Forms.PictureBox();
            this.btnPrivEnvia = new System.Windows.Forms.Button();
            this.pictboxReceiver = new System.Windows.Forms.PictureBox();
            this.pictboxSender = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.typePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxSender)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbPrivChat
            // 
            this.rtbPrivChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPrivChat.BackColor = System.Drawing.SystemColors.Info;
            this.rtbPrivChat.EnableAutoDragDrop = true;
            this.rtbPrivChat.Location = new System.Drawing.Point(186, 12);
            this.rtbPrivChat.Name = "rtbPrivChat";
            this.rtbPrivChat.ReadOnly = true;
            this.rtbPrivChat.Size = new System.Drawing.Size(465, 212);
            this.rtbPrivChat.TabIndex = 0;
            this.rtbPrivChat.Text = "";
            // 
            // rtbPrivEnvia
            // 
            this.rtbPrivEnvia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbPrivEnvia.BackColor = System.Drawing.SystemColors.Window;
            this.rtbPrivEnvia.EnableAutoDragDrop = true;
            this.rtbPrivEnvia.Location = new System.Drawing.Point(186, 259);
            this.rtbPrivEnvia.Name = "rtbPrivEnvia";
            this.rtbPrivEnvia.Size = new System.Drawing.Size(373, 113);
            this.rtbPrivEnvia.TabIndex = 1;
            this.rtbPrivEnvia.Text = "";
            // 
            // btnEmo
            // 
            this.btnEmo.Location = new System.Drawing.Point(186, 230);
            this.btnEmo.Name = "btnEmo";
            this.btnEmo.Size = new System.Drawing.Size(26, 23);
            this.btnEmo.TabIndex = 3;
            this.btnEmo.UseVisualStyleBackColor = true;
            this.btnEmo.Visible = false;
            // 
            // typetxt
            // 
            this.typetxt.AutoSize = true;
            this.typetxt.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.typetxt.Location = new System.Drawing.Point(210, 381);
            this.typetxt.Name = "typetxt";
            this.typetxt.Size = new System.Drawing.Size(106, 12);
            this.typetxt.TabIndex = 5;
            this.typetxt.Text = "Fulano está digitando...";
            this.typetxt.Visible = false;
            // 
            // typePic
            // 
            this.typePic.Image = global::ChatProdan.Properties.Resources.typing20;
            this.typePic.Location = new System.Drawing.Point(186, 378);
            this.typePic.Name = "typePic";
            this.typePic.Size = new System.Drawing.Size(20, 19);
            this.typePic.TabIndex = 4;
            this.typePic.TabStop = false;
            this.typePic.Visible = false;
            // 
            // btnPrivEnvia
            // 
            this.btnPrivEnvia.Image = global::ChatProdan.Properties.Resources.send1;
            this.btnPrivEnvia.Location = new System.Drawing.Point(565, 259);
            this.btnPrivEnvia.Name = "btnPrivEnvia";
            this.btnPrivEnvia.Size = new System.Drawing.Size(86, 113);
            this.btnPrivEnvia.TabIndex = 2;
            this.btnPrivEnvia.UseVisualStyleBackColor = true;
            // 
            // pictboxReceiver
            // 
            this.pictboxReceiver.Location = new System.Drawing.Point(12, 12);
            this.pictboxReceiver.Name = "pictboxReceiver";
            this.pictboxReceiver.Size = new System.Drawing.Size(150, 150);
            this.pictboxReceiver.TabIndex = 6;
            this.pictboxReceiver.TabStop = false;
            // 
            // pictboxSender
            // 
            this.pictboxSender.Location = new System.Drawing.Point(12, 259);
            this.pictboxSender.Name = "pictboxSender";
            this.pictboxSender.Size = new System.Drawing.Size(113, 113);
            this.pictboxSender.TabIndex = 7;
            this.pictboxSender.TabStop = false;
            // 
            // FrmPrivado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(663, 409);
            this.Controls.Add(this.pictboxSender);
            this.Controls.Add(this.pictboxReceiver);
            this.Controls.Add(this.typetxt);
            this.Controls.Add(this.typePic);
            this.Controls.Add(this.btnEmo);
            this.Controls.Add(this.btnPrivEnvia);
            this.Controls.Add(this.rtbPrivEnvia);
            this.Controls.Add(this.rtbPrivChat);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrivado";
            ((System.ComponentModel.ISupportInitialize)(this.typePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictboxSender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbPrivChat;
        private System.Windows.Forms.RichTextBox rtbPrivEnvia;
        private System.Windows.Forms.Button btnPrivEnvia;
        private System.Windows.Forms.Button btnEmo;
        private System.Windows.Forms.PictureBox typePic;
        private System.Windows.Forms.Label typetxt;
        private System.Windows.Forms.PictureBox pictboxReceiver;
        private System.Windows.Forms.PictureBox pictboxSender;
    }
}