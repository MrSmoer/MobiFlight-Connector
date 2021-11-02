using MobiFlight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiFlight
{
    public class NanoConfig : MobiFlightBoardsConfig
    {

        public NanoConfig()
        {
            boardCapabilities = new NanoCapabilities();

            friendlyNameIdentifier = "Nano";

            // vars from MobiFlightMouleInfo

            LatestFirmware = "1.11.3";

            // these types are used for standard stock arduino boards
            TYPE_ARDUINO = "Arduino Nano";


            // these types are used once the MF firmware is installed
            TYPE = "MobiFlight Nano";

            // message size is used for building
            // correct chunk sizes for messages
            // to the arduino boards
            MESSAGE_MAX_SIZE = 32;

            // this is used to check for 
            // maximum config length and
            // alert the user in the UI if exceeded
            EEPROM_SIZE = 256;

            PINS = new List<MobiFlightPin>() {
                { new MobiFlightPin() { Pin =  2 } },
                { new MobiFlightPin() { Pin =  3, isPWM = true } },
                { new MobiFlightPin() { Pin =  4 } },
                { new MobiFlightPin() { Pin =  5, isPWM = true } },
                { new MobiFlightPin() { Pin =  6, isPWM = true } },
                { new MobiFlightPin() { Pin =  7 } },
                { new MobiFlightPin() { Pin =  8 } },
                { new MobiFlightPin() { Pin =  9, isPWM = true } },
                // 10-19
                { new MobiFlightPin() { Pin = 10, isPWM = true } },
                { new MobiFlightPin() { Pin = 11, isPWM = true } },
                { new MobiFlightPin() { Pin = 12 } },
                { new MobiFlightPin() { Pin = 13 } },
                { new MobiFlightPin() { Pin = 14, isAnalog = true, Name = "A0" } },
                { new MobiFlightPin() { Pin = 15, isAnalog = true, Name = "A1" } },
                { new MobiFlightPin() { Pin = 16, isAnalog = true, Name = "A2" } },
                { new MobiFlightPin() { Pin = 17, isAnalog = true, Name = "A3" } },
                { new MobiFlightPin() { Pin = 18, isAnalog = true, Name = "A4", isI2C = true } },
                { new MobiFlightPin() { Pin = 19, isAnalog = true, Name = "A5", isI2C = true } },
                // 20-21
                { new MobiFlightPin() { Pin = 20, isAnalog = true, Name = "A6" } },
                { new MobiFlightPin() { Pin = 21, isAnalog = true, Name = "A7" } },
            };

            VIDPID = new String[] {
            "VID_1A86&PID_7523", // this is actually an CH-340 and can be a Mega OR an UNO OR an Nano
            };

        }
    }


    public class NanoCapabilities : MobiFlightCapabilities
    {
        public NanoCapabilities()
        {
            MaxOutputs = 10;
            MaxButtons = 16;
            MaxLedSegments = 1;
            MaxEncoders = 2;
            MaxSteppers = 2;
            MaxServos = 2;
            MaxLcdI2C = 2;
            MaxAnalogInputs = 2;
        }
    }
}