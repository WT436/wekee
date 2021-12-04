﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues
{
    public class SearchOrderPageInput: OrderByPageListInput
    {
        /// <summary>Tên trường tìm kiếm</summary>
        public string PropertySearch { get; set; } = "None";
        /// <summary>Nội dung</summary>
        public string ValuesSearch { get; set; } = "None";
    }
}
