using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;

namespace SeldatMRMS.Management.FormManager
{
    public partial class LiveViewForm : Form
    {

        public class Contour
        {
            public int id;
            public int x, y, h, w;
        }

        public List<Contour> contourList;
        public string area;
        public string stationID;
        public struct CameraStrt
        {
            public VideoCapture capture;
            public String url;
            public Mat frame;
        }
        public CameraStrt cameraStrt;
        public LiveViewForm(String url)
        {
            InitializeComponent();
            cameraStrt.url = url;

        }

        public void setcam( string area, string stationID)
        {
        
            toolStripStatusLabel1.Visible = false;
            contourList = new List<Contour>();
            this.area = area;
            this.stationID = stationID;
            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Resources\\yaml\\station_" + stationID + ".yml";
            var input = new StreamReader(m_exePath);
            var yaml = new YamlStream();
            yaml.Load(input);
            foreach (YamlMappingNode entry in (YamlSequenceNode)yaml.Documents[0].RootNode)
            {
                Contour temp = new Contour();
                var items = (YamlSequenceNode)entry.Children[new YamlScalarNode("points")];
                var itemss = (YamlScalarNode)entry.Children[new YamlScalarNode("id")];
                temp.id = Int32.Parse(itemss.ToString());
                temp.x = Int32.Parse(items[0][0].ToString());
                temp.y = Int32.Parse(items[0][1].ToString());
                temp.h = Int32.Parse(items[1][0].ToString()) - temp.x;
                temp.w = Int32.Parse(items[1][1].ToString()) - temp.y;
                contourList.Add(temp);

            }

        }
        private void ImageGrabbed(object sender, EventArgs e)
        {
            if (cameraStrt.capture != null && cameraStrt.capture.Ptr != IntPtr.Zero)
            {
                try
                {
                    if (cameraStrt.capture.IsOpened)
                    {
                        Mat frame = new Mat();
                        cameraStrt.capture.Read(frame);
                        this.Invoke((MethodInvoker)delegate
                        {
                            Image<Bgr, Byte> img = frame.ToImage<Bgr, Byte>();
                            toolStripProgressBar1.Value = 300;
                            toolStripStatusLabel1.Text = Properties.Resources.LIVE_VIEW_STATUS_FINISHED;
                            toolStripStatusLabel1.Visible = true;
                            toolStripProgressBar1.Visible = false;
                            timer1.Stop();
                            streamView.SizeMode = PictureBoxSizeMode.StretchImage;
                            FontFace font = new FontFace();
                            List<bool> palletStatusArray = RegistrationAgent.areaList[area].GetPalletArray(stationID);
                            for (int index = 0; index < contourList.Count;index++)
                            {
                                img.Draw(new Rectangle(contourList[index].x, contourList[index].y, contourList[index].h, contourList[index].w), (palletStatusArray[index])? (new Bgr(0, 255, 0)): (new Bgr(0, 0, 200)), 5);
                                img.Draw(contourList[index].id.ToString(), new Point(contourList[index].x + 10, contourList[index].y + 50), font, 1.2, (palletStatusArray[index]) ? (new Bgr(0, 255, 0)) : (new Bgr(0, 0, 200)), 3);

                            }
                            
                            streamView.Image = img.ToBitmap();
                        });
                    }

                }
                catch { }
            }
        }

        private void LiveViewForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Task.Run(() =>
            {
                cameraStrt.capture = new VideoCapture(cameraStrt.url);
                cameraStrt.capture.ImageGrabbed += ImageGrabbed;
                cameraStrt.frame = new Mat();
                cameraStrt.capture.Start();
            });
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripProgressBar1.Value <= 270)
            {
                toolStripProgressBar1.Increment(2);
            }
        }
        
    }
}
