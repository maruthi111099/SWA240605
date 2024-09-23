using Newtonsoft.Json;
using System.IO;
using System;

namespace SWA240605_WebAPI.Application.Convertors
{
    public class StreamStringConverter : JsonConverter
    {
        private static Type AllowedType = typeof(Stream);

        public override bool CanConvert(Type objectType)
            => objectType == AllowedType;

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (existingValue == null) throw new Exception();
            if (reader == null || reader.Value == null) throw new Exception();

            var objectContents = (reader == null || reader.Value == null) ? string.Empty : (string)reader.Value;
            var base64Decoded = Convert.FromBase64String(objectContents);

            var memoryStream = new MemoryStream(base64Decoded);

            return memoryStream;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null) throw new Exception();

            var valueStream = (FileStream)value;
            var fileBytes = new byte[valueStream.Length];

            valueStream.Read(fileBytes, 0, (int)valueStream.Length);

            var bytesAsString = Convert.ToBase64String(fileBytes);

            writer.WriteValue(bytesAsString);
        }
    }
}
