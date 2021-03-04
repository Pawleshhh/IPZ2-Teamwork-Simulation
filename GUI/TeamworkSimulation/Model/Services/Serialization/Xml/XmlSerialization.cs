using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace TeamworkSimulation.Model
{
    public class XmlSerialization<T> : ISerializationService<T>
    {

        public XmlWriterSettings WriterSettings { get; set; } = new XmlWriterSettings();
        public XmlReaderSettings ReaderSettings { get; set; } = new XmlReaderSettings();

        public T LoadObject(string path)
        {
            var deSer = new DataContractSerializer(typeof(T));

            using (XmlReader r = XmlReader.Create(path, ReaderSettings))
            {
                return (T)deSer.ReadObject(r);
            }
        }

        public void SaveObject(T t, string path)
        {
            var ser = new DataContractSerializer(typeof(T));

            using (XmlWriter writer = XmlWriter.Create(path, WriterSettings))
            {
                ser.WriteObject(writer, t);
            }
        }
    }
}
