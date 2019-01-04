using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlDeserializerSample
{
    [XmlRoot]
    public class RootScreen
    {
        [XmlAttribute]
        public string NamedNodeId;

        [XmlAttribute]
        public string ParentSubTarget;

        [XmlElement("MenuLandingScreen")]
        public List<MenuLandingScreen> menuLandingScreens = new List<MenuLandingScreen>();
    }

    public class MenuLandingScreen
    {
        [XmlAttribute]
        public string NamedNodeId;

        [XmlAttribute]
        public string ParentSubTarget;

        [XmlElement("PropertyScreen")]
        public List<PropertyScreen> PropertyScreens = new List<PropertyScreen>();
    }

    public class PropertyScreen
    {
        [XmlAttribute]
        public string NamedNodeId;

        [XmlAttribute]
        public string ParentSubTarget;

        [XmlElement("Text")]
        public List<string> ocrTextList = new List<string>();
    }


    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RootScreen));
            RootScreen result;

            StreamReader reader = new StreamReader(@"c:\Users\jsalama\Desktop\SettingsDeviceUiMapping.xml");
            result = (RootScreen) serializer.Deserialize(reader);

            Console.WriteLine(result.NamedNodeId);
            Console.WriteLine(result.ParentSubTarget);

            foreach (var landingScreen in result.menuLandingScreens)
            {
                Console.WriteLine('\t' + landingScreen.NamedNodeId);
                Console.WriteLine('\t' + landingScreen.ParentSubTarget);

                foreach (var propertyScreen in landingScreen.PropertyScreens)
                {
                    Console.WriteLine("\t\t" + propertyScreen.NamedNodeId);
                    Console.WriteLine("\t\t" + propertyScreen.ParentSubTarget);

                    foreach (var textField in propertyScreen.ocrTextList)
                    {
                        Console.WriteLine("\t\t\t" + textField);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
