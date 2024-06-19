using todo_list_backend.Data.Models;

namespace todo_list_backend.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        void AddTodoItem(TodoItem todoItemModel);
        List<TodoItem> GetTodos();
    }
}
