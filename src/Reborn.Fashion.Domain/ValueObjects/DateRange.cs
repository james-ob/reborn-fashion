namespace Reborn.Fashion.Domain.ValueObjects;

public class DateRange
{
    public DateTime Start { get; private set; }
    public DateTime? End { get; private set; }

    public DateRange(DateTime start, DateTime? end)
    {
        if (end is not null && end <= start)
            throw new Exception("End date must be after start date");

        Start = start;
        End = end;
    }
}
