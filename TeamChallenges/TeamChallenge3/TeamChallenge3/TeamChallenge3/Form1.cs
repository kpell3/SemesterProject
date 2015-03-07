using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;

namespace TeamChallenge3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ActiveDirectoryAuthenticate(string username, string password)
        {
            using (DirectoryEntry entry = new DirectoryEntry("LDAP://UISDC01.UIS.EDU"))
            {
                entry.Username = username;
                entry.Password = password;
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = "(sAMAccountName=" + username + ")";
                try
                {
                    SearchResult _sr = searcher.FindOne();
                    string _name = _sr.Properties["displayname"][0].ToString();
                    MessageBox.Show("Authentication Succeeded!");
                }
                catch( Exception e )
                {
                    MessageBox.Show("Authentication Failed!" + e.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveDirectoryAuthenticate( UsernameBox.Text, PasswordBox.Text );
        }
    }
}
