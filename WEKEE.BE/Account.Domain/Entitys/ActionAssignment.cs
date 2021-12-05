﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class ActionAssignment
    {
        public int Id { get; set; }
        public int? PermissionId { get; set; }
        public int? ActionId { get; set; }
        public DateTime DateCreate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Action Action { get; set; }
        public virtual Permission Permission { get; set; }
    }
}