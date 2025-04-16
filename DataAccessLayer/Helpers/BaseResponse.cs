using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers
{
    public class BaseResponse<T>
    {
        public bool Ok { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public string? Succeeded { get; set; }


        public static BaseResponse<T> OK(T data, string message = "")
        {
            return new BaseResponse<T>
            {
                Ok = true,
                Message = message,
                Data = data,
                Succeeded = "200"
            };
        }

        public static BaseResponse<T> Fail(string message)
        {
            return new BaseResponse<T>
            {
                Ok = false,
                Message = message
            };
        }
    }
}
