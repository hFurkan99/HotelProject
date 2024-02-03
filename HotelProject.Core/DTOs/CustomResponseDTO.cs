using System.Text.Json.Serialization;

namespace HotelProject.Core.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Messages { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                Messages = new List<string> { "It was done successfully" },
                Errors = new List<string> { "No error" }
            };
        }

        public static CustomResponseDTO<T> Success(T data, int statusCode)
        {
            return new CustomResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode,
                Messages = new List<string> { "It was done successfully" },
                Errors = new List<string> { "No error" }
            };
        }

        public static CustomResponseDTO<T> Success(T data, int statusCode, List<string> messages)
        {
            return new CustomResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode,
                Messages = messages,
                Errors = new List<string> { "No error" },
            };
        }

        public static CustomResponseDTO<T> Success(int statusCode, List<string> messages)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                Messages = messages,
                Errors = new List<string> { "No error" },
            };
        }

        public static CustomResponseDTO<T> Success(T data, int statusCode, string message)
        {
            return new CustomResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode,
                Messages = new List<string> { message }
            };
        }

        public static CustomResponseDTO<T> Success(int statusCode, string messages)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                Messages = new List<string> { messages },
                Errors = new List<string> { "No error" },
            };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                Errors = errors,
                Messages = new List<string> { "Operation failed" },
            };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                Errors = new List<string> { error },
                Messages = new List<string> { "Operation failed" },
            };
        }
    }
}
