﻿using System;
using System.Collections.Generic;
using Framework.Infrastructure.Models.Result;
using Framework.Infrastructure.Models.Search;
using LogR.Common.Enums;
using LogR.Common.Models.Logs;
using LogR.Common.Models.Search;
using LogR.Common.Models.Stats;

namespace LogR.Common.Interfaces.Repository.Log
{
    public interface ILogReadRepository
    {
        //API for getting logs
        ReturnListWithSearchModel<AppLog, AppLogSearchCriteria> GetAppLogs(AppLogSearchCriteria search);

        ReturnListWithSearchModel<PerfLog, PerformanceLogSearchCriteria> GetPerformanceLogs(PerformanceLogSearchCriteria search);

        ReturnListWithSearchModel<WebLog, WebLogSearchCriteria> GetWebLogs(WebLogSearchCriteria search);

        ReturnListWithSearchModel<EventLog, EventLogSearchCriteria> GetEventLogs(EventLogSearchCriteria search);

        // Parameters
        ReturnListWithSearchModel<string, BaseSearchCriteria> GetAppNames(StoredLogType logType, BaseSearchCriteria search);

        ReturnListWithSearchModel<string, BaseSearchCriteria> GetMachineNames(StoredLogType logType, BaseSearchCriteria search);

        ReturnListWithSearchModel<string, BaseSearchCriteria> GetUserNames(StoredLogType logType, BaseSearchCriteria search);

        ReturnListWithSearchModel<string, BaseSearchCriteria> GetSeverityNames(StoredLogType logType, BaseSearchCriteria search);

        //Stats API
        Dictionary<DateTime, long> GetAppLogsStatsByDay();

        ReturnModel<DashboardSummary> GetDashboardSummary();

        void GetPerformanceLogsStatsByDay();

        ReturnModel<SystemStats> GetStats();
    }
}