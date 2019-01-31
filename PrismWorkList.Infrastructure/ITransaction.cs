using System;

namespace PrismWorkList.Infrastructure
{
    public interface ITransaction:IDisposable
    {
        void Complete();
    }
}
