﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;

namespace MobiFlight
{
    static class MobiFlightFirmwareUpdater
    {
        /***
         * "D:\portableapps\arduino-1.0.5\hardware\tools\avr\bin\avrdude"
         */
        public static String ArduinoIdePath { get; set; }
        public static String AvrPath { get { return "hardware\\tools\\avr"; } }

        /***
         * C:\\Users\\SEBAST~1\\AppData\\Local\\Temp\\build2060068306446321513.tmp\\cmd_test_mega.cpp.hex
         **/
        public static String FirmwarePath { get; set; }

        public static bool IsValidArduinoIdePath(string path)
        {
            return Directory.Exists(path + "\\" + AvrPath);
        }

        public static bool IsValidFirmwareFilepath(string filepath)
        {
            return File.Exists(filepath);
        }

        public static bool Update(MobiFlightModule module)
        {
            String Port = module.InitUploadAndReturnUploadPort();
            if (module.Connected) module.Disconnect();

            while (!SerialPort.GetPortNames().Contains(Port))
            {
                System.Threading.Thread.Sleep(100);
            }

            RunAvrDude(Port, module.ArduinoType);

            return true;
        }

        /*
        public static String GetLatestFirmwareFile(String ArduinoType)
        {
            String prefix = "mobiflight_micro_";
            if (MobiFlightModuleInfo.TYPE_ARDUINO_MEGA == ArduinoType)
            {
                prefix = "mobiflight_mega_";
            }
            string[] filePaths = Directory.GetFiles(@FirmwarePath, prefix + "*.hex");

            String result = null;
            foreach (string file in filePaths)
            {
            }

            if (result == null) throw new FileNotFoundException("Could not find any firmware in " + FirmwarePath);
            return result;
        }
        */

        public static void RunAvrDude(String Port, String ArduinoType)
        {
            String FirmwareName = "mobiflight_mega_" + new MegaConfig().LatestFirmware.Replace('.', '_') + ".hex";
            String ArduinoChip = "atmega2560";
            String BaudRate = "115200";
            String C = "wiring";

            BoardConfigProvider configProvider = new BoardConfigProvider();
            List<MobiFlightBoardsConfig> boards = configProvider.GetBoardsConfigs();
            foreach (MobiFlightBoardsConfig cfg in boards)
            {
                if (cfg.TYPE_ARDUINO == ArduinoType)
                {
                    FirmwareName = cfg.FirmwarePrename + cfg.LatestFirmware.Replace('.', '_') + ".hex";
                    ArduinoChip = cfg.ArduinoChip;
                    BaudRate = cfg.BaudRate;
                    C = cfg.C;
                }
            }


            if (!IsValidFirmwareFilepath(FirmwarePath + "\\" + FirmwareName))
            {
                String message = "Firmware not found: " + FirmwarePath + "\\" + FirmwareName;
                Log.Instance.log(message, LogSeverity.Error);
                throw new FileNotFoundException(message);
            }

            String verboseLevel = "";
            //verboseLevel = " -v -v -v -v";

            String FullAvrDudePath = ArduinoIdePath + "\\" + AvrPath;

            var proc1 = new ProcessStartInfo();
            string anyCommand = "-C\"" + FullAvrDudePath + "\\etc\\avrdude.conf\"" + verboseLevel + " -p" + ArduinoChip + " -c" + C + " -P\\\\.\\" + Port + " -b" + BaudRate + " -D -Uflash:w:\"" + FirmwarePath + "\\" + FirmwareName + "\":i";
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = "\"" + FullAvrDudePath + "\"";
            proc1.FileName = "\"" + FullAvrDudePath + "\\bin\\avrdude" + "\"";
            //proc1.Verb = "runas";
            proc1.Arguments = anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            //proc1.WindowStyle = ProcessWindowStyle.Maximized;
            //proc1.RedirectStandardOutput = true;
            //proc1.RedirectStandardError = true;
            Log.Instance.log("RunAvrDude : " + proc1.FileName, LogSeverity.Info);
            Log.Instance.log("RunAvrDude : " + anyCommand, LogSeverity.Info);
            Process p = Process.Start(proc1);
            // string output = p.StandardOutput.ReadToEnd();
            // string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            //Log.Instance.log("Firmware Upload Output: " + output, LogSeverity.Debug);
            Log.Instance.log("Firmware Upload Exit Code: " + p.ExitCode, LogSeverity.Info);
            if (p.ExitCode != 0)
            {
                //Log.Instance.log("Firmware Upload Error Output: " + output, LogSeverity.Debug);
                String message = "Something went wrong when flashing with command \n" + proc1.FileName + " " + anyCommand;
                Log.Instance.log(message, LogSeverity.Error);
                throw new Exception(message);
            }
        }
    }
}
