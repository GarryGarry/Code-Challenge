using System;
using System.Collections.Generic;
using System.IO;
using dotnet_code_challenge.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace dotnet_code_challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintNames p = new PrintNames();           
            p.GetFilePath();
            Console.ReadLine();
        }


    }
}