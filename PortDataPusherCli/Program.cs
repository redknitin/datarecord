using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortDataPusher.Serial;

namespace PortDataPusherCli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() < 3)
            {
                string usageMsg = @"
PortDataPusherCli {CMD} {PORTNO} {FILENAME}

Commands:
r - record
p - play
";
                Console.WriteLine(usageMsg);
            }

            switch (args[0].ToLower())
            {
                case "r": //Record
                    //PortDataPusherCli.exe r com4 saga.txt
                    SerialRecorder sr = new SerialRecorder(args[1].ToUpper(), 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    sr.Record(args[2]);
                    break;
                case "p": //Play
                    //PortDataPusherCli.exe p com3 stargate.txt
                    SerialPlayer sp = new SerialPlayer(args[1].ToUpper(), 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                    sp.Play(args[2]);
                    break;
            }
        }
    }
}
