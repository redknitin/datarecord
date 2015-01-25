using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PortDataPusher.Serial
{
    public class SerialPlayer : SerialAdapter
    {
        public SerialPlayer(string aPortname = "COM1", int aBaudrate = 9600, Parity aParity = Parity.None, int aDatabits = 9, StopBits aStopbits = StopBits.One) : base(aPortname, aBaudrate, aParity, aDatabits, aStopbits) { }

        public void Play(string aFilename)
        {
            var fsread = new System.IO.StreamReader(aFilename);
            string dataStr;
            while (!fsread.EndOfStream) { 
                dataStr = fsread.ReadLine();

                List<byte> lstByteData = new List<byte>();
                lstByteData.Add((byte)2);
                lstByteData.AddRange(System.Text.ASCIIEncoding.ASCII.GetBytes(dataStr));
                lstByteData.Add((byte)3);
                lstByteData.Add((byte)10);
                lstByteData.Add((byte)13);

                mPort.Write(lstByteData.ToArray(), 0, lstByteData.Count);
            }
        }
    }
}
