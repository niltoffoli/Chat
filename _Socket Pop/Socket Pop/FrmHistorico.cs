using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ChatProdan
{
    public partial class FrmHistorico : Form
    {
        public FrmHistorico()
        {
            InitializeComponent();
            lstHistorico.ItemActivate += lstHistorico_ItemActivate;
            ListaArquivos();            
        }

        public void ListaArquivos()
        {
            try
            {
                lstHistorico.Items.Clear();

                string folder = string.Format("{0}\\Historicos", Application.UserAppDataPath);
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    ListViewItem item = new ListViewItem(fileName);
                    item.Tag = file;
                    lstHistorico.Items.Add(item);
                }
            }
            catch (System.IO.IOException IOexcp) { }
            catch (System.Xml.XmlException XMLexcp) { }
        }

        void lstHistorico_ItemActivate(object sender, EventArgs e)
        {
            rtbHistorico.Clear();
            CarregaHistorico();
            //LeHistorico();
        }

        private void CarregaHistorico()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(lstHistorico.SelectedItems[0].Tag.ToString());
                XmlNodeList nodes = document.SelectNodes("/root/DADOS_MENSAGEM");
                DateTime oldDate = DateTime.MinValue;
                foreach (XmlNode item in nodes)
                {
                    XmlNode node = item.SelectSingleNode("SenderUser");
                    string sender = node != null ? node.InnerText : "";
                    node = item.SelectSingleNode("Hora");
                    string hora = node != null ? node.InnerText : "";
                    node = item.SelectSingleNode("Mensagem");
                    string mensagem = node != null ? node.InnerText : "";
                    node = item.SelectSingleNode("Data");
                    string data = node != null ? node.InnerText : "";
                    DateTime date = Convert.ToDateTime(data);
                    if (!date.Equals(oldDate))
                    {
                        oldDate = date;
                        rtbHistorico.AppendText(string.Format("--------------------- {0} --------------------{1}", oldDate, Environment.NewLine));
                    }
                    rtbHistorico.AppendText(string.Format("{0} {1}: {2} {3}", hora, sender, mensagem.Trim(), Environment.NewLine));
                }
            }
            catch (Exception excp) { }
        }
    
    }
}
