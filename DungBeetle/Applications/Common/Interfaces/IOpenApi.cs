using DungBeetle.Domain.Models;

namespace DungBeetle.Applications.Common.Interfaces;

public interface IOpenApi
{
    Task<IEnumerable<DayOfMonth>> GetDays(int year, int month);
}