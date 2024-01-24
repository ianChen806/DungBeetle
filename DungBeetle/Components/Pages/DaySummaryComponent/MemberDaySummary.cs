namespace DungBeetle.Components.Pages.DaySummaryComponent;

public class MemberDaySummary
{
    public string Name { get; set; } = "";

    public int FirstHolidayDays { get; set; }

    public int FirstWorkDays { get; set; }

    public int FirstDays { get; set; }

    public int SecondDays { get; set; }

    public int SecondHolidayDays { get; set; }

    public int SecondWorkDays { get; set; }

    public int Total => FirstDays + SecondDays;
}