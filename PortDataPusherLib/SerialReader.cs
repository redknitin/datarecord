using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PortDataPusher.Serial
{
    public class SerialReader : SerialAdapter
    {
        public SerialReader(string aPortname = "COM1", int aBaudrate = 9600, Parity aParity = Parity.None, int aDatabits = 9, StopBits aStopbits = StopBits.One) : base(aPortname, aBaudrate, aParity, aDatabits, aStopbits) { }

        public string Read()
        {
            mStop = false;
            mPort.ReadTimeout = 2000;
            int lData;
            while (true)
            {
                try
                {
                    //mPort.ReadTo(((byte)2).ToString());
                    lData = mPort.ReadByte();
                    if (lData != 2) continue;
                    List<byte> lstBytes = new List<byte>();
                    while ((lData = mPort.ReadByte()) != 3)
                    {
                        lstBytes.Add((byte)lData);
                    }
                    
                    string cdrString = System.Text.ASCIIEncoding.ASCII.GetString(lstBytes.ToArray());
                    cdrString.Replace("\r", "\0"); //Just in case a line break appears
                    cdrString.Replace("\n", "\0");

                    return cdrString;
                }
                catch (TimeoutException tex)
                {
                    continue;
                }
            }
        }
    }
}
