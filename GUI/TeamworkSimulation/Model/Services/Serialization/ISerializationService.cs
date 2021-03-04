using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public interface ISerializationService<T>
    {

        T LoadObject(string path);

        void SaveObject(T t, string path);

    }
}
