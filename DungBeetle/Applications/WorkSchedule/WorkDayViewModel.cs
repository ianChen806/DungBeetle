namespace DungBeetle.Applications.WorkSchedule;

public class WorkDayViewModel
{
    public event Action? OnDataChanged;

    public List<WorkScheduleViewModel> Days { get; set; } = [];

    public List<string> Members { get; set; } = [];

    public int WorkdayAvgDays => Days.Count(r => !r.IsHoliday) / Members.Count;

    public int HolidayAvgDays => Days.Count(r => r.IsHoliday) / Members.Count;

    public void DataChanged()
    {
        OnDataChanged?.Invoke();
    }
}
