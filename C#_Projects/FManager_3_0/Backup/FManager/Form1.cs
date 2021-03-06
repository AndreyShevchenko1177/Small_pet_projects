﻿using System;
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

        

        public Form1()
        {
            InitializeComponent();
            sorter = new ColumnSorter();
            toolStripButton3.Image = Properties.Resources.Checkbox_unchecked;
        }


        private void ListDirectories() {

            path = folderBrowserDialog1.SelectedPath;
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

                    if (pdf.EndsWith(".pdf"))
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

            path2 = folderBrowserDialog2.SelectedPath;
            files = Directory.GetFiles(path2);
            listView2.Items.Clear();
            Int32 index = 0;
            listView2.SmallImageList = imageList2;
            foreach (string f in files)
            {
                f_name = Path.GetFileName(f);
                listView2.Items.Add(f_name);
                listView2.Items[index].ImageIndex = 0;
                

                // time of modification
                dt_m = File.GetLastWriteTime(f);
                listView2.Items[index].SubItems.Add(dt_m.ToString("yy.MM.dd HH:mm:ss"));

                index++;
            }
            toolStripTextBox2.Text = path2;
            toolStripTextBox2.TextBox.Width = toolStrip3.Width - 100; 
            toolStripTextBox2.ToolTipText = path2;

        }


        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (path != "")
            {
                folderBrowserDialog1.SelectedPath = path;
            }
            folderBrowserDialog1.ShowDialog();
            ListDirectories();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (path2 != "")
            {
                folderBrowserDialog2.SelectedPath = path2;
            }
            folderBrowserDialog2.ShowDialog();
            ListFiles();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter("settings.txt");
            sw.WriteLine(path);
            sw.WriteLine(path2);
            sw.WriteLine(GeometryToString(this, splitter1, listView1, listView2));
            sw.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("settings.txt"))
            {
                StreamReader sr = new StreamReader("settings.txt");
                path = sr.ReadLine();
                path2 = sr.ReadLine();
                string win_prop = sr.ReadLine();
                sr.Close();

                GeometryFromString(win_prop, this, splitter1, listView1, listView2);
                splitter1.SplitPosition = this.Width / 2;

                folderBrowserDialog1.SelectedPath = path;
                folderBrowserDialog2.SelectedPath = path2;

                if (path != "")
                {
                    ListDirectories();
                }
                if (path2 != "")
                {
                    ListFiles();
                }
            }
        }


        public static string GeometryToString(Form mainForm, Splitter mainSplitter, 
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

        public static void GeometryFromString(string thisWindowGeometry, 
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
                 curr_pdf = i_folder.SubItems[1].Text;
                 if (curr_pdf.IndexOf(".pdf") >= 0)
                 {
                     curr_pdf = curr_pdf.Substring(0, curr_pdf.IndexOf(".pdf"));

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

         private void listView2_SelectedIndexChanged(object sender, EventArgs e)
         {

         }

         private void bt_rescan_Click(object sender, EventArgs e)
         {
              ListDirectories();
              ListFiles();
         } 




    }
}
