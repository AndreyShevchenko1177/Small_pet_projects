namespace FManager
{
    partial class Form3
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
            this.bt_ok = new System.Windows.Forms.Button();
            this.lb_name = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.tbx_left_path = new System.Windows.Forms.TextBox();
            this.tbx_right_path = new System.Windows.Forms.TextBox();
            this.lb_left_path = new System.Windows.Forms.Label();
            this.lb_right_path = new System.Windows.Forms.Label();
            this.bt_left_path = new System.Windows.Forms.Button();
            this.bt_right_path = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog3_1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog3_2 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(228, 284);
            this.bt_ok.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(101, 28);
            this.bt_ok.TabIndex = 0;
            this.bt_ok.Text = "OK";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(17, 16);
            this.lb_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(108, 17);
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "Settings Name: ";
            // 
            // tbx_name
            // 
            this.tbx_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_name.Location = new System.Drawing.Point(21, 37);
            this.tbx_name.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(409, 22);
            this.tbx_name.TabIndex = 2;
            // 
            // tbx_left_path
            // 
            this.tbx_left_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_left_path.Location = new System.Drawing.Point(60, 117);
            this.tbx_left_path.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_left_path.Name = "tbx_left_path";
            this.tbx_left_path.Size = new System.Drawing.Size(371, 22);
            this.tbx_left_path.TabIndex = 3;
            // 
            // tbx_right_path
            // 
            this.tbx_right_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_right_path.Location = new System.Drawing.Point(60, 199);
            this.tbx_right_path.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_right_path.Name = "tbx_right_path";
            this.tbx_right_path.Size = new System.Drawing.Size(371, 22);
            this.tbx_right_path.TabIndex = 4;
            // 
            // lb_left_path
            // 
            this.lb_left_path.AutoSize = true;
            this.lb_left_path.Location = new System.Drawing.Point(21, 95);
            this.lb_left_path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_left_path.Name = "lb_left_path";
            this.lb_left_path.Size = new System.Drawing.Size(79, 17);
            this.lb_left_path.TabIndex = 5;
            this.lb_left_path.Text = "Jobs Path: ";
            // 
            // lb_right_path
            // 
            this.lb_right_path.AutoSize = true;
            this.lb_right_path.Location = new System.Drawing.Point(21, 177);
            this.lb_right_path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_right_path.Name = "lb_right_path";
            this.lb_right_path.Size = new System.Drawing.Size(72, 17);
            this.lb_right_path.TabIndex = 6;
            this.lb_right_path.Text = "Tiffs Path:";
            // 
            // bt_left_path
            // 
            this.bt_left_path.AutoEllipsis = true;
            this.bt_left_path.BackgroundImage = global::FManager.Properties.Resources.folderopen;
            this.bt_left_path.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_left_path.Location = new System.Drawing.Point(21, 112);
            this.bt_left_path.Margin = new System.Windows.Forms.Padding(4);
            this.bt_left_path.Name = "bt_left_path";
            this.bt_left_path.Size = new System.Drawing.Size(31, 28);
            this.bt_left_path.TabIndex = 7;
            this.bt_left_path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_left_path.UseVisualStyleBackColor = true;
            this.bt_left_path.Click += new System.EventHandler(this.bt_left_path_Click);
            // 
            // bt_right_path
            // 
            this.bt_right_path.AutoEllipsis = true;
            this.bt_right_path.BackgroundImage = global::FManager.Properties.Resources.folderopen;
            this.bt_right_path.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_right_path.Location = new System.Drawing.Point(21, 196);
            this.bt_right_path.Margin = new System.Windows.Forms.Padding(4);
            this.bt_right_path.Name = "bt_right_path";
            this.bt_right_path.Size = new System.Drawing.Size(31, 28);
            this.bt_right_path.TabIndex = 8;
            this.bt_right_path.UseVisualStyleBackColor = true;
            this.bt_right_path.Click += new System.EventHandler(this.bt_right_path_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(341, 284);
            this.bt_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(100, 28);
            this.bt_cancel.TabIndex = 9;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 327);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_right_path);
            this.Controls.Add(this.bt_left_path);
            this.Controls.Add(this.lb_right_path);
            this.Controls.Add(this.lb_left_path);
            this.Controls.Add(this.tbx_right_path);
            this.Controls.Add(this.tbx_left_path);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.bt_ok);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Settings ";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.TextBox tbx_left_path;
        private System.Windows.Forms.TextBox tbx_right_path;
        private System.Windows.Forms.Label lb_left_path;
        private System.Windows.Forms.Label lb_right_path;
        private System.Windows.Forms.Button bt_left_path;
        private System.Windows.Forms.Button bt_right_path;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3_1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog3_2;
    }
}