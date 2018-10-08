using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView
{

    public partial class CurveInfo:Form
	{
		System.Windows.Point startpos;
		System.Windows.Point middlepos;
		System.Windows.Point endpos;
		List<Position> radiusesPoslist;
		public delegate void LoadChangedCurveParams(CurveParams param);
		public LoadChangedCurveParams loadChangedCurveParams;
		public delegate void CurveParamsFinished();
		public CurveParamsFinished changedCurveParamsFinhed;
		public CurveInfo(System.Windows.Point startpos, System.Windows.Point middlepos, System.Windows.Point endpos,List<Position> radiusesPoslist)
		{
			InitializeComponent();
			this.startpos = startpos;
			this.middlepos = middlepos;
			this.endpos = endpos;
			this.radiusesPoslist = radiusesPoslist;
			trackBar_distance.Maximum = radiusesPoslist.Count;
			trackBar_distance.Minimum =0;
		}
		void calculateparams()
		{
			try
			{
				int postrack = trackBar_distance.Value;
				if (postrack >= trackBar_distance.Maximum)
					postrack = trackBar_distance.Maximum - 1;
				double radius = Math.Sqrt(Math.Pow(this.radiusesPoslist[postrack].X - this.startpos.X, 2) + Math.Pow(this.radiusesPoslist[postrack].Y - this.startpos.Y, 2));
				double radius2 = Math.Sqrt(Math.Pow(this.radiusesPoslist[postrack].X - this.endpos.X, 2) + Math.Pow(this.radiusesPoslist[postrack].Y - this.endpos.Y, 2));
				double _dv = Convert.ToDouble(txt_dv.Text);
				double _dw =_dv / radius;
				double angle=0;
				if (radio_dr_negative.Checked)
					_dw = -_dw;
				if (radio_0degree.Checked)
					angle = 0;
				if (radio_90degree.Checked)
					angle = Math.PI/2;
				if (radio_180degree.Checked)
					angle = Math.PI;
				if (radio_90_neg_degree.Checked)
					angle = -Math.PI / 2;
				if (radio_180_neg_degree.Checked)
					angle = -Math.PI;
				txt_radius.Text = "" + radius;
				txt_temp.Text = "" + radius2;
				txt_dr.Text = "" + _dw;

				loadChangedCurveParams(new CurveParams() { R = radius, dw = _dw, dv = _dv,startdir=angle });
			}
			catch {
				MessageBox.Show("Valid Error !");
			}
		}

		private void CurveInfo_Load(object sender, EventArgs e)
		{

		}

		private void trackBar_distance_Scroll(object sender, EventArgs e)
		{
			calculateparams();
		}

		private void txt_dv_TextChanged(object sender, EventArgs e)
		{
			calculateparams();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			changedCurveParamsFinhed();
			Close();
		}

		private void groupBox4_Enter(object sender, EventArgs e)
		{

		}
	}
}
