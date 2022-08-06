﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(AutoMapper.Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}