/* Title:           Work Task Stats Class
 * Date:            3-26-18
 * Author:          Terry Holmes
 * 
 * Description:     This is used to get information and calculate information */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace WorkTaskStatsDLL
{
    public class WorkTaskStatsClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        WorkTaskStatsDataSet aWorkTaskStatsDataSet;
        WorkTaskStatsDataSetTableAdapters.worktaskstatsTableAdapter aWorkTaskStatsTableAdapter;

        InsertWorkTaskStatsEntryTableAdapters.QueriesTableAdapter aInsertWorkTaskStatsTableAdapter;

        UpdateWorkTaskStatsEntryTableAdapters.QueriesTableAdapter aUpdateWorkTaskStatsTableAdapter;

        FindSortedWorkTaskStatsDataSet aFindSortedWorkTaskStatsDataSet;
        FindSortedWorkTaskStatsDataSetTableAdapters.FindSortedWorkTaskStatsTableAdapter aFindSortedWorkTaskStatsTableAdapter;

        FindWorkTaskStatsByTaskIDDataSet aFindWorkTaskStatsByTaskIDDataSet;
        FindWorkTaskStatsByTaskIDDataSetTableAdapters.FindWorkTaskStatsByWorkTaskIDTableAdapter aFindWorkTaskStatsByTaskIDTableAdapter;

        public FindWorkTaskStatsByTaskIDDataSet FindWorkTaskStatsByTaskID(int intWorkTaskID)
        {
            try
            {
                aFindWorkTaskStatsByTaskIDDataSet = new FindWorkTaskStatsByTaskIDDataSet();
                aFindWorkTaskStatsByTaskIDTableAdapter = new FindWorkTaskStatsByTaskIDDataSetTableAdapters.FindWorkTaskStatsByWorkTaskIDTableAdapter();
                aFindWorkTaskStatsByTaskIDTableAdapter.Fill(aFindWorkTaskStatsByTaskIDDataSet.FindWorkTaskStatsByWorkTaskID, intWorkTaskID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Task Stats Class // Find Work Task Stats By Task ID " + Ex.Message);
            }

            return aFindWorkTaskStatsByTaskIDDataSet;
        }
        public FindSortedWorkTaskStatsDataSet FindSortedWorkTaskStats()
        {
            try
            {
                aFindSortedWorkTaskStatsDataSet = new FindSortedWorkTaskStatsDataSet();
                aFindSortedWorkTaskStatsTableAdapter = new FindSortedWorkTaskStatsDataSetTableAdapters.FindSortedWorkTaskStatsTableAdapter();
                aFindSortedWorkTaskStatsTableAdapter.Fill(aFindSortedWorkTaskStatsDataSet.FindSortedWorkTaskStats);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Task Stats Class // Find Sorted Work Task Stats " + Ex.Message);
            }

            return aFindSortedWorkTaskStatsDataSet;
        }
        public bool UpdatetWorkTaskStats(int intWorkTaskID, decimal decTaskMean, decimal decTaskVariance, decimal decTaskSD, decimal decTaskLimiter)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateWorkTaskStatsTableAdapter = new UpdateWorkTaskStatsEntryTableAdapters.QueriesTableAdapter();
                aUpdateWorkTaskStatsTableAdapter.UpdateWorkTaskStats(intWorkTaskID, decTaskMean, decTaskVariance, decTaskSD, decTaskLimiter);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Task Stats Class // Update Work Task Stats " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertWorkTaskStats(int intWorkTaskID, decimal decTaskMean, decimal decTaskVariance, decimal decTaskSD, decimal decTaskLimiter)
        {
            bool blnFatalError = false;

            try
            {
                aInsertWorkTaskStatsTableAdapter = new InsertWorkTaskStatsEntryTableAdapters.QueriesTableAdapter();
                aInsertWorkTaskStatsTableAdapter.InsertWorkTaskStats(intWorkTaskID, decTaskMean, decTaskVariance, decTaskSD, decTaskLimiter);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Task Stats Class // Insert Work Task Stats " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public WorkTaskStatsDataSet GetWorkTaskStatsInfo()
        {
            try
            {
                aWorkTaskStatsDataSet = new WorkTaskStatsDataSet();
                aWorkTaskStatsTableAdapter = new WorkTaskStatsDataSetTableAdapters.worktaskstatsTableAdapter();
                aWorkTaskStatsTableAdapter.Fill(aWorkTaskStatsDataSet.worktaskstats);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Task Stats Class // Get Work Task Stats Info " + Ex.Message);
            }

            return aWorkTaskStatsDataSet;
        }
        public void UpdateWorkTaskStatsDB(WorkTaskStatsDataSet aWorkTaskStatsDataSet)
        {
            try
            {
                aWorkTaskStatsTableAdapter = new WorkTaskStatsDataSetTableAdapters.worktaskstatsTableAdapter();
                aWorkTaskStatsTableAdapter.Update(aWorkTaskStatsDataSet.worktaskstats);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Work Task Stats Class // Get Work Task Stats Info " + Ex.Message);
            }
        }
    }
}
