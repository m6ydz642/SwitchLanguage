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
        /*[DllImport("imm32.dll")]
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
        public const int IME_CMODE_NATIVE = 0x1;         //한글*/
        #endregion

        /*[Description("IME Hangul mode")] 
        int VK_HANGUL = 0x15;*/
            

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        // public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
        // int로 안쓰고 열거형 타입으로 쓸경우

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte a, byte bScan, int dwFlags, int dwExtraInfo);
  

        private const int VK_RETURN = 0x0D;
        private const int VK_A = (int)Keys.HangulMode;


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
            Load += TrayIcon_Load;

            TrayIcon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
            Resize += MainForm_Resize;




            //  RegisterHotKey((int)this.Handle, 0, 0x0, (int)Keys.LControlKey);
            /*    RegisterHotKey((int)this.Handle, 0, (int)Keys.LControlKey, (int)Keys.LControlKey);
                RegisterHotKey((int)this.Handle, 1, 0x2, 0x4);
                RegisterHotKey((int)this.Handle, 2, 0x0, (int)Keys.Space);*/
            // 0x3 = 쉬프트 
            // 0x2 = 컨트롤
            RegisterHotKey((int)this.Handle, 0, 0x2, (int)Keys.Space);

            // RegisterHotKey(this.Handle, 0, KeyModifiers.Alt, Keys.Space);
         //  Application.Run(); // 윈폼 안쓰고 백그라운드로 실행 // 백그라운드로 실행하니 트레이 아이콘 안먹어서 잠시뺌
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState) // 최소 사이즈
            {
                // TrayIcon.Visible = true; // tray icon 표시
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState) // 원래 사이즈
            {
                TrayIcon.Visible = false;
                this.ShowInTaskbar = true; // 작업 표시줄 표시
            }


        }

            private void Tray_Icon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

        }

        private void TrayIcon_Load(object sender, EventArgs e)
        {
           TrayIcon.ContextMenuStrip = contextTrayMenu;

        }



        //  윈폼 밖에서 작동하는 함수
        protected override void WndProc(ref Message m)

        {

            base.WndProc(ref m);

            var a = (Keyboard.IsKeyDown(Key.Space));

            if (m.Msg == (int)0x312) //핫키가 눌러지면 312 정수 메세지를 받게됨
           {

                //  if (m.WParam == (IntPtr)0x0) // 그 키의 ID가 0이면
               // if ((Keyboard.IsKeyDown(Key.Space)))
               // {
                  
                    // keybd_event(VK_A, 0, (int)Keys.HangulMode, 0);  // 이거나 밑에꺼나 차이가 없네?
                    keybd_event(VK_A, 0, 0, (int)Keys.HangulMode);
                    // 한영키 입력으로 처리 (Sendkeys.Send()가 안되고 한영을 지원안함)
                    // IME 방식도 지원하지 않음
                    //  keybd_event(VK_A, 0, 0, 0); // 키 때문 부분 없앰 
               // }

                if (m.WParam == (IntPtr)0x1) // 그 키의 ID가 1이면
                {

                }
            }
        }

     /*   private void ChangeIME()
        {
            IntPtr hwnd = ImmGetContext(this.Handle);  // C# WindowForm만 적용됨.
            // [한/영]전환 b_toggle : true=한글, false=영어
            int dwConversion = 0; int dwSentence = 0;

            bool b_toggle = ImmGetConversionStatus(hwnd, ref dwConversion, ref dwSentence);

          
            Int32 dwConversionStatus = (b_toggle == true ? IME_CMODE_NATIVE : IME_CMODE_ALPHANUMERIC);
            
            var a = ImmSetConversionStatus(hwnd, dwConversionStatus, 0); // 설정 전달


            if (b_toggle)
            {
                ImmSetConversionStatus(hwnd, IME_CMODE_NATIVE, 0); // 한글
            }
            else
            {
                ImmSetConversionStatus(hwnd, IME_CMODE_ALPHANUMERIC, 0); // 영어
            }
        }

        private void ChangeIME(bool b_toggle)
        {
            IntPtr hwnd = ImmGetContext(this.Handle);  //C# WindowForm만 적용됨.
            // [한/영]전환 b_toggle : true=한글, false=영어
            Int32 dwConversion = (b_toggle == true ? IME_CMODE_NATIVE : IME_CMODE_ALPHANUMERIC);
            ImmSetConversionStatus(hwnd, dwConversion, 0);
        }*/



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
            MessageBox.Show("백그라운드로 이미 작동하고 있어서 필요없음");
        }

        private void 보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /*
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
}*/
    }


}
