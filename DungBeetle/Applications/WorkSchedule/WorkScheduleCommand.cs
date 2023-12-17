using DungBeetle.Domain.ValueObject;

namespace DungBeetle.Applications.WorkSchedule;

public class WorkScheduleCommand
{
    public DateObject Date { get; set; }

    public List<MemberWorkDay> Members { get; set; } = new();
}
