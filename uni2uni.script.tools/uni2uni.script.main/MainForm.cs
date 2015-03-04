using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uni2uni.script.bll;
using uni2uni.script.main.common;
using uni2uni.script.model;

namespace uni2uni.script.main
{
    public partial class MainForm : Form
    {
        private readonly DatabaseService dbService = new DatabaseService();
        private readonly TableService tableService;
        public MainForm()
        {
            InitializeComponent();
            BindLeftTree();
            //tableService = new TableService("uni2uni_order");
           // DataTable dt = tableService.GetQueryData("SELECT  RelatedID,OrderID,Productname FROM dbo.GeneralOrder ");
            AnalyzeSQL(@"SELECT RelatedID,OrderID,Productname,DeliveryCosts FROM uni2uni_order.dbo.GeneralOrder WHERE RelatedID IN('21099000053','21099000259')");

            //IList<Column> columnList=dbService.GetTableColumnPropyte("GeneralOrder");
            //
            string content=CreateInvokeContent(@"uni2uni.script.main.template.sqltemplate");
            //textContent.Text = content;
           
        }

        private void BindLeftTree()
        {
            IList<DataBase> databaseList=dbService.GetDatabase();
            foreach (var item in databaseList)
            {
                TreeNode node = new TreeNode(item.Name);
                try
                {
                    LoadTables(node, item.Name);
                }
                catch (Exception)
                {
                    continue;
                }
               
                leftTree.Nodes.Add(node);
            }
          
        }

        private void LoadTables(TreeNode node,string dbName)
        {
            IList<Table> tables = dbService.GetAllTables(dbName);
            foreach (var item in tables)
            {
                TreeNode tNode = new TreeNode(item.TableName);
                node.Nodes.Add(tNode);
            }
        }

        private string CreateInvokeContent(string assembPath)
        {
            try
            {
                Type type = Type.GetType(assembPath);
                MethodInfo mthod = type.GetMethod("TransformText");
                object csObj = System.Activator.CreateInstance(type);
                string content = mthod.Invoke(csObj, null).ToString();
                return content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }

        }

        private void AnalyzeSQL(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return;
            sql = sql.Trim();
            SysCommon.StrSql = sql;
            int index=sql.IndexOf("FROM");
            if (index<0) {
                index = sql.IndexOf("from");
            }
            int windex= sql.IndexOf("WHERE");
            string strwhere= sql.Substring(windex);
            sql = sql.Replace(strwhere, "");
            string str = sql.Substring(index+4);
            if (string.IsNullOrWhiteSpace(str))
                return;
            string[] arr = str.Split('.');
            SysCommon.Database = arr[0].Trim();
            SysCommon.TableName = arr[2].Trim();

            string txt = sql.Replace(str, "").Replace("SELECT","").Replace("select","").Replace("FROM","").Replace("from","");
            if (string.IsNullOrWhiteSpace(txt))
                return;
           string[] arrField = txt.Split(',');
           SysCommon.Fields = arrField;
           //for (int i = 0; i < arrField.Length; i++)
           //{ 
           //}
          
        }

    }
}
