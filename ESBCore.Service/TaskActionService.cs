using Abp.Application.Services;
using Abp.BackgroundJobs;
using Abp.Dependency;
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
    public class TaskActionService : ApplicationService, ITaskActionService
    {
        private readonly IBackgroundJobManager _backgroundJobManager;

        public TaskActionService(IBackgroundJobManager backgroundJobManager)
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
            var service = IocManager.Instance.Resolve<BaseService>(Type.GetType(args.targetservice));
            service.Execute(args);
        }
    }
}
