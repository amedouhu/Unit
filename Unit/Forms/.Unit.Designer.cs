namespace Unit
{
    partial class Unit
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Unit));
            this.pl_side = new System.Windows.Forms.Panel();
            this.bt_host = new System.Windows.Forms.Button();
            this.bt_connect = new System.Windows.Forms.Button();
            this.lb_unit = new System.Windows.Forms.Label();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.tb_chat = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.pl_position = new System.Windows.Forms.Panel();
            this.lb_position = new System.Windows.Forms.Label();
            this.pl_side.SuspendLayout();
            this.pl_position.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_side
            // 
            this.pl_side.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pl_side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.pl_side.Controls.Add(this.bt_host);
            this.pl_side.Controls.Add(this.bt_connect);
            this.pl_side.Controls.Add(this.lb_unit);
            this.pl_side.Location = new System.Drawing.Point(0, -1);
            this.pl_side.Name = "pl_side";
            this.pl_side.Size = new System.Drawing.Size(169, 451);
            this.pl_side.TabIndex = 0;
            // 
            // bt_host
            // 
            this.bt_host.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.bt_host.FlatAppearance.BorderSize = 0;
            this.bt_host.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.bt_host.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_host.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_host.ForeColor = System.Drawing.Color.White;
            this.bt_host.Location = new System.Drawing.Point(16, 411);
            this.bt_host.Name = "bt_host";
            this.bt_host.Size = new System.Drawing.Size(142, 27);
            this.bt_host.TabIndex = 2;
            this.bt_host.Text = "host";
            this.bt_host.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_host.UseVisualStyleBackColor = false;
            this.bt_host.Click += new System.EventHandler(this.bt_host_Click);
            // 
            // bt_connect
            // 
            this.bt_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.bt_connect.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_connect.FlatAppearance.BorderSize = 0;
            this.bt_connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.bt_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_connect.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_connect.ForeColor = System.Drawing.Color.White;
            this.bt_connect.Location = new System.Drawing.Point(16, 378);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(142, 27);
            this.bt_connect.TabIndex = 1;
            this.bt_connect.Text = "connect";
            this.bt_connect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_connect.UseVisualStyleBackColor = false;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // lb_unit
            // 
            this.lb_unit.AutoSize = true;
            this.lb_unit.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.lb_unit.Location = new System.Drawing.Point(12, 13);
            this.lb_unit.Name = "lb_unit";
            this.lb_unit.Size = new System.Drawing.Size(38, 20);
            this.lb_unit.TabIndex = 0;
            this.lb_unit.Text = "Unit";
            // 
            // tb_message
            // 
            this.tb_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.tb_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_message.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_message.ForeColor = System.Drawing.Color.White;
            this.tb_message.Location = new System.Drawing.Point(175, 411);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(430, 27);
            this.tb_message.TabIndex = 3;
            // 
            // tb_chat
            // 
            this.tb_chat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.tb_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_chat.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_chat.ForeColor = System.Drawing.Color.White;
            this.tb_chat.Location = new System.Drawing.Point(175, 38);
            this.tb_chat.MaxLength = 0;
            this.tb_chat.Multiline = true;
            this.tb_chat.Name = "tb_chat";
            this.tb_chat.ReadOnly = true;
            this.tb_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_chat.Size = new System.Drawing.Size(521, 367);
            this.tb_chat.TabIndex = 2;
            this.tb_chat.Text = "Started unit.";
            // 
            // bt_send
            // 
            this.bt_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.bt_send.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_send.FlatAppearance.BorderSize = 0;
            this.bt_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_send.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_send.ForeColor = System.Drawing.Color.White;
            this.bt_send.Location = new System.Drawing.Point(611, 411);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(85, 27);
            this.bt_send.TabIndex = 4;
            this.bt_send.Text = "send";
            this.bt_send.UseVisualStyleBackColor = false;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // pl_position
            // 
            this.pl_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_position.BackColor = System.Drawing.Color.Red;
            this.pl_position.Controls.Add(this.lb_position);
            this.pl_position.Location = new System.Drawing.Point(167, -1);
            this.pl_position.Name = "pl_position";
            this.pl_position.Size = new System.Drawing.Size(542, 33);
            this.pl_position.TabIndex = 5;
            // 
            // lb_position
            // 
            this.lb_position.AutoSize = true;
            this.lb_position.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_position.ForeColor = System.Drawing.Color.White;
            this.lb_position.Location = new System.Drawing.Point(4, 5);
            this.lb_position.Name = "lb_position";
            this.lb_position.Size = new System.Drawing.Size(64, 20);
            this.lb_position.TabIndex = 6;
            this.lb_position.Text = "@Home";
            // 
            // Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.pl_position);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tb_chat);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.pl_side);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(724, 489);
            this.Name = "Unit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit";
            this.Resize += new System.EventHandler(this.Unit_Resize);
            this.pl_side.ResumeLayout(false);
            this.pl_side.PerformLayout();
            this.pl_position.ResumeLayout(false);
            this.pl_position.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pl_side;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.Label lb_unit;
        private System.Windows.Forms.TextBox tb_chat;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_host;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Panel pl_position;
        private System.Windows.Forms.Label lb_position;
    }
}

