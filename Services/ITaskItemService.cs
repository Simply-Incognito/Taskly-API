using Taskly.Models;
using Taskly.Repositories;

namespace Taskly.Services
{
    public interface ITaskItemService
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem newTaskItem);
        Task UpdateTaskAsync(TaskItem newTaskItem);
        Task DeleteTaskAsync(int id);
    }
}