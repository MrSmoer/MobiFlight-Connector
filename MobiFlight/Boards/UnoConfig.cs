using MobiFlight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiFlight
{
    public class UnoConfig : MobiFlightBoardsConfig
    {

        public UnoConfig()
        {
            boardCapabilities = new UnoCapabilities();

            friendlyNameIdentifier = "Uno";

            // vars from MobiFlightMouleInfo

            LatestFirmware = "1.11.3";

            // these types are used for standard stock arduino boards
            TYPE_ARDUINO = "Arduino Uno";


            // these types are used once the MF firmware is installed
            TYPE = "MobiFlight Uno";

            // message size is used for building
            // correct chunk sizes for messages
            // to the arduino boards
            MESSAGE_MAX_SIZE = 32;

            // this is used to check for 
            // maximum config length and
            // alert the user in the UI if exceeded
            EEPROM_SIZE = 256;

            // vars from MobiFlightFirmwareUpdater
            String FirmwarePrename = "mobiflight_uno_";
            String FirmwareName = FirmwarePrename + LatestFirmware.Replace('.', '_') + ".hex";
            String ArduinoChip = "atmega328p";
            String BaudRate = "115200";
            String C = "arduino"; // UNUSED FIELD

            PINS = new List<MobiFlightPin>() {
            { new MobiFlightPin() { Pin =  2, isPWM = true } },
            { new MobiFlightPin() { Pin =  3, isPWM = true } },
            { new MobiFlightPin() { Pin =  4, isPWM = true } },
            { new MobiFlightPin() { Pin =  5, isPWM = true } },
            { new MobiFlightPin() { Pin =  6, isPWM = true } },
            { new MobiFlightPin() { Pin =  7, isPWM = true } },
            { new MobiFlightPin() { Pin =  8, isPWM = true } },
            { new MobiFlightPin() { Pin =  9, isPWM = true } },
            // 10-19
            { new MobiFlightPin() { Pin = 10, isPWM = true } },
            { new MobiFlightPin() { Pin = 11, isPWM = true } },
            { new MobiFlightPin() { Pin = 12, isPWM = true } },
            { new MobiFlightPin() { Pin = 13, isPWM = true } },
            { new MobiFlightPin() { Pin = 14 } },
            { new MobiFlightPin() { Pin = 15 } },
            { new MobiFlightPin() { Pin = 16 } },
            { new MobiFlightPin() { Pin = 17 } },
            { new MobiFlightPin() { Pin = 18 } },
            { new MobiFlightPin() { Pin = 19 } },
            // 20-29
            { new MobiFlightPin() { Pin = 20, isI2C = true } },
            { new MobiFlightPin() { Pin = 21, isI2C = true } },
            { new MobiFlightPin() { Pin = 22 } },
            { new MobiFlightPin() { Pin = 23 } },
            { new MobiFlightPin() { Pin = 24 } },
            { new MobiFlightPin() { Pin = 25 } },
            { new MobiFlightPin() { Pin = 26 } },
            { new MobiFlightPin() { Pin = 27 } },
            { new MobiFlightPin() { Pin = 28 } },
            { new MobiFlightPin() { Pin = 29 } },
            // 30-39
            { new MobiFlightPin() { Pin = 30 } },
            { new MobiFlightPin() { Pin = 31 } },
            { new MobiFlightPin() { Pin = 32 } },
            { new MobiFlightPin() { Pin = 33 } },
            { new MobiFlightPin() { Pin = 34 } },
            { new MobiFlightPin() { Pin = 35 } },
            { new MobiFlightPin() { Pin = 36 } },
            { new MobiFlightPin() { Pin = 37 } },
            { new MobiFlightPin() { Pin = 38 } },
            { new MobiFlightPin() { Pin = 39 } },
            // 40-49
            { new MobiFlightPin() { Pin = 40 } },
            { new MobiFlightPin() { Pin = 41 } },
            { new MobiFlightPin() { Pin = 42 } },
            { new MobiFlightPin() { Pin = 43 } },
            { new MobiFlightPin() { Pin = 44, isPWM = true } },
            { new MobiFlightPin() { Pin = 45, isPWM = true } },
            { new MobiFlightPin() { Pin = 46, isPWM = true } },
            { new MobiFlightPin() { Pin = 47 } },
            { new MobiFlightPin() { Pin = 48 } },
            { new MobiFlightPin() { Pin = 49 } },
            // 50-59
            { new MobiFlightPin() { Pin = 50 } },
            { new MobiFlightPin() { Pin = 51 } },
            { new MobiFlightPin() { Pin = 52 } },
            { new MobiFlightPin() { Pin = 53 } },
            { new MobiFlightPin() { Pin = 54, isAnalog = true, Name = "A0" } },
            { new MobiFlightPin() { Pin = 55, isAnalog = true, Name = "A1" } },
            { new MobiFlightPin() { Pin = 56, isAnalog = true, Name = "A2" } },
            { new MobiFlightPin() { Pin = 57, isAnalog = true, Name = "A3" } },
            { new MobiFlightPin() { Pin = 58, isAnalog = true, Name = "A4" } },
            { new MobiFlightPin() { Pin = 59, isAnalog = true, Name = "A5" } },
            // 60-69
            { new MobiFlightPin() { Pin = 60, isAnalog = true, Name = "A6" } },
            { new MobiFlightPin() { Pin = 61, isAnalog = true, Name = "A7" } },
            { new MobiFlightPin() { Pin = 62, isAnalog = true, Name = "A8" } },
            { new MobiFlightPin() { Pin = 63, isAnalog = true, Name = "A9" } },
            { new MobiFlightPin() { Pin = 64, isAnalog = true, Name = "A10" } },
            { new MobiFlightPin() { Pin = 65, isAnalog = true, Name = "A11" } },
            { new MobiFlightPin() { Pin = 66, isAnalog = true, Name = "A12" } },
            { new MobiFlightPin() { Pin = 67, isAnalog = true, Name = "A13" } },
            { new MobiFlightPin() { Pin = 68, isAnalog = true, Name = "A14" } },
            { new MobiFlightPin() { Pin = 69, isAnalog = true, Name = "A15" } }
        };

            VIDPID = new String[] { "VID_2341&PID_0010",
                "VID_2341&PID_0042",
                "VID_2341&PID_0001",            // was reported on youtube video
                "VID_8087&PID_0024",
                //"VID_1A86&PID_7523",            // this is actually an CH-340 and can be a Mega OR an UNO
                "VID_2A03&PID_0042",            // http://www.mobiflight.de/forum/message/983.html
                "VID_0403&PID_6001",            // http://www.mobiflight.de/forum/topic/570.html
                "VID_0403\\+PID_6001\\+.+",     // https://bitbucket.org/mobiflight/mobiflightfc/issues/265
                                                // https://bitbucket.org/mobiflight/mobiflightfc/issues/280/ftdi-driver-board-is-not-connected
                                                // added from https://github.com/arduino/Arduino/blob/1.8.0/hardware/arduino/avr/boards.txt#L51-L58
                "VID_2A03&PID_0010",
                "VID_2341&PID_0210",
                "VID_2341&PID_0242",
                "VID_10C4&PID_EA60"             // https://www.mobiflight.com/forum/message/20158.html
            };

        }
    }




    public class UnoCapabilities : MobiFlightCapabilities
    {
        public UnoCapabilities()
        {
            MaxOutputs = 8;
            MaxButtons = 8;
            MaxLedSegments = 1;
            MaxEncoders = 2;
            MaxSteppers = 2;
            MaxServos = 2;
            MaxLcdI2C = 2;
            MaxAnalogInputs = 2;
        }
    }
}