using Snap7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SiemensSimulator
{
    public partial class Form1 : Form
    {
        static S7Server Server;

        static S7Server.TSrvCallback TheEventCallBack; // <== Static var containig the callback

        delegate void AsynUpdateUI(string status);


        const int size = 1024;


        static byte[] buf1 = new byte[size];
        static byte[] buf2 = new byte[size];
        static byte[] buf3 = new byte[size];
        static byte[] buf4 = new byte[size];
        static byte[] buf5 = new byte[size];
        static byte[] buf6 = new byte[size];
        static byte[] buf7 = new byte[size];
        static byte[] buf8 = new byte[size];
        static byte[] buf9 = new byte[size];
        static byte[] buf10 = new byte[size];

        static Dictionary<byte[], int> data = new Dictionary<byte[], int>();

        public Form1()
        {
            InitializeComponent();

            data.Add(buf1, 0);
            data.Add(buf2, 0);
            data.Add(buf3, 0);
            data.Add(buf4, 0);
            data.Add(buf5, 0);
            data.Add(buf6, 0);
            data.Add(buf7, 0);
            data.Add(buf8, 0);
            data.Add(buf9, 0);
            data.Add(buf10, 0);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Server = new S7Server();

            TheEventCallBack = new S7Server.TSrvCallback(EventCallback);
            Server.SetEventsCallBack(TheEventCallBack, IntPtr.Zero);

            int Error = Server.Start();

            showMsg("Start:" + Error);

            var dbs = ConfigurationManager.AppSettings["dbs"];
            if (!string.IsNullOrEmpty(dbs))
            {
                foreach (var cmd in dbs.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Reg(cmd);
                }
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            Reg(this.cb_num.Text);

        }

        private void Reg(string str)
        {
            var num = 0;

            if (int.TryParse(str, out num))
            {
                if (!data.ContainsValue(num))
                {
                    var item = data.FirstOrDefault(x => x.Value == 0);

                    if (item.Key == null)
                    {
                        showMsg("注册失败:超过限制数量" + data.Count);
                        return;
                    }

                    data[item.Key] = num;

                    int Error = Server.RegisterArea(S7Server.srvAreaDB, num, item.Key, item.Key.Length);

                    showMsg("注册" + Error + ":DB" + num + "大小" + item.Key.Length + "字节");

                    this.cb_num.Items.Add(num);

                }
            }
        }

        void EventCallback(IntPtr usrPtr, ref S7Server.USrvEvent Event, int Size)
        {
            var msg = Server.EventText(ref Event);
            Log.Logger.TraceLog(msg);
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            var num = 0;

            if (int.TryParse(this.cb_num.Text, out num))
            {
                if (data.ContainsValue(num))
                {
                    var item = data.FirstOrDefault(x => x.Value == 0);

                    if (item.Key == null)
                    {
                        showMsg("DB" + num + "未注册");
                        return;
                    }

                    data[item.Key] = 0;

                    int Error = Server.UnregisterArea(S7Server.srvAreaDB, num);

                    showMsg("移除" + Error + ":DB" + num);

                    this.cb_num.Items.Remove(num);

                }
            }
        }

        void showMsg(string msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (string s)
                {
                    this.tb_msg.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "->" + msg + "\r\n";
                }), msg);
            }
            else
            {
                this.tb_msg.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "->" + msg + "\r\n";
            }
        }

    }
}
