using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChatProdan
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario(DadosConversa MyUser, EventHandler upd)
        {
            InitializeComponent();
            _upd = upd;

            this.FormClosing += FrmUsuario_FormClosing;
            this.Activated += FrmUsuario_Activated;
            pictboxUser.Click += pictboxUser_Click;
            openFileImg.FileOk += openFileImg_FileOk;
            btnOK.Click += btnOK_Click;
            //Setar estado inicial dos controles
            txtUsername.Text = MyUser.ReceiverUSER;
            rdbOnline.Checked = MyUser.ReceiverStatus.Contains("online");
            rdbAusente.Checked = MyUser.ReceiverStatus.Contains("ausente");
            rdbOcupado.Checked = MyUser.ReceiverStatus.Contains("ocupado");
            pictboxUser.ImageLocation = Config.Default.UserImg;
        }

        void openFileImg_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                FileInfo img = new FileInfo(openFileImg.FileName);
                if (img.Extension != ".jpg")
                {
                    MessageBox.Show("Arquivo selecionado inválido. Somente permitido arquivos JPG.");
                    return;
                }
                string imgdir = string.Format("{0}\\Imagens", Application.StartupPath);
                if (!Directory.Exists(imgdir))
                {
                    Directory.CreateDirectory(imgdir);
                }
                string newfile = imgdir + "\\userimage" + img.Extension;
                img.CopyTo(newfile, true);
                pictboxUser.ImageLocation = newfile;
                Config.Default.UserImg = newfile;
                Config.Default.Save();
            }

            catch (System.IO.IOException IOexcp)
            {
                MessageBox.Show("Erro IO:\n" + IOexcp.Message);
            }
            catch (Exception excp)
            {
                MessageBox.Show("Erro:\n" + excp.Message);
            }
        }

        void pictboxUser_Click(object sender, EventArgs e)
        {
            openFileImg.ShowDialog();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            string[] dados = new string[4];
            dados[0] = txtUsername.Text;
            dados[1] = Config.Default.UserIP;
            dados[2] = Config.Default.PortaTCP.ToString();
            RadioButton checkedButton = GroupStatus.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            dados[3] = checkedButton.Tag.ToString();
            Config.Default.Username = dados[0];
            Config.Default.Save();
            if (_upd != null)
                _upd.Invoke(dados , null);
            this.Close();
        }

        #region Controle de Janela
        /// <summary>
        /// Bloqueia o form principal ao iniciar este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FrmUsuario_Activated(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }
        /// <summary>
        /// Desvloqueia o form principal ao fechar este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }
        #endregion

        EventHandler _upd = null;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
