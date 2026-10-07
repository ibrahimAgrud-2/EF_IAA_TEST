using EF_InternApplicationAutomator.Business.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Tasks;

namespace EF_InternApplicationAutomator.API.Controllers.Tasks
{
    [Route("api/Tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksBL _Tasks;

        public TasksController(TasksBL tasks)
        {
            _Tasks = tasks;
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TaskResponseDTO>> GetAllTasks()
        {
            List<TaskResponseDTO> tasks = _Tasks.GetAllTasks();
            if (tasks.Count == 0)
            {
                return NotFound("No Data Available in the Table");
            }

            return Ok(tasks);
        }

        [HttpGet("{id}", Name = "FindTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskResponseDTO> Find(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not Accepted ID {id}");
            }

            TaskResponseDTO? task = _Tasks.Find(id);
            if (task == null)
            {
                return NotFound($"No Task With ID {id}");
            }

            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TaskResponseDTO> AddNewTask(TaskCreateDTO newTask)
        {
            if (newTask == null)
            {
                return BadRequest("Invalid Task data.");
            }

            int taskID = _Tasks.AddTask(newTask);
            if (taskID < 1)
            {
                return BadRequest("Could Not Add Task");
            }

            var createdTask = new TaskResponseDTO(
                taskID,
                newTask.CreatedByUserID,
                newTask.OngoingProjectID,
                newTask.Title,
                newTask.CreatedAt,
                newTask.DueDate);

            return CreatedAtRoute("FindTask", new { id = taskID }, createdTask);
        }

        [HttpPut("{id}", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskResponseDTO> UpdateTask(int id, TaskCreateDTO taskDTO)
        {
            if (id < 1 || taskDTO == null)
            {
                return BadRequest("Invalid Task data.");
            }

            if (!_Tasks.IsTaskExists(id))
            {
                return NotFound($"No Task With ID {id}");
            }

            if (_Tasks.UpdateTask(id, taskDTO) > 0)
            {
                return Ok(new TaskResponseDTO(
                    id,
                    taskDTO.CreatedByUserID,
                    taskDTO.OngoingProjectID,
                    taskDTO.Title,
                    taskDTO.CreatedAt,
                    taskDTO.DueDate));
            }

            return BadRequest("Could Not Update Task");
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteTask(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not Accepted ID {id}");
            }

            if (!_Tasks.IsTaskExists(id))
            {
                return NotFound($"No Task With ID {id}");
            }

            if (_Tasks.DeleteTask(id))
            {
                return NoContent();
            }

            return NotFound("Delete Process terminated. No rows deleted!");
        }

        [HttpGet("exists/{taskID}")]
        public bool IsTaskExists(int taskID)
        {
            return taskID > 0 && _Tasks.IsTaskExists(taskID);
        }
    }
}
