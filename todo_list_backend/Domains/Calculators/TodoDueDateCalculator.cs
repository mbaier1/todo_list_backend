using todo_list_backend.Domains.Calculators.Interfaces;

namespace todo_list_backend.Domains.Calculators;

public class TodoDueDateCalculator : ITodoDueDateCalculator
{
    public bool CalculateDueDateStatus(string date)
    {
        var convertedDate = Convert.ToDateTime(date);
        var utcConvertedDate = DateTime.SpecifyKind(convertedDate, DateTimeKind.Utc);

        return DateTime.UtcNow.Date > utcConvertedDate.Date;
    }
}
