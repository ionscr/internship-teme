using System.Linq;

namespace Checkin_Platform.Infrastructure.Data.Repository
{
    public class resultDto
    {
        public string Name { get; set; }
        public double Avg { get; set; }
        public int Max { get; set; }
    }
    public class tema
    {
        private readonly AppDbContext _appDbContext;

        public tema(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void main()
        {
            var groupBy = _appDbContext.Schedule.Where(s => s.Id > 2)
                .GroupBy(s => s.Classroom)
                .Select(x => new resultDto {
                    Name = x.Key.Name ?? "No name",
                    Avg = x.Average(y => y.ClassId != null ? y.ClassId : y.ClassroomId),
                    Max = x.Max(y => y.ClassId)  
                })
                .Where(s => s.Name.Any(x => x.ToString().Contains("exec")));
        }
    }
}

public static class PaginationExtension
{
    public static IQueryable<T> Page<T>(this IOrderedQueryable<T> query, int page =1, int pageSize = 10)
    {
        return query.Skip((page-1) * pageSize).Take(pageSize);
    }
}
