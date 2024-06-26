﻿using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NRemote
{
    public partial class frmMain : Form
    {
        delegate int delegateHookCallback(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, delegateHookCallback lpfn, IntPtr hMod, uint dwThreadId);
        delegateHookCallback mouseHookProc = null;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        IntPtr hookPtr = IntPtr.Zero;




        bool CaptureStart = false;
        int imgwidth = 0, imgheight = 0;
        Message message = new Message();
        List<KeyInfo> KeyDownCtlKeys = new List<KeyInfo>();
        public frmMain()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += MouseEvents;
            停止ToolStripMenuItem.Enabled = false;
            this.Text += $" <Ver:{Application.ProductVersion}>";
            Hook();
        }


        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmSetting();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CaptureStart = true;
                backgroundWorker1.RunWorkerAsync();
                停止ToolStripMenuItem.Enabled = true;
                開始ToolStripMenuItem.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            using (var capture = new VideoCapture())
            {
                capture.Open(Properties.Settings.Default.CameraID);

                capture.FrameHeight = Properties.Settings.Default.H;
                capture.FrameWidth = Properties.Settings.Default.W;
                message.Height = capture.FrameHeight;
                message.Width = capture.FrameWidth;


                imgheight = capture.FrameHeight;
                imgwidth = capture.FrameWidth;
                if (!capture.IsOpened())
                {
                    throw new Exception("capture initialization failed");
                }

                Invoke(new Action(() =>
                {
                    this.Height = this.Height + imgheight - pictureBox1.Height;
                    this.Width = this.Width + imgwidth - pictureBox1.Width;
                }));
                try { 
                serialPort1.PortName = $"COM{Properties.Settings.Default.COM}";
                serialPort1.Open();
                }catch(Exception ex)
                {
                    MessageBox.Show("COMポートがOpenできません。","",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CaptureStart = false;
                    停止ToolStripMenuItem.Enabled = false;
                    開始ToolStripMenuItem.Enabled = true;
                    return;
                }

                Mat mat = new Mat();
                while (CaptureStart)
                {
                    try
                    {

                        capture.Read(mat);
                        if (mat.Empty())
                        {
                            continue;
                        }

                        if (mat.Size().Width > 0)
                        {
                            pictureBox1.Image = BitmapConverter.ToBitmap(mat);
                        }
                        Task.Delay(50);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureStart = false;
            停止ToolStripMenuItem.Enabled = false;
            開始ToolStripMenuItem.Enabled = true;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (CaptureStart)
            {
                pictureBox1.Cursor = Cursors.Cross;
            }
            else
            {
                pictureBox1.Cursor = Cursors.Default;
            }
        }


        public void Hook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                // フックを行う
                // 第1引数   フックするイベントの種類
                //   13はキーボードフックを表す
                // 第2引数 フック時のメソッドのアドレス
                //   フックメソッドを登録する
                // 第3引数   インスタンスハンドル
                //   現在実行中のハンドルを渡す
                // 第4引数   スレッドID
                //   0を指定すると、すべてのスレッドでフックされる
                var currentProcess = Process.GetCurrentProcess();
                mouseHookProc = HookCallback;
                hookPtr = SetWindowsHookEx(
                    13,
                    mouseHookProc,
                    GetModuleHandle(curModule.ModuleName),
                  0
                );
            }
        }

        public void HookEnd()
        {
            UnhookWindowsHookEx(hookPtr);
            hookPtr = IntPtr.Zero;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            HookEnd();
        }



        int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (this.Focused == false) return 0;
            if (serialPort1.IsOpen == false) return 0;
            // フックしたキー
            // Debug.WriteLine($"{(Keys)(short)Marshal.ReadInt32(lParam)} {((short)Marshal.ReadInt32(lParam)).ToString("x")}" );
            var key = message.GetSendKeyCode((short)Marshal.ReadInt32(lParam));
            var param = (short)wParam;
            byte[] sendData;
            switch (param)
            {
                case 0x100:
                    Debug.WriteLine($"Key Dn:{key.KeyName} 0x{key.SendKeyCode.ToString("X")}");
                    if (key.CtlKey)
                    {
                        if (KeyDownCtlKeys.Any(X => X == key) == false) KeyDownCtlKeys.Add(key);
                        sendData = message.getKebordMessage(KeyDownCtlKeys.ToArray());
                        serialPort1.Write(sendData, 0, sendData.Length);
                    }
                    else
                    {
                        var keyList = KeyDownCtlKeys.ToList();
                        keyList.Add(key);
                        sendData = message.getKebordMessage(keyList.ToArray());
                        serialPort1.Write(sendData, 0, sendData.Length);
                    }
                    break;
                case 0x101:
                    Debug.WriteLine($"Key Up:{key.KeyName} 0x{key.SendKeyCode.ToString("X")}");
                    if (key.CtlKey)
                    {
                        KeyDownCtlKeys.RemoveAll(X => X == key);
                        sendData = message.getKebordMessage(null);
                        serialPort1.Write(sendData, 0, sendData.Length);
                        sendData = message.getKebordMessage(KeyDownCtlKeys.ToArray());
                        serialPort1.Write(sendData, 0, sendData.Length);
                    }
                    else
                    {
                        sendData = message.getKebordMessage(null);
                        serialPort1.Write(sendData, 0, sendData.Length);
                    }

                    break;
                default:
                    break;
            }

            return 1;
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {



        }

        bool LeftButton;
        bool RightButton;
        bool MiddleButton;

        private void MouseEvents(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (this.Focused == false) return;
            if (serialPort1.IsOpen == false) return;

            LeftButton = e.Button == MouseButtons.Left;
            RightButton = e.Button == MouseButtons.Right;
            MiddleButton = e.Button == MouseButtons.Middle;
           int mouseWheel=  e.Delta /120;
            System.Drawing.Point point = new System.Drawing.Point(pos.X, pos.Y);
            byte[] sendData = message.getMouseMessage(point, LeftButton, RightButton, MiddleButton, mouseWheel);
            serialPort1.Write(sendData, 0, sendData.Length);

        }
    }
}
