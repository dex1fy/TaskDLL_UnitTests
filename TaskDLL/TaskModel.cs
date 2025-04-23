namespace TaskManagerLibrary
{
    public class TaskModel
    {
        public int Id { get; set; }                     // Уникальный идентификатор задачи
        public string Description { get; set; }          // Описание задачи
        public bool IsCompleted { get; set; }           // Признак завершения задачи
    }
}