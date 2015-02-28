using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.ManagedDataAccess.Types;

namespace TeamChallenge2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowButton_Click(new object(), new EventArgs());
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            DataView1.Rows.Clear();
            string oradb = "User Id=kpell3;Password=oracle;Data Source=(DESCRIPTION=" +
                "(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.uis.edu)(PORT=1521))" +
                "(CONNECT_DATA=(SID=oracle)));";
            OracleConnection myconnection = new OracleConnection(oradb);
            myconnection.Open();
            OracleCommand mycommand = myconnection.CreateCommand();
            mycommand.CommandText = "SELECT * FROM Team5Members";
            mycommand.CommandType = CommandType.Text;
            OracleDataReader dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                Object[] Values = new Object[dr.FieldCount];
                int numColumns = dr.GetValues(Values);
                DataView1.Rows.Add(Values);
            }
            myconnection.Dispose();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < DataView1.Rows.Count; ++x)
            {
                if ( !DBNull.Value.Equals(DataView1.Rows[x].Cells[0].Value) && Convert.ToBoolean(DataView1.Rows[x].Cells[0].Value))
                {
                    string oradb = "User Id=kpell3;Password=oracle;Data Source=(DESCRIPTION=" +
                                "(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.uis.edu)(PORT=1521))" +
                                "(CONNECT_DATA=(SID=oracle)));";
                    OracleConnection myconnection = new OracleConnection(oradb);
                    myconnection.Open();
                    OracleCommand mycommand = myconnection.CreateCommand();
                    mycommand.CommandText = "DELETE FROM Team5members WHERE NAME='" + DataView1.Rows[x].Cells[1].Value.ToString() + "'";
                    mycommand.CommandType = CommandType.Text;
                    OracleDataReader dr = mycommand.ExecuteReader();
                    myconnection.Dispose();
                }
            }
            ShowButton_Click(sender, e);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Grab the actual name we need to add from the textbox
            string mNameToAdd = AddMemberName.Text;
            string oradb = "User Id=kpell3;Password=oracle;Data Source=(DESCRIPTION=" +
                "(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.uis.edu)(PORT=1521))" +
                "(CONNECT_DATA=(SID=oracle)));";
            OracleConnection myconnection = new OracleConnection(oradb);
            myconnection.Open();
            OracleCommand mycommand = myconnection.CreateCommand();
            mycommand.CommandText = "INSERT INTO Team5members (Name,Job) VALUES ('" + AddMemberName.Text + "', '" + AddMemberJob.Text + "')";
            mycommand.CommandType = CommandType.Text;
            OracleDataReader dr = mycommand.ExecuteReader();
            myconnection.Dispose();
            ShowButton_Click(sender, e);
        }

        private void UpdateMemberButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < DataView1.Rows.Count; ++x)
            {
                if (!DBNull.Value.Equals(DataView1.Rows[x].Cells[0].Value) && Convert.ToBoolean(DataView1.Rows[x].Cells[0].Value))
                {
                    //Grab the actual name we need to add from the textbox
                    string mNameToAdd = AddMemberName.Text;
                    string oradb = "User Id=kpell3;Password=oracle;Data Source=(DESCRIPTION=" +
                        "(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.uis.edu)(PORT=1521))" +
                        "(CONNECT_DATA=(SID=oracle)));";
                    OracleConnection myconnection = new OracleConnection(oradb);
                    myconnection.Open();
                    OracleCommand mycommand = myconnection.CreateCommand();
                    mycommand.CommandText = "UPDATE Team5members SET " +
                    "Name='" + AddMemberName.Text + "', " +
                    "Job='" + AddMemberJob.Text + "' " +
                    "WHERE Name='" + DataView1.Rows[x].Cells[1].Value.ToString() + "' " +
                    "AND Job='" + DataView1.Rows[x].Cells[2].Value.ToString() + "'";
                    mycommand.CommandType = CommandType.Text;
                    OracleDataReader dr = mycommand.ExecuteReader();
                    myconnection.Dispose();
                    ShowButton_Click(sender, e);
                }
            }
        }
    }
}
