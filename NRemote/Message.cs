using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace NRemote
{
    public class Message
    {
        List<KeyInfo> _keys = new List<KeyInfo>();

        public int Height { get; set; }
        public int Width { get; set; }
        public Message()
        {
            _keys.Add(new KeyInfo(0x31, "1", 0x1E));
            _keys.Add(new KeyInfo(0x32, "2", 0x1F));
            _keys.Add(new KeyInfo(0x33, "3", 0x20));
            _keys.Add(new KeyInfo(0x34, "4", 0x21));
            _keys.Add(new KeyInfo(0x35, "5", 0x22));
            _keys.Add(new KeyInfo(0x36, "6", 0x23));
            _keys.Add(new KeyInfo(0x37, "7", 0x24));
            _keys.Add(new KeyInfo(0x38, "8", 0x25));
            _keys.Add(new KeyInfo(0x39, "9", 0x26));
            _keys.Add(new KeyInfo(0x30, "0", 0x27));


            _keys.Add(new KeyInfo(0x41, "A", 0x04));
            _keys.Add(new KeyInfo(0x42, "B", 0x05));
            _keys.Add(new KeyInfo(0x43, "C", 0x06));
            _keys.Add(new KeyInfo(0x44, "D", 0x07));
            _keys.Add(new KeyInfo(0x45, "E", 0x08));
            _keys.Add(new KeyInfo(0x46, "F", 0x09));
            _keys.Add(new KeyInfo(0x47, "G", 0x0A));
            _keys.Add(new KeyInfo(0x48, "H", 0x0B));
            _keys.Add(new KeyInfo(0x49, "I", 0x0C));
            _keys.Add(new KeyInfo(0x4A, "J", 0x0D));
            _keys.Add(new KeyInfo(0x4B, "K", 0x0E));
            _keys.Add(new KeyInfo(0x4C, "L", 0x0F));
            _keys.Add(new KeyInfo(0x4D, "M", 0x10));
            _keys.Add(new KeyInfo(0x4E, "N", 0x11));
            _keys.Add(new KeyInfo(0x4F, "O", 0x12));
            _keys.Add(new KeyInfo(0x50, "P", 0x13));
            _keys.Add(new KeyInfo(0x51, "Q", 0x14));
            _keys.Add(new KeyInfo(0x52, "R", 0x15));
            _keys.Add(new KeyInfo(0x53, "S", 0x16));
            _keys.Add(new KeyInfo(0x54, "T", 0x17));
            _keys.Add(new KeyInfo(0x55, "U", 0x18));
            _keys.Add(new KeyInfo(0x56, "X", 0x19));
            _keys.Add(new KeyInfo(0x57, "V", 0x1A));
            _keys.Add(new KeyInfo(0x58, "W", 0x1B));
            _keys.Add(new KeyInfo(0x59, "Y", 0x1C));
            _keys.Add(new KeyInfo(0x5A, "Z", 0x1D));
            _keys.Add(new KeyInfo(0xD, "Enter(左)", 0x28));
            _keys.Add(new KeyInfo(0x8, "Backspace", 0x2A));
            _keys.Add(new KeyInfo(0x9, "Tab", 0x2B));
            _keys.Add(new KeyInfo(0x20, "Space", 0x2C));
            _keys.Add(new KeyInfo(0xBD, "-", 0x2D));
            _keys.Add(new KeyInfo(0xDE, "^", 0x2E));
            _keys.Add(new KeyInfo(0xC0, "@", 0x2F));
            _keys.Add(new KeyInfo(0xDB, "[", 0x30));
            _keys.Add(new KeyInfo(0xDD, "]", 0x31));
            _keys.Add(new KeyInfo(0xBB, ";", 0x33));
            _keys.Add(new KeyInfo(0xBA, ":", 0x34));
             //_keys.Add(new KeyInfo(0xF3, "半角／全角", 0x35));
            //     _keys.Add(new KeyInfo(0xF4, "半角／全角", 0x35));
            _keys.Add(new KeyInfo(0xBC, ",", 0x36));
            _keys.Add(new KeyInfo(0xBE, ".", 0x37));
            _keys.Add(new KeyInfo(0xBF, "/", 0x38));
            _keys.Add(new KeyInfo(0xF0, "Caps Lock", 0x39));
            _keys.Add(new KeyInfo(0x70, "F1", 0x3A));
            _keys.Add(new KeyInfo(0x71, "F2", 0x3B));
            _keys.Add(new KeyInfo(0x72, "F3", 0x3C));
            _keys.Add(new KeyInfo(0x73, "F4", 0x3D));
            _keys.Add(new KeyInfo(0x74, "F5", 0x3E));
            _keys.Add(new KeyInfo(0x75, "F6", 0x3F));
            _keys.Add(new KeyInfo(0x76, "F7", 0x40));
            _keys.Add(new KeyInfo(0x77, "F8", 0x41));
            _keys.Add(new KeyInfo(0x78, "F9", 0x42));
            _keys.Add(new KeyInfo(0x79, "F10", 0x43));
            _keys.Add(new KeyInfo(0x7A, "F11", 0x44));
            _keys.Add(new KeyInfo(0x7B, "F12", 0x45));
            _keys.Add(new KeyInfo(0x2C, "Print Screen", 0x46));
            //   _keys.Add(new KeyInfo(42, "Scroll Lock", 0x47));
            //   _keys.Add(new KeyInfo(43, "Pause", 0x48));
            _keys.Add(new KeyInfo(0x2D, "Insert", 0x49));
            _keys.Add(new KeyInfo(0x24, "Home", 0x4A));
            _keys.Add(new KeyInfo(0x21, "Page Up", 0x4B));
            _keys.Add(new KeyInfo(0x2E, "Delete", 0x4C));
            _keys.Add(new KeyInfo(0x23, "End", 0x4D));
            _keys.Add(new KeyInfo(0x22, "Page Down", 0x4E));
            _keys.Add(new KeyInfo(0x27, "→", 0x4F));
            _keys.Add(new KeyInfo(0x25, "←", 0x50));
            _keys.Add(new KeyInfo(0x28, "↓", 0x51));
            _keys.Add(new KeyInfo(0x26, "↑", 0x52));
            //   _keys.Add(new KeyInfo(48, "Num Lock", 0x53));
            //   _keys.Add(new KeyInfo(49, "／(テンキー)", 0x54));
            //   _keys.Add(new KeyInfo(50, "９(テンキー)", 0x55));
            //   _keys.Add(new KeyInfo(51, "＋(テンキー)", 0x56));
            //   _keys.Add(new KeyInfo(52, "Enter(右)", 0x57));
            //   _keys.Add(new KeyInfo(53, "Esc", 0x58));
            //   _keys.Add(new KeyInfo(54, "１(テンキー)", 0x59));
            //   _keys.Add(new KeyInfo(92, "２(テンキー)", 0x5A));
            //   _keys.Add(new KeyInfo(93, "．(テンキー)", 0x5B));
            //   _keys.Add(new KeyInfo(94, "４(テンキー)", 0x5C));
            //   _keys.Add(new KeyInfo(95, "５(テンキー)", 0x5D));
            //   _keys.Add(new KeyInfo(96, "３(テンキー)", 0x5E));
            //   _keys.Add(new KeyInfo(97, "７(テンキー)", 0x5F));
            //   _keys.Add(new KeyInfo(55, "８(テンキー)", 0x60));
            //   _keys.Add(new KeyInfo(56, "６(テンキー)", 0x61));
            //   _keys.Add(new KeyInfo(57, "０(テンキー)", 0x62));
            //   _keys.Add(new KeyInfo(58, "－(テンキー)", 0x63));

            //   _keys.Add(new KeyInfo(59, "Application", 0x65));

            _keys.Add(new KeyInfo(0xDC, @"\", 0x87));
            //   _keys.Add(new KeyInfo(0xF0, "カタカナひらがな", 0x88));
            //   _keys.Add(new KeyInfo(0xF2, "カタカナひらがな", 0x88));
            _keys.Add(new KeyInfo(0xE2, @"\", 0x89));
            _keys.Add(new KeyInfo(0x1C, "変換", 0x8A));
            _keys.Add(new KeyInfo(0x1D, "無変換", 0x8B));

            _keys.Add(new KeyInfo(0xA2, "Ctrl(左)", 0xE0, true, 0x01));
            _keys.Add(new KeyInfo(0xA0, "Shift(左)", 0xE1, true, 0x02));
            _keys.Add(new KeyInfo(0xA4, "Alt(左)", 0xE2, true, 0x04));
            _keys.Add(new KeyInfo(0x5B, "Windows(左)", 0xE3, true, 0x08));
            _keys.Add(new KeyInfo(0xA3, "Ctrl(右)", 0xE4, true, 0x10));
            _keys.Add(new KeyInfo(0xA1, "Shift(右)", 0xE5, true, 0x20));
            _keys.Add(new KeyInfo(0xA5, "Alt(右)", 0xE6, true, 0x40));
            //  _keys.Add(new KeyInfo(107, "WIndows(右)", 0xE7));

        }

        public KeyInfo GetSendKeyCode(short KeyCode)
        {

            var key = _keys.FirstOrDefault(x => x.KeyCode == KeyCode);

            if (key != null)
            {
                return key;
            }
            else
            {
                Debug.WriteLine($"Keycode Not Found:0x{KeyCode.ToString("X")}");
                return new KeyInfo(0x00, "Null", 0x00);
            }


        }

        const byte HEAD1 = 0x57;
        const byte HEAD2 = 0xAB;
        const int DATA_POS = 5;
        public byte[] getKebordMessage(KeyInfo[] keys)
        {

            //キー離すコマンド
            byte[] cmd = new byte[] { HEAD1, HEAD2, 0x00, 0x02, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C };
            if (keys != null)
            {
                byte ckey = 0x00;
                byte ukey = 0x00;
                foreach (var key in keys)
                {
                    if (key.CtlKey)
                    {
                        ckey += key.CtlCode;
                    }
                    else
                    {
                        ukey = key.SendKeyCode;
                    }
                }
                cmd[DATA_POS + 0] = ckey;
                cmd[DATA_POS + 2] = ukey;
                byte sum = (byte)(HEAD1 + HEAD2 + 0x02 + 0x08 + ckey + ukey);
                cmd[13] = sum;
            }
            return cmd;
        }



        public byte[] getMouseMessage(Point pos, bool MouseLeftOn, bool MouseRightOn, bool MouseCenterOn, int Scroll)
        {
            byte[] cmd = new byte[] { HEAD1, HEAD2, 0x00, 0x04, 0x07, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            byte mousekey = 0x00;
            if (MouseLeftOn) mousekey += 0x01;
            if (MouseRightOn) mousekey += 0x02;
            if (MouseCenterOn) mousekey += 0x04;
            cmd[DATA_POS + 1] = mousekey;

            int x = (4096 * pos.X) / Width;
            int y = (4096 * pos.Y) / Height;

      

            var bytes = BitConverter.GetBytes(x);
            cmd[DATA_POS + 2] = bytes[0];
            cmd[DATA_POS + 3] = bytes[1];

            bytes = BitConverter.GetBytes(y);
            cmd[DATA_POS + 4] = bytes[0];
            cmd[DATA_POS + 5] = bytes[1];

            cmd[DATA_POS + 6] = (byte)Scroll;

            int int_sum = 0;
            foreach (byte b in cmd)
            {
                int_sum += b;
            }
            byte sum = (byte)int_sum;
            cmd[12] = sum;

            return cmd;
        }
    }



    public class KeyInfo
    {
        public KeyInfo(short KeyCode, String KeyName, byte SendKeyCode, bool CtlKey = false, byte CtlCode = 0)
        {
            this.KeyCode = KeyCode;
            this.KeyName = KeyName;
            this.SendKeyCode = SendKeyCode;
            this.CtlKey = CtlKey;
            this.CtlCode = CtlCode;
        }
        public short KeyCode { get; private set; }
        public String KeyName { get; private set; }
        public byte SendKeyCode { get; private set; }
        public bool CtlKey { get; private set; }
        public byte CtlCode { get; private set; }
    }
}
