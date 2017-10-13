﻿using System;
using Framework.Infrastructure.Logging;
using Framework.Infrastructure.Models.Result;
using LogR.Common.Enums;
using LogR.Common.Interfaces.Repository;
using LogR.Common.Interfaces.Service;
using LogR.Common.Models.Logs;
using LogR.Common.Models.Search;
using LogR.Common.Models.Stats;

namespace LogR.Service
{
    public class LogRetrivalService : ILogRetrivalService
    {
        private ILog log;
        private ILogRepository logRepository;

        public LogRetrivalService(ILog log, ILogRepository logRepository)
        {
            this.log = log;
            this.logRepository = logRepository;
        }

        public ReturnModel<DashboardSummary> GetDashboardSummary()
        {
            var result = logRepository.GetDashboardSummary();
            return result;
        }

        public ReturnListWithSearchModel<AppLog, AppLogSearchCriteria> GetAppLogs(AppLogSearchCriteria search)
        {
            try
            {
                return logRepository.GetAppLogs(search);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error when getting App Log  List ");
                search.TotalRowCount = 0;
                search.CurrentRows = 0;
                return new ReturnListWithSearchModel<AppLog, AppLogSearchCriteria>(search, ex);
            }
        }

        public ReturnListWithSearchModel<PerfLog, PerformanceLogSearchCriteria> GetPerformanceLogs(PerformanceLogSearchCriteria search)
        {
            try
            {
                return logRepository.GetPerformanceLogs(search);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error when getting Performance Log  List ");
                search.TotalRowCount = 0;
                search.CurrentRows = 0;
                return new ReturnListWithSearchModel<PerfLog, PerformanceLogSearchCriteria>(search, ex);
            }
        }

        public ReturnModel<bool> DeleteAppLog(string id)
        {
            try
            {
                return logRepository.DeleteLog(StoredLogType.AppLog, id);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error when getting Deleting App Log  - id = " + id);
                return new ReturnModel<bool>(ex);
            }
        }

        public ReturnModel<bool> DeletePerformanceLog(string id)
        {
            try
            {
                return logRepository.DeleteLog(StoredLogType.PerfLog, id);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error when getting Deleting Performance Log  - id = " + id);
                return new ReturnModel<bool>(ex);
            }
        }

        public ReturnModel<SystemStats> GetStats()
        {
            try
            {
                return logRepository.GetStats();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Error when getting stats");
                return new ReturnModel<SystemStats>("Error when getting stats", ex);
            }
        }
    }
}
