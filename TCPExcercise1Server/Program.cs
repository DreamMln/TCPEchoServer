using System;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace TCPExcercise1Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TCP Echo Server!");

            //The purpose of these exercises is to introduce you to
            //TCP Socket programming in C#

            //The first project to create is a simple Echo server.

            //In this first iteration of the server, the server must read a
            //line, and send that back, and after this, it must close the
            //connection.

            //initialize an object of the TcpListener class
            TcpListener listener = new TcpListener(IPAddress.Any, 7);
            //This object can “listen” for incoming connections on more
            //or more specific network adapter(s)(IPAddress) and
            //a specific port(7 in the example)

            //is not the client IP, it is because a host (PC) can have
            //several IP Addresses, and we can specify which to use,
            //meaning which should accept incoming connections (clients).

            //Call the .Start() method on your listener,
            //to begin listening for connections.
            listener.Start();

            //Then wait for a connection to be established. You will do
            //this be adding the code line:
            //AcceptTcpClient - This returns a TcpClient object
            //(which we will refer to as socket), which can be
            //communicated with.

            TcpClient socket = listener.AcceptTcpClient();
            //The code will stop here, and wait until a client connects.
            //Nothing more will be executed until then.

            //streams - read and write to the connection
            //These streams are accessed by first getting a stream
            //containing both:
            NetworkStream networkStream = socket.GetStream();
            //then splitting it into two streams
            StreamReader reader = new StreamReader(networkStream);
            StreamWriter writer = new StreamWriter(networkStream);

            //This is the server you are creating.

            //read what the client sends by calling the method
            //ReadLine on the reader object:
            string message = reader.ReadLine();

            //For debugging purposes write the line you just read
            //to the Console.
            Console.WriteLine("From client: " + message);

            //Herfra bliver det ECHO:
            //This is a simple echo server, that only reacts to a single message
            //and echo that back. This is now archived. 
            //Then write the line back to the client, use the writer object:
            writer.WriteLine("From server: " + message);
            //This means that all that is left is cleanup.
            //Whenever you are writing to a stream, you should always flush!
            //skyl ud!
            writer.Flush();
            //Close socket, stop the listner
            socket.Close();
            listener.Stop();





        }
    }
}
