using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView.Path
{
    public partial class SetLineParams : Form
	{
		public System.Windows.Point startpos;
		public System.Windows.Point endpos;
		public double _startdir;
		public double _enddir;
		public double _unitstep;
		public delegate void LoadChangedLineParams(LineParams param);
		public LoadChangedLineParams loadChangedLineParams;
		public delegate void GetLineStartPoint();
		public GetLineStartPoint getLineStartPoint;
		public delegate void GetLineEndPoint();
		public GetLineEndPoint getLineEndPoint;

		public delegate void SetLineStartPoint();
		public SetLineStartPoint setLineStartPoint;
		public delegate void SetLineEndPoint();
		public SetLineEndPoint setLineEndPoint;

		public delegate void LineParamsFinished();
		public LineParamsFinished changedLineParamsFinhed;
		public delegate void LineParamsCancelled();
		public LineParamsCancelled lineParamsCancelled;
		public LineParams lineParam;
		public SetLineParams()
		{
			InitializeComponent();
			this.TopMost = true;
			lineParam = new LineParams();

			//calculateparams();
		}

		private void SetLineParams_Load(object sender, EventArgs e)
		{

		}



		private void btn_set_Click(object sender, EventArgs e)
		{


		}
		void calculateparams()
		{
			try
			{
				_startdir = trackBar_angleStartPoint.Value * Math.PI / 180.0;
				txt_angleStartPoint.Text = "" + trackBar_angleStartPoint.Value;
				_enddir = trackBar_angleEndPoint.Value * Math.PI / 180.0;
				txt_AngleEndPoint.Text = "" + trackBar_angleEndPoint.Value;
				_unitstep = Convert.ToDouble(txt_unitstep.Text);
				String namepath = txt_namepath.Text;
				lineParam.startpoint = startpos;
				lineParam.Nameobj = namepath;
				lineParam.endpoint = endpos;
				lineParam.unitstep = _unitstep;
				lineParam.startdir = _startdir;
				lineParam.enddir = _enddir;
				loadChangedLineParams(lineParam);
			}
			catch
			{
				MessageBox.Show("Valid Error !");
			}
		}
		public void setparams()
		{
			
			lineParam.startpoint = startpos;
			lineParam.Nameobj = Name;
			lineParam.endpoint = endpos;
			lineParam.unitstep = _unitstep;
			lineParam.startdir = _startdir;
			lineParam.enddir = _enddir;
		}
		public void displayparams()
		{
			txt_startpointX.Text = ""+startpos.X;
			txt_startpointY.Text = "" + startpos.Y;
			txt_endpointX.Text = "" + endpos.X;
			txt_endpointY.Text = "" + endpos.Y;
		}
		public bool findObject(String name)
		{
			try
			{
					if (name.Equals(lineParam.Nameobj))
					{
						return true;
					}
			}
			catch
			{
			}
			return false;
		}
		public void setStartPoint(System.Windows.Point startpos)
		{
			this.startpos = startpos;
			txt_startpointX.Text = "" + startpos.X.ToString("0.0");
			txt_startpointY.Text = "" + startpos.Y.ToString("0.0");
		}
		public void setEndPoint(System.Windows.Point endpos)
		{
			this.endpos = endpos;
			txt_endpointX.Text = "" + endpos.X.ToString("0.0");
			txt_endpointY.Text = "" + endpos.Y.ToString("0.0");

		}
		public System.Windows.Point getStartPoint()
		{
			return this.startpos;
		}
		public System.Windows.Point getEndPoint()
		{
			return this.endpos;
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btn_getStartPoint_Click(object sender, EventArgs e)
		{
			getLineStartPoint();
		}

		private void btn_endStartPoint_Click(object sender, EventArgs e)
		{
			getLineEndPoint();
		}

		private void txt_startpointX_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.startpos = new System.Windows.Point(Convert.ToDouble(txt_startpointX.Text), Convert.ToDouble(txt_startpointY.Text));
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}

		private void txt_startpointY_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.startpos = new System.Windows.Point(Convert.ToDouble(txt_startpointX.Text), Convert.ToDouble(txt_startpointY.Text));
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}

		private void txt_endpointX_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.endpos = new System.Windows.Point(Convert.ToDouble(txt_endpointX.Text), Convert.ToDouble(txt_endpointY.Text));
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}

		private void txt_endpointY_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.endpos = new System.Windows.Point(Convert.ToDouble(txt_endpointX.Text), Convert.ToDouble(txt_endpointY.Text));
				calculateparams();
			}
			catch { MessageBox.Show("Point Valid Wrong !"); }
		}


		private void InsertPoint_Load_1(object sender, EventArgs e)
		{

		}

		private void trackBar_angleStartPoint_Scroll(object sender, EventArgs e)
		{
			calculateparams();
		}

		private void SetLineParams_Load_1(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void trackBar_angleEndPoint_Scroll(object sender, EventArgs e)
		{
			calculateparams();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			changedLineParamsFinhed();
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			lineParamsCancelled();
		}
		public JObject createJsonstring()
		{
			dynamic product = new JObject();
			product.name = lineParam.Nameobj;
			dynamic sp = new JObject();
			sp.X = startpos.X;
			sp.Y = startpos.Y;
			dynamic ep = new JObject();
			ep.X = endpos.X;
			ep.Y = endpos.Y;
			product.startPoint = sp;
			product.endPoint = ep;
			product.startdir = _startdir;
			product.enddir = _enddir;
			product.unitStep = _unitstep;
			return product;

		}

		private void txt_namepath_TextChanged(object sender, EventArgs e)
		{

		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			CreateRobotPathPlan createRobotPathPlan = new CreateRobotPathPlan();
			createRobotPathPlan.linePathPlan(lineParam);
			createRobotPathPlan.saveStraigthLine();
		}
	}
}
