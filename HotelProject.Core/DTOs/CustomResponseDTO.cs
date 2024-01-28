using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelProject.Core.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDTO<T> Success(T data, int statusCode)
        {
            return new CustomResponseDTO<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDTO<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                Errors = new List<string> { error }
            };
        }
    }

    public class CustomNoContentResponseDTO
    {
        //public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        //public static CustomNoContentResponseDTO Succes(T data, int statusCode)
        //{
        //    return new CustomNoContentResponseDTO { Data = data, StatusCode = statusCode };
        //}

        public static CustomNoContentResponseDTO Success(int statusCode)
        {
            return new CustomNoContentResponseDTO { StatusCode = statusCode };
        }

        public static CustomNoContentResponseDTO Fail(int statusCode, List<string> errors)
        {
            return new CustomNoContentResponseDTO { StatusCode = statusCode, Errors = errors };
        }

        public static CustomNoContentResponseDTO Fail(int statusCode, string error)
        {
            return new CustomNoContentResponseDTO
            {
                StatusCode = statusCode,
                Errors = new List<string> { error }
            };
        }
    }
}
