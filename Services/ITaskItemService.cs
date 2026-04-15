using Taskly.Models;
using Taskly.Repositories;

namespace Taskly.Services
{
    public interface ITaskItemService
    {
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        TaskItem CreateTask(TaskItem newTaskItem);
        void UpdateTask(TaskItem newTaskItem);
        void DeleteTask(int id);
    }
}