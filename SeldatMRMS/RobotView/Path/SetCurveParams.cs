using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView
{

    public partial class SetCurveParams : Form
	{
		public System.Windows.Point startpos;
		public System.Windows.Point middlepos;
		public System.Windows.Point endpos;
		public double _startdir;
		public double _enddir;
		public double radius;
		public double _dw;
		public double _dv;

		public CurveParams curveParam;
		public List<Position> radiusesPoslist;
		public delegate void LoadChangedCurveParams(CurveParams param);
		public LoadChangedCurveParams loadChangedCurveParams;
		public delegate void GetCurveStartPoint();
		public GetCurveStartPoint getCurveStartPoint;
		public delegate void GetCurveEndPoint();
		public GetCurveEndPoint getCurveEndPoint;

		public delegate void SetCurveStartPoint();
		public SetCurveStartPoint setCurveStartPoint;
		public delegate void SetCurveEndPoint();
		public SetCurveEndPoint setCurveEndPoint;

		public delegate void CurveParamsFinished();
		public CurveParamsFinished changedCurveParamsFinhed;
		public delegate void CurveParamsCancelled();
		public CurveParamsCancelled curveParamsCancelled;
		public SetCurveParams()
		{
			InitializeComponent();
			this.TopMost = true;
			curveParam = new CurveParams();

		}
		public System.Windows.Point calmiddlePoint(System.Windows.Point Apos, System.Windows.Point Bpos)
		{
			System.Windows.Point middlePos = new System.Windows.Point((Apos.X + Bpos.X) / 2.0, (Apos.Y + Bpos.Y) / 2.0);
			return middlePos;
		}
		public List<Position> RadisusOnnbisectLine(System.Windows.Point Apos, System.Windows.Point Bpos)
		{

			System.Windows.Point middlePos = new System.Windows.Point((Apos.X + Bpos.X) / 2.0, (Apos.Y + Bpos.Y) / 2.0);
			System.Windows.Point ABPos = new System.Windows.Point(Bpos.X - Apos.X, Bpos.Y - Apos.Y);
			List<Position> Mpos = new List<Position>();
			if (ABPos.X == 0)
			{
				for (double i = 0; i < 100; i += 1)
				{
					double yy = (Apos.Y + Bpos.Y) / 2.0;
					Mpos.Add(new Position() { X = middlePos.X + i, Y = yy });
				}
				for (double i = 0; i > -100; i -= 1)
				{
					double yy = (Apos.Y + Bpos.Y) / 2.0;
					Mpos.Add(new Position() { X = middlePos.X + i, Y = yy });
				}

			}
			else if (ABPos.Y == 0)
			{

				for (double i = 0; i < 100; i += 1)
				{
					double xx = (Apos.X + Bpos.X) / 2.0;
					Mpos.Add(new Position() { X = xx, Y = middlePos.Y + i });
				}
				for (double i = 0; i > -100; i -= 1)
				{
					double xx = (Apos.X + Bpos.X) / 2.0;
					Mpos.Add(new Position() { X = xx, Y = middlePos.Y + i });
				}
			}
			else
			{
				for (double i = 0; i < 100; i += 1)
				{
					double yy = middlePos.Y + i;
					double xx = (-ABPos.Y * (yy - middlePos.Y) + ABPos.X * middlePos.X) / ABPos.X;
					Mpos.Add(new Position() { X = xx, Y = yy });
				}
				for (double i = 0; i > -100; i -= 1)
				{
					double yy = middlePos.Y + i;
					double xx = (-ABPos.Y * (yy - middlePos.Y) + ABPos.X * middlePos.X) / ABPos.X;
					Mpos.Add(new Position() { X = xx, Y = yy });
				}
			}
			return Mpos;
		}
		public List<Position> getRadius()
		{
			List<Position> radiusesPoslist=RadisusOnnbisectLine(this.startpos, this.endpos);
			this.radiusesPoslist = radiusesPoslist;
			trackBar_distance.Maximum = radiusesPoslist.Count;
			trackBar_distance.Minimum = 0;
			return radiusesPoslist;
		}
		public void setStartPoint(System.Windows.Point startpos)
		{
			this.startpos = startpos;
			getRadius();
			txt_startpointX.Text = "" + startpos.X.ToString("0.0");
			txt_startpointY.Text = "" + startpos.Y.ToString("0.0");
			RadisusOnnbisectLine(this.startpos, this.endpos);
		}
		public void setEndPoint(System.Windows.Point endpos)
		{
			this.endpos = endpos;
			getRadius();
			txt_endpointX.Text = "" + endpos.X.ToString("0.0");
			txt_endpointY.Text = "" + endpos.Y.ToString("0.0");
			RadisusOnnbisectLine(this.startpos, this.endpos);

		}
		public System.Windows.Point getStartPoint()
		{
			return this.startpos;
		}
		public System.Windows.Point getEndPoint()
		{
			return this.endpos;
		}
		public System.Windows.Point getMiddlePoint()
		{
			return calmiddlePoint(this.startpos,this.endpos);
		}
		public void setparams()
		{
			curveParam.startpoint = startpos;
			curveParam.Nameobj = Name ;
			curveParam.endpoint = endpos;
			curveParam.R = radius;
			curveParam.dw = _dw;
			curveParam.dv = _dv; curveParam.startdir = _startdir; curveParam.enddir = _enddir; 
		}
		void calculateparams()
		{
			try
			{
				int postrack = trackBar_distance.Value;
				if (postrack >= trackBar_distance.Maximum)
					postrack = trackBar_distance.Maximum - 1;
				radius = Math.Sqrt(Math.Pow(this.radiusesPoslist[postrack].X - this.startpos.X, 2) + Math.Pow(this.radiusesPoslist[postrack].Y - this.startpos.Y, 2));
				double radius2 = Math.Sqrt(Math.Pow(this.radiusesPoslist[postrack].X - this.endpos.X, 2) + Math.Pow(this.radiusesPoslist[postrack].Y - this.endpos.Y, 2));
				_dv = Convert.ToDouble(txt_dv.Text);
				_dw = _dv / radius;
				_startdir = trackBar_angleStartPoint.Value*Math.PI/180.0;
				if (radio_dr_negative.Checked)
					_dw = -_dw;
				txt_radius.Text = "" + radius.ToString("0.00");
				txt_dr.Text = "" + _dw.ToString("0.00");
				txt_angleStartPoint.Text = "" + trackBar_angleStartPoint.Value;
				_enddir = trackBar_angleEndPoint.Value * Math.PI / 180.0;
				txt_AngleEndPoint.Text = "" + trackBar_angleEndPoint.Value;
				String namepath = txt_namepath.Text;
				curveParam.startpoint = startpos;
				curveParam.Nameobj = namepath; ;
				curveParam.endpoint = endpos;
				curveParam.R = radius;
				curveParam.dw = _dw;
				curveParam.dv = _dv;
				curveParam.startdir = _startdir;
				curveParam.enddir = _enddir;
				loadChangedCurveParams(curveParam);
			}
			catch
			{
				MessageBox.Show("Valid Error !");
			}
		}

		private void CurveInfo_Load(object sender, EventArgs e)
		{

		}
		public bool findObject(String name)
		{
			try
			{
				if (name.Equals(curveParam.Nameobj))
				{
					MessageBox.Show("S " + curveParam.Nameobj);
					return true;
				}
			}
			catch { }
			return false;
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
			curveParamsCancelled();
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

		private void trackBar_rotEndPoint_Scroll(object sender, EventArgs e)
		{

			calculateparams();
		}

		private void trackBar_angleStartPoint_Scroll(object sender, EventArgs e)
		{

			calculateparams();
		}

		private void radio_dr_positive_CheckedChanged(object sender, EventArgs e)
		{

			calculateparams();
		}

		private void radio_dr_negative_CheckedChanged(object sender, EventArgs e)
		{

			calculateparams();
		}

		private void btn_getStartPoint_Click(object sender, EventArgs e)
		{
			getCurveStartPoint();
		}

		private void btn_endStartPoint_Click(object sender, EventArgs e)
		{
			getCurveEndPoint();
		}

		private void txt_startpointX_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.startpos = new System.Windows.Point(Convert.ToDouble(txt_startpointX.Text), Convert.ToDouble(txt_startpointY.Text));
				getRadius();
				RadisusOnnbisectLine(this.startpos, this.endpos);
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}

		private void txt_startpointY_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.startpos = new System.Windows.Point(Convert.ToDouble(txt_startpointX.Text), Convert.ToDouble(txt_startpointY.Text));
				getRadius();
				RadisusOnnbisectLine(this.startpos, this.endpos);
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}

		private void txt_endpointX_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.endpos = new System.Windows.Point(Convert.ToDouble(txt_endpointX.Text), Convert.ToDouble(txt_endpointY.Text));
				getRadius();
				RadisusOnnbisectLine(this.startpos, this.endpos);
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}

		private void txt_endpointY_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.endpos = new System.Windows.Point(Convert.ToDouble(txt_endpointX.Text), Convert.ToDouble(txt_endpointY.Text));
				getRadius();
				RadisusOnnbisectLine(this.startpos, this.endpos);
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}
		public JObject createJsonstring()
		{
			dynamic product = new JObject();
			product.name = curveParam.Nameobj;
			dynamic sp = new JObject();
			sp.X = startpos.X;
			sp.Y = startpos.Y;
			dynamic mp = new JObject();
			mp.X = middlepos.X;
			mp.Y = middlepos.Y;
			dynamic ep = new JObject();
			ep.X =endpos.X;
			ep.Y =endpos.Y;
			product.startPoint = sp;
			product.middlePoint = mp;
			product.endPoint = ep;
			product.startdir = _startdir;
			product.enddir = _enddir;
			product.radius = curveParam.R;
			product.dv = curveParam.dv;
			product.dw = curveParam.dw;
			return product;

		}
		private void groupBox6_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox8_Enter(object sender, EventArgs e)
		{

		}

		private void txt_namepath_TextChanged(object sender, EventArgs e)
		{
			curveParam.Nameobj = txt_namepath.Text;
		}

		private void groupBox5_Enter(object sender, EventArgs e)
		{

		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			CreateRobotPathPlan createRobotPathPlan = new CreateRobotPathPlan();
			createRobotPathPlan.CurvePathPlan(curveParam);
			createRobotPathPlan.saveCurveLine();
		}
	}
}
