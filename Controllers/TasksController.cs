using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskCoreAPI.Exceptions;
using Taskly.Models;
using Taskly.Services;

namespace Taskly.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        public TasksController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }


        // Get All Tasks
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAllTasksAsync()
        {
            return Ok(await _taskItemService.GetAllTasksAsync());
        }

        // Get Task By ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskItem>> GetTaskByIdAsync(int id)
        {
            TaskItem taskItem;
            try
            {
                taskItem = await _taskItemService.GetTaskByIdAsync(id);
                return Ok(taskItem);
            }  catch (NotFoundException)
            {
                //return NotFound(ex.Message);
                throw;
            }  catch (Exception)
            {
                throw;
            }
        }

        // Get Completed Tasks
        [HttpGet("completed")]
        public async Task<ActionResult<TaskItem>> GetAllCompletedTasksAsync()
        {
            IEnumerable<TaskItem> completedTasks;
            try
            {
                completedTasks = await _taskItemService.GetCompletedTasks();
                return Ok(completedTasks);
            } catch(Exception)
            {
                throw;
            }         
        }

        // Create Task
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTaskAsync([FromBody] TaskItem newTaskItem)
        {
            try
            {
                newTaskItem = await _taskItemService.CreateTaskAsync(newTaskItem);

                // Use action name without the 'Async' suffix and explicitly name the route value 'id'
                return CreatedAtAction(nameof(GetTaskByIdAsync).Replace("Async", ""), new { id = newTaskItem.Id }, newTaskItem);
            }
            catch (NotFoundException)
            {
                throw;
            } catch(Exception)
            {
                throw;
            }
        }

        // Update Task
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TaskItem>> UpdateTaskAsync(int id, [FromBody] TaskItem updatedTaskItem)
        {        
           try
            {
                return Ok(await _taskItemService.UpdateTaskAsync(id, updatedTaskItem));
            } catch (NotFoundException)
            {
                throw;
            } catch (Exception)
            {
                throw;
            }
        }

        // Delete task
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTaskAsync(int id)
        {
            try
            {
                await _taskItemService.DeleteTaskAsync(id);

                return NoContent();
            } catch (NotFoundException)
            {
                throw;
            } catch (Exception)
            {
                throw;
            }  
        } 


    }
}