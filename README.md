# Модуль TaskManager

## Описание

Модуль `TaskManager` предназначен для управления задачами. Он предоставляет функциональность для добавления, удаления, изменения статуса задач, а также для получения информации о задачах.

## Запуск проекта
Клонировать репозиторий 
``` bash 
   git clone https://github.com/dex1fy/TaskDLL_UnitTests.git
```
Запустить:
``` bash
    dotnet run [параметр1] [параметр2]
```
## Основные функции

### Добавление задачи

- Метод `AddTask` позволяет добавить новую задачу с уникальным идентификатором и возвращает этот идентификатор.
- Удаление задачи
Метод RemoveTask удаляет задачу по её идентификатору и возвращает true, если задача была найдена и удалена.
```
public bool RemoveTask(int id)
```

- Получение всех задач
Метод GetAllTasks возвращает список всех задач.
```
public IEnumerable<TaskModel> GetAllTasks()
```

- Получение задачи по ID
Метод GetTaskById возвращает задачу по её идентификатору или null, если задача не найдена.
```
public TaskModel GetTaskById(int id)
```

- Изменение статуса задачи
Метод ChangeTaskStatus изменяет статус задачи на "завершена" или "незавершена".
```
public bool ChangeTaskStatus(int id, bool isCompleted)
```

- Проверка существования задачи
Метод CheckIfTaskExists проверяет, существует ли задача с указанным идентификатором.
```
public bool CheckIfTaskExists(int id)
```

- Обновление описания задачи
Метод UpdateTaskDescription обновляет описание задачи по её идентификатору.
```
public void UpdateTaskDescription(int id, string newDescription)
```

- Подсчет количества задач
Метод CountTasks возвращает общее количество задач.
```
public int CountTasks()
```

- Получение завершенных задач
Метод GetCompletedTasks возвращает список завершенных задач.
```
public IEnumerable<TaskModel> GetCompletedTasks()
```

- Получение незавершенных задач
Метод GetIncompleteTasks возвращает список незавершенных задач.
```
public IEnumerable<TaskModel> GetIncompleteTasks()
```


Пример использования

```
using TaskDLL;

class Program
{
    static void Main()
    {
        var taskManager = new TaskManager();

        // Добавление задачи
        var taskId = taskManager.AddTask("Test task");

        // Получение всех задач
        var allTasks = taskManager.GetAllTasks();

        // Изменение статуса задачи
        taskManager.ChangeTaskStatus(taskId, true);

        // Получение завершенных задач
        var completedTasks = taskManager.GetCompletedTasks();

        // Подсчет количества задач
        var taskCount = taskManager.CountTasks();
    }
}
```
