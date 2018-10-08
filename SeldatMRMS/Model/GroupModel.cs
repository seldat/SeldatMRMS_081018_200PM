using Newtonsoft.Json.Linq;
using SeldatMRMS.Management;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SeldatMRMS.Model
{
    public partial class GroupModel : Form
    {

        public List<StationModel> stationRegistrationList;
        public List<ChargerModel> chargerRegistrationList;
        public List<ReadyModel> readyRegistrationList;

        public List<PathModel> pathRegistrationList;
        public List<HighwayModel> highwayRegistrationList;

        public List<CheckinModel> checkinRegistrationList;
        public List<CheckoutModel> checkoutRegistrationList;

        public GroupModel()
        {
            InitializeComponent();
            stationRegistrationList = RegistrationAgent.stationRegistrationList;
            chargerRegistrationList = RegistrationAgent.chargerRegistrationList;
            readyRegistrationList = RegistrationAgent.readyRegistrationList;
            pathRegistrationList = RegistrationAgent.pathRegistrationList;
            highwayRegistrationList = RegistrationAgent.highwayRegistrationList;
            checkinRegistrationList = RegistrationAgent.checkinRegistrationList;
            checkoutRegistrationList = RegistrationAgent.checkoutRegistrationList;



        }

        private void GroupModel_Load(object sender, EventArgs e)
        {
            cb_type.Items.Add("Highway");
            //    if (highwayRegistrationList.Count != 0)
            //    {
            //        cb_type.Items.Add("Highway");
            //        foreach (HighwayModel item in highwayRegistrationList)
            //        {
            //            cb_item.Items.Add(item.properties.NameID);
            //        }
            //    }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            createJsonstring();
            //Console.WriteLine(treeView1.Focused);
        }
        

        private void btn_add_Click(object sender, EventArgs e)
        {
            if ((cb_type.Text != "") &&
                (cb_item.Text != ""))
            {
                if (treeView1.SelectedNode != null)
                {
                    if (cb_type.Text == "Highway")
                    {
                        TreeNode newNode = new TreeNode(cb_item.Text);
                        newNode.Name = cb_item.Text;
                        treeView1.Nodes.Add(newNode);
                        cb_item.Items.Remove(cb_item.SelectedItem);
                        if (cb_item.Items.Count != 0)
                        {
                            cb_item.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        TreeNode newNode = new TreeNode(cb_item.Text);
                        newNode.Name = cb_item.Text;
                        treeView1.SelectedNode.Nodes.Add(newNode);
                        cb_item.Items.Remove(cb_item.SelectedItem);
                        if (cb_item.Items.Count != 0)
                        {
                            cb_item.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    if (cb_type.Text == "Highway")
                    {
                        TreeNode newNode = new TreeNode(cb_item.Text);
                        newNode.Name = cb_item.Text;
                        treeView1.Nodes.Add(newNode);
                        cb_item.Items.Remove(cb_item.SelectedItem);
                        if (cb_item.Items.Count != 0)
                        {
                            cb_item.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void btn_view_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = createJsonstring().ToString();
        }

        private void cb_type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cb_type_change();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show(e.Node.Text);
            selected_node_change();
        }

        public JObject createJsonstring()
        {
            dynamic product = new JObject();
            dynamic content = new JObject();
            dynamic depend = new JObject();


            dynamic contentHighwayArray = new JArray();
            dynamic contentCheckinArray = new JArray();
            dynamic contentCheckoutArray = new JArray();
            dynamic contentDockingArray = new JArray();
            dynamic contentPutawayArray = new JArray();
            dynamic contentMixedArray = new JArray();
            dynamic contentReadyArray = new JArray();
            dynamic contentChargerArray = new JArray();
            dynamic contentHalfpointArray = new JArray();
            foreach(HighwayModel temp in RegistrationAgent.highwayRegistrationList)
            {
                dynamic tempitem = new JObject();
                tempitem.name = temp.properties.NameKey;
                contentHighwayArray.Add(tempitem);
            }
            foreach (CheckinModel temp in RegistrationAgent.checkinRegistrationList)
            {
                dynamic tempitem = new JObject();
                tempitem.name = temp.props.NameKey;
                dynamic loc = new JObject();
                loc.X = temp.props.X;
                loc.Y = temp.props.Y;
                tempitem.loc = loc;
                contentCheckinArray.Add(tempitem);
            }
            foreach (CheckoutModel temp in RegistrationAgent.checkoutRegistrationList)
            {
                dynamic tempitem = new JObject();
                tempitem.name = temp.props.NameKey;
                dynamic loc = new JObject();
                loc.X = temp.props.X;
                loc.Y = temp.props.Y;
                tempitem.loc = loc;
                contentCheckoutArray.Add(tempitem);
            }
            foreach (StationModel temp in RegistrationAgent.stationRegistrationList)
            {
                if (temp.props.typeName == "DOCKING")
                {
                    dynamic tempitem = new JObject();
                    tempitem.name = temp.props.NameKey;
                    contentDockingArray.Add(tempitem);
                }
            }
            foreach (StationModel temp in RegistrationAgent.stationRegistrationList)
            {
                if (temp.props.typeName == "PUTAWAY")
                {
                    dynamic tempitem = new JObject();
                    tempitem.name = temp.props.NameKey;
                    contentPutawayArray.Add(tempitem);
                }
            }
            foreach (StationModel temp in RegistrationAgent.stationRegistrationList)
            {
                if (temp.props.typeName == "MIXED")
                {
                    dynamic tempitem = new JObject();
                    tempitem.name = temp.props.NameKey;
                    contentMixedArray.Add(tempitem);
                }
            }
            foreach (ReadyModel temp in RegistrationAgent.readyRegistrationList)
            {
                dynamic tempitem = new JObject();
                tempitem.name = temp.props.NameKey;
                contentReadyArray.Add(tempitem);
            }
            foreach (ChargerModel temp in RegistrationAgent.chargerRegistrationList)
            {
                dynamic tempitem = new JObject();
                tempitem.name = temp.props.NameKey;
                contentChargerArray.Add(tempitem);
            }


            content.highway = contentHighwayArray;
            content.checkin = contentCheckinArray;
            content.checkout = contentCheckoutArray;
            content.docking = contentDockingArray;
            content.putaway = contentPutawayArray;
            content.mixed = contentMixedArray;
            content.charger = contentChargerArray;
            content.ready = contentReadyArray;
            //content.halfpoint = contentHighwayArray;

            product.content = content;
            //=====================================
            dynamic depend_highway_Array = new JArray();
            foreach (TreeNode n in treeView1.Nodes) //Highway Nodes
            {
                dynamic depend_highway_item = new JObject();
                depend_highway_item.name = n.Name;
                dynamic highway_checkin_Array = new JArray();
                dynamic highway_checkout_Array = new JArray();
                foreach (TreeNode tn in n.Nodes)//Checkin node, Checkout node
                {
                    dynamic highway_checkin_item = new JObject();
                    dynamic highway_checkout_item = new JObject();
                    if (tn.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "CKI")
                    {
                        dynamic checkin_docking_Array = new JArray();
                        dynamic checkin_putaway_Array = new JArray();
                        dynamic checkin_mixed_Array = new JArray();
                        dynamic checkin_charger_Array = new JArray();
                        dynamic checkin_ready_Array = new JArray();

                        highway_checkin_item.name = tn.Name;
                        foreach (TreeNode tnc in tn.Nodes)
                        {

                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "DCK")
                            {
                                checkin_docking_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "PAW")
                            {
                                checkin_putaway_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "MIX")
                            {
                                checkin_mixed_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "CHG")
                            {
                                checkin_charger_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "RDY")
                            {
                                checkin_ready_Array.Add(tnc.Name);
                            }

                        }
                        highway_checkin_item.docking = checkin_docking_Array;
                        highway_checkin_item.putaway = checkin_putaway_Array;
                        highway_checkin_item.mixed = checkin_mixed_Array;
                        highway_checkin_item.charger = checkin_charger_Array;
                        highway_checkin_item.ready = checkin_ready_Array;
                        highway_checkin_Array.Add(highway_checkin_item);
                    }
                    if (tn.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "CKO")
                    {
                        dynamic checkout_docking_Array = new JArray();
                        dynamic checkout_putaway_Array = new JArray();
                        dynamic checkout_mixed_Array = new JArray();
                        dynamic checkout_charger_Array = new JArray();
                        dynamic checkout_ready_Array = new JArray();

                        highway_checkout_item.name = tn.Name;
                        foreach (TreeNode tnc in tn.Nodes)
                        {

                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "DCK")
                            {
                                checkout_docking_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "PAW")
                            {
                                checkout_putaway_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "MIX")
                            {
                                checkout_mixed_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "CHG")
                            {
                                checkout_charger_Array.Add(tnc.Name);
                            }
                            if (tnc.Name.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0, 3) == "RDY")
                            {
                                checkout_ready_Array.Add(tnc.Name);
                            }

                        }
                        highway_checkout_item.docking = checkout_docking_Array;
                        highway_checkout_item.putaway = checkout_putaway_Array;
                        highway_checkout_item.mixed = checkout_mixed_Array;
                        highway_checkout_item.charger = checkout_charger_Array;
                        highway_checkout_item.ready = checkout_ready_Array;
                        highway_checkout_Array.Add(highway_checkout_item);
                    }

                }
                depend_highway_item.checkin = highway_checkin_Array;
                depend_highway_item.checkout = highway_checkout_Array;
                depend_highway_Array.Add(depend_highway_item);
            }
            depend.highway = depend_highway_Array;
            product.depend = depend;
            
            return product;

        }

        

        private void selected_node_change ()
        {
            //Console.WriteLine(treeView1.SelectedNode.Name);
            switch (treeView1.SelectedNode.Text.Split(new[] { " --- " }, StringSplitOptions.None)[0].Substring(0,3))
            {
                case "HWA":
                    {
                        cb_type.Items.Clear();
                        cb_item.Items.Clear();
                        cb_type.Items.Add("Highway");
                        cb_type.Items.Add("Check-in");
                        cb_type.Items.Add("Check-out");
                        cb_type.SelectedIndex = 0;
                        cb_type_change();
                        break;
                    }
                case "CKI":
                    {
                        cb_type.Items.Clear();
                        cb_item.Items.Clear();
                        cb_type.Items.Add("Station");
                        cb_type.Items.Add("Charger");
                        cb_type.Items.Add("Ready");
                        cb_type.SelectedIndex = 0;
                        cb_type_change();
                        break;
                    }
                case "CKO":
                    {
                        cb_type.Items.Clear();
                        cb_item.Items.Clear();
                        cb_type.Items.Add("Station");
                        cb_type.Items.Add("Charger");
                        cb_type.Items.Add("Ready");
                        cb_type.SelectedIndex = 0;
                        cb_type_change();
                        break;
                    }
                default:
                    {
                        cb_type.Items.Clear();
                        cb_item.Items.Clear();
                        break;
                    }
            }
        }

        private void cb_type_change()
        {
            if (cb_type.Text != "")
            {
                switch (cb_type.Text)
                {
                    case "Highway":
                        {
                            cb_item.Items.Clear();
                            if (RegistrationAgent.highwayRegistrationList.Count != 0)
                            {
                                foreach (HighwayModel item in RegistrationAgent.highwayRegistrationList)
                                {
                                    if (!CallRecursive(treeView1, item.properties.NameKey))
                                    {
                                        cb_item.Items.Add(item.properties.NameKey);
                                    }
                                }
                            }
                            break;
                        }
                    case "Check-in":
                        {
                            cb_item.Items.Clear();
                            if (RegistrationAgent.checkinRegistrationList.Count != 0)
                            {
                                foreach (CheckinModel item in RegistrationAgent.checkinRegistrationList)
                                {
                                    if (!CallRecursive(treeView1, item.props.NameKey))
                                    {
                                        cb_item.Items.Add(item.props.NameKey);
                                    }
                                }
                            }
                            break;
                        }
                    case "Check-out":
                        {
                            cb_item.Items.Clear();
                            if (RegistrationAgent.checkoutRegistrationList.Count != 0)
                            {
                                foreach (CheckoutModel item in RegistrationAgent.checkoutRegistrationList)
                                {
                                    if (!CallRecursive(treeView1, item.props.NameKey))
                                    {
                                        cb_item.Items.Add(item.props.NameKey);
                                    }
                                }
                            }
                            break;
                        }
                    case "Station":
                        {
                            cb_item.Items.Clear();
                            if (RegistrationAgent.stationRegistrationList.Count != 0)
                            {
                                foreach (StationModel item in RegistrationAgent.stationRegistrationList)
                                {
                                    if (!CallRecursive(treeView1, item.props.NameKey))
                                    {
                                        cb_item.Items.Add(item.props.NameKey);
                                    }
                                }
                            }
                            break;
                        }
                    case "Charger":
                        {
                            cb_item.Items.Clear();
                            if (RegistrationAgent.chargerRegistrationList.Count != 0)
                            {
                                foreach (ChargerModel item in RegistrationAgent.chargerRegistrationList)
                                {
                                    if (!CallRecursive(treeView1, item.props.NameKey))
                                    {
                                        cb_item.Items.Add(item.props.NameKey);
                                    }
                                }
                            }
                            break;
                        }
                    case "Ready":
                        {
                            cb_item.Items.Clear();
                            if (RegistrationAgent.readyRegistrationList.Count != 0)
                            {
                                foreach (ReadyModel item in RegistrationAgent.readyRegistrationList)
                                {
                                    if (!CallRecursive(treeView1, item.props.NameKey))
                                    {
                                        cb_item.Items.Add(item.props.NameKey);
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        {
                            cb_item.Items.Clear();
                            break;
                        }
                }
            }
        }
        

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode nodeClicked;
            // Get the node clicked on
            nodeClicked = this.treeView1.GetNodeAt(e.X, e.Y);
            // Was the node clicked on?
            if (!(nodeClicked == null))
            {
                Console.WriteLine("Node is: " + nodeClicked.Name);

            }
            else
            {
                Console.WriteLine("No node clicked.");
                treeView1.SelectedNode = null;
                cb_type.Items.Clear();
                cb_item.Items.Clear();
                cb_type.Items.Add("Highway");
                cb_type.SelectedIndex = 0;
                cb_type_change();
            }
            if (e.Button == MouseButtons.Right)
                this.treeView1.SelectedNode = nodeClicked;
        }

        private bool PrintRecursive(TreeNode treeNode, string nodeName)
        {
            // Print the node.  
            //System.Diagnostics.Debug.WriteLine(treeNode.Text);
            //MessageBox.Show(treeNode.Text);
            // Print each node recursively.
            bool result = false;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Name == nodeName)
                {
                    return true;
                }
                else
                {
                    result= PrintRecursive(tn, nodeName);
                    if (result)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        // Call the procedure using the TreeView.  
        private bool CallRecursive(TreeView treeView, string nodeName)
        {
            // Print each node recursively.
            bool result = false;
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                if (n.Name == nodeName)
                {
                    return true;
                }
                else
                {
                    result= PrintRecursive(n, nodeName);
                    if (result)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

        }
    }
}
