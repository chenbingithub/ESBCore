using Abp.Application.Services;
using ESBCore.BackgroundJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESBCore
{
    public interface ITaskActionAppService : IApplicationService
    {
        void Execute(TaskActionJobArgs args);
        void Enqueue(TaskActionJobArgs args);
    }
}
