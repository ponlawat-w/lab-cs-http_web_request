using System;
using System.IO;
using System.Net;
using System.Text;

namespace get_request
{
    class Program
    {
        public static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create(args[0]);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();
            string statusText = ((HttpWebResponse)response).StatusDescription;
            Console.WriteLine("STATUS: " + statusText);
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string responseText = reader.ReadToEnd();
            Console.WriteLine("RESPONSE: " + responseText);
            reader.Close();
            response.Close();
        }
    }
}