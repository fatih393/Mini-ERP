using Mini_ERP.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Application.Features
{
    public class DataResult<T> : IDataResult<T>
    {
        public bool Success { get; }

        public string Message { get; }

        public T Data { get; }
        public DataResult(T data, bool success, string message )
        {
            Success = success;
            Message = message;
            Data = data;
        }
     
    }

    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult( T data,string message) : base(data,true, message) { }
        
        public SuccessDataResult(T data): base(data, true, null) { }
    }
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message) : base(default, false, message) { }
        public ErrorDataResult() : base(default, false, "Bir hata oldu") { }
    }


}
