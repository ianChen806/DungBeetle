using DungBeetle.Components.Pages.MemberListComponent;

namespace DungBeetle.Applications.WorkSchedule;

public class WorkScheduleResult
{
    public required List<DayInMonth> ScheduleFirst { get; set; }

    public required List<DayInMonth> ScheduleSecond { get; set; }

    public WorkDayViewModel ToViewModel(List<MemberInfoViewModel> members)
    {
        return new WorkDayViewModel()
        {
            Members = members.Select(r => r.Name).ToList(),
            Days = ScheduleFirst
                .OrderBy(r => r.Date)
                .Zip(ScheduleSecond)
                .Select(r => new WorkScheduleViewModel
                {
                    Date = r.First.Date,
                    First = r.First.Person,
                    Second = r.Second.Person,
                    IsHoliday = r.First.IsHoliday
                })
                .ToList()
        };
    }
}
