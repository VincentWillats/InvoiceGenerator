using System.IO;
using System.Xml.Serialization;

namespace InvoiceGenerator
{
    class XmlManager
    {
        public static void xmlDataWriter(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        public static Settings XmlSettingsReader(string filename)
        {
            Settings obj = new Settings();
            XmlSerializer xs = new XmlSerializer(typeof(Settings));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            obj = (Settings)xs.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
