using todo_list_backend.Data.Models;

namespace todo_list_backend.Domains.Calculators.Interfaces;

public interface ITodoCompletedStatusCalculator
{
    bool CalculateStatus(TodoItem todoItemModel);
}
