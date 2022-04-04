﻿using Album.Application.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Album.Application.Domain.Shared.DataTransfer
{
    public class BasicImage
    {
        public Image Image { get; set; }
        public string NameReturn { get; set; }
        public ConfigImaging Quality { get; set; } = ConfigImaging.Low;
    }
}
