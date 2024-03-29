﻿using System.Collections.Generic;

namespace Api.Helper.ContentWrapper.MVC.ResponseModel
{
    public class ListResultDto<T> 
    {
        public List<T> Data { get; set; } = new List<T>();
        public string Summary { get; set; }

        public ListResultDto(List<T> data, string summary = "")
        {
            this.Data = data;
            this.Summary = summary;
        }
    }
}
