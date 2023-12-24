using DungBeetle.Applications.WorkSchedule;
using Microsoft.AspNetCore.Components;

namespace DungBeetle.Components.Pages.CalenderComponent;

public class CalenderBase : ComponentBase
{
    [Parameter]
    public List<WorkScheduleViewModel> Days { get; set; } = [];

    [Parameter]
    public int Year { get; set; }

    [Parameter]
    public int Month { get; set; }

    protected IEnumerable<IEnumerable<WorkScheduleViewModel>> Weeks()
    {
        var firstWeek = (int) new DateTime(Year, Month, 1).DayOfWeek;
        var empty = Enumerable
            .Range(0, firstWeek)
            .Select(_ => new WorkScheduleViewModel());
        return empty.Concat(Days)
            .Select((day, index) => new { Day = day, Index = index })
            .GroupBy(r => r.Index / 7)
            .Select(r => r.Select(x => x.Day));
    }

    protected void SelectDay(WorkScheduleViewModel day, int number)
    {
        if (number == 1)
        {
            day.IsSelectFirst = !day.IsSelectFirst;
            if (Days.Count(d => d.IsSelectFirst) == 2)
            {
                var first = Days.Find(r => r.IsSelectFirst)!;
                var second = Days.FindLast(r => r.IsSelectFirst)!;
                var firstName = first.First;
                var secondName = second.First;
                first.First = secondName;
                second.First = firstName;

                first.IsSelectFirst = false;
                second.IsSelectFirst = false;
            }
        }
        else
        {
            day.IsSelectSecond = !day.IsSelectSecond;
            if (Days.Count(d => d.IsSelectSecond) == 2)
            {
                var first = Days.Find(r => r.IsSelectSecond)!;
                var second = Days.FindLast(r => r.IsSelectSecond)!;
                var firstName = first.Second;
                var secondName = second.Second;
                first.Second = secondName;
                second.Second = firstName;

                first.IsSelectSecond = false;
                second.IsSelectSecond = false;
            }
        }
    }
}
