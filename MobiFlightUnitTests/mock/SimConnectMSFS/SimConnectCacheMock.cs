﻿using MobiFlight.SimConnectMSFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiFlightUnitTests.mock.SimConnectMSFS
{
    class SimConnectCacheMock : SimConnectCache
    {
        public void Clear()
        {
            return;
        }

        public bool connect()
        {
            return true;
        }

        public bool disconnect()
        {
            return true;
        }

        public double getFloatValue(int offset, byte size)
        {
            return double.MaxValue;
        }

        public long getLongValue(int offset, byte size)
        {
            return long.MaxValue;
        }

        public double getDoubleValue(int offset, byte size)
        {
            return double.MaxValue;
        }

        public string getStringValue(int offset, byte size)
        {
            return "String";
        }

        public long getValue(int offset, byte size)
        {
            return long.MaxValue;
        }

        public bool isConnected()
        {
            return true;
        }

        public void setOffset(int offset, byte value)
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = offset, Value = value.ToString() });
            return;
        }

        public void setOffset(int offset, short value)
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = offset, Value = value.ToString() });
            return;
        }

        public void setOffset(int offset, int value, bool writeOnly)
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = offset, Value = value.ToString() });
            return;
        }

        public void setOffset(int offset, float value)
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = offset, Value = value.ToString() });
            return;
        }

        public void setOffset(int offset, double value)
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = offset, Value = value.ToString() });
            return;
        }

        public void setOffset(int offset, string value)
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = offset, Value = value.ToString() });
            return;
        }

        public void executeMacro(string macroName, int paramValue)
        { 
            //FIXME: need to mock this correctly.
            return;
        }

        public void setEventID(int eventID, int param)
        {
            /*
             * This is the old way of setting the eventID
             * It actually became deprecated with the 
             * new FSUIPC library because it offers
             * a special function and there is not 
             * so much that we can test here
             */
            Writes.Add(new FSUIPCMockOffset() { Offset = 0x0, Value = "SetEventID" });
            return;
        }

        public void setEventID(string param)
        {
            /*
             * This is the old way of setting the eventID
             * It actually became deprecated with the 
             * new FSUIPC library because it offers
             * a special function and there is not 
             * so much that we can test here
             */
            Writes.Add(new FSUIPCMockOffset() { Offset = 0x0, Value = "SetEventID" });
            return;
        }

        public void Write()
        {
            Writes.Add(new FSUIPCMockOffset() { Offset = 0x0, Value = "Write" });
            return;
        }
    }

    class FSUIPCMockOffset
    {
        public int Offset;
        public String Value;
    }
}