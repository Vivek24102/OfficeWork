﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebDemo_Common.Helper
{
    public class BaseApiResponse
    {
        public BaseApiResponse() { }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ApiResponse<T> : BaseApiResponse
    {
        public virtual IList<T> Data { get; set; }
    }
    public class ApiPostResponse<T> : BaseApiResponse
    {
        public virtual T Data { get; set; }
    }
}