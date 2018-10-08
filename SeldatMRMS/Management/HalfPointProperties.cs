using SeldatMRMS.Model;
using System;
using System.Windows.Forms;

namespace SeldatMRMS.Management
{
    public partial class HalfPointProperties: Form
    {
		HalfPoint hp;
		MainWindow content;
		public HalfPointProperties(MainWindow content, HalfPoint hp)
        {
            InitializeComponent();
			this.content = content;
			this.hp = hp;
			this.content.IsEnabled = false;
		}

		private void btn_update_Click(object sender, EventArgs e)
		{
			try
			{
				this.hp.properties.NameObj = txt_halfpoint_nameobj.Text;
				this.hp.properties.label = txt_halfpoint_label.Text;
				this.hp.setTextlabel(this.hp.properties.label);
				this.hp.properties.LengthValue = Convert.ToDouble(txt_halfpoint_length.Text);
				this.hp.properties.CostValue = Convert.ToDouble(txt_halfpoint_cost.Text);
				this.hp.properties.X_model = Convert.ToDouble(txt_halfpoint_xmodel.Text);
				this.hp.properties.Y_model = Convert.ToDouble(txt_halfpoint_ymodel.Text);
				RegistrationAgent.interfacePointer.updatePropertiesInformationPoint();
				this.Close();
			}
			catch { MessageBox.Show("Error Formating"); }
		}

		private void HalfPointEditForm_Load(object sender, EventArgs e)
		{
			try
			{
				txt_halfpoint_nameobj.Text = this.hp.properties.NameObj;
				txt_halfpoint_label.Text = this.hp.properties.label;
				txt_halfpoint_length.Text = this.hp.properties.LengthValue + "";
				txt_halfpoint_cost.Text = this.hp.properties.CostValue + "";
				txt_halfpoint_xmodel.Text = this.hp.properties.X_model + "";
				txt_halfpoint_ymodel.Text = this.hp.properties.Y_model + "";
			}
			catch { }
		}

		private void HalfPointEditForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.content.IsEnabled = true;
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			
		}

		private void btn_cancel_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
