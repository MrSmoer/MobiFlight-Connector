using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobiFlight.UI.Panels.Settings.Device
{
    public partial class MFOutputPanel : UserControl
    {
        /// <summary>
        /// Gets raised whenever config object has changed
        /// </summary>
        public event EventHandler Changed;

        private MobiFlight.Config.Output output;
        bool initialized = false;
        String MobiFlightModuleType;

        public MFOutputPanel()
        {
            InitializeComponent();
            mfPinComboBox.Items.Clear();
        }

        public MFOutputPanel(MobiFlight.Config.Output output, List<MobiFlightPin> Pins, String MobiFlightModuleType)
            : this()
        {
            Console.WriteLine("Pinpanel");
            ComboBoxHelper.BindMobiFlightFreePins(mfPinComboBox, Pins, output.Pin);
            this.MobiFlightModuleType = MobiFlightModuleType;
            Console.WriteLine("Pinpanel2");

            if (mfPinComboBox.Items.Count > 0)
            {
                mfPinComboBox.SelectedIndex = 0;
            }
            Console.WriteLine("Pinpanel3");
            // TODO: Complete member initialization
            this.output = output;
            mfPinComboBox.SelectedValue = byte.Parse(output.Pin);
            textBox1.Text = output.Name;
            Console.WriteLine("Pinpanel4");
            setValues();
            Console.WriteLine("Pinpanel5");
            Console.WriteLine("Hier");
            Console.WriteLine("Hier2");
            initialized = true;

        }

        private void value_Changed(object sender, EventArgs e)
        {
            if (!initialized) return;

            setValues();

            if (Changed != null)
                Changed(output, new EventArgs());
        }

        private bool isPwmPin()
        {
            bool result = false;
            byte bPin = byte.Parse(mfPinComboBox.SelectedItem.ToString());
            MobiFlightPin pin;
            Console.WriteLine("is pwmpin");
            
            BoardConfigProvider configProvider = new BoardConfigProvider();
            List<MobiFlightBoardsConfig> boards = configProvider.GetBoardsConfigs();
            foreach (MobiFlightBoardsConfig cfg in boards)
            {
                Console.WriteLine(MobiFlightModuleType);
                if (cfg.TYPE == MobiFlightModuleType)
                {
                    pin = cfg.PINS.Find(x => (x.Pin == bPin));
                    result = pin.isPWM;
                    break;
                }
            }
            return result;
        }

        private void setValues()
        {
            mfPinLabel.Text = isPwmPin() ? "Pin (PWM)" : "Pin";
            output.Pin = mfPinComboBox.SelectedItem.ToString();
            output.Name = textBox1.Text;
        }
    }
}
