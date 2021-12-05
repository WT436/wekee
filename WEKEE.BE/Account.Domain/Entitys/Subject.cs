﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Entitys
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectAssignments = new HashSet<SubjectAssignment>();
            SubjectGroups = new HashSet<SubjectGroup>();
        }

        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int? GorupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual Group Gorup { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<SubjectAssignment> SubjectAssignments { get; set; }
        public virtual ICollection<SubjectGroup> SubjectGroups { get; set; }
    }
}