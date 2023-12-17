using DungBeetle.Applications.WorkSchedule;
using Microsoft.AspNetCore.Components;

namespace DungBeetle.Components.Pages;

public class CalenderBase : ComponentBase
{
    private int _firstWeek;

    [Parameter]
    public List<WorkScheduleViewModel> Days { get; set; } = new();

    [Parameter]
    public int Year { get; set; }

    [Parameter]
    public int Month { get; set; }

    protected override Task OnInitializedAsync()
    {
        _firstWeek = (int) new DateTime(Year, Month, 1).DayOfWeek;
        return base.OnInitializedAsync();
    }

    protected IEnumerable<IEnumerable<WorkScheduleViewModel>> Weeks()
    {
        var empty = Enumerable
            .Range(0, _firstWeek)
            .Select(_ => new WorkScheduleViewModel());
        return empty.Concat(Days)
            .Select((day, index) => new { Day = day, Index = index })
            .GroupBy(r => r.Index / 7)
            .Select(r => r.Select(x => x.Day));
    }
}
