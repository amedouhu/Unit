﻿namespace Unit
{
    partial class Host
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Host));
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_host = new System.Windows.Forms.Button();
            this.lb_port = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.lb_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.Red;
            this.bt_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bt_close.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_close.FlatAppearance.BorderSize = 0;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_close.ForeColor = System.Drawing.Color.White;
            this.bt_close.Location = new System.Drawing.Point(12, 306);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(420, 27);
            this.bt_close.TabIndex = 3;
            this.bt_close.Text = "close";
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_host
            // 
            this.bt_host.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.bt_host.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_host.FlatAppearance.BorderSize = 0;
            this.bt_host.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_host.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_host.ForeColor = System.Drawing.Color.White;
            this.bt_host.Location = new System.Drawing.Point(12, 273);
            this.bt_host.Name = "bt_host";
            this.bt_host.Size = new System.Drawing.Size(420, 27);
            this.bt_host.TabIndex = 2;
            this.bt_host.Text = "host";
            this.bt_host.UseVisualStyleBackColor = false;
            this.bt_host.Click += new System.EventHandler(this.bt_host_Click);
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_port.ForeColor = System.Drawing.Color.White;
            this.lb_port.Location = new System.Drawing.Point(12, 9);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(29, 15);
            this.lb_port.TabIndex = 0;
            this.lb_port.Text = "port";
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.tb_port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_port.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_port.ForeColor = System.Drawing.Color.White;
            this.tb_port.Location = new System.Drawing.Point(12, 27);
            this.tb_port.MaxLength = 5;
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(420, 27);
            this.tb_port.TabIndex = 1;
            // 
            // lb_error
            // 
            this.lb_error.AutoSize = true;
            this.lb_error.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_error.ForeColor = System.Drawing.Color.Red;
            this.lb_error.Location = new System.Drawing.Point(12, 255);
            this.lb_error.Name = "lb_error";
            this.lb_error.Size = new System.Drawing.Size(0, 15);
            this.lb_error.TabIndex = 4;
            // 
            // Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(444, 345);
            this.Controls.Add(this.lb_error);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_host);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.tb_port);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 384);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 384);
            this.Name = "Host";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_host;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label lb_error;
    }
}