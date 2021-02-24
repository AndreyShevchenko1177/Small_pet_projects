using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;




namespace FManager
{


     public partial class Form1 : Form
    {
        public string path = "";
        public string path2 = "";
        public string[] subdirs;
        public string[] files;
        public DirectoryInfo[] subdirs_info;
        public FileInfo[] files_info;
        ColumnSorter sorter;
        public static bool b_need_sort = false;
         
        public List<TrueFlowSettings> SettingsList;




        public Form1()
        {
            InitializeComponent();
            sorter = new ColumnSorter();
            toolStripButton3.Image = Properties.Resources.Checkbox_unchecked;
            SettingsList = new List<TrueFlowSettings>();
        }


        private void ListDirectories() {

            //path = folderBrowserDialog1.SelectedPath;
            subdirs = Directory.GetDirectories(path);
            b_need_sort = false;
            
            listView1.Items.Clear();
            Int32 index = 0;
            DateTime dt_mod;
            string dir_name;
            listView1.SmallImageList = imageList1;

            foreach (string dir in subdirs)
            {
                string[] file;

                dir_name = Path.GetFileName(dir);
                listView1.Items.Add(dir_name);
                listView1.Items[index].ImageIndex = 0;

                // list pdf files
                if (!(dir.EndsWith("System Volume Information")))
                {
                    if (Directory.Exists(dir + "\\Documents\\RUNLIST-0"))
                    {
                        file = Directory.GetFiles(dir + "\\Documents\\RUNLIST-0");
                    }
                    else { file = new string[] { "" }; }
                }
                else break;
                bool b = false;
                string pdf;
                foreach (string pdf1 in file)
                {
                    
                    pdf = Path.GetFileName(pdf1);

                    if (pdf.ToUpper().EndsWith(".PDF") || pdf.ToUpper().EndsWith(".PS"))
                    {
                        listView1.Items[index].SubItems.Add(pdf);
                        b = true;
                        break;
                    }
                 }
                if (!b) {
                    listView1.Items[index].SubItems.Add("");
                    b = false;
                }

                // time of modification
                dt_mod = Directory.GetLastWriteTime(dir);
                listView1.Items[index].SubItems.Add(dt_mod.ToString("yy.MM.dd HH:mm:ss"));
                
                index++;
            }

            toolStripTextBox1.Text = path;
            toolStripTextBox1.ToolTipText = path;
            toolStripTextBox1.TextBox.Width = toolStrip2.Width - 50; 
            
        }

        private void ListFiles()
        {
            DateTime dt_m;
            string f_name;
            b_need_sort = false;

            //path2 = folderBrowserDialog2.SelectedPath;
            files = Directory.GetFiles(path2);
            listView2.Items.Clear();
            Int32 index = 0;
            listView2.SmallImageList = imageList2;
            foreach (string f in files)
            {
                f_name = Path.GetFileName(f);
                if (f_name.ToUpper().IndexOf(".TIF") > 0)
                {
                    listView2.Items.Add(f_name);
                    listView2.Items[index].ImageIndex = 0;

                    // time of modification
                    dt_m = File.GetLastWriteTime(f);
                    listView2.Items[index].SubItems.Add(dt_m.ToString("yy.MM.dd HH:mm:ss"));

                    index++;
                }
            }
            toolStripTextBox2.Text = path2;
            toolStripTextBox2.TextBox.Width = toolStrip3.Width - 100; 
            toolStripTextBox2.ToolTipText = path2;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("settings.txt");
                sw.WriteLine(path);
                sw.WriteLine(path2);
                sw.WriteLine(GeometryToString(this, splitter1, listView1, listView2));
                sw.WriteLine(cbx_settings.Text);
                sw.WriteLine(SerializeSettings());
                sw.Close();
            }
            catch (Exception ex) { }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("settings.txt"))
            {

                StreamReader sr = new StreamReader("settings.txt");
                path = sr.ReadLine();
                path2 = sr.ReadLine();
                string win_prop = sr.ReadLine();
                string last_settings = sr.ReadLine();
                string fts_list = sr.ReadToEnd();
                sr.Close();


                GeometryFromString(win_prop, this, splitter1, listView1, listView2);
                splitter1.SplitPosition = this.Width / 2;

                // deserialize TrueFlowSettings list
                if (fts_list != "" && fts_list != null)
                {
                    try
                    {
                        byte[] byteArray = Encoding.Default.GetBytes(fts_list);
                        MemoryStream stream = new MemoryStream(byteArray);
                        BinaryFormatter bin = new BinaryFormatter();

                        stream.Position = 0;

                        List<TrueFlowSettings> list1 = new List<TrueFlowSettings>();

                        list1 = (List<TrueFlowSettings>)bin.Deserialize(stream);

                        SettingsList.Clear();

                        foreach (TrueFlowSettings sett in list1)
                        {
                            SettingsList.Add(sett);
                            cbx_settings.Items.Add(sett.SettingsName);
                        }

                        if (last_settings != "" && last_settings != null)
                        {
                            cbx_settings.Text = last_settings;
                        }
                    }
                    catch (Exception exc) { }
                }
                else {
                    bt_rescan.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
            } // if (File.Exists("settings.txt"))
            else {
                bt_rescan.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }


        public string GeometryToString(Form mainForm, Splitter mainSplitter, 
                                              ListView lv_left, ListView lv_right)
        {


            return mainForm.Location.X.ToString() + "|" +
                mainForm.Location.Y.ToString() + "|" +
                mainForm.Size.Width.ToString() + "|" +
                mainForm.Size.Height.ToString() + "|" +
                mainForm.WindowState.ToString()
                + "|" +
                mainSplitter.SplitPosition.ToString()
                + "|" +

                lv_left.Columns[0].Width + "|" +
                lv_left.Columns[1].Width + "|" +
                lv_left.Columns[2].Width + "|" +

                lv_right.Columns[0].Width + "|" +
                lv_right.Columns[1].Width;
        }

        private static bool GeometryIsBizarreSize(Size size)
        {
            return (size.Height <= Screen.PrimaryScreen.WorkingArea.Height &&
                size.Width <= Screen.PrimaryScreen.WorkingArea.Width);
        }

        private static bool GeometryIsBizarreLocation(Point loc, Size size)
        {
            bool locOkay;
            if (loc.X < 0 || loc.Y < 0)
            {
                locOkay = false;
            }
            else if (loc.X + size.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                locOkay = false;
            }
            else if (loc.Y + size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                locOkay = false;
            }
            else
            {
                locOkay = true;
            }
            return locOkay;
        }

        public void GeometryFromString(string thisWindowGeometry, 
                                              Form formIn, Splitter splitterIn,
                                              ListView lv_left, ListView lv_right)
        {
            if (string.IsNullOrEmpty(thisWindowGeometry) == true)
            {
                return;
            }
            string[] numbers = thisWindowGeometry.Split('|');
            string windowString = numbers[4];
            if (windowString == "Normal")
            {
                Point windowPoint = new Point(int.Parse(numbers[0]),
                    int.Parse(numbers[1]));
                Size windowSize = new Size(int.Parse(numbers[2]),
                    int.Parse(numbers[3]));

                bool locOkay = GeometryIsBizarreLocation(windowPoint, windowSize);
                bool sizeOkay = GeometryIsBizarreSize(windowSize);

                if (locOkay == true && sizeOkay == true)
                {
                    formIn.Location = windowPoint;
                    formIn.Size = windowSize;
                    formIn.StartPosition = FormStartPosition.Manual;
                    formIn.WindowState = FormWindowState.Normal;
                }
                else if (sizeOkay == true)
                {
                    formIn.Size = windowSize;
                }
            }
            else if (windowString == "Maximized")
            {
                formIn.Location = new Point(100, 100);
                formIn.StartPosition = FormStartPosition.Manual;
                formIn.WindowState = FormWindowState.Maximized;
            }

            splitterIn.SplitPosition = int.Parse(numbers[5]);

            lv_left.Columns[0].Width = int.Parse(numbers[6]);
            lv_left.Columns[1].Width = int.Parse(numbers[7]);
            lv_left.Columns[2].Width = int.Parse(numbers[8]);

            lv_right.Columns[0].Width = int.Parse(numbers[9]);
            lv_right.Columns[1].Width = int.Parse(numbers[10]);
           
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            toolStripTextBox1.TextBox.Width = toolStrip2.Width - 50;
            toolStripTextBox2.TextBox.Width = toolStrip3.Width - 100;
        }

        private void listView2_Resize(object sender, EventArgs e)
        {
            toolStripTextBox2.TextBox.Width = toolStrip3.Width - 100;
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            toolStripTextBox1.TextBox.Width = toolStrip2.Width - 50;
        }


        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.Checked)
                    item.BackColor = Color.Pink;
                else
                    item.BackColor = Color.White;
            }
        }




        public class ColumnSorter : IComparer
        {
            int currentColumn;
            bool sortAscending = true;

            public int CurrentColumn
            {
                set
                {
                    if (currentColumn == value)
                        sortAscending = !sortAscending;
                    else
                    {
                        currentColumn = value;
                        sortAscending = true;
                    }
                }
            }

            public bool AscendingOrder {
                set {
                    sortAscending = value;
                }            
            }


            public int Compare(object x, object y)
            {

                if (b_need_sort)
                {
                    string value1 = ((ListViewItem)x).SubItems[currentColumn].Text;
                    string value2 = ((ListViewItem)y).SubItems[currentColumn].Text;

                    return String.Compare(value1, value2) * (sortAscending ? 1 : -1);

                }
                return 0;

            }
            public ColumnSorter()
            {
            }
        }

         


         private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
         {

            b_need_sort = true;
            sorter.CurrentColumn = e.Column;
            listView2.ListViewItemSorter = sorter;
            listView2.Sort();

            
         }

         private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
         {
             b_need_sort = true;
             sorter.CurrentColumn = e.Column;
             listView1.ListViewItemSorter = sorter;
             listView1.Sort();
         }

         private void button2_Click(object sender, EventArgs e)
         {

             DialogResult result;
             result = MessageBox.Show("Are you sure to delete the files?", 
                      "Deleting TIFF files",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

             if (result == System.Windows.Forms.DialogResult.Yes)
             {

                 string tiff_to_del;

                 foreach (ListViewItem tiff in listView2.Items)
                 {
                     if (tiff.Checked)
                     {
                         tiff_to_del = path2 + "\\" + tiff.Text;
                         File.Delete(tiff_to_del);
                     }
                 }

                 ListFiles();
             }

         }

         private void button1_Click(object sender, EventArgs e)
         {


             SearchParamsForm fm_params = new SearchParamsForm();
             fm_params.ShowDialog();

             if (fm_params.Param_Is_Selected)
             {
                 CheckTiffs(fm_params.Search_Param, fm_params.Days_After);
             }
             
         }

         
         public void CheckTiffs(SearchParamsForm.SearchParam par, Int32 days_after){

             string curr_pdf;
             string folder_date;
             DateTime dt_folder_date;
             DateTime dt_tiff_date;

             CultureInfo culture = new CultureInfo("en-Us");
             string s = culture.DateTimeFormat.ShortDatePattern;

             toolStripProgressBar1.ProgressBar.Width = this.Width - 30;
             toolStripProgressBar1.Visible = true;
             toolStripProgressBar1.Value = 1;
             toolStripProgressBar1.Increment(0);
                     
             foreach (ListViewItem i in listView2.Items) {
                 i.Checked = true;
             }
             toolStripButton3.Image = Properties.Resources.Checkbox;

             foreach (ListViewItem i_folder in listView1.Items)
             {
                 if (i_folder.SubItems[1].Text != "")
                 {
                     curr_pdf = i_folder.SubItems[1].Text;
                 }
                 else {
                     curr_pdf = "";
                 }

                 if ((curr_pdf.ToUpper().IndexOf(".PDF") > 0) || (curr_pdf.ToUpper().IndexOf(".PS") > 0))
                 {
                     if (curr_pdf.ToUpper().IndexOf(".PDF") > 0)
                     {
                         curr_pdf = curr_pdf.Substring(0, curr_pdf.ToUpper().IndexOf(".PDF"));
                     }
                     if (curr_pdf.ToUpper().IndexOf(".PS") > 0)
                     {
                         curr_pdf = curr_pdf.Substring(0, curr_pdf.ToUpper().IndexOf(".PS"));
                     }

                     foreach (ListViewItem curr_tiff in listView2.Items)
                     {
                     if (curr_tiff.Text.StartsWith(curr_pdf))
                     {
                             
                         folder_date = i_folder.Text.Substring(2, 6);
                         // format = m/d/yyyy
                         folder_date = folder_date.Substring(2, 2) + "/" +
                                       folder_date.Substring(4, 2) + "/" +
                                       folder_date.Substring(0, 2);
                         dt_folder_date = DateTime.Parse(folder_date, culture);

                         dt_tiff_date = File.GetLastWriteTime(
                                             path2 + "\\" +
                                             curr_tiff.Text);


                         if (par == SearchParamsForm.SearchParam.Same)
                         {
                             if (dt_tiff_date.Date == dt_folder_date.Date)
                             {
                                 curr_tiff.Checked = false;
                             }
                         }                                                        

                         if (par == SearchParamsForm.SearchParam.SameAfter) {

                             if ((dt_tiff_date.Date >= dt_folder_date.Date) &&
                                 (dt_tiff_date.Date <= 
                                      (dt_folder_date.Date.AddDays(days_after))))
                             {
                                 curr_tiff.Checked = false;
                             }

                         }

                         if (par == SearchParamsForm.SearchParam.MatchAfter) {

                             if ((dt_tiff_date.Date == dt_folder_date.Date) ||
                                 (dt_tiff_date.Date >=
                                    dt_folder_date.Date))
                             {
                                 curr_tiff.Checked = false;
                             }
                         }

                     }
                     } // foreach
                 }
                 toolStripProgressBar1.Increment(1);
                 if (toolStripProgressBar1.Value >= toolStripProgressBar1.Maximum) {
                     toolStripProgressBar1.Value = 1;
                 }
             }

             toolStripProgressBar1.Increment(toolStripProgressBar1.Maximum);

             toolStripProgressBar1.Visible = false;

         } // end of CheckTiffs



         private void toolStripButton3_Click(object sender, EventArgs e)
         {
             foreach (ListViewItem i in listView2.Items)
             {
                 i.Checked = false;
             }
             toolStripButton3.Image = Properties.Resources.Checkbox_unchecked;
         }


         private void bt_rescan_Click(object sender, EventArgs e)
         {

              TrueFlowSettings curr_sett = FindSettings(cbx_settings.Text);

              path = curr_sett.LeftPath;
              path2 = curr_sett.RightPath;

              ListDirectories();
              ListFiles();
         }

         private void bt_about_Click(object sender, EventArgs e)
         {
             AboutBox1 about = new AboutBox1();
             about.ShowDialog();
         }

         private void createSettingsToolStripMenuItem_Click(object sender, EventArgs e)
         {
             TrueFlowSettings sett = new TrueFlowSettings();
            
             Form3 fm_sett = new Form3(this, sett);
             fm_sett.Text = "Create Settings";
             fm_sett.ShowDialog();

             if (sett.SettingsName != null && sett.LeftPath != null && sett.RightPath != null)
             {
                 SettingsList.Add(sett);
                 SettingsList.Reverse();


                 cbx_settings.Items.Clear();

                 foreach (TrueFlowSettings ts in SettingsList)
                 {
                     cbx_settings.Items.Add(ts.SettingsName);
                     bt_rescan.Enabled = true;
                     button1.Enabled = true;
                     button2.Enabled = true;
                 }
                 cbx_settings.Text = cbx_settings.Items[0].ToString();

             }

         }

         private void editSettingsToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (cbx_settings.Items.Count > 0 && cbx_settings.Text != "" && cbx_settings.Text != null)
             {
                 TrueFlowSettings curr_sett = FindSettings(cbx_settings.Text);
                 Form3 fm_sett = new Form3(this, curr_sett);
                 fm_sett.Text = "Edit Settings";
                 fm_sett.ShowDialog();
             }
             else {
                 MessageBox.Show("   There is no settings to edit! Please, create new settings!");             
             }

       

         }


         private void deleteSettingsToolStripMenuItem_Click(object sender, EventArgs e)
         {
             DialogResult result;
             result = MessageBox.Show("Are you sure to delete the settings " + cbx_settings.Text + "?", 
                      "Deleting settings",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 TrueFlowSettings curr_sett = FindSettings(cbx_settings.Text);
                 SettingsList.Remove(curr_sett);
                 cbx_settings.Items.Remove(cbx_settings.Text);
                 if (cbx_settings.Items.Count > 0)
                 {
                     cbx_settings.Text = cbx_settings.Items[0].ToString();
                 }
                 else
                 {
                     cbx_settings.Text = "";
                 }
             }
         }


         private string SerializeSettings()
         {
             Stream stream = new MemoryStream();
             BinaryFormatter formatter = new BinaryFormatter();
             formatter.Serialize(stream, SettingsList);

             string text = "";

             stream.Position = 0;

             StreamReader reader = new StreamReader(stream, Encoding.Default);
             text = reader.ReadToEnd();

             return text;
         }



         private TrueFlowSettings FindSettings(string settings_name)
         {

             TrueFlowSettings ret_sett = SettingsList.Find(
             delegate(TrueFlowSettings s)
             {
                 return s.SettingsName == settings_name;
             }
             );

             return ret_sett;
         }

         private void cbx_settings_SelectedIndexChanged(object sender, EventArgs e)
         {
             TrueFlowSettings curr_sett = FindSettings(cbx_settings.Text);

             path = curr_sett.LeftPath;
             path2 = curr_sett.RightPath;

             listView1.Items.Clear();
             listView2.Items.Clear();

             toolStripTextBox1.Text = path;
             toolStripTextBox1.ToolTipText = path;
             toolStripTextBox1.TextBox.Width = toolStrip2.Width - 50; 

             toolStripTextBox2.Text = path2;
             toolStripTextBox2.TextBox.Width = toolStrip3.Width - 100;
             toolStripTextBox2.ToolTipText = path2;
         }


    } // end class



     [Serializable()]
     public class TrueFlowSettings : Object
     {

         public string SettingsName;
         public string LeftPath;
         public string RightPath;

     }




}
