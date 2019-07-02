using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using MaterialIcons;
using MahApps.Metro;
using MaterialDesignThemes;
using MaterialSkin;
using MetroSet_UI.Controls;
using MetroSet_UI.Forms;
using System.IO.Ports;
using System.Threading;


namespace AkuApp
{

    
    public partial class Form1 : MetroSetForm
    {
       private SerialPort _sport = new SerialPort();
       private int counters = 0;
       private values value;
       private string textt;
       public Form1() // CONSTRACTIR
        {

            InitializeComponent();

            // Seri port zaman aşımı değerini 1500 milisaniye olarak belirledik
            //
            //  SERİ PORTU BAĞLAMA - CONNECT TO SERİAL PORT 
            //
            _sport.BaudRate = 115200;
            _sport.PortName = "COM3";
            _sport.DataBits = 8;
            _sport.Parity = Parity.None;
            _sport.StopBits = StopBits.One;
               
            _sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);

            _sport.Open();
            /*
             *  Other connect method. / Diğer bağlanma metodu
             *  SerialPort sp = new SerialPort("COM1",115200,Parity.None,8,StopBits.One);
             */

            this.Closing += Form1_Closing;
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {

            _sport.Close();
        }

        void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /* TextBox.CheckForIllegalCrossThreadCalls = false;
            char[] veri = new char[_sport.ReadBufferSize];
            listBox1.Items.Add(veri);
            */
            string data = _sport.ReadLine();       // bufferdan verileri oku
            if (!string.IsNullOrEmpty(data))
            {       
                if (listBox1.InvokeRequired)
                {
                    if (counters < 6)
                    { 
                    listBox1.Invoke(new Action(() =>
                    {
                        listBox1.Items.Add(data);


                        if (counters == 1)
                        {
                            //textt = data.Substring(18, 5);
                            //cell_1_lb.Text = textt.Substring(0,2)+","+textt.Substring(2,2);
                            //texting = data.ToString(); #Eltebliğ
                            cell_1_lb.Text = data.Substring(18, 1) + "," + data.Substring(19, 3);
                            cell_2_lb.Text = data.Substring(23, 1) + "," + data.Substring(24, 3);
                            cell_3_lb.Text = data.Substring(28, 1) + "," + data.Substring(29, 3);
                            cell_4_lb.Text = data.Substring(33, 1) + "," + data.Substring(34, 3);
                            cell_5_lb.Text = data.Substring(38, 1) + "," + data.Substring(39, 3);
                            cell_6_lb.Text = data.Substring(43, 1) + "," + data.Substring(44, 3);
                            cell_7_lb.Text = data.Substring(48, 1) + "," + data.Substring(49, 3);
                        }

                        if (counters == 2)
                        {

                            Vtotal_tb.Text = data.Substring(13, 2) + "," + data.Substring(15, 1)+" V";
                           Watt_tb.Text = data.Substring(23, 6)+ " W";
                           EWh_tb.Text = data.Substring(30, 6);
                           EAH_tb.Text = data.Substring(37, 5) + " Ah";
                           Current_tb.Text = data.Substring(17, 4) + "," + data.Substring(21, 1) + " A";
                           if(Int32.Parse(data.Substring(43, 3))<100)
                            SOC_tb.Text="%"+data.Substring(44, 2) ;
                           else
                           {
                               SOC_tb.Text = "%" + data.Substring(43, 3);
                           }


                        }

                        if (counters == 3)
                        {

                            temperature_1_tb.Text = data.Substring(13, 3) + "," + data.Substring(16, 1)+"°C";
                            temperature_2_tb.Text = data.Substring(18, 3) + "," + data.Substring(20, 1) + "°C";
                            temperature_3_tb.Text = data.Substring(23, 3) + "," + data.Substring(25, 1) + "°C";
                            temperature_intT1_tb.Text = data.Substring(28, 3) + "," + data.Substring(30, 1) + "°C";


                        }

                    }));
                 //   val=value.valuess(data, counters); #Eltebliğ
                   
                        counters++;
                    

                    }
                    
                    if (counters == 6)
                        counters = 0;
                   // Thread.Sleep(1000);

                }
            }

        }


    }


}
