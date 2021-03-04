using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TeamworkSimulation.Model
{
    public class WindowsServicesFactory : ServicesFactory
    {


        public override IFileService CreateFileService()
        {
            return new WindowsFileService();
        }

        public override IUserMessageService CreateUserMessageService()
        {
            return new WindowsUserMessage();
        }

        public override ISerializationService<T> CreateSerializer<T>()
        {
            return new XmlSerialization<T>();
        }
    }
}
