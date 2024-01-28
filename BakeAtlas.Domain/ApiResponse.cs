﻿namespace BakeAtlas.Domain
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse(bool isSucceeded, string message, int statusCode, T data, List<string> errors)
        {
            Succeeded = isSucceeded;
            Message = message;
            StatusCode = statusCode;
            Data = data;
            Errors = errors;
        }

        public ApiResponse(T data, string message = null, int statusCode = 200)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        // Constructor for failed responses with errors
        //added
        public ApiResponse(List<string> errors, string message = null, int statusCode = 400)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            StatusCode = statusCode;
        }

        public ApiResponse(bool isSucceeded, int statusCode, string message)
        {
            Succeeded = isSucceeded;
            Message = message;
            StatusCode = statusCode;
        }

        //ended
        public ApiResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public ApiResponse(bool isSucceeded, T data, List<string> errors)
        {
            Succeeded = isSucceeded;
            Data = data;
            Errors = errors;
        }
        public ApiResponse(bool isSucceeded, string message, int statusCode, List<string> errors)
        {
            Succeeded = isSucceeded;
            Errors = errors;
            Message = message;
            StatusCode = statusCode;
            Errors = errors;
        }
        public static ApiResponse<T> Success(T data, string message, int statusCode)
        {
            return new ApiResponse<T>(true, message, statusCode, data, new List<string>());
        }
        public static ApiResponse<T> Failed(List<string> errors)
        {
            return new ApiResponse<T>(false, default, errors);
        }
        public static ApiResponse<T> Failed(bool isSucceeded, string message, int statusCode, List<string> errors)
        {
            return new ApiResponse<T>(isSucceeded, message, statusCode, errors);
        } 
      
    }
}
