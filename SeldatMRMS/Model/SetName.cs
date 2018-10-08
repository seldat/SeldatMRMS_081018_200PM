using System;
using System.Windows.Forms;

namespace SeldatMRMS.Model
{
    public partial class SetName : Form
	{
		public String highWayStr="";
		private GroupPathModels groupPathModels;
		public SetName(GroupPathModels p)
		{
			InitializeComponent();
			groupPathModels = p;
		}

		private void btn_update_Click(object sender, EventArgs e)
		{
			if (txt_namehighway.Text.Length > 0)
			{
			
				highWayStr = txt_namehighway.Text;
				this.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void SetName_Load(object sender, EventArgs e)
        {

        }
    }
}
