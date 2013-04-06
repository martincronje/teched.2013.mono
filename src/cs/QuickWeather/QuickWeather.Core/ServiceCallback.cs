using System;

namespace QuickWeather.Core
{
    public class ServiceCallback<T>
    {
        public ServiceCallback(Action<T> onData, Action<Exception> onError)
        {
            OnError = onError;
            OnData = onData;
        }

        public Action<Exception> OnError { get; private set; }
        public Action<T> OnData { get; private set; }
    }
}