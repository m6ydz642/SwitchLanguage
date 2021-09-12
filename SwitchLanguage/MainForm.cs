using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace SwitchLanguage
{
    public partial class MainForm : Form
    {
        bool isRunning;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

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

            //Keys.Control;
            //Keys.A;

            /*           isRunning = true;
                       Thread TH = new Thread(Keyboardd);
                       TH.SetApartmentState(ApartmentState.STA);
                       CheckForIllegalCrossThreadCalls = false;
                       TH.Start();*/
             //  Application.Run(); // 윈폼 안쓰고 백그라운드로 실행

 




          /*  KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(Form1_KeyDown);*/

                if (((Keyboard.IsKeyDown(Key.LeftCtrl))))
                {
                    //CTRL + F is currently pressed
                }

            //  RegisterHotKey((int)this.Handle, 0, 0x0, (int)Keys.LControlKey);
            /*    RegisterHotKey((int)this.Handle, 0, (int)Keys.LControlKey, (int)Keys.LControlKey);
                RegisterHotKey((int)this.Handle, 1, 0x2, 0x4);
                RegisterHotKey((int)this.Handle, 2, 0x0, (int)Keys.Space);*/
            // 0x3 = 쉬프트
            // 0x2 = 컨트롤
            RegisterHotKey((int)this.Handle, 0, 0x2, (int)Keys.Space);
           // RegisterHotKey(this.Handle, 0, KeyModifiers.Alt, Keys.Space);


        } 

        /*     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
             {
                 switch (keyData)
                 {
                     case Keys.F1:
                         break;
                     default:
                         break;
                 }
                 return base.ProcessCmdKey(ref msg, keyData);
             }*/




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

                    // listViewFile_move(-1);

                }

                if (m.WParam == (IntPtr)0x1) // 그 키의 ID가 1이면

                {

                    // listViewFile_move(+1);

                }

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


        void Keyboardd()
        {
            int count = 0;
            while (isRunning)
            {
                Thread.Sleep(40); // minimum CPU usage
                                  //if ((Keyboard.GetKeyStates(Key.LeftCtrl)) > 0 && (Keyboard.GetKeyStates(Key.Space) > 0))
                                  //  //  (Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.None) > 0) // KeyStates.Down
                int controlkey = ((int)(Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down));
                int spacekey = ((int)(Keyboard.GetKeyStates(Key.Space) & KeyStates.Down));
                if (controlkey > 0 && spacekey > 0)
                {
                    MessageBox.Show("감지!");
                }  
                else 
                {
                   // label1.Text = "Not Pressed";
                }
                
            }
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
