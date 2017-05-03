﻿using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogR.Code.Models.Search
{
    public class PerformanceLogSearchCriteria : BaseSearchCriteria
    {
        public String AppName { get; set; }
        public Double? TimeTaken { get; set; }
    }
}
