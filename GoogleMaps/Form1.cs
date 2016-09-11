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
            DataTable dt = new DBManagement().Load("Countries");

            foreach(DataRow dr in dt.Rows)
            {
                treeView1.Nodes.Add(new TreeNode(dr["Name"].ToString()));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
