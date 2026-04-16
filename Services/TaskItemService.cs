using System.Collections.Generic;
using Taskly.Models;
using Taskly.Repositories;

namespace Taskly.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskRepository _repository;

        public TaskItemService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> GetAllTasksAsync() => await _repository.GetAllTasksAsync();
        public async Task<TaskItem> GetTaskByIdAsync(int id) => await _repository.GetTaskByIdAsync(id);
        public async Task<TaskItem> CreateTaskAsync(TaskItem newTaskItem) => await _repository.CreateTaskAsync(newTaskItem);
        public async Task UpdateTaskAsync(TaskItem newTaskItem) => await _repository.UpdateTaskAsync(newTaskItem);
        public async Task DeleteTaskAsync(int id) => await _repository.DeleteTaskAsync(id);
    }
}
