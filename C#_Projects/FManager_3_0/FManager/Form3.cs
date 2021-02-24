using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FManager
{


    public partial class Form3 : Form
    {

        TrueFlowSettings settings;
        Form1 form1;

        public Form3(Form1 fm, TrueFlowSettings st)
        {
            InitializeComponent();
            settings = st;
            form1 = fm;
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            settings = null;
            this.Close();           
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {

            if (tbx_name.Text == "") {
                MessageBox.Show("   Please, specify the settings name!");
                return;
            }
            if (tbx_left_path.Text == "")
            {
                MessageBox.Show("   Please, specify the jobs path!");
                return;
            }
            if (tbx_right_path.Text == "")
            {
                MessageBox.Show("   Please, specify the tiffs path!");
                return;
            }
            settings.SettingsName = tbx_name.Text;
            settings.LeftPath = tbx_left_path.Text;
            settings.RightPath = tbx_right_path.Text;

            this.Close();
        }

        private void bt_left_path_Click(object sender, EventArgs e)
        {
            folderBrowserDialog3_1.SelectedPath = settings.LeftPath;
            folderBrowserDialog3_1.ShowDialog();
            tbx_left_path.Text = folderBrowserDialog3_1.SelectedPath;
        }

        private void bt_right_path_Click(object sender, EventArgs e)
        {
            folderBrowserDialog3_2.SelectedPath = settings.RightPath;
            folderBrowserDialog3_2.ShowDialog();
            tbx_right_path.Text = folderBrowserDialog3_2.SelectedPath;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (settings != null)
            {
                tbx_name.Text = settings.SettingsName;
                tbx_left_path.Text = settings.LeftPath;
                tbx_right_path.Text = settings.RightPath;
            }
            else {
                MessageBox.Show("   There is no settings to display!");
            }
        }


    }
}
