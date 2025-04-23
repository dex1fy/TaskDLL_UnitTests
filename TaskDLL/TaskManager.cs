using System.Collections.Generic;

namespace TaskDLL
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TaskManager
    {
        private static int NextId = 1;
        private readonly Dictionary<int, TaskModel> Tasks = new Dictionary<int, TaskModel>();

        public int AddTask(string description)
        {
            var task = new TaskModel { Id = NextId++, Description = description };
            Tasks.Add(task.Id, task);
            return task.Id;
        }

        public bool RemoveTask(int id)
        {
            return Tasks.Remove(id);
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return Tasks.Values;
        }

        public TaskModel GetTaskById(int id)
        {
            return Tasks.TryGetValue(id, out var task) ? task : null;
        }

        public bool ChangeTaskStatus(int id, bool isCompleted)
        {
            if (!Tasks.TryGetValue(id, out var task)) return false;
            task.IsCompleted = isCompleted;
            return true;
        }

        public bool CheckIfTaskExists(int id)
        {
            return Tasks.ContainsKey(id);
        }

        public void UpdateTaskDescription(int id, string newDescription)
        {
            if (Tasks.TryGetValue(id, out var task))
                task.Description = newDescription;
        }

        public int CountTasks()
        {
            return Tasks.Count;
        }

        public IEnumerable<TaskModel> GetCompletedTasks()
        {
            return Tasks.Values.Where(t => t.IsCompleted);
        }

        public IEnumerable<TaskModel> GetIncompleteTasks()
        {
            return Tasks.Values.Where(t => !t.IsCompleted);
        }
    }
}