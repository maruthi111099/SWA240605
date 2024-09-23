using System.Collections.Generic;

namespace SWA240605_WebAPI.Application.Wrappers
{
    public class APIResponse<T>
    {
        public bool Succeed { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; } = default!;

        public APIResponse() 
        { }

        public APIResponse(T data)
        {
            Succeed = true;
            Data = data;
        }

        public APIResponse(T data, string message)
        {
            Succeed = true;
            Data = data;
            Message = message;
        }
    }
}
