using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ChatProdan {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    public sealed partial class Config {
        
        public Config() 
        {
            // // To add event handlers for saving and changing settings, uncomment the lines below:

            // this.SettingChanging += this.SettingChangingEventHandler;
          
            this.SettingsSaving += this.SettingsSavingEventHandler;
            
        }

        public void DefineParam()
        {
            Config.Default.StartWindows = false;
            Config.Default.StartMinimized = false;
            Config.Default.AbrirJanela = true;
            Config.Default.UserIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            Config.Default.PortaTCP = 8083;
            Config.Default.PortaUDP = 8082;
            Config.Default.Username = Environment.MachineName;
            Config.Default.GroupChat = false;
            Config.Default.HistOn = true;
            Config.Default.HistLocal = string.Format("{0}\\Historicos", Application.StartupPath);
            Config.Default.UserImg = string.Empty;
            Config.Default.ParamSetados = true;
            Config.Default.Save();
        }

        public void LeConfig()
        {

        }

        public void GravaConfig()
        {

        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
           
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.


        }
    }
}
