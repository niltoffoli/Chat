using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ChatProdan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool ok;
            System.Threading.Mutex m_chat = new System.Threading.Mutex(true, "ChatMutex", out ok); //cria mutex (mutual exclusion) para impedir multiplas instancias do apliacativo
            if (!ok)                                                                               //o windows registra a mutex "ChatBMutex" como sendo deste aplicativo, 
            {                                                                                      //se tentar abri-lo novamente o windows verifica que a mutex ja esta em uso.   
                MessageBox.Show("Já existre uma instância do programa em execução\n"+Application.ProductName, m_chat.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0)
            {
                Application.Run(new FrmChat(args[0]));
            }
            else
            {
                Application.Run(new FrmChat("normalstate"));
            }
            
            GC.KeepAlive(m_chat); // registra a mutex 
        }
    }
}
