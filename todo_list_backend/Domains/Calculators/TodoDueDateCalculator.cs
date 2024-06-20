using todo_list_backend.Domains.Calculators.Interfaces;

namespace todo_list_backend.Domains.Calculators;

public class TodoDueDateCalculator : ITodoDueDateCalculator
{
    public bool CalculateDueDateStatus(string date)
    {
        var convertedDate = Convert.ToDateTime(date);

        return DateTime.UtcNow.Date > convertedDate.Date;
    }
}
