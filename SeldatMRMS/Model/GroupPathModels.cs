using SeldatMRMS.Management;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeldatMRMS.Model
{
    public partial class GroupPathModels : Form
	{
		public GroupPathModels()
		{
			InitializeComponent();
		}

		private void list_pathmodel_SelectedIndexChanged(object sender, EventArgs e)
		{
			string tmpStr = "";
			foreach (var item in listB_group.SelectedItems)
			{
				tmpStr += listB_group.GetItemText(item) + "\n";
			}
			Console.WriteLine(tmpStr);
		}
		private void loadPathModels()
		{
			if (RegistrationAgent.pathRegistrationList.Count > 0)
			{
				list_pathmodel.Items.Clear();
				List<String> pathNameList=new List<String>();
				foreach(PathModel p in RegistrationAgent.pathRegistrationList)
				{
					pathNameList.Add(p.properties.roadName);
				}
				list_pathmodel.DataSource = pathNameList;
			}
		}
		private void refresh()
		{
			loadPathModels();
		}
		private void GroupPathModels_Load(object sender, EventArgs e)
		{
			loadPathModels();
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			string curItem = list_pathmodel.SelectedItem.ToString();
			listB_group.Items.Add(curItem);
		}

		private void btn_remove_Click(object sender, EventArgs e)
		{
			try
			{
				listB_group.Items.Remove(listB_group.Items[listB_group.SelectedIndex]);
			}
			catch { }
		}
		private void save()
		{
		/*	bool isExist = false;
			HighwayModel highway = new HighwayModel();
			if (RegistrationAgent.highwayRegistrationList.Count > 0)
			{
				
				for (int index = 0; index < listB_group.Items.Count; index++)
				{
					
					String roadname = listB_group.Items[index].ToString();
					MessageBox.Show(roadname);
					String highwayname = "";
					foreach (HighwayModel p in RegistrationAgent.highwayRegistrationList)
					{
						if (p.findPathsExist(roadname) >= 0)
						{
							highwayname = p.properties.roadName;
							isExist = true;
							break;
						}
					}
					if (isExist)
					{
						MessageBox.Show("Group is failed: " + roadname + "existed in " + highwayname);
						break;
					}
				}
			}
			if (!isExist)
			{
				SetName psetname = new SetName(this);
				psetname.ShowDialog();
				String name = psetname.highWayStr;
				if (name.Length > 0)
				{
					highway.properties.roadName = name;
					String textpaths = "";
					for (int index = 0; index < listB_group.Items.Count; index++)
					{
						String roadname = listB_group.Items[index].ToString();
						textpaths += roadname + ",";
						highway.addPathModel(roadname);
					}
					RegistrationAgent.highwayRegistrationList.Add(highway);
					DataGridViewRow row = (DataGridViewRow)dg_highway.Rows[0].Clone();
					row.Cells[0].Value = name;
					row.Cells[1].Value = textpaths;
					dg_highway.Rows.Add(row);
				}
				else
				{
					MessageBox.Show("Not a name to save");
				}
			}*/
		}
		private void btn_save_Click(object sender, EventArgs e)
		{
			save();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				dg_highway.Rows[0].Selected = true;
				MessageBox.Show("" + dg_highway.SelectedRows[0].Index);
				RegistrationAgent.highwayRegistrationList.RemoveAt(dg_highway.SelectedRows[0].Index);
				dg_highway.Rows.RemoveAt(dg_highway.SelectedRows[0].Index);
			}
			catch { }
			
		}

		private void btn_refresh_Click(object sender, EventArgs e)
		{
			listB_group.Items.Clear();
		}
	}
}
