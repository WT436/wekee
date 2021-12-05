﻿using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    public interface ISubjectAssignment
    {
        Task<List<SubjectAssignmentDto>> WatchAccountSubject(int id_Account);
        Task<List<SubjectAssignmentDto>> WatchSubjectRole(int id_Subject);
        Task<bool> CreateOrUpdateSubjectAssignment(int idSubject, int idRole);
    }
}