using System;
using System.IO;
using System.Net;
using System.Text;

namespace post_request
{
    class Program
    {
        public static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create(args[0]);
            request.Method = "POST";

            string data = args[1];
            byte[] dataInBytes = Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataInBytes.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(dataInBytes, 0, dataInBytes.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            string statusText = ((HttpWebResponse)response).StatusDescription;
            Console.WriteLine("STATUS: " + statusText);
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string responseText = reader.ReadToEnd();

            Console.WriteLine("RESPONSE: " + responseText);

            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}