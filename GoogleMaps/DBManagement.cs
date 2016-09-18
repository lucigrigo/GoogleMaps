using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GoogleMaps
{
    class DBManagement
    {
        private string cones = Properties.Settings.Default.DBConnection;
        private SqlCommand scom=null;
        private SqlDataReader sreader=null;
        private DataTable tab=null;
        private SqlConnection sc=null;

        public DataTable Load(string tableName)
        {

            sc = new SqlConnection(cones);
            sc.Open();
            scom = new SqlCommand("SELECT * FROM " + tableName, sc);
            sreader = scom.ExecuteReader();
            tab = new DataTable();
            tab.Load(sreader);
            sc.Close();

            return tab;
        }

        public DataTable LoadSQL(string query)
        {
            sc = new SqlConnection(cones);
            sc.Open();
            scom = new SqlCommand(query,sc);
      
            // sreader = new SqlDataReader();
            sreader = scom.ExecuteReader();
            tab = new DataTable();
            tab.Load(sreader);
            sc.Close();

            return tab;
        }
    }
}
