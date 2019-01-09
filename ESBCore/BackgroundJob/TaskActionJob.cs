using Abp.BackgroundJobs;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.BackgroundJob
{
    public class TaskActionJob : BackgroundJob<TaskActionJobArgs>, ITransientDependency
    {
        private ITaskActionAppService _taskActionAppService;
        public TaskActionJob(ITaskActionAppService taskActionAppService)
        {
            _taskActionAppService = taskActionAppService;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        public override void Execute(TaskActionJobArgs args)
        {
            _taskActionAppService.Execute(args);
        }
    }
}
