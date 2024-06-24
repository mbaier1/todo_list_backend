using todo_list_backend.Data.Models;
using todo_list_backend.Domains.Calculators.Interfaces;

namespace todo_list_backend.Domains.Calculators;

public class TodoCompletedStatusCalculator : ITodoCompletedStatusCalculator
{
    public bool CalculateStatus(TodoItem todoItemModel)
    {
        if (todoItemModel.SubTodoItems != null && todoItemModel.SubTodoItems.Any()) 
        {
            if (todoItemModel.TodoIsCompleted)
                SetAllSubTodosToComplete(todoItemModel.SubTodoItems.ToList());
        }
        
        return todoItemModel.TodoIsCompleted;
    }

    private void SetAllSubTodosToComplete(List<SubTodoItem> subTodoItems)
    {
        subTodoItems.ForEach(s => s.SubTodoIsComplete = true);
    }
}
