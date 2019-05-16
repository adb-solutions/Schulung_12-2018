using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using FlowDesign.Shared;

namespace FlowDesign.Persistenz
{
    public static class XMLSerialisierer
    {
        internal static void SerializieObject(string pfad, Transaktion transaktion)
        {
            XmlSerializer serializer = new XmlSerializer(transaktion.GetType());

            using (FileStream stream = new FileStream(pfad, FileMode.Append))
            {
                serializer.Serialize(stream, transaktion);
            }
        }

        internal static object DeserializeObject(string eintrag, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            using (StringReader stringReader = new StringReader(eintrag))
            {
                object obj = serializer.Deserialize(stringReader);
                return obj;
            }
        }
    }
}