using System.Collections.Generic;
using TaskCoreAPI.Exceptions;
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

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllTasksAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetCompletedTasks()
        {
            return (await _repository.GetAllTasksAsync()).Where(item => item.IsCompleted == true);
             
        }
        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            if (id <= 0) throw new BadRequestException("Invalid ID");

            _= await _repository.GetTaskByIdAsync(id) ?? throw new NotFoundException("Task not found.");

            return await _repository.GetTaskByIdAsync(id);

        }
        public async Task<TaskItem> CreateTaskAsync(TaskItem newTaskItem)
        {
            if (newTaskItem == null || string.IsNullOrEmpty(newTaskItem.Title)) throw new BadRequestException("Task Title cannot be empty.");

            return await _repository.CreateTaskAsync(newTaskItem);
        }
        public async Task<TaskItem> UpdateTaskAsync(int id, TaskItem newTaskItem)
        {
            var taskItem = await GetTaskByIdAsync(id) ?? throw new NotFoundException($"Task not found.");

            if (newTaskItem.IsCompleted && taskItem.IsCompleted)
            {
                throw new BadRequestException("Task is already completed.");
            } else if (newTaskItem.IsCompleted && string.IsNullOrEmpty((taskItem.Title).Trim()))
            {
                throw new BadRequestException("You cannot complete a task that has no title.");
            }

            newTaskItem.Id = id;
               
            await _repository.UpdateTaskAsync(newTaskItem);

            return newTaskItem;
        }
        public async Task DeleteTaskAsync(int id)
        {
            var taskItem = await GetTaskByIdAsync(id) ?? throw new NotFoundException($"Task not found.");

            if (taskItem.IsCompleted) throw new BadRequestException("Completed tasks cannot be deleted.");

            await _repository.DeleteTaskAsync(taskItem);
        }
    }
}
