﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Domain.Dto;
using Account.Domain.ObjectValues;

namespace Account.Application.Interface
{
    public interface IAtomic
    {
        List<AtomicDto> GetAll();
        Task<List<AtomicDto>> GetAllAsync();
    }
}