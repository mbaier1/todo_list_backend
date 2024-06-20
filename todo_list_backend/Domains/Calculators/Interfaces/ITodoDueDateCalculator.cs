namespace todo_list_backend.Domains.Calculators.Interfaces
{
    public interface ITodoDueDateCalculator
    {
        bool CalculateDueDateStatus(string date);
    }
}
