using SeldatMRMS.Management;
using System;
using System.Windows.Forms;

namespace SeldatMRMS.Model
{
    public partial class PathProperties : Form
	{
		PathModel ps;
		MainWindow content;
		public PathProperties(MainWindow content,PathModel ps)
		{
			InitializeComponent();
			this.ps = ps;
			this.content = content;
			this.content.IsEnabled = false;
		}
		private void PathEditForm_Load(object sender, EventArgs e)
		{

		}
		private void btn_update_Click(object sender, EventArgs e)
		{

		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.content.IsEnabled = true;
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				this.ps.properties.roadName = txt_path_roadName.Text;
				RegistrationAgent.interfacePointer.updatePropertiesInformationPath();
				this.content.IsEnabled = true;
				this.Close();

			}
			catch { MessageBox.Show("Error Formating"); }
		}
	}
}
