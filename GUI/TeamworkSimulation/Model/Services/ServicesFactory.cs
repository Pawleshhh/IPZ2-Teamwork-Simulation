using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public abstract class ServicesFactory
    {

        public abstract IFileService CreateFileService();

        public abstract IUserMessageService CreateUserMessageService();

        public abstract ISerializationService<T> CreateSerializer<T>();

    }
}
