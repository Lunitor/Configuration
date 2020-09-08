using Lunitor.Configuration.Core;
using Lunitor.Configuration.Core.Model;
using Microsoft.Win32.TaskScheduler;

namespace Lunitor.Configuration.Infrastructure
{
    public class WindowsTaskServiceConfigurator : IServiceConfigurator
    {
        public void Start(Service service)
        {
            var task = TaskService.Instance.GetTask(service.Name);
            task.Enabled = true;
        }

        public void Stop(Service service)
        {
            var task = TaskService.Instance.GetTask(service.Name);
            task.Enabled = false;
        }

        public ServiceStatus GetStatus(Service service)
        {
            var taskName = service.Name.Replace("/", "\\");
            var task = TaskService.Instance.GetTask(taskName);

            return task.Enabled ? ServiceStatus.Running : ServiceStatus.Stopped;
        }
    }
}
