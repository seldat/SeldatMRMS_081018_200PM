using Newtonsoft.Json.Linq;
using SeldatMRMS.Management;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeldatMRMS.Model
{
    public partial class LineInfo : Form
    {
        int numLines;
        int numPallets;
        double step;
        double firstPalletinLine;
        bool flagIncrease;
        List<ParamOnALine> paramOnALineList = new List<ParamOnALine>();

        public class Location
        {
            public double X;
            public double Y;
            public double Angle;
        }
        public class LocateAPallet
        {
            public Location loc;
            public double threshold;
        }
        public class ParamOnALine
        {
            public List<LocateAPallet> locateAPalletList = new List<LocateAPallet>();
            public Location loc;
        }

        public LineInfo()
        {
            InitializeComponent();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                numLines = int.Parse(txt_numberofLines.Text);
                numPallets = int.Parse(txt_numberofPallets.Text);
                step = double.Parse(txt_step.Text);
                flagIncrease = rdB_increase.Checked;
                firstPalletinLine = double.Parse(txt_theBeginPosition.Text);
            }
            catch { };
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                numLines = int.Parse(txt_numberofLines.Text);
                numPallets = int.Parse(txt_numberofPallets.Text);
                step = double.Parse(txt_step.Text);
                flagIncrease = rdB_increase.Checked;
                firstPalletinLine = double.Parse(txt_theBeginPosition.Text);
            }
            catch { };
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            generator();
        }
        public void generator()
        {
            dGV_LineInfo.Rows.Clear();
            try
            {
                if (flagIncrease)
                {
                    for(int iline=0;iline< numLines;iline++)
                    {
                        double beginPos = firstPalletinLine;
                        for (int ipallet = 0; ipallet < numPallets; ipallet++)
                        {
                            int n = dGV_LineInfo.Rows.Add();
                            dGV_LineInfo.Rows[n].Cells[0].Value = iline+"."+ ipallet;
                            dGV_LineInfo.Rows[n].Cells[6].Value = beginPos;
                            beginPos = beginPos + step;
                        }
                    }
                }
                else
                {
                    for (int iline = 0; iline < numLines; iline++)
                    {
                       double beginPos = firstPalletinLine;
                        for (int ipallet = 0; ipallet < numPallets; ipallet++)
                        {
                            int n = dGV_LineInfo.Rows.Add();
                            dGV_LineInfo.Rows[n].Cells[0].Value = iline + "." + ipallet;
                            dGV_LineInfo.Rows[n].Cells[6].Value = beginPos;
                            beginPos = beginPos - step;
                        }
                    }
                }

            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Error in Generating, please check params again !", "errorConsole");
            }
        }

        public void update()
        {
            paramOnALineList.Clear();
            int nextStep = 0;
            try
            {
                    for (int iline = 0; iline < numLines; iline++)
                    {
                        ParamOnALine paramOnALine = new ParamOnALine();
                        double LX = Convert.ToDouble(dGV_LineInfo.Rows[nextStep].Cells[1].Value);
                        double LY = Convert.ToDouble(dGV_LineInfo.Rows[nextStep].Cells[2].Value);
                        double LA = Convert.ToDouble(dGV_LineInfo.Rows[nextStep].Cells[3].Value);
                        paramOnALine.loc = new Location {X= LX, Y=LY,Angle=LA };
                        for (int ipallet = 0; ipallet < numPallets; ipallet++)
                        {
                            LocateAPallet locateAPallet = new LocateAPallet();
                            double PX = Convert.ToDouble(dGV_LineInfo.Rows[ipallet+nextStep].Cells[4].Value);
                            double PY = Convert.ToDouble(dGV_LineInfo.Rows[+ipallet+nextStep].Cells[5].Value);
                            locateAPallet.loc = new Location { X = PX,Y= PY};
                            locateAPallet.threshold= Convert.ToDouble(dGV_LineInfo.Rows[ipallet+nextStep].Cells[6].Value);
                            paramOnALine.locateAPalletList.Add(locateAPallet);
                        }
                        paramOnALineList.Add(paramOnALine);
                        nextStep += numPallets;
                    }
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Error in Update, please check params again !", "errorConsole");
            }
        }

        public Location getLine(int linenum)
        {
            try
            {
                if (paramOnALineList.Count > 0)
                {
                    return paramOnALineList[linenum].loc;
                }
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Out of Range Value [Line] !", "errorConsole");
            }
            return null;
        }
        public LocateAPallet getPallet(int linenum,int palletnum)
        {
            try
            {
                if (paramOnALineList.Count > 0)
                {
                    return paramOnALineList[linenum].locateAPalletList[palletnum];
                }
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Out of Range Value [Pallet] !", "errorConsole");
            }
            return null;
        }

        public JObject save(String nameStation)
        {
            dynamic product = new JObject();
            try
            {
                product.nLines = int.Parse(txt_numberofLines.Text);
                product.nPallets = int.Parse(txt_numberofPallets.Text);
                product.step = double.Parse(txt_step.Text);
                product.beginPos = double.Parse(txt_theBeginPosition.Text);
                product.increase = rdB_increase.Checked;
                dynamic locations = new JArray();
                for (int index = 0; index < dGV_LineInfo.RowCount; index++)
                {
                    dynamic location = new JObject();
                    location.LX = double.Parse(dGV_LineInfo.Rows[index].Cells[1].Value.ToString());
                    location.LY = double.Parse(dGV_LineInfo.Rows[index].Cells[2].Value.ToString());
                    location.LA = double.Parse(dGV_LineInfo.Rows[index].Cells[3].Value.ToString());
                    location.PX = double.Parse(dGV_LineInfo.Rows[index].Cells[4].Value.ToString());
                    location.PY = double.Parse(dGV_LineInfo.Rows[index].Cells[5].Value.ToString());
                    locations.Add(location);
                }
                product.locations = locations;
            }
            catch {
                RegistrationAgent.mainWindowPointer.LogConsole("no Information about Line and Pallet in Station " + nameStation + "!", "errorConsole");
            }
            return product;
        }

        public void loadparams(JToken results)
        {
            try
            {
                numLines = int.Parse((string)results["nLines"]);
                numPallets = int.Parse((string)results["nPallets"]);
                step = double.Parse((string)results["step"]);
                firstPalletinLine = double.Parse((string)results["beginPos"]);
                flagIncrease = bool.Parse((string)results["increase"]);
                txt_numberofLines.Text = numLines + "";
                txt_numberofPallets.Text = numPallets + "";
                txt_step.Text = step + "";
                txt_theBeginPosition.Text = firstPalletinLine + "";
                rdB_increase.Checked = (bool)flagIncrease;
                generator();
                int index = 0;
                foreach (var result in results["locations"])
                {

                    dGV_LineInfo.Rows[index].Cells[1].Value = (string)result["LX"];
                    dGV_LineInfo.Rows[index].Cells[2].Value = (string)result["LY"];
                    dGV_LineInfo.Rows[index].Cells[3].Value = (string)result["LA"];
                    dGV_LineInfo.Rows[index].Cells[4].Value = (string)result["PX"];
                    dGV_LineInfo.Rows[index].Cells[5].Value = (string)result["PY"];
                    index++;
                   
                }
                update();
            }
            catch { }
        
        }

        private void dGV_LineInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_numberofLines_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numLines = int.Parse(txt_numberofLines.Text);
                numPallets = int.Parse(txt_numberofPallets.Text);
                step = double.Parse(txt_step.Text);
                flagIncrease = rdB_increase.Checked;
                firstPalletinLine = double.Parse(txt_theBeginPosition.Text);
            }
            catch { };
        }

        private void txt_numberofPallets_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numLines = int.Parse(txt_numberofLines.Text);
                numPallets = int.Parse(txt_numberofPallets.Text);
                step = double.Parse(txt_step.Text);
                flagIncrease = rdB_increase.Checked;
                firstPalletinLine = double.Parse(txt_theBeginPosition.Text);
            }
            catch { };
        }

        private void txt_step_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numLines = int.Parse(txt_numberofLines.Text);
                numPallets = int.Parse(txt_numberofPallets.Text);
                step = double.Parse(txt_step.Text);
                flagIncrease = rdB_increase.Checked;
                firstPalletinLine = double.Parse(txt_theBeginPosition.Text);
            }
            catch { };
        }

        private void txt_theBeginningPosition_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numLines = int.Parse(txt_numberofLines.Text);
                numPallets = int.Parse(txt_numberofPallets.Text);
                step = double.Parse(txt_step.Text);
                flagIncrease = rdB_increase.Checked;
                firstPalletinLine = double.Parse(txt_theBeginPosition.Text);
            }
            catch { };
        }


        private void button1_Click(object sender, EventArgs e)
        {
            update();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(""+getPallet(0,2).loc.X);
            MessageBox.Show("" + getPallet(0, 2).loc.X);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
