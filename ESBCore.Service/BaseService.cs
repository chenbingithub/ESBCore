using Abp.Application.Services;
using ESBCore.BackgroundJob;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.Service
{
   public abstract class BaseService : ApplicationService
    {
        public abstract void Execute(TaskActionJobArgs args);
    }
}
