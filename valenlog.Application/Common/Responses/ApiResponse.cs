﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResponse<T> Ok(T data, string? message = null) => new()
        {
            Success = true,
            Message = message,
            Data = data
        };

        public static ApiResponse<T> Fail(string? message = null, List<string>? errors = null) => new()
        {
            Success = false,
            Message = message,
            Errors = errors
        };
    }
}
