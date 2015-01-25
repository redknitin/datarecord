using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PortDataPusher.Serial
{
    public class SerialAdapter : IDisposable
    {
        protected SerialPort mPort = null;
        protected bool mStop = false;

        public SerialAdapter(string aPortname, int aBaudrate, Parity aParity, int aDatabits, StopBits aStopbits)
        {
            mPort = new SerialPort(aPortname, aBaudrate, aParity, aDatabits, aStopbits);
            mPort.DiscardNull = mPort.DtrEnable = mPort.RtsEnable = true;
            mPort.Handshake = Handshake.RequestToSendXOnXOff;
            mPort.Open();
        }

        public void Dispose()
        {
            if (mPort == null) return; //just in case
            if (mPort.IsOpen) mPort.Close();
        }
    }
}
