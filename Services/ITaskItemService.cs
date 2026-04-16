using Taskly.Models;
using Taskly.Repositories;

namespace Taskly.Services
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetCompletedTasks();
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem newTaskItem);
        Task<TaskItem> UpdateTaskAsync(int id, TaskItem newTaskItem);
        Task DeleteTaskAsync(int id);
    }
}