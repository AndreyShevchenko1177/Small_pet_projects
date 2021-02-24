namespace FManager
{
    partial class SearchParamsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbox_params = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_match_after = new System.Windows.Forms.RadioButton();
            this.rb_same_after = new System.Windows.Forms.RadioButton();
            this.rb_same = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbox_params.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbox_params
            // 
            this.gbox_params.Controls.Add(this.numericUpDown1);
            this.gbox_params.Controls.Add(this.label1);
            this.gbox_params.Controls.Add(this.rb_match_after);
            this.gbox_params.Controls.Add(this.rb_same_after);
            this.gbox_params.Controls.Add(this.rb_same);
            this.gbox_params.Location = new System.Drawing.Point(12, 12);
            this.gbox_params.Name = "gbox_params";
            this.gbox_params.Size = new System.Drawing.Size(374, 114);
            this.gbox_params.TabIndex = 0;
            this.gbox_params.TabStop = false;
            this.gbox_params.Text = "Search Parameters";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(130, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "days after";
            // 
            // rb_match_after
            // 
            this.rb_match_after.AutoSize = true;
            this.rb_match_after.Checked = true;
            this.rb_match_after.Location = new System.Drawing.Point(17, 68);
            this.rb_match_after.Name = "rb_match_after";
            this.rb_match_after.Size = new System.Drawing.Size(277, 17);
            this.rb_match_after.TabIndex = 2;
            this.rb_match_after.TabStop = true;
            this.rb_match_after.Text = "The date of TIFF match or is later than the folder date";
            this.rb_match_after.UseVisualStyleBackColor = true;
            this.rb_match_after.Click += new System.EventHandler(this.rb_match_after_Click);
            // 
            // rb_same_after
            // 
            this.rb_same_after.AutoSize = true;
            this.rb_same_after.Location = new System.Drawing.Point(17, 44);
            this.rb_same_after.Name = "rb_same_after";
            this.rb_same_after.Size = new System.Drawing.Size(107, 17);
            this.rb_same_after.TabIndex = 1;
            this.rb_same_after.Text = "The same day or ";
            this.rb_same_after.UseVisualStyleBackColor = true;
            this.rb_same_after.Click += new System.EventHandler(this.rb_same_after_Click);
            // 
            // rb_same
            // 
            this.rb_same.AutoSize = true;
            this.rb_same.Location = new System.Drawing.Point(17, 20);
            this.rb_same.Name = "rb_same";
            this.rb_same.Size = new System.Drawing.Size(92, 17);
            this.rb_same.TabIndex = 0;
            this.rb_same.Text = "The same day";
            this.rb_same.UseVisualStyleBackColor = true;
            this.rb_same.Click += new System.EventHandler(this.rb_same_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 189);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbox_params);
            this.Name = "SearchParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose the Search Parameters";
            this.Activated += new System.EventHandler(this.SearchParamsForm_Activated);
            this.gbox_params.ResumeLayout(false);
            this.gbox_params.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbox_params;
        private System.Windows.Forms.RadioButton rb_match_after;
        private System.Windows.Forms.RadioButton rb_same_after;
        private System.Windows.Forms.RadioButton rb_same;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}