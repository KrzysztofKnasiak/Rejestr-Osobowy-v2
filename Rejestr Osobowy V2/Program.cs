using System;
using System.IO;
using System.Xml.Serialization;
namespace Rejestr_Osobowy_V2
{
    [Serializable]
    class Program
    {
        public static Memory m = new Memory();
        static void Main(string[] args)
        {

            LoadXML();
            m.Menu();
            SaveXML();
            
            

        }

        public static void LoadXML()
        {
            try
            {
                Stream FileRe = new FileStream("SAVE1.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer read = new XmlSerializer(typeof(Memory));
                m = (Memory)read.Deserialize(FileRe);
                FileRe.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SaveXML()
        {
            try
            {
                Console.WriteLine("Zapisywanie danych i zamykanie aplikacji ...");
                Stream FileWr = new FileStream("SAVE1.xml", FileMode.Create);
                XmlSerializer save = new XmlSerializer(typeof(Memory));
                save.Serialize(FileWr, m);
                FileWr.Close();
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

    }
}
