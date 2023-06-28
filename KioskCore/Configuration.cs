using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KioskCore;

namespace KioskCore
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
            FillSettings();
        }

        public void FillSettings()
        {
            if (KioskCoreTaskTray.processPath != null)
            {
                browseLabel.Text = KioskCoreTaskTray.processPath;
                reopenCheckBox.Checked = KioskCoreTaskTray.reopenProgram;
                logCheckBox.Checked = KioskCoreTaskTray.saveLog;
                ctrlEscCheckBox.Checked = KioskCoreTaskTray.ctrlEscBlock;
                taskbarCheckBox.Checked = KioskCoreTaskTray.hideTaskBar;
                bringForwardCheckBox.Checked = KioskCoreTaskTray.bringFront;
                hourComboBox.Text = KioskCoreTaskTray.closeHour.ToString();
                minuteComboBox.Text = KioskCoreTaskTray.closeMinute.ToString();
                intervalComboBox.Text = KioskCoreTaskTray.controlInterval.ToString();
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "Executable File |*.exe",
                Title = "Select the program you want to run."
            };
            file.ShowDialog();

            KioskCoreTaskTray.processPath = file.FileName;
            browseLabel.Text = file.FileName;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidityControl())
                {
                    if (File.Exists(KioskCoreTaskTray.settingsPath))
                    {
                        File.Delete(KioskCoreTaskTray.settingsPath);
                    }

                    using (StreamWriter file = File.CreateText(KioskCoreTaskTray.settingsPath))
                    {
                        file.WriteLine(browseLabel.Text);
                        file.WriteLine(hourComboBox.SelectedItem);
                        file.WriteLine(minuteComboBox.SelectedItem);
                        file.WriteLine(intervalComboBox.SelectedItem);
                        file.WriteLine(reopenCheckBox.Checked ? "1" : "0");
                        file.WriteLine(logCheckBox.Checked ? "1" : "0");
                        file.WriteLine(ctrlEscCheckBox.Checked ? "1" : "0");
                        file.WriteLine(taskbarCheckBox.Checked ? "1" : "0");
                        file.WriteLine(bringForwardCheckBox.Checked ? "1" : "0");
                        file.Close();
                    }
                    KioskCoreTaskTray.closeHour = Convert.ToInt16(hourComboBox.SelectedItem);
                    KioskCoreTaskTray.closeMinute = Convert.ToInt16(minuteComboBox.SelectedItem);
                    KioskCoreTaskTray.controlInterval = Convert.ToInt16(intervalComboBox.SelectedItem);
                    KioskCoreTaskTray.reopenProgram = reopenCheckBox.Checked;
                    KioskCoreTaskTray.saveLog = logCheckBox.Checked;
                    KioskCoreTaskTray.ctrlEscBlock = ctrlEscCheckBox.Checked;
                    KioskCoreTaskTray.hideTaskBar = taskbarCheckBox.Checked;
                    KioskCoreTaskTray.bringFront = bringForwardCheckBox.Checked;

                    FillSettings();
                    KioskCoreTaskTray.newSettings = true;
                    MessageBox.Show("Settings saved.");
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("There is an error- " + Ex.Message);
            }
        }

        bool ValidityControl()
        {
            if (browseLabel.Text == "Select the program you want to run." ||
                hourComboBox.SelectedItem == null ||
                minuteComboBox.SelectedItem == null ||
                intervalComboBox.SelectedItem == null)
            {
                return false;
            }
            else
                return true;

        }
    }
}
