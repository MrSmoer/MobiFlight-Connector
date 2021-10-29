using MobiFlight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiFlight
{
    public class MicroConfig : MobiFlightBoardsConfig
    {

        public MicroConfig()
        {
            boardCapabilities = new MicroCapabilities();

            friendlyNameIdentifier = "Micro"; // TODO Assumed value

            // vars from MobiFlightMouleInfo

            LatestFirmware = "1.11.3";

            // these types are used for standard stock arduino boards
            TYPE_ARDUINO = "Arduino Micro Pro";


            // these types are used once the MF firmware is installed
            TYPE = "MobiFlight Micro";

            // message size is used for building
            // correct chunk sizes for messages
            // to the arduino boards
            MESSAGE_MAX_SIZE = 32;

            // this is used to check for 
            // maximum config length and
            // alert the user in the UI if exceeded
            EEPROM_SIZE = 256;

            // vars from MobiFlightFirmwareUpdater
            String FirmwarePrename = "mobiflight_micro_";
            String FirmwareName = FirmwarePrename + LatestFirmware.Replace('.', '_') + ".hex";
            String ArduinoChip = "atmega32u4";
            String BaudRate = "57600";
            String C = "avr109"; // UNUSED FIELD

            PINS = new List<MobiFlightPin>() {
            { new MobiFlightPin() { Pin =  0 } },
            { new MobiFlightPin() { Pin =  1 } },
            { new MobiFlightPin() { Pin =  2, isI2C = true } },
            { new MobiFlightPin() { Pin =  3, isPWM = true, isI2C = true} },
            { new MobiFlightPin() { Pin =  4, isAnalog = true } },
            { new MobiFlightPin() { Pin =  5, isPWM = true } },
            { new MobiFlightPin() { Pin =  6, isPWM = true, isAnalog = true } },
            { new MobiFlightPin() { Pin =  7 } },
            { new MobiFlightPin() { Pin =  8, isAnalog = true } },
            { new MobiFlightPin() { Pin =  9, isPWM = true, isAnalog = true } },
            // 10-19
            { new MobiFlightPin() { Pin = 10, isPWM = true } },
            { new MobiFlightPin() { Pin = 14 } },
            { new MobiFlightPin() { Pin = 15 } },
            { new MobiFlightPin() { Pin = 16 } },
            { new MobiFlightPin() { Pin = 17 } },
            { new MobiFlightPin() { Pin = 18, isAnalog = true, Name = "A0" } },
            { new MobiFlightPin() { Pin = 19, isAnalog = true, Name = "A1" } },
            // 20-21
            { new MobiFlightPin() { Pin = 20, isAnalog = true, Name = "A2" } },
            { new MobiFlightPin() { Pin = 21, isAnalog = true, Name = "A3" } }
        };

            VIDPID = new String[] {
            "VID_1B4F&PID_9206",
            "VID_2341&PID_8036",  // Arduino Pro Micro
            "VID_2341&PID_8037"   // https://bitbucket.org/mobiflight/mobiflightfc/issues/324/add-new-micro-pro-vid_2341-pid_8037
        };


        }
    }




    public class MicroCapabilities : MobiFlightCapabilities
    {
        public MicroCapabilities()
        {
            MaxOutputs = 10;
            MaxButtons = 16;
            MaxLedSegments = 1;
            MaxEncoders = 4;
            MaxSteppers = 2;
            MaxServos = 2;
            MaxLcdI2C = 2;
            MaxAnalogInputs = 2;
        }
    }
}