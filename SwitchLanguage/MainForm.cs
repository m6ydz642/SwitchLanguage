using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SwitchLanguage
{
    public partial class MainForm : Form
    {
        bool isRunning;
        public MainForm()
        {
            InitializeComponent();

            //Keys.Control;
            //Keys.A;

            isRunning = true;
            Thread TH = new Thread(Keyboardd);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();


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
            Keyboardd();
        }
    }


}
