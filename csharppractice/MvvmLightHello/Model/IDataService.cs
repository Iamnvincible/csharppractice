using System;

namespace MvvmLightHello.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}