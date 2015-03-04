using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IISWebSiteManager
{
    public partial class MainForm : Form
    {
        ServerManager iisManager = new ServerManager();//ServerManager.OpenRemote("192.168.2.192");//
        string CurrentSiteName { set; get; }
        public MainForm()
        {
            InitializeComponent();

            BindSiteAll();
            

            #region MyRegion
            //string siteName = "mydemosite";
            //ServerManager iisManager = new ServerManager();
            //SiteCollection siteCollection = iisManager.Sites;
            //var site = siteCollection.Where(x => x.Name == siteName).FirstOrDefault();
            //if (site == null)
            //{
            //    iisManager.Sites.Add(siteName, "http", "*:80:", @"D:\Android");
            //    iisManager.CommitChanges();
            //}
            //else
            //{
            //    //  MessageBox.Show("已有相同网站存在！");
            //}

            //iisManager.Sites[siteName].Stop();
            //iisManager.Sites[siteName].Start();



            ////将一个应用程序（Application）添加到一个站点
            //iisManager.Sites[siteName].Applications.Add("/blog", "d:\\blog");
            //// iisManager.CommitChanges();

            ////建立一个虚拟目录（Virtual Directory）
            //Microsoft.Web.Administration.Application app = iisManager.Sites[siteName].Applications["/blog"];
            //app.VirtualDirectories.Add("/images", "d:\\virdir");
            //iisManager.CommitChanges();

            //回收应用程序池
            // iisManager.ApplicationPools["DefaultAppPool"].Recycle();

            //得到当前正在处理的请求
            //StringBuilder str = new StringBuilder();
            //foreach (WorkerProcess w3wp in iisManager.WorkerProcesses)
            //{
            //    str.Append("W3WP  " + w3wp.ProcessId + "\n");
            //    foreach (Request request in w3wp.GetRequests(0))
            //    {
            //        str.Append(request.Url + "-" + request.ClientIPAddr + " " + request.TimeElapsed + " " + request.TimeInState + "\n");
            //    }
            //} 
            #endregion

        }



        #region ==按钮事件
        /// <summary>
        /// 停止站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_stop_Click(object sender, EventArgs e)
        {
            try
            {
                iisManager.Sites[CurrentSiteName].Stop();
                MessageBox.Show("站点已停止！");
                BindSiteAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 启动站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
            try
            {
                iisManager.Sites[CurrentSiteName].Start();
                MessageBox.Show("站点已启动！");
                BindSiteAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 移除站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_remove_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存站点设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbSitePath.Text))
                return;
            if (string.IsNullOrWhiteSpace(CurrentSiteName))
            {
                MessageBox.Show("请选择要设置的站点！");
                return;
            }

            try
            {
                var binding=iisManager.Sites[CurrentSiteName].Bindings[0];
                
                VirtualDirectory virDir = iisManager.Sites[CurrentSiteName].Applications[0].VirtualDirectories[0];
                virDir.PhysicalPath = this.tbSitePath.Text;
                iisManager.CommitChanges();
                MessageBox.Show("站点参数设置成功！");
                BindSiteAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 选择目录路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_file_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog foderDialog = new FolderBrowserDialog();
            if (foderDialog.ShowDialog() == DialogResult.OK)
            {
                tbSitePath.Text = foderDialog.SelectedPath;
            }

        }

        private void dgvSiteData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetInitTextBox();
        }
        #endregion

        #region ==公共方法
        /// <summary>
        /// 绑定IIS服务器上的所有站点
        /// </summary>
        private void BindSiteAll()
        {
            DataTable tData = new DataTable();
            
            
            tData.Columns.Add("id");
            tData.Columns.Add("name");
            tData.Columns.Add("host");
            tData.Columns.Add("state");
            tData.Columns.Add("port");
            tData.Columns.Add("protocol");
            tData.Columns.Add("pool");
            tData.Columns.Add("path");
            try
            {
                SiteCollection siteCollection = iisManager.Sites;
                foreach (Microsoft.Web.Administration.Site site in siteCollection)
                {
                    DataRow dr = tData.NewRow();
                    dr["id"] = site.Id.ToString();
                    dr["name"] = site.Name;
                    dr["host"] = site.Bindings[0].Host;
                    dr["state"] = site.State.ToString();
                    dr["path"] = site.Applications[0].VirtualDirectories[0].PhysicalPath;//获取网站物理路径
                    dr["port"] = site.Bindings[0].EndPoint;
                    dr["protocol"] = site.Bindings[0].Protocol;
                    dr["pool"] = site.Applications[0].ApplicationPoolName;

                    tData.Rows.Add(dr);
                }
                dgvSiteData.DataSource = tData;
                dgvSiteData.CellClick += dgvSiteData_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

       

        /// <summary>
        /// 设置textbox文本框初始化值
        /// </summary>
        private void SetInitTextBox()
        {
            DataGridViewRow dr = dgvSiteData.CurrentRow;
            tbSiteName.Text = CurrentSiteName = dr.Cells["SiteName"].Value.ToString();
            tbSitePath.Text =dr.Cells["PhysicalPath"].Value.ToString();
            string port = dr.Cells["Port"].Value.ToString();
            string[] arr = port.Split(':');
            tbport.Text = arr[1];
            tbipaddress.Text = arr[0];
            tbhost.Text = dr.Cells["host"].Value.ToString();
        }
        #endregion


    }

}
