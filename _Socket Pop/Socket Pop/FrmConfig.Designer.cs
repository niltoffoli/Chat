namespace ChatProdan
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.btnGrava = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmboxConexoes = new System.Windows.Forms.ComboBox();
            this.configTabs = new System.Windows.Forms.TabControl();
            this.tabGer = new System.Windows.Forms.TabPage();
            this.checkWinStart = new System.Windows.Forms.CheckBox();
            this.checkMinimizado = new System.Windows.Forms.CheckBox();
            this.tabMsg = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTaskbar = new System.Windows.Forms.RadioButton();
            this.rdbAbre = new System.Windows.Forms.RadioButton();
            this.chkGroup = new System.Windows.Forms.CheckBox();
            this.tabHis = new System.Windows.Forms.TabPage();
            this.tabCon = new System.Windows.Forms.TabPage();
            this.numUDP = new System.Windows.Forms.NumericUpDown();
            this.numTCP = new System.Windows.Forms.NumericUpDown();
            this.lbupd = new System.Windows.Forms.Label();
            this.lbtcp = new System.Windows.Forms.Label();
            this.lbip = new System.Windows.Forms.Label();
            this.btnRedef = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkHist = new System.Windows.Forms.CheckBox();
            this.lblHistLoc = new System.Windows.Forms.Label();
            this.txtHistLoc = new System.Windows.Forms.TextBox();
            this.btnHistLoc = new System.Windows.Forms.Button();
            this.folderHist = new System.Windows.Forms.FolderBrowserDialog();
            this.configTabs.SuspendLayout();
            this.tabGer.SuspendLayout();
            this.tabMsg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabHis.SuspendLayout();
            this.tabCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTCP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrava
            // 
            this.btnGrava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrava.Location = new System.Drawing.Point(330, 291);
            this.btnGrava.Name = "btnGrava";
            this.btnGrava.Size = new System.Drawing.Size(100, 32);
            this.btnGrava.TabIndex = 0;
            this.btnGrava.Text = "OK";
            this.btnGrava.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmboxConexoes
            // 
            this.cmboxConexoes.Enabled = false;
            this.cmboxConexoes.FormattingEnabled = true;
            this.cmboxConexoes.Location = new System.Drawing.Point(34, 54);
            this.cmboxConexoes.Name = "cmboxConexoes";
            this.cmboxConexoes.Size = new System.Drawing.Size(190, 21);
            this.cmboxConexoes.TabIndex = 2;
            // 
            // configTabs
            // 
            this.configTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configTabs.Controls.Add(this.tabGer);
            this.configTabs.Controls.Add(this.tabMsg);
            this.configTabs.Controls.Add(this.tabHis);
            this.configTabs.Controls.Add(this.tabCon);
            this.configTabs.ItemSize = new System.Drawing.Size(58, 18);
            this.configTabs.Location = new System.Drawing.Point(0, 0);
            this.configTabs.Name = "configTabs";
            this.configTabs.SelectedIndex = 0;
            this.configTabs.Size = new System.Drawing.Size(434, 285);
            this.configTabs.TabIndex = 6;
            // 
            // tabGer
            // 
            this.tabGer.Controls.Add(this.checkWinStart);
            this.tabGer.Controls.Add(this.checkMinimizado);
            this.tabGer.Location = new System.Drawing.Point(4, 22);
            this.tabGer.Name = "tabGer";
            this.tabGer.Padding = new System.Windows.Forms.Padding(3);
            this.tabGer.Size = new System.Drawing.Size(426, 259);
            this.tabGer.TabIndex = 0;
            this.tabGer.Text = "Gerais";
            this.tabGer.UseVisualStyleBackColor = true;
            // 
            // checkWinStart
            // 
            this.checkWinStart.AutoSize = true;
            this.checkWinStart.Location = new System.Drawing.Point(31, 38);
            this.checkWinStart.Name = "checkWinStart";
            this.checkWinStart.Size = new System.Drawing.Size(143, 17);
            this.checkWinStart.TabIndex = 3;
            this.checkWinStart.Text = "Iniciar com o Windows";
            this.checkWinStart.UseVisualStyleBackColor = true;
            // 
            // checkMinimizado
            // 
            this.checkMinimizado.AutoSize = true;
            this.checkMinimizado.Location = new System.Drawing.Point(31, 67);
            this.checkMinimizado.Name = "checkMinimizado";
            this.checkMinimizado.Size = new System.Drawing.Size(120, 17);
            this.checkMinimizado.TabIndex = 4;
            this.checkMinimizado.Text = "Iniciar Minimizado";
            this.checkMinimizado.UseVisualStyleBackColor = true;
            // 
            // tabMsg
            // 
            this.tabMsg.Controls.Add(this.groupBox1);
            this.tabMsg.Controls.Add(this.chkGroup);
            this.tabMsg.Location = new System.Drawing.Point(4, 22);
            this.tabMsg.Name = "tabMsg";
            this.tabMsg.Size = new System.Drawing.Size(426, 259);
            this.tabMsg.TabIndex = 2;
            this.tabMsg.Text = "Mensagens";
            this.tabMsg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTaskbar);
            this.groupBox1.Controls.Add(this.rdbAbre);
            this.groupBox1.Location = new System.Drawing.Point(31, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 77);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ação ao receber nova mensagem";
            // 
            // rdbTaskbar
            // 
            this.rdbTaskbar.AutoSize = true;
            this.rdbTaskbar.Location = new System.Drawing.Point(13, 44);
            this.rdbTaskbar.Name = "rdbTaskbar";
            this.rdbTaskbar.Size = new System.Drawing.Size(259, 17);
            this.rdbTaskbar.TabIndex = 10;
            this.rdbTaskbar.TabStop = true;
            this.rdbTaskbar.Text = "Manter novas mensagens na barra de tarefas.";
            this.rdbTaskbar.UseVisualStyleBackColor = true;
            // 
            // rdbAbre
            // 
            this.rdbAbre.AutoSize = true;
            this.rdbAbre.Location = new System.Drawing.Point(13, 21);
            this.rdbAbre.Name = "rdbAbre";
            this.rdbAbre.Size = new System.Drawing.Size(239, 17);
            this.rdbAbre.TabIndex = 9;
            this.rdbAbre.TabStop = true;
            this.rdbAbre.Text = "Abrir novas mensagens automaticamente.";
            this.rdbAbre.UseVisualStyleBackColor = true;
            // 
            // chkGroup
            // 
            this.chkGroup.AutoSize = true;
            this.chkGroup.Location = new System.Drawing.Point(31, 38);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(195, 17);
            this.chkGroup.TabIndex = 11;
            this.chkGroup.Text = "Agrupar mensagens por usuário.";
            this.chkGroup.UseVisualStyleBackColor = true;
            // 
            // tabHis
            // 
            this.tabHis.Controls.Add(this.btnHistLoc);
            this.tabHis.Controls.Add(this.txtHistLoc);
            this.tabHis.Controls.Add(this.lblHistLoc);
            this.tabHis.Controls.Add(this.checkHist);
            this.tabHis.Location = new System.Drawing.Point(4, 22);
            this.tabHis.Name = "tabHis";
            this.tabHis.Size = new System.Drawing.Size(426, 259);
            this.tabHis.TabIndex = 3;
            this.tabHis.Text = "Históricos";
            this.tabHis.UseVisualStyleBackColor = true;
            // 
            // tabCon
            // 
            this.tabCon.Controls.Add(this.numUDP);
            this.tabCon.Controls.Add(this.numTCP);
            this.tabCon.Controls.Add(this.lbupd);
            this.tabCon.Controls.Add(this.lbtcp);
            this.tabCon.Controls.Add(this.lbip);
            this.tabCon.Controls.Add(this.cmboxConexoes);
            this.tabCon.Location = new System.Drawing.Point(4, 22);
            this.tabCon.Name = "tabCon";
            this.tabCon.Padding = new System.Windows.Forms.Padding(3);
            this.tabCon.Size = new System.Drawing.Size(426, 259);
            this.tabCon.TabIndex = 1;
            this.tabCon.Text = "Conexões";
            this.tabCon.UseVisualStyleBackColor = true;
            // 
            // numUDP
            // 
            this.numUDP.Enabled = false;
            this.numUDP.Location = new System.Drawing.Point(34, 178);
            this.numUDP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numUDP.Name = "numUDP";
            this.numUDP.Size = new System.Drawing.Size(95, 22);
            this.numUDP.TabIndex = 9;
            // 
            // numTCP
            // 
            this.numTCP.Enabled = false;
            this.numTCP.Location = new System.Drawing.Point(34, 120);
            this.numTCP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numTCP.Name = "numTCP";
            this.numTCP.Size = new System.Drawing.Size(95, 22);
            this.numTCP.TabIndex = 8;
            // 
            // lbupd
            // 
            this.lbupd.AutoSize = true;
            this.lbupd.Location = new System.Drawing.Point(31, 162);
            this.lbupd.Name = "lbupd";
            this.lbupd.Size = new System.Drawing.Size(192, 13);
            this.lbupd.TabIndex = 5;
            this.lbupd.Text = "Porta para envio de Broadcast (UDP)";
            // 
            // lbtcp
            // 
            this.lbtcp.AutoSize = true;
            this.lbtcp.Location = new System.Drawing.Point(31, 104);
            this.lbtcp.Name = "lbtcp";
            this.lbtcp.Size = new System.Drawing.Size(196, 13);
            this.lbtcp.TabIndex = 4;
            this.lbtcp.Text = "Porta para envio de Mensagens (TCP)";
            // 
            // lbip
            // 
            this.lbip.AutoSize = true;
            this.lbip.Location = new System.Drawing.Point(31, 38);
            this.lbip.Name = "lbip";
            this.lbip.Size = new System.Drawing.Size(46, 13);
            this.lbip.TabIndex = 3;
            this.lbip.Text = "IP Atual";
            // 
            // btnRedef
            // 
            this.btnRedef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRedef.Location = new System.Drawing.Point(4, 291);
            this.btnRedef.Name = "btnRedef";
            this.btnRedef.Size = new System.Drawing.Size(100, 32);
            this.btnRedef.TabIndex = 7;
            this.btnRedef.Text = "Redefinir";
            this.btnRedef.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(222, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Aplicar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkHist
            // 
            this.checkHist.AutoSize = true;
            this.checkHist.Location = new System.Drawing.Point(31, 38);
            this.checkHist.Name = "checkHist";
            this.checkHist.Size = new System.Drawing.Size(113, 17);
            this.checkHist.TabIndex = 0;
            this.checkHist.Text = "Gravar Históricos";
            this.checkHist.UseVisualStyleBackColor = true;
            // 
            // lblHistLoc
            // 
            this.lblHistLoc.AutoSize = true;
            this.lblHistLoc.Location = new System.Drawing.Point(28, 68);
            this.lblHistLoc.Name = "lblHistLoc";
            this.lblHistLoc.Size = new System.Drawing.Size(65, 13);
            this.lblHistLoc.TabIndex = 1;
            this.lblHistLoc.Text = "Localização";
            // 
            // txtHistLoc
            // 
            this.txtHistLoc.Location = new System.Drawing.Point(31, 84);
            this.txtHistLoc.Name = "txtHistLoc";
            this.txtHistLoc.Size = new System.Drawing.Size(214, 22);
            this.txtHistLoc.TabIndex = 2;
            // 
            // btnHistLoc
            // 
            this.btnHistLoc.Image = global::ChatProdan.Properties.Resources.browse;
            this.btnHistLoc.Location = new System.Drawing.Point(251, 84);
            this.btnHistLoc.Name = "btnHistLoc";
            this.btnHistLoc.Size = new System.Drawing.Size(22, 22);
            this.btnHistLoc.TabIndex = 3;
            this.btnHistLoc.UseVisualStyleBackColor = true;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 335);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRedef);
            this.Controls.Add(this.configTabs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGrava);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opções";
            this.configTabs.ResumeLayout(false);
            this.tabGer.ResumeLayout(false);
            this.tabGer.PerformLayout();
            this.tabMsg.ResumeLayout(false);
            this.tabMsg.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabHis.ResumeLayout(false);
            this.tabHis.PerformLayout();
            this.tabCon.ResumeLayout(false);
            this.tabCon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTCP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGrava;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmboxConexoes;
        private System.Windows.Forms.TabControl configTabs;
        private System.Windows.Forms.TabPage tabGer;
        private System.Windows.Forms.TabPage tabCon;
        private System.Windows.Forms.Button btnRedef;
        private System.Windows.Forms.CheckBox checkWinStart;
        private System.Windows.Forms.CheckBox checkMinimizado;
        private System.Windows.Forms.Label lbip;
        private System.Windows.Forms.Label lbupd;
        private System.Windows.Forms.Label lbtcp;
        private System.Windows.Forms.NumericUpDown numUDP;
        private System.Windows.Forms.NumericUpDown numTCP;
        private System.Windows.Forms.TabPage tabMsg;
        private System.Windows.Forms.RadioButton rdbTaskbar;
        private System.Windows.Forms.RadioButton rdbAbre;
        private System.Windows.Forms.TabPage tabHis;
        private System.Windows.Forms.CheckBox chkGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHistLoc;
        private System.Windows.Forms.TextBox txtHistLoc;
        private System.Windows.Forms.Label lblHistLoc;
        private System.Windows.Forms.CheckBox checkHist;
        private System.Windows.Forms.FolderBrowserDialog folderHist;
    }
}