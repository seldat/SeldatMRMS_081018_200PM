using HelixToolkit.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Threading;
namespace SeldatMRMS.RobotView
{
    /// <summary>
    /// Interaction logic for MapSettingF.xaml
    /// </summary>
    public partial class MapSettingF : Window
    {
        public delegate void LogHandler(string tag,string message);
        public event LogHandler Log;
        String TEXT_GRID_WIDTH = "1000";
        String TEXT_GRID_LENGTH = "1000";
        String TEXT_GRID_MINORDISTANCE= "10";
        String TEXT_GRID_MAJORDISTANCE = "15";
        String TEXT_GRID_BACKGROUND = "#FFFFFFFF";
        String TEXT_GRID_OPACITY = "0.8";
        String TEXT_GRID_NORMAL = "0,0,1";
        String TEXT_ROBOT_AMOUNTS = "0";
        String TEXT_ROBOT_INFOMATION = "";
        String TEXT_PATHMAP = "";
        
        public MapSettingF()
        {
            InitializeComponent();
            this.Topmost = true;
            GlobalVariables.GRIDLINE_WIDTH = Convert.ToDouble(txt_borderX.Text);
            GlobalVariables.GRIDLINE_LENGTH = Convert.ToDouble(txt_borderY.Text);
            GlobalVariables.MEASUREMENT_UNITMETTERINPIXEL = Convert.ToDouble(txt_unitMeterPixel.Text);
 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_gridwidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double _with = Convert.ToDouble(txt_gridwidth.Text);
                TEXT_GRID_WIDTH = "" + _with;

            }
            catch {
                MessageBox.Show("Wrong Width Value");
            }
        }

        private void btn_gridColorBG_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void slider_gridopacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                TEXT_GRID_OPACITY = txt_gridopacity.Text;
               // txt_gridopacity.Text = "" + TEXT_GRID_OPACITY;
            }
            catch { }
        }
        private void updategrid()
        {
            TEXT_GRID_BACKGROUND = "" + _colorPicker.SelectedColor;
            String griddata =TEXT_GRID_WIDTH + "%" + TEXT_GRID_LENGTH + "%" + TEXT_GRID_MINORDISTANCE + "%" + TEXT_GRID_MAJORDISTANCE +"%" + TEXT_GRID_BACKGROUND +"%" + TEXT_GRID_OPACITY+"%" + TEXT_GRID_NORMAL;
            Log("TAG-GRID",griddata);
            
        }
        private void updatemap()
        {

            String griddata = TEXT_PATHMAP + "%" + txt_borderX.Text + "%" + txt_borderY.Text + "%" + txt_borderZ.Text + "%" + txt_mappointX.Text + "%" + txt_mappointY.Text;
            Log("TAG-MAP", griddata);

        }
        private void updateRobot()
        {
            TEXT_ROBOT_AMOUNTS = txt_amountrobot.Text;
            String griddata;
            if (radioBtn_robotnewcreate.IsChecked == true)
            {
                griddata = TEXT_ROBOT_AMOUNTS + "%1";
                Log("TAG-ROBOT", griddata);
            }
            if (radioBtn_robotaddmore.IsChecked == true)
            {
                griddata = TEXT_ROBOT_AMOUNTS + "%0";
                Log("TAG-ROBOT", griddata);
            }
            

        }
        private void updateinformation()
        {
            
                Log("TAG-INFORMATION", TEXT_ROBOT_INFOMATION);

        }
        private void _colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            
            
        }

        private void txt_gridlength_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double _length = Convert.ToDouble(txt_gridlength.Text);
                TEXT_GRID_LENGTH = "" + _length;

            }
            catch
            {
                MessageBox.Show("Wrong Major Length Value");
            }
        }

        private void txt_gridminordistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double _minordistance = Convert.ToDouble(txt_gridminordistance.Text);
                TEXT_GRID_MINORDISTANCE = "" + _minordistance;

            }
            catch
            {
                MessageBox.Show("Wrong Minor Distance Value");
            }
        }

        private void txt_gridmajordistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double _majordistance = Convert.ToDouble(txt_gridmajordistance.Text);
                TEXT_GRID_MAJORDISTANCE= "" + _majordistance;
                

            }
            catch
            {
                MessageBox.Show("Wrong Major Distance Value");
            }
        }

        private void btn_apply_Click(object sender, RoutedEventArgs e)
        {
			done();


		}

		public void doneSetParams()
		{

			string Location = AppDomain.CurrentDomain.BaseDirectory;
			///MessageBox.Show(Location);
			TEXT_PATHMAP = Location + "Resources\\Map\\Map.jpg";
			txt_pathmap.Text = TEXT_PATHMAP;
			try
			{
				loadinform(TEXT_PATHMAP);
			}
			catch
			{
				MessageBox.Show("Path Map is wrong");
			}

		}
		public void done()
		{
			Thread pthreadload = new Thread(LoadInformation);
			pthreadload.Start();
		}

        private void radio_gridNormalX_Checked(object sender, RoutedEventArgs e)
        {
            TEXT_GRID_NORMAL = "1,0,0";
        }

        private void radio_gridNormalY_Checked(object sender, RoutedEventArgs e)
        {
            TEXT_GRID_NORMAL = "0,1,0";
        }

        private void radio_gridNormalZ_Checked(object sender, RoutedEventArgs e)
        {
            TEXT_GRID_NORMAL = "0,0,1";
        }
        public void LoadInformation()
        {
            Dispatcher.Invoke((Action)delegate
            {

                       updategrid();
                       updatemap();
                       updateRobot();
                       updateinformation();

             });
            
        }
        private void btn_pathmap(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TEXT_PATHMAP = openFileDialog.FileName;
                txt_pathmap.Text = TEXT_PATHMAP;
                try
                {
                    //MessageBox.Show(TEXT_PATHMAP);
                    loadinform(TEXT_PATHMAP);
                }
                catch
                {
                    MessageBox.Show("Path is wrong");
                }
            }

        }

        private void loadinform(String path)
        {
                try
                {
                    BitmapImage bi = new BitmapImage(new Uri(TEXT_PATHMAP, UriKind.Absolute));
                    GlobalVariables.MAP_WIDTHPIXEL = bi.PixelWidth;
                    GlobalVariables.MAP_HEIGHTPIXEL = bi.PixelHeight;
                    double largesize = bi.PixelWidth <= bi.PixelHeight ? bi.PixelWidth : bi.PixelHeight; // select the small length of image
                    //double largesize = 832;
                    txt_gridwidth.Text = "" + largesize;
                    txt_gridlength.Text = "" + largesize;
                    txt_gridmajordistance.Text = "" + (largesize / 40.00).ToString("0.000");
                    txt_gridminordistance.Text = "" + (largesize / 40.00).ToString("0.000");
                    txt_borderX.Text = "" + GlobalVariables.MAP_WIDTHPIXEL;
                    txt_borderY.Text = "" + GlobalVariables.MAP_HEIGHTPIXEL;

                    GlobalVariables.GRIDLINE_WIDTH = Convert.ToDouble(txt_borderX.Text);
                    GlobalVariables.GRIDLINE_LENGTH = Convert.ToDouble(txt_borderY.Text);
                    GlobalVariables.MEASUREMENT_UNITASQUARE_LENGTH = largesize / 40;
                    GlobalVariables.MEASUREMENT_UNITASQUARE_METER = Convert.ToDouble(txt_unitMeterPixel.Text) * GlobalVariables.MEASUREMENT_UNITASQUARE_LENGTH;

                    txt_mappointX.Text = "" + GlobalVariables.MAP_WIDTHPIXEL;
                    txt_mappointY.Text = "" + GlobalVariables.MAP_HEIGHTPIXEL;
                    //     txt_asquared.Text = "" + GlobalVariables.MEASUREMENT_UNITASQUARE+" (m)";

                    ModelImporter import = new ModelImporter();
                    Model3D device = import.Load(GlobalVariables.getPathRobot3DModel());
					
                    double Sx = device.Bounds.SizeX/100; // size in cm  to m
				    //MessageBox.Show("size X:" +Sx);
                    double Sy = device.Bounds.SizeY/100;
                    double Sz = device.Bounds.SizeZ/100;
                    GlobalVariables.ROBOT_SCALED =GlobalVariables.ConvertMetertoUnitLength(Sx/100) / Sx; 

				richtxt_detailInformation.Document.Blocks.Clear();
                    String inform = "Detail information: \n";
                    inform += "+Length of a square: " + GlobalVariables.MEASUREMENT_UNITASQUARE_LENGTH + "\n";
                    inform += "+Length meter of a squared: " + GlobalVariables.MEASUREMENT_UNITASQUARE_METER + "\n"; /// số ô là 40 , 
                    inform += "+ Robot size (m): " + Sx.ToString("0.00") + " // " + Sy.ToString("0.00") + " // " + Sz.ToString("0.00") + "\n";
                    inform += "+ Scaled Robot: " + GlobalVariables.ROBOT_SCALED.ToString("0.00");
                    richtxt_detailInformation.AppendText(inform);
                    TEXT_ROBOT_INFOMATION = inform;
                }
                catch
                {
                    MessageBox.Show("Path is wrong");
                }

        }
        private void txt_borderX_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txt_borderY.Text = txt_borderX.Text;
            }
            catch { }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txt_gridopacity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TEXT_GRID_OPACITY = txt_gridopacity.Text;
                double temp = Convert.ToDouble(TEXT_GRID_OPACITY);
            }
            catch { }
        }

        private void txt_unitMeterPixel_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* try
            {
                GlobalVariables.MEASUREMENT_UNITASQUARE = Convert.ToDouble(txt_unitMeterPixel.Text) * (GlobalVariables.MAP_WIDTHPIXEL / Convert.ToDouble(txt_borderX.Text));
                txt_asquared.Text = "" + GlobalVariables.MEASUREMENT_UNITASQUARE.ToString("0.00") + " (m)";
                GlobalVariables.MEASUREMENT_UNITMETTERINPIXEL = Convert.ToDouble(txt_unitMeterPixel.Text);
            }
            catch { }*/
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
			doneSetParams();
			/*MessageBox.Show("please choose Map !!"+ Location);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TEXT_PATHMAP = Location+ "\\Debug\\Resources\\Map\\Map.jpg";
                txt_pathmap.Text = TEXT_PATHMAP;
                try
                {
                    loadinform(TEXT_PATHMAP);
                }
                catch
                {
                    MessageBox.Show("Path is wrong");
                }
            }*/
		}
    }
}
