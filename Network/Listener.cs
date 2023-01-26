using System;
using System.Net.Sockets;
using System.Net;
using System.Text;


namespace A2.Listener
{
class Listener
{


    static IPAddress mcastAddress;
    static int mcastPort;
    static Socket mcastSocket;



    static void BroadcastMessage(string message)
    {

    }


    static void Main()
    {
        // Initialize the multicast address group and multicast port.
        // Both address and port are selected from the allowed sets as
        // defined in the related RFC documents. These are the same 
        // as the values used by the sender.
        mcastAddress = IPAddress.Parse("230.0.0.1");
        mcastPort = 11000;
        IPEndPoint endPoint;

        try
        {
            mcastSocket = new Socket(AddressFamily.InterNetwork,
                           SocketType.Dgram,
                           ProtocolType.Udp);

            //Send multicast packets to the listener.
            endPoint = new IPEndPoint(mcastAddress, mcastPort);
            mcastSocket.SendTo(ASCIIEncoding.ASCII.GetBytes("Hello Multicast Listener"), endPoint);
            Console.WriteLine("Multicast data sent.....");
        }
        catch (Exception e)
        {
            Console.WriteLine("\n" + e.ToString());
        }

        mcastSocket.Close();

    }
}
}