using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parser
{
    record Dog : IElement
    {
        public string Name { get; init; }
        public string Weight { get; init; }
        public string Color { get; init; }

        public Dog(string name, string weight, string color)
        {
            Name = name;
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            return $"Dog(name={Name}, weight={Weight}, color={Color})";
        }
    }

    class Dogs : AFields
    {
        private List<IElement> _dogs = new List<IElement>();
        public override List<IElement> Elements { get => _dogs; set => _dogs = value; }

        public Dogs(List<IElement> dogs)
        {
            _dogs = dogs;
        }

        public override string ToString()
        {
            string result = "Dogs {\r\n";
            _dogs.ForEach(e => result += $"\t{e.ToString()}\r\n");
            result += "}";

            return result;
        }
    }

    class Parse : AParse
    {
        public override AFields FormatParse(string filepath)
        {
            XDocument xdoc = XDocument.Load(filepath);
            XElement? firstElement = xdoc.Element("dogs");

            if (firstElement == null)
                throw new NullReferenceException("Failture while document parsing");

            List<IElement> result = new List<IElement>();

            foreach (XElement cd in firstElement.Elements("dog"))
            {
                Dog disk = new Dog(
                    cd.Element("dogName")!.Value,
                    double.Parse(cd.Element("dogWeight")!.Value).ToString() + cd.Element("dogWeight")!.Attribute("caption")!.Value,
                    cd.Element("dogColor")!.Value
                    );

                result.Add((IElement)disk);
            }

            return new Dogs(result);
        }
    }
}
