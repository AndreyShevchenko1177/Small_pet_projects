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

    public partial class SearchParamsForm : Form
    {
        SearchParam search_param = SearchParam.SameAfter;
        bool param_selected = false;
        Int32 days_after = 0;

        public enum SearchParam { 
            Same = 1,
            SameAfter = 2, // default
            MatchAfter=3
        }

        public SearchParamsForm()
        {
            InitializeComponent();
        }

        public SearchParam Search_Param
        {
            set
            {
                search_param = value;
            }
            get {

                return search_param;
            }
        }

        public bool Param_Is_Selected
        {
            set
            {
                param_selected = value;
            }
            get
            {

                return param_selected;
            }
        }

        public Int32 Days_After
        {
            set
            {
                days_after = value;
            }
            get
            {

                return days_after;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (rb_same.Checked) {
                search_param = SearchParam.Same; // the same day
            }
            if (rb_same_after.Checked) {
                search_param = SearchParam.SameAfter;
            }
            if (rb_match_after.Checked) {
                search_param = SearchParam.MatchAfter;
            }

            days_after = (Int32)numericUpDown1.Value;

            param_selected = true;

            this.Close();


        }

        private void SearchParamsForm_Activated(object sender, EventArgs e)
        {
            param_selected = false;
            numericUpDown1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            param_selected = false;
            this.Close();
        }

        private void rb_same_after_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
        }

        private void rb_same_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
        }

        private void rb_match_after_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
        }
    }
}
