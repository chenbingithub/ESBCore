using Abp.Application.Services;
using Abp.BackgroundJobs;
using Abp.Reflection.Extensions;
using ESBCore.BackgroundJob;
using ESBCore.Service.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ESBCore.Service
{
    public class TaskActionAppService : ApplicationService, ITaskActionAppService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TaskActionAppService(IBackgroundJobManager backgroundJobManager)
        {
            _backgroundJobManager = backgroundJobManager;
        }
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  void Enqueue(TaskActionJobArgs args)
        {
             _backgroundJobManager.Enqueue<TaskActionJob, TaskActionJobArgs>(args);
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        public void Execute(TaskActionJobArgs args)
        {
           var service= Assembly.Load(typeof(TaskActionAppService).Assembly.GetName()).CreateInstance(args.targetservice) as BaseService;
            service.Execute(args);
        }
    }
}
