using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainContent.Generic
{
    /// <summary>
    /// 泛型结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct PieceOfData<T>
    {
        private T _Data;

        public T Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public PieceOfData(T value)
        {
            _Data = value;
        }        
    }

    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IMyIfc<T>
    {
        T ReturnIt(T inValue);
    }
}
