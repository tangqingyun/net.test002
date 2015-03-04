namespace IISWebSiteManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSiteData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSiteName = new System.Windows.Forms.TextBox();
            this.tbSitePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_file = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.tbipaddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbhost = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhysicalPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiteData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSiteData
            // 
            this.dgvSiteData.AllowUserToAddRows = false;
            this.dgvSiteData.AllowUserToDeleteRows = false;
            this.dgvSiteData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSiteData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiteData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SiteName,
            this.host,
            this.SiteProtocol,
            this.Port,
            this.protocol,
            this.pool,
            this.PhysicalPath});
            this.dgvSiteData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvSiteData.Location = new System.Drawing.Point(12, 12);
            this.dgvSiteData.Name = "dgvSiteData";
            this.dgvSiteData.ReadOnly = true;
            this.dgvSiteData.RowTemplate.Height = 23;
            this.dgvSiteData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiteData.Size = new System.Drawing.Size(814, 160);
            this.dgvSiteData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "站点名称：";
            // 
            // tbSiteName
            // 
            this.tbSiteName.Location = new System.Drawing.Point(78, 193);
            this.tbSiteName.Name = "tbSiteName";
            this.tbSiteName.Size = new System.Drawing.Size(185, 21);
            this.tbSiteName.TabIndex = 2;
            // 
            // tbSitePath
            // 
            this.tbSitePath.Location = new System.Drawing.Point(77, 259);
            this.tbSitePath.Name = "tbSitePath";
            this.tbSitePath.Size = new System.Drawing.Size(537, 21);
            this.tbSitePath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "物理路径：";
            // 
            // button_file
            // 
            this.button_file.Location = new System.Drawing.Point(639, 257);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(75, 23);
            this.button_file.TabIndex = 5;
            this.button_file.Text = "浏览...";
            this.button_file.UseVisualStyleBackColor = true;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // button_stop
            // 
            this.button_stop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_stop.Location = new System.Drawing.Point(78, 307);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 6;
            this.button_stop.Text = "停止";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_start.Location = new System.Drawing.Point(188, 307);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "启动";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_remove
            // 
            this.button_remove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_remove.Location = new System.Drawing.Point(302, 308);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 7;
            this.button_remove.Text = "移除";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_save.Location = new System.Drawing.Point(416, 308);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 8;
            this.button_save.Text = "保存设置";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // tbipaddress
            // 
            this.tbipaddress.Location = new System.Drawing.Point(359, 193);
            this.tbipaddress.Name = "tbipaddress";
            this.tbipaddress.Size = new System.Drawing.Size(196, 21);
            this.tbipaddress.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP地址：";
            // 
            // tbport
            // 
            this.tbport.Location = new System.Drawing.Point(639, 193);
            this.tbport.Name = "tbport";
            this.tbport.Size = new System.Drawing.Size(75, 21);
            this.tbport.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "端口：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "主机名：";
            // 
            // tbhost
            // 
            this.tbhost.Location = new System.Drawing.Point(78, 223);
            this.tbhost.Name = "tbhost";
            this.tbhost.Size = new System.Drawing.Size(185, 21);
            this.tbhost.TabIndex = 14;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 50;
            // 
            // SiteName
            // 
            this.SiteName.DataPropertyName = "name";
            this.SiteName.HeaderText = "站点名称";
            this.SiteName.Name = "SiteName";
            this.SiteName.ReadOnly = true;
            // 
            // host
            // 
            this.host.DataPropertyName = "host";
            this.host.HeaderText = "主机";
            this.host.Name = "host";
            this.host.ReadOnly = true;
            // 
            // SiteProtocol
            // 
            this.SiteProtocol.DataPropertyName = "state";
            this.SiteProtocol.HeaderText = "状态";
            this.SiteProtocol.Name = "SiteProtocol";
            this.SiteProtocol.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.DataPropertyName = "port";
            this.Port.HeaderText = "IP/端口号";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            // 
            // protocol
            // 
            this.protocol.DataPropertyName = "protocol";
            this.protocol.HeaderText = "协议";
            this.protocol.Name = "protocol";
            this.protocol.ReadOnly = true;
            // 
            // pool
            // 
            this.pool.DataPropertyName = "pool";
            this.pool.HeaderText = "应用程序池";
            this.pool.Name = "pool";
            this.pool.ReadOnly = true;
            // 
            // PhysicalPath
            // 
            this.PhysicalPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PhysicalPath.DataPropertyName = "path";
            this.PhysicalPath.HeaderText = "物理路径";
            this.PhysicalPath.Name = "PhysicalPath";
            this.PhysicalPath.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 415);
            this.Controls.Add(this.tbhost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbipaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_remove);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.tbSitePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSiteName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSiteData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IIS网站管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiteData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSiteData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSiteName;
        private System.Windows.Forms.TextBox tbSitePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox tbipaddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbhost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn host;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn pool;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhysicalPath;

    }
}

