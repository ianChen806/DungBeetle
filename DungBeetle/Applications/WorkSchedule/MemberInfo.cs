namespace DungBeetle.Applications.WorkSchedule;

public class MemberInfo
{
    public string Name { get; set; } = null!;

    public List<DateTime> IgnoreDays { get; set; } = [];
}
