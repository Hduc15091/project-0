using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using SymbolFactoryDotNet;

namespace he_thong_xu_ly_nuoc_thai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region skip
        private void standardControl1_Load(object sender, EventArgs e)
        {

        }

        private void standardControl12_Load(object sender, EventArgs e)
        {

        }

        private void standardControl2_Load(object sender, EventArgs e)
        {

        }

        private void standardControl8_Load(object sender, EventArgs e)
        {

        }
        

        private void standardControl44_Load(object sender, EventArgs e)
        {

        }
        

       

        private void label19_Click(object sender, EventArgs e)
        {

        }
        

        private void label27_Click(object sender, EventArgs e)
        {

        }
        #endregion
        Plc _PLC = new Plc(CpuType.S71200, "192.168.1.6", 0, 0);
        byte[] Output = new byte[10];
        byte[] Memo = new byte[20];
        byte[] Input = new byte[20];
        private void ON_OFF(StandardControl sd, bool value)
        {
            if (value == true)
            {
                sd.DiscreteValue1 = true;
            }
            else sd.DiscreteValue1 = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _PLC.Open();
            if (_PLC.IsConnected == true)
            {
                MessageBox.Show("Connected!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Interval = 1000;
                timer1.Enabled = true;
                grbThietLap.Visible = false;
                
            }
            else
                MessageBox.Show("Error!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void thietLapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbThietLap.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region denLed
            Memo = _PLC.ReadBytes(DataType.Memory, 0, 0, 15);
            if (Memo[10].SelectBit(0) == true)
            {
                ON_OFF(sdLED, true);
            }
            else ON_OFF(sdLED, false);
            #endregion

            

            #region bom/van
            Output = _PLC.ReadBytes(DataType.Output , 0, 0, 1);
            if (Output[0].SelectBit(2) == true)
            {
                ON_OFF(sdPump3, true);
            }
            else ON_OFF(sdPump3, false);

            if (Output[0].SelectBit(0) == true)
            {
                ON_OFF(sdPump1, true);
            }
            else ON_OFF(sdPump1, false);

            if (Output[0].SelectBit(1) == true)
            {
                ON_OFF(sdPump2, true);
            }
            else ON_OFF(sdPump2, false);

            if (Output[0].SelectBit(4) == true)
            {
                ON_OFF(sdValve1, true);
            }
            else ON_OFF(sdValve1, false);

            if (Output[0].SelectBit(5) == true)
            {
                ON_OFF(sdValve2, true);
            }
            else ON_OFF(sdValve2, false);

            if (Output[0].SelectBit(3) == true)
            {
                ON_OFF(sdPump4, true);
            }
            else ON_OFF(sdPump4, false);
            #endregion 
        }
        #region senserOn/off
        private void btnOn_1T_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.2", true);
            ON_OFF(sdSS1_Low, true);
            btnOn_1T.BackColor = Color.LimeGreen;
            btnOff_1T.BackColor = Color.Gainsboro;
        }

        private void btnOff_1T_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.2", false);
            ON_OFF(sdSS1_Low, false);
            btnOn_1T.BackColor = Color.Gainsboro;
            btnOff_1T.BackColor = Color.Red;
        }

        private void btnOn_1C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.3", true);
            ON_OFF(sdSS1_HIgh, true);
            btnOn_1C.BackColor = Color.LimeGreen;
            btnOff_1C.BackColor = Color.Gainsboro;
        }

        private void btnOff_1C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.3", false);
            ON_OFF(sdSS1_HIgh, false);
            btnOn_1C.BackColor = Color.Gainsboro;
            btnOff_1C.BackColor = Color.Red;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.4", true);
            ON_OFF(sdSS2_Low, true);
            btnOn_2T.BackColor = Color.LimeGreen;
            btnOff_2T.BackColor = Color.Gainsboro;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.4", false);
            ON_OFF(sdSS2_Low, false);
            btnOn_2T.BackColor = Color.Gainsboro;
            btnOff_2T.BackColor = Color.Red;
        }

        private void btnOn_2C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.5", true);
            ON_OFF(sdSS2_HIgh, true);
            btnOn_2C.BackColor = Color.LimeGreen;
            btnOff_2C.BackColor = Color.Gainsboro;
        }

        private void btnOff_2C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.5", false);
            ON_OFF(sdSS2_HIgh, false);
            btnOn_2C.BackColor = Color.Gainsboro;
            btnOff_2C.BackColor = Color.Red;
        }

        private void btnOn_3T_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.6", true);
            ON_OFF(sdSS3_Low, true);
            btnOn_3T.BackColor = Color.LimeGreen;
            btnOff_3T.BackColor = Color.Gainsboro;

        }
        private void btnOff_3T_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.6", false);
            ON_OFF(sdSS3_Low, false);
            btnOn_3T.BackColor = Color.Gainsboro;
            btnOff_3T.BackColor = Color.Red;
        }

        private void btnOn_3C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.7", true);
            ON_OFF(sdSS3_HIgh, true);
            btnOn_3C.BackColor = Color.LimeGreen;
            btnOff_3C.BackColor = Color.Gainsboro;
        }

        private void btnOff_3C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.7", false);
            ON_OFF(sdSS3_HIgh, false);
            btnOn_3C.BackColor = Color.Gainsboro;
            btnOff_3C.BackColor = Color.Red;
        }

        private void btnOn_4T_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX1.0", true);
            ON_OFF(sdSS4_Low, true);
            btnOn_4T.BackColor = Color.LimeGreen;
            btnOff_4T.BackColor = Color.Gainsboro;
        }

        private void btnOff_4T_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX1.0", false);
            ON_OFF(sdSS4_Low, false);
            btnOn_4T.BackColor = Color.Gainsboro;
            btnOff_4T.BackColor = Color.Red;
        }

        private void btnOn_4C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX1.1", true);
            ON_OFF(sdSS4_HIgh, true);
            btnOn_4C.BackColor = Color.LimeGreen;
            btnOff_4C.BackColor = Color.Gainsboro;
        }

        private void btnOff_4C_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX1.1", false);
            ON_OFF(sdSS4_HIgh, false);
            btnOn_4C.BackColor = Color.Gainsboro;
            btnOff_4C.BackColor = Color.Red;
        }

        #endregion

        #region start/stop
        private void btnStart_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.0", true);
            _PLC.Write("DB4.DBX0.0", false);
            btnStart.BackColor = Color.LimeGreen;
            btnStop.BackColor = Color.Gainsboro;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _PLC.Write("DB4.DBX0.1", true);
            _PLC.Write("DB4.DBX0.1", false);       
            ON_OFF(sdSS1_Low, false);           
            ON_OFF(sdSS1_HIgh, false);                
            ON_OFF(sdSS2_Low, false);                
            ON_OFF(sdSS2_HIgh, false);
            ON_OFF(sdSS3_Low, false);                
            ON_OFF(sdSS3_HIgh, false);
            ON_OFF(sdSS4_Low, false);
            ON_OFF(sdSS4_HIgh, false);
            btnStart.BackColor = Color.Gainsboro;
            btnStop.BackColor = Color.Red;
            btnOn_1T.BackColor = Color.Gainsboro;
            btnOff_1T.BackColor = Color.Red;
            btnOn_1C.BackColor = Color.Gainsboro;
            btnOff_1C.BackColor = Color.Red;
            btnOn_2T.BackColor = Color.Gainsboro;
            btnOff_2T.BackColor = Color.Red;
            btnOn_2C.BackColor = Color.Gainsboro;
            btnOff_2C.BackColor = Color.Red;
            btnOn_3T.BackColor = Color.Gainsboro;
            btnOff_3T.BackColor = Color.Red;
            btnOn_3C.BackColor = Color.Gainsboro;
            btnOff_3C.BackColor = Color.Red;
            btnOn_4T.BackColor = Color.Gainsboro;
            btnOff_4T.BackColor = Color.Red;
            btnOn_4C.BackColor = Color.Gainsboro;
            btnOff_4C.BackColor = Color.Red;
        }
        #endregion


        #region thietlap
        private void btnSend_Click(object sender, EventArgs e)
        {
            _PLC.Write("MD20", int.Parse(txbTime_LP.Text));
            _PLC.Write("MD8", double.Parse(txbSetSalt.Text));
        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            _PLC.Write("MD4", double.Parse(txbSalt.Text));
        }

        
    }
}
