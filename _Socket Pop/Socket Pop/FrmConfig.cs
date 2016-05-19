using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace ChatProdan
{
    public partial class FrmConfig : Form
    {
        EventHandler _Define = null;

        public FrmConfig()
        {
            InitializeComponent();
            LeConfig();
            ListaAdaptadores();
            btnGrava.Click += btnGrava_Click;
            btnRedef.Click += btnRedef_Click;
            btnCancel.Click += btnCancel_Click;
            this.Activated +=FrmConfig_Activated;
            this.FormClosing += FrmConfig_FormClosing;
            checkHist.CheckedChanged += checkHist_CheckedChanged;
            btnHistLoc.Click += btnHistLoc_Click;                   

        }

        void btnHistLoc_Click(object sender, EventArgs e)
        {
            folderHist.ShowDialog();
            txtHistLoc.Text = folderHist.SelectedPath.ToString();
        }

        void checkHist_CheckedChanged(object sender, EventArgs e)
        {
            lblHistLoc.Enabled = checkHist.Checked;
            txtHistLoc.Enabled = checkHist.Checked;
            btnHistLoc.Enabled = checkHist.Checked;
        }

        void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        void FrmConfig_Activated(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnRedef_Click(object sender, EventArgs e)
        {
            Config cfg = new Config();
            cfg.DefineParam();
            LeConfig();
        }

        void btnGrava_Click(object sender, EventArgs e)
        {
            Config.Default.StartWindows = checkWinStart.Checked;
            Config.Default.StartMinimized = checkMinimizado.Checked;

            if (rdbAbre.Checked)
            {
                Config.Default.AbrirJanela = true;
            }
            if (rdbTaskbar.Checked)
            {
                Config.Default.AbrirJanela = false;
            }
            Config.Default.UserIP = cmboxConexoes.Text;
            Config.Default.PortaTCP = Convert.ToInt32(Math.Round(numTCP.Value, 0));
            Config.Default.PortaUDP = Convert.ToInt32(Math.Round(numUDP.Value, 0));
            // Grava informações no registro para inicialização automatica
            if (checkWinStart.Checked == true && checkMinimizado.Checked == true)
            {
                try
                {
                    RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("Chat Prodan", "\"" + Application.ExecutablePath.ToString() + "\"" + " -min");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

            if (checkWinStart.Checked == true && checkMinimizado.Checked == false)
            {
                try
                {
                    RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("Chat Prodan", "\"" + Application.ExecutablePath.ToString() + "\"");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            if (checkWinStart.Checked == false)
            {
                try
                {
                    RegistryKey remove = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    remove.DeleteValue("Chat Prodan", false);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            Config.Default.HistOn = checkHist.Checked;
            if (checkHist.Checked && Directory.Exists(txtHistLoc.Text))
            {
                Config.Default.HistLocal = txtHistLoc.Text;
            }
            else
            {
                MessageBox.Show("Diretório Inválido.");
                this.configTabs.SelectedTab = tabHis;
                this.ActiveControl = txtHistLoc;
                txtHistLoc.Focus();
                return;
            }
            // end gravação registro
            Config.Default.Save();
            MessageBox.Show("Configurações Salvas.");
            this.Close();
        }

        public void LeConfig()
        {
            checkWinStart.Checked = Config.Default.StartWindows;
            checkMinimizado.Checked = Config.Default.StartMinimized;
            cmboxConexoes.Text = Config.Default.UserIP;
            numTCP.Value = Config.Default.PortaTCP;
            numUDP.Value = Config.Default.PortaUDP;
         
            if (Config.Default.AbrirJanela)
            {
                rdbAbre.Checked = true;
                rdbTaskbar.Checked = false;
            }
            else
            {
                rdbAbre.Checked = false;
                rdbTaskbar.Checked = true;
            }

            checkHist.Checked = Config.Default.HistOn;
            txtHistLoc.Text = Config.Default.HistLocal;
            lblHistLoc.Enabled = checkHist.Checked;
            txtHistLoc.Enabled = checkHist.Checked;
            btnHistLoc.Enabled = checkHist.Checked;
            
        }

        public void ListaAdaptadores()
        {
            foreach (IPAddress item in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    string value = item.ToString();
                    cmboxConexoes.Items.Add(value);
                }
               
            }

        }
     
    }
}
