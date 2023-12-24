namespace DungBeetle.Applications.WorkSchedule;

public class WorkScheduleViewModel
{
    public DateTime Date { get; set; }

    public string? First { get; set; }

    public string? Second { get; set; }

    public bool IsHoliday { get; set; }

    public bool IsSelectFirst { get; set; }

    public bool IsSelectSecond { get; set; }

    public string FirstColor => IsSelectFirst ? "bisque" : "";

    public string SecondColor => IsSelectSecond ? "bisque" : "";
}
