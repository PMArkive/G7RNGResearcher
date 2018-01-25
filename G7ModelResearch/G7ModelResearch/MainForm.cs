using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G7ModelResearch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ntrclient = new NtrClient();
            ntrclient.Connect += OnConnected;
            ntrclient.Message += OnMsgArrival;
            IP.Text = Properties.Settings.Default.IP;
            ntrclient.setServer(IP.Text, 8000);
            B_Connect_Click(null, null);
        }
        private static NtrClient ntrclient;
        private static List<Model> ModelStatus = new List<Model>();

        private void NTR_Timer_Tick(object sender, EventArgs e)
        {
            try { ntrclient.sendHeartbeatPacket(); } catch { }
        }

        private void OnConnected(object sender, EventArgs e)
        {
            if (ntrclient.port == 8000)
            {
                Log.Items.Add("Console Connected");
                Properties.Settings.Default.IP = IP.Text;
                Properties.Settings.Default.Save();
                B_Connect.Enabled = false;
                B_Disconnect.Enabled = true;
                NTR_Timer.Enabled = true;
                ntrclient.listprocess();
            }
        }

        private void OnDisconnected(bool Success = true)
        {
            Log.Items.Add(Success ? "Disconnected" : "No Connection");
            NTR_Timer.Enabled = false;
            B_Connect.Enabled = true;
            B_Disconnect.Enabled = false;
        }

        private int ModelIndex;
        private int lastModelNumber;
        private int Time;
        private void OnMsgArrival(object sender, NtrClient.InfoEventArgs e)
        {
            Invoke(new Action(() =>
            {
                switch (e.info)
                {
                    case "Breakpoint":
                        uint[] output = (uint[])e.data;
                        if (output[0] == 2) // 1 Graphic Frame
                        {
                            if (ModelIndex == lastModelNumber)
                            {
                                Time++;
                                Log.Items.RemoveAt(Math.Max(0, Log.Items.Count - 1));
                            }
                            else
                            {
                                Time = 1;
                                lastModelNumber = ModelIndex;
                            }
                            if (ModelIndex > 0)
                                Log.Items.Add("ModelNumber:" + lastModelNumber.ToString() + "\t\t x " + Time.ToString());
                            UpdateModel();
                            DGV.DataSource = new BindingSource(ModelStatus.Select(t => t.Clone()).ToArray(), null);
                            DGV.CurrentCell = null;
                            RemoveFlag();
                            ModelIndex = 0;
                        }
                        else if (output[0] == 3) // Blink
                        {
                            var a = ModelStatus.FirstOrDefault(m => m.address == output[2]);
                            if (a == null)
                            {
                                ModelStatus.Add(new Model
                                {
                                    Index = ModelIndex++,
                                    address = output[2],
                                });
                            }
                            else
                                a.Index = ModelIndex++;
                        }
                        else // Other usage
                        {
                            if (ModelIndex > 0)
                                Log.Items.Add(ModelIndex.ToString() + "Model Passed");
                            Time = 0;
                            switch (output[0])
                            {
                                case 4:
                                    Log.Items.Add("Lead Ability Check");
                                    break;
                            }
                            Log.Items.Add("ModelNumber:" + lastModelNumber.ToString() + "\t\t x 0");
                        }
                        ntrclient.resume();
                        break;
                    case "Disconnect":
                        B_Disconnect_Click(null, null);
                        return;
                    case null:
                        Log.Items.Add((string)e.data);
                        return;
                }
            }));
        }

        private void UpdateModel()
        {
            foreach (var A in ModelStatus)
                A.Data = ntrclient.SingleThreadRead(A.address, Model.Size);
        }

        private void RemoveFlag()
        {
            foreach (var A in ModelStatus)
                A.Index = -1;
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            ntrclient.setServer(IP.Text, 8000);
            try
            {
                ntrclient.connectToServer();
            }
            catch
            {
                OnDisconnected(false);
            }
        }

        private void B_Disconnect_Click(object sender, EventArgs e)
        {
            ntrclient.disconnect();
            OnDisconnected();
        }

        private void B_run_Click(object sender, EventArgs e)
        {
        }

        private void B_Enable_Click(object sender, EventArgs e)
        {
            ntrclient.Enable();
        }

        private void B_Disable_Click(object sender, EventArgs e)
        {
            try { ntrclient.Disable(); } catch { };
        }

        private void B_Clear_Click(object sender, EventArgs e)
        {
            Log.Items.Clear();
            ModelStatus.Clear();
            ModelIndex = lastModelNumber = Time = 0;
        }
    }
}
