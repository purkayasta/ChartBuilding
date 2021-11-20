﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Interfaces
{
    public interface IObjectService
    {
        ValueTask<IEnumerable<ObjectDto>> GetAllAsync();
    }
}
