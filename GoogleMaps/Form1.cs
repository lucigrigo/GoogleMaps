using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace GoogleMaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void LoadData()
        {
            DataTable dt = new DBManagement().LoadSQL("SELECT * FROM Countries");

            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode(dr["Name"].ToString());
                string query = "SELECT c.Name FROM cities c JOIN countries co ON co.Id=c.Country_ID WHERE co.Name='" + dr["Name"] + "'";
                DataTable dt1 = new DBManagement().LoadSQL(query);
                foreach (DataRow dr1 in dt1.Rows)
                {
                    tn.Nodes.Add(new TreeNode(dr1["Name"].ToString()));

                }
                treeView1.Nodes.Add(tn);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            webBrowser1.Url = new Uri("https://www.google.ro/search?q=bmw+m4&source=lnms&tbm=isch&sa=X&ved=0ahUKEwj_uZjNx5jPAhWBORoKHQEaDjEQ_AUICCgB&biw=1366&bih=667");
        }
    }
}
