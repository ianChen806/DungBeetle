using DungBeetle.Domain.ValueObject;

namespace DungBeetle.Applications.WorkSchedule;

public class WorkScheduleCommand
{
    public DateObject Date { get; set; }

    public List<MemberInfo> Members { get; set; } = [];
}
