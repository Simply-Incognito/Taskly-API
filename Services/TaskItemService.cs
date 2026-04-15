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

        public List<TaskItem> GetAllTasks() => _repository.GetAllTasks();
        public TaskItem GetTaskById(int id) => _repository.GetTaskById(id);
        public TaskItem CreateTask(TaskItem newTaskItem) => _repository.CreateTask(newTaskItem);
        public void UpdateTask(TaskItem newTaskItem) => _repository.UpdateTask(newTaskItem);
        public void DeleteTask(int id) => _repository.DeleteTask(id);
    }
}
