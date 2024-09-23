using SWA240605_WebAPI.Application.Convertors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace SWA240605_WebAPI.Application.Wrappers
{
    public class DocumentResponse<T> where T : FileStream
    {
        public bool Succeed { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();

        public string FileName { get; set; } = string.Empty;
        public DateTime FileCreatedOn { get; set; }

        [JsonConverter(typeof(StreamStringConverter))]
        public T Data { get; set; }

        public DocumentResponse(T data)
        {
            Data = data;
        }

        public DocumentResponse(T data, string fileName, DateTime fileCreatedOn)
        {
            Succeed = true;
            FileName = fileName;
            FileCreatedOn = fileCreatedOn;
            Data = data;
        }

        public DocumentResponse(T data, string fileName, DateTime fileCreatedOn, string message)
        {
            Succeed = true;
            Message = message;
            FileName = fileName;
            FileCreatedOn = fileCreatedOn;
            Data = data;
        }
    }
}
