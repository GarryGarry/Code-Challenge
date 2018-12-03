using System;
using System.Collections.Generic;
using System.Text;
using dotnet_code_challenge.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Xml.Linq;
using System.Xml;

namespace dotnet_code_challenge
{
    public class PrintNames
    {
        public void GetFilePath()
        {
            List<RaceViewModel> Model = new List<RaceViewModel>();
            var pathToJson = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "dotnet-code-challenge/FeedData/Wolferhampton_Race1.json");

            using (StreamReader r = File.OpenText(pathToJson))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var child in array["RawData"]["Markets"][0]["Selections"])
                {
                    var name = child["Tags"]["name"];
                    var price = child["Price"];
                    var nP = new RaceViewModel
                    {
                        Name = name,
                        Price = price
                    };
                    Model.Add(nP);
                }
                PrintNames p = new PrintNames();
                p.Print(Model);               
            }
        }

        public ArrayList Print(List<RaceViewModel> model)
        {
            if(model == null)
            {
                Console.WriteLine("Names are {0}", "No data is avialable");
                throw new NullReferenceException("model is null");
            };
            var values = model.OrderBy(x => x.Price).ToList();
            ArrayList k = new ArrayList();
            foreach (var m in values)
            {
                var n  = string.IsNullOrEmpty(m.Name) ? " " : m.Name;                
                Console.WriteLine("Names are : {0}", n);             
                k.Add(n);
            }
            return k;
           
        }
    }
}
