using DungBeetle.Applications.WorkSchedule;
using DungBeetle.Components.Pages.MemberListComponent;
using DungBeetle.Domain.ValueObject;
using Microsoft.AspNetCore.Components;

namespace DungBeetle.Components.Pages;

public class HomeBase : ComponentBase
{
    [Inject]
    public required WorkScheduleHandler Handler { get; set; }

    [Inject]
    public required TimeProvider TimeProvider { get; set; }

    protected int Year { get; set; }

    protected int Month { get; set; }

    protected List<MemberInfoViewModel> Members { get; set; } = [];

    protected WorkDayViewModel Model { get; set; } = new();

    protected override Task OnInitializedAsync()
    {
        var nextMonth = TimeProvider.GetLocalNow().AddDays(1);
        Year = nextMonth.Year;
        Month = nextMonth.Month;

        return base.OnInitializedAsync();
    }

    protected async Task Submit()
    {
        if (Members.Any() == false)
        {
            return;
        }

        var result = await Handler.Handle(new WorkScheduleCommand
        {
            Date = new DateObject(Year, Month),
            Members = Members.Select(r => new MemberInfo
            {
                Name = r.Name,
                IgnoreDays = r.IgnoreDays.Select(s => new DateTime(Year, Month, s)).ToList()
            }).ToList()
        });
        Model = result.ToViewModel(Members);
        ActivePanel = 2;
    }

    protected int ActivePanel { get; set; } = 1;

    protected void ShowPanel(int panel)
    {
        ActivePanel = panel;
    }

    protected string ActiveClass(int panel)
    {
        return ActivePanel == panel ? "active" : "";
    }
}
