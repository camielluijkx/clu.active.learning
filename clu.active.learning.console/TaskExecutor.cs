using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clu.active.learning.console
{
    public class TaskExecutor
    {
        public IEnumerable<Task> Execute(Action[] jobs) // log position of each operation
        {
            var tasks = new Task[jobs.Length];
            for (int i = 0; i < jobs.Length; i++)
            {
                //tasks[i] = Task.Factory.StartNew(() => RunJob(jobs[i], i)); // IOB

                tasks[i] = new Task((idx) => RunJob(jobs[(int)idx], (int)idx), i);
                tasks[i].Start();

                //tasks[i] = new Task(() => RunJob(jobs[i], i)); // IOB
                //tasks[i].Start();

                //tasks[i] = Task.Run(() => RunJob(jobs[i], i)); // IOB
            }
            return tasks;
        }

        public void RunJob(Action job, int index)
        {
            job.Invoke();

            Console.WriteLine($"Running job {index}.");
        }

        public static void Test()
        {
            TaskExecutor taskExecutor = new TaskExecutor();
            var jobs = new Action[10];

            for (int i = 0; i < jobs.Length; i++)
            {
                jobs[i] = new Action(() => Console.WriteLine($"Hello from job {i}!"));
            }

            taskExecutor.Execute(jobs);

            Console.ReadLine();
        }
    }
}