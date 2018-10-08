using System;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView
{
    public partial class Form1 : Form
    {
        public delegate void GETDATAGRIDVIEW(DataGridView datagrid);
        public GETDATAGRIDVIEW getdatagridview;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
               // int rowindex = dataGridView1.CurrentCell.RowIndex;
            //.    dataGridView1.Rows.RemoveAt(rowindex);

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                dataGridView1.Rows.Remove(row);

            }
            catch { }
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            getdatagridview(dataGridView1);
           // this.Close();
        }

        private void comboBox_palletnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            if(comboBox_palletnum.Text.Equals("3A1"))
            {
                row.Cells[0].Value = comboBox_palletnum.Text;
                row.Cells[1].Value = "7.7,-1.47,180";
                row.Cells[2].Value = "11.5,13,0";
                row.Cells[3].Value = "-10.08,-1.55,0";
                row.Cells[4].Value = "-15,-15.8,0";
                dataGridView1.Rows.Add(row);
            }
            else if (comboBox_palletnum.Text.Equals("10A1"))
            {
                row.Cells[0].Value = comboBox_palletnum.Text;
                row.Cells[1].Value = "7.7,-1.47,180";
				row.Cells[2].Value = "13,13.5,0";
				row.Cells[3].Value = "-10.08,-1.55,0";
				row.Cells[4].Value = "-13.5,-13.8,0";
				dataGridView1.Rows.Add(row);
            }
			else if (comboBox_palletnum.Text.Equals("3B1"))
			{
				row.Cells[0].Value = comboBox_palletnum.Text;
				row.Cells[1].Value = "7.55,0.41,180";
				row.Cells[2].Value = "11.5,13,0";
				row.Cells[3].Value = "-9.89,0.37,0";
				row.Cells[4].Value = "-15,-15.8,0";
				dataGridView1.Rows.Add(row);
			}
			else if (comboBox_palletnum.Text.Equals("10B1"))
			{
				row.Cells[0].Value = comboBox_palletnum.Text;
				row.Cells[1].Value = "7.55,0.41,180";
				row.Cells[2].Value = "13,13.5,0";
				row.Cells[3].Value = "-9.89,0.37,0";
				row.Cells[4].Value = "-13.5,-13.8,0";
				dataGridView1.Rows.Add(row);
			}
			else if (comboBox_palletnum.Text.Equals("3C1"))
			{
				row.Cells[0].Value = comboBox_palletnum.Text;
				row.Cells[1].Value = "7.5,2.4,180";
				row.Cells[2].Value = "11.5,13,0";
				row.Cells[3].Value = "-9.94,2.25,0";
				row.Cells[4].Value = "-15,-15.8,0";
				dataGridView1.Rows.Add(row);
			}
			else if (comboBox_palletnum.Text.Equals("10C1"))
			{
				row.Cells[0].Value = comboBox_palletnum.Text;
				row.Cells[1].Value = "7.5,2.4,180";
				row.Cells[2].Value = "13,13.5,0";
				row.Cells[3].Value = "-9.94,2.25,0";
				row.Cells[4].Value = "-13.5,-13.8,0";
				dataGridView1.Rows.Add(row);
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
