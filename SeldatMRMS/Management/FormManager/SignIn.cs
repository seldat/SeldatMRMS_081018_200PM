using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeldatMRMS.Management.FormManager
{
    public partial class SignIn: Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_user.Text == "")
            {
                toolStripStatusLabel1.Text = "Input your UserName";
                return;
            }
            if (tb_pwd.Text == "")
            {
                toolStripStatusLabel1.Text = "Input your Password";
                return;
            }
            if ((tb_user.Text == Properties.Resources.ROOT_USERNAME) && (tb_pwd.Text == Properties.Resources.ROOT_PASSWORD))
            {
                toolStripStatusLabel1.Text = "Welcome!";
                return;
            }
            else
            {
                toolStripStatusLabel1.Text = "Username or Password Incorrect!";
                return;
            }
        }
    }
}
