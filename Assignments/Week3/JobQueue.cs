using System;
using Assignments.Common;

namespace Assignments.Week3
{
    public class JobQueueWorker : IComparable<JobQueueWorker>, IPrioritizable
    {
        public readonly int Id;
        public long NextFreeTime;

        public JobQueueWorker(int id)
        {
            Id = id;
        }


        public int CompareTo(JobQueueWorker other)
        {
            if (NextFreeTime == other.NextFreeTime)
            {
                return other.Id - Id;
            }
            return other.NextFreeTime - NextFreeTime > 0 ? 1 : -1;
        }

        public void SetMaxPriority()
        {
            throw new NotImplementedException();
        }
    }

    public class JobQueue : IAssignment
    {
        private class JobQueueReport
        {
            public readonly int AssignedWorker;
            public readonly long StartTime;

            public JobQueueReport(int assignedWorker, long startTime)
            {
                AssignedWorker = assignedWorker;
                StartTime = startTime;
            }
        }

        public string Execute(IDataSource input)
        {
            input.MoveNext();
            var numWorkers = input.Current.NextInt();
            var m = input.Current.NextInt();

            input.MoveNext();
            var jobs = new int[m];
            for (int i = 0; i < m; ++i)
            {
                jobs[i] = input.Current.NextInt();
            }

            var reports = AssignJobs(numWorkers, jobs);
            var res = new DataSource();
            foreach (var report in reports)
            {
                res.AppendLine(report.AssignedWorker + " " + report.StartTime);
            }
            return res.ToString();
        }

        private JobQueueReport[] _AssignJobs(int numWorkers, int[] jobs)
        {
            // TODO: replace this code with a faster algorithm.
            var reports = new JobQueueReport[jobs.Length];
            var heap = new PriorityQueue<JobQueueWorker>(numWorkers);
            for (int i = 0; i < numWorkers; i++)
            {
                heap.Insert(new JobQueueWorker(id: i));
            }

            for (int i = 0; i < jobs.Length; i++)
            {
                int duration = jobs[i];
                var bestWorker = heap.GetMax();

                reports[i] = new JobQueueReport(assignedWorker: bestWorker.Id, startTime: bestWorker.NextFreeTime);
                bestWorker.NextFreeTime += duration;

                heap.UpdateMax();
            }
            return reports;
        }

        private JobQueueReport[] AssignJobs(int numWorkers, int[] jobs)
        {
            // TODO: replace this code with a faster algorithm.
            var reports = new JobQueueReport[jobs.Length];
            long[] nextFreeTime = new long[numWorkers];
            for (int i = 0; i < jobs.Length; i++)
            {
                int duration = jobs[i];
                int bestWorker = 0;
                for (int j = 0; j < numWorkers; ++j)
                {
                    if (nextFreeTime[j] < nextFreeTime[bestWorker])
                    {
                        bestWorker = j;
                    }
                }
                reports[i] = new JobQueueReport(assignedWorker: bestWorker, startTime: nextFreeTime[bestWorker]);
                nextFreeTime[bestWorker] += duration;
            }
            return reports;
        }
    }
}