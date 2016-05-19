namespace ChatProdan
{
    partial class FrmChat
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChat));
            this.lstUsuarios = new System.Windows.Forms.ListView();
            this.statusIcons = new System.Windows.Forms.ImageList(this.components);
            this.bandeja = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuBandeja = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponívelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ausenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ocupadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.históricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuBandeja.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Usuários";
            columnHeader1.Width = 190;
            // 
            // lstUsuarios
            // 
            this.lstUsuarios.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstUsuarios.BackColor = System.Drawing.SystemColors.Info;
            this.lstUsuarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
            this.lstUsuarios.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lstUsuarios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstUsuarios.FullRowSelect = true;
            this.lstUsuarios.GridLines = true;
            this.lstUsuarios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstUsuarios.HideSelection = false;
            this.lstUsuarios.HoverSelection = true;
            this.lstUsuarios.Location = new System.Drawing.Point(12, 47);
            this.lstUsuarios.MultiSelect = false;
            this.lstUsuarios.Name = "lstUsuarios";
            this.lstUsuarios.Size = new System.Drawing.Size(195, 430);
            this.lstUsuarios.SmallImageList = this.statusIcons;
            this.lstUsuarios.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstUsuarios.StateImageList = this.statusIcons;
            this.lstUsuarios.TabIndex = 0;
            this.lstUsuarios.TileSize = new System.Drawing.Size(168, 35);
            this.lstUsuarios.UseCompatibleStateImageBehavior = false;
            this.lstUsuarios.View = System.Windows.Forms.View.Details;
            // 
            // statusIcons
            // 
            this.statusIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("statusIcons.ImageStream")));
            this.statusIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.statusIcons.Images.SetKeyName(0, "useronline.png");
            this.statusIcons.Images.SetKeyName(1, "useraway.png");
            this.statusIcons.Images.SetKeyName(2, "userbusy.png");
            // 
            // bandeja
            // 
            this.bandeja.ContextMenuStrip = this.menuBandeja;
            this.bandeja.Icon = ((System.Drawing.Icon)(resources.GetObject("bandeja.Icon")));
            this.bandeja.Text = "Chat Prodan";
            this.bandeja.Visible = true;
            // 
            // menuBandeja
            // 
            this.menuBandeja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuBandeja.Name = "menuBandeja";
            this.menuBandeja.Size = new System.Drawing.Size(107, 48);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disponívelToolStripMenuItem,
            this.ausenteToolStripMenuItem,
            this.ocupadoToolStripMenuItem,
            this.offlineToolStripMenuItem});
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // disponívelToolStripMenuItem
            // 
            this.disponívelToolStripMenuItem.Name = "disponívelToolStripMenuItem";
            this.disponívelToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.disponívelToolStripMenuItem.Text = "Disponível";
            // 
            // ausenteToolStripMenuItem
            // 
            this.ausenteToolStripMenuItem.Name = "ausenteToolStripMenuItem";
            this.ausenteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ausenteToolStripMenuItem.Text = "Ausente";
            // 
            // ocupadoToolStripMenuItem
            // 
            this.ocupadoToolStripMenuItem.Name = "ocupadoToolStripMenuItem";
            this.ocupadoToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ocupadoToolStripMenuItem.Text = "Ocupado";
            // 
            // offlineToolStripMenuItem
            // 
            this.offlineToolStripMenuItem.Name = "offlineToolStripMenuItem";
            this.offlineToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.offlineToolStripMenuItem.Text = "Offline";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem,
            this.opçõesToolStripMenuItem,
            this.históricoToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem1});
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(123, 98);
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.Image = global::ChatProdan.Properties.Resources.user_24;
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.usuárioToolStripMenuItem.Text = "Usuário";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.Image = global::ChatProdan.Properties.Resources.config_24;
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // históricoToolStripMenuItem
            // 
            this.históricoToolStripMenuItem.Image = global::ChatProdan.Properties.Resources.hist_24;
            this.históricoToolStripMenuItem.Name = "históricoToolStripMenuItem";
            this.históricoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.históricoToolStripMenuItem.Text = "Histórico";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            this.sairToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.sairToolStripMenuItem1.Text = "Sair";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 487);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.AutoEllipsis = true;
            this.btnMenu.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Image = global::ChatProdan.Properties.Resources.menu_20;
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenu.Location = new System.Drawing.Point(175, 11);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(32, 30);
            this.btnMenu.TabIndex = 7;
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 509);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lstUsuarios);
            this.Controls.Add(this.btnMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(329, 644);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(235, 547);
            this.Name = "FrmChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Prodan";
            this.menuBandeja.ResumeLayout(false);
            this.menuPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstUsuarios;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.NotifyIcon bandeja;
        private System.Windows.Forms.ContextMenuStrip menuBandeja;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponívelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ausenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocupadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem históricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ImageList statusIcons;
    }
}

