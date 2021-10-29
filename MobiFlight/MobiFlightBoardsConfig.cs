using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiFlight
{
    public class MobiFlightBoardsConfig : IModuleInfo
    {
        public MobiFlightCapabilities boardCapabilities { get; set; }



        // vars from MobiFlightMouleInfo
        public String friendlyNameIdentifier = "Unknown";

        // these types are used for standard stock arduino boards
        public String TYPE_ARDUINO = "Unknown";

        public String LatestFirmware = "Unknown";


        // these types are used once the MF firmware is installed
        public String TYPE = TYPE_UNKNOWN;

        // message size is used for building
        // correct chunk sizes for messages
        // to the arduino boards
        public int MESSAGE_MAX_SIZE;

        // this is used to check for 
        // maximum config length and
        // alert the user in the UI if exceeded
        public int EEPROM_SIZE;

        // vars from MobiFlightFirmwareUpdater
        public String FirmwarePrename;
        public String FirmwareName;
        public String ArduinoChip;
        public String BaudRate = "115200";
        public String C; // UNUSED FIELD


        String _version = "n/a";
        public String Type { get; set; }
        public String Serial { get; set; }
        public String Port { get; set; }
        public String Name { get; set; }
        public String Config { get; set; }

        public List<MobiFlightPin> PINS;

        public String[] VIDPID;
        internal static readonly string TYPE_UNKNOWN;

        public String Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public bool HasSuitingMfFirmware()
        {
            Console.WriteLine("Correct Firmware version");
            return (Type == TYPE);
        }

        public MobiFlightCapabilities GetCapabilities()
        {
            return boardCapabilities;
        }

    }

    public abstract class MobiFlightCapabilities
    {
        public int MaxOutputs = 0;
        public int MaxButtons = 0;
        public int MaxLedSegments = 0;
        public int MaxEncoders = 0;
        public int MaxSteppers = 0;
        public int MaxServos = 0;
        public int MaxLcdI2C = 0;
        public int MaxAnalogInputs = 0;
    }

    public class MobiFlightPin
    {
        public byte Pin { get; set; }
        public bool isAnalog = false;
        public bool isPWM = false;
        public bool isI2C = false;
        public bool Used = false;
        private string name = null;

        public string Name
        {
            get { return name != null ? name : Pin.ToString(); }
            set { name = value; }
        }

        public MobiFlightPin()
        {
        }
        public MobiFlightPin(MobiFlightPin pin)
        {
            Pin = pin.Pin;
            isAnalog = pin.isAnalog;
            isPWM = pin.isPWM;
            isI2C = pin.isI2C;
            Used = pin.Used;
            Name = pin.Name;
        }
        public override String ToString()
        {
            return Pin.ToString();
        }


    }
    public class BoardConfigProvider
    {
        List<MobiFlightBoardsConfig> configs = new List<MobiFlightBoardsConfig> {
            { new MegaConfig() },
            { new UnoConfig() },
            { new MicroConfig() },
            { new NanoConfig() }
        };

        public List<MobiFlightBoardsConfig> GetBoardsConfigs()
        {
            return configs;
        }

        public MobiFlightBoardsConfig GetBoardConfigByName(String FriendlyName)
        {
            MobiFlightBoardsConfig boardConfig = new MobiFlightBoardsConfig(); ;
            foreach (var c in configs)
            {
                if (FriendlyName.Contains(c.friendlyNameIdentifier))
                {
                    boardConfig = c;
                }
            }
            return boardConfig;
        }

        public MobiFlightBoardsConfig GetBoardConfigByVidPi(String Pid)
        {
            MobiFlightBoardsConfig boardConfig = new MobiFlightBoardsConfig();
            foreach (var c in configs)
            {
                foreach (var pid in c.VIDPID)
                {
                    Console.WriteLine(pid);
                    if (Pid.Contains(pid))
                    {
                        boardConfig = c;
                    }
                }
            }
            return boardConfig;
        }



        /* DATA FROM MobiFlightFirmwareUpdater for unimplmented Boards
            if (MobiFlightBoardsConfig.TYPE_ARDUINO_MICRO == ArduinoType)
            {
                FirmwareName = "mobiflight_micro_" + MobiFlightBoardsConfig.LatestFirmwareMicro.Replace('.', '_') + ".hex";
                ArduinoChip = "atmega32u4";
                BaudRate = "57600";
                C = "avr109";
            }
            else if (MobiFlightBoardsConfig.TYPE_ARDUINO_UNO == ArduinoType)
            {
                //:\Projekte\MobiFlightFC\FirmwareSource\arduino - 1.8.0\hardware\tools\avr / bin / avrdude - CD:\Projekte\MobiFlightFC\FirmwareSource\arduino - 1.8.0\hardware\tools\avr / etc / avrdude.conf - v - patmega328p - carduino - PCOM11 - b115200 - D - Uflash:w: C: \Users\SEBAST~1\AppData\Local\Temp\arduino_build_118832 / mobiflight_mega.ino.hex:i
                FirmwareName = "mobiflight_uno_" + MobiFlightBoardsConfig.LatestFirmwareUno.Replace('.', '_') + ".hex";
                ArduinoChip = "atmega328p";
                BaudRate = "115200";
                C = "arduino";
            }
            else if (MobiFlightBoardsConfig.TYPE_ARDUINO_NANO == ArduinoType) // TODO dont understand
            {
                //:\Projekte\MobiFlightFC\FirmwareSource\arduino - 1.8.0\hardware\tools\avr / bin / avrdude - CD:\Projekte\MobiFlightFC\FirmwareSource\arduino - 1.8.0\hardware\tools\avr / etc / avrdude.conf - v - patmega328p - carduino - PCOM11 - b115200 - D - Uflash:w: C: \Users\SEBAST~1\AppData\Local\Temp\arduino_build_118832 / mobiflight_mega.ino.hex:i
                FirmwareName = "mobiflight_uno_" + MobiFlightBoardsConfig.LatestFirmwareUno.Replace('.', '_') + ".hex";
                ArduinoChip = "atmega328p";
                BaudRate = "115200";
                C = "arduino";
            }*/

    }

}
