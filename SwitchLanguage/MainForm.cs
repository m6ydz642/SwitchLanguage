using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace SwitchLanguage
{
    public partial class MainForm : Form
    {


        bool isRunning;
        // object CurrentCulture;
        #region imm32.dll :: Get_IME_Mode IME가져오기
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("imm32.dll")]
        public static extern Boolean ImmSetConversionStatus(IntPtr hIMC, Int32 fdwConversion, Int32 fdwSentence);
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr IParam);
        [DllImport("imm32.dll")] private static extern bool 
        ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);


        public const int IME_CMODE_ALPHANUMERIC = 0x0;   //영문
        public const int IME_CMODE_NATIVE = 0x1;         //한글
        #endregion

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        // public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
        // int로 안쓰고 열거형 타입으로 쓸경우

        // int로 안쓰고 열거형 타입으로 쓸경우
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
        const int HOTKEY_ID = 31197; //Any number to use to identify the hotkey instance

        public MainForm()
        {
            InitializeComponent();

     
            //  RegisterHotKey((int)this.Handle, 0, 0x0, (int)Keys.LControlKey);
            /*    RegisterHotKey((int)this.Handle, 0, (int)Keys.LControlKey, (int)Keys.LControlKey);
                RegisterHotKey((int)this.Handle, 1, 0x2, 0x4);
                RegisterHotKey((int)this.Handle, 2, 0x0, (int)Keys.Space);*/
            // 0x3 = 쉬프트
            // 0x2 = 컨트롤
            RegisterHotKey((int)this.Handle, 0, 0x2, (int)Keys.Space);
            // RegisterHotKey(this.Handle, 0, KeyModifiers.Alt, Keys.Space);



        }



        //  윈폼 밖에서 작동하는 함수
        protected override void WndProc(ref Message m)

        {

            base.WndProc(ref m);

            var a = (Keyboard.IsKeyDown(Key.Space));

            if (m.Msg == (int)0x312) //핫키가 눌러지면 312 정수 메세지를 받게됨
           {

                //  if (m.WParam == (IntPtr)0x0) // 그 키의 ID가 0이면
                if ((Keyboard.IsKeyDown(Key.Space)))
                {
                    ChangeIME();
                }

                if (m.WParam == (IntPtr)0x1) // 그 키의 ID가 1이면

                {

                    // listViewFile_move(+1);

                }

            }

        }

        private void ChangeIME()
        {
            IntPtr hwnd = ImmGetContext(this.Handle);  // C# WindowForm만 적용됨.
            // [한/영]전환 b_toggle : true=한글, false=영어
            int dwConversion = 0; int dwSentence = 0;

            bool b_toggle = ImmGetConversionStatus(hwnd, ref dwConversion, ref dwSentence);

    
            Int32 dwConversionStatus = (b_toggle == true ? IME_CMODE_NATIVE : IME_CMODE_ALPHANUMERIC);
            var a = ImmSetConversionStatus(hwnd, dwConversionStatus, 0); // 설정 전달

            if (dwConversion == 0)
            {
                ImmSetConversionStatus(hwnd, IME_CMODE_NATIVE, 0); // 한글


            }
            else
            {
                ImmSetConversionStatus(hwnd, IME_CMODE_ALPHANUMERIC, 0); // 영어
            }

        }




        // 윈폼 안에서 작동하는 함수
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)

        {

            Keys key = keyData & ~(Keys.Shift | Keys.Control);



            switch (key)

            {

                case Keys.F:

                    // 조합키 사용 시

                    if ((keyData & Keys.Control) != 0)

                    {

                        MessageBox.Show("Ctrl+F");

                    }

                    break;

                case Keys.F5:

                    // 단일키 사용시

                    MessageBox.Show("f5");

                    break;

                default:

                    MessageBox.Show("지정되지 않은 키입니다.");

                    return base.ProcessCmdKey(ref msg, keyData);

            }

            return true;


        }


     
        private void button1_Click(object sender, EventArgs e)
        {
        //    Keyboardd();
        //    backgroundkey();
        }

        private void backgroundkey()
        {
            Message x = new Message();
            Keys key;
            key = Keys.Control;
            while (isRunning)
            {
                Thread.Sleep(40); // minimum CPU usage
                                  //if ((Keyboard.GetKeyStates(Key.LeftCtrl)) > 0 && (Keyboard.GetKeyStates(Key.Space) > 0))
                ProcessCmdKey(ref x, key);

            }
        }
    }


}
