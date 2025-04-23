using TaskDLL; 

namespace TaskDLL.Tests
{
    public class TaskManagerTests
    {
        private readonly TaskManager _taskManager;

        public TaskManagerTests()
        {
            _taskManager = new TaskManager(); 
        }

        [Fact]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            var initialCount = _taskManager.CountTasks();
            _taskManager.AddTask("Test task");
            Assert.Equal(initialCount + 1, _taskManager.CountTasks());
        }

        [Fact]
        public void RemoveTask_ShouldDecreaseTaskCount()
        {
            var taskId = _taskManager.AddTask("Task to be removed");
            var initialCount = _taskManager.CountTasks();
            _taskManager.RemoveTask(taskId);
            Assert.Equal(initialCount - 1, _taskManager.CountTasks());
        }

        [Fact]
        public void GetAllTasks_ReturnsListOfAddedTasks()
        {
            _taskManager.AddTask("First task");
            _taskManager.AddTask("Second task");
            var tasks = _taskManager.GetAllTasks();
            Assert.NotEmpty(tasks);
            Assert.Contains(tasks, t => t.Description == "First task");
            Assert.Contains(tasks, t => t.Description == "Second task");
        }

        [Fact]
        public void ChangeTaskStatus_ChangesTaskCompletion()
        {
            var taskId = _taskManager.AddTask("Task for completion change");
            _taskManager.ChangeTaskStatus(taskId, true);
            var updatedTask = _taskManager.GetTaskById(taskId);
            Assert.True(updatedTask.IsCompleted);
        }

        [Fact]
        public void CheckIfTaskExists_ValidIDReturnsTrue()
        {
            var taskId = _taskManager.AddTask("Existing task");
            bool exists = _taskManager.CheckIfTaskExists(taskId);
            Assert.True(exists);
        }

        [Fact]
        public void UpdateTaskDescription_ChangesTaskDescription()
        {
            var taskId = _taskManager.AddTask("Old description");
            _taskManager.UpdateTaskDescription(taskId, "New description");
            var updatedTask = _taskManager.GetTaskById(taskId);
            Assert.Equal("New description", updatedTask.Description);
        }

        [Fact]
        public void GetCompletedTasks_ReturnsOnlyCompletedTasks()
        {
            _taskManager.AddTask("Incomplete task");
            var completedTaskId = _taskManager.AddTask("This will be marked as done");
            _taskManager.ChangeTaskStatus(completedTaskId, true);
            var completedTasks = _taskManager.GetCompletedTasks();
            Assert.Single(completedTasks);
        }

        [Fact]
        public void GetIncompleteTasks_ReturnsOnlyIncompleteTasks()
        {
            _taskManager.AddTask("Incomplete task");
            var completedTaskId = _taskManager.AddTask("This will be marked as done");
            _taskManager.ChangeTaskStatus(completedTaskId, true);
            var incompleteTasks = _taskManager.GetIncompleteTasks();
            Assert.Single(incompleteTasks);
        }

        [Fact]
        public void GetTaskById_ReturnsCorrectTask()
        {
            var taskId = _taskManager.AddTask("Task to find");
            var task = _taskManager.GetTaskById(taskId);
            Assert.NotNull(task);
            Assert.Equal("Task to find", task.Description);
        }

        [Fact]
        public void CountTasks_ReturnsCorrectCount()
        {
            _taskManager.AddTask("First task");
            _taskManager.AddTask("Second task");
            Assert.Equal(2, _taskManager.CountTasks());
        }

        [Fact]
        public void RemoveTask_NonExistingTask_ReturnsFalse()
        {
            var result = _taskManager.RemoveTask(999); // ID несуществующей задачи
            Assert.False(result);
        }

        [Fact]
        public void ChangeTaskStatus_NonExistingTask_ReturnsFalse()
        {
            var result = _taskManager.ChangeTaskStatus(999, true); // ID несуществующей задачи
            Assert.False(result);
        }

        [Fact]
        public void UpdateTaskDescription_NonExistingTask_DoesNotThrow()
        {
            _taskManager.UpdateTaskDescription(999, "New description"); // ID несуществующей задачи
            // Ожидаем, что метод не выбросит исключение
        }
    }
}