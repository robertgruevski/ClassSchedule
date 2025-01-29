using System.Linq.Expressions;

namespace ClassSchedule.Models.DataLayer
{
	public class QueryOptions<T>
	{
		public Expression<Func<T, Object>> OrderBy { get; set; }
		public Expression<Func<T, Object>> ThenOrderBy { get; set; }
		public Expression<Func<T, bool>> Where { get; set; }
		private string[] includes = Array.Empty<string>();
		public string Includes
		{
			set => includes = value.Replace(" ", "").Split(',');
		}
		public string[] GetIncludes() => includes;
		public bool HasWhere => Where != null;
		public bool HasOrderBy => OrderBy != null;
		public bool HasThenOrderBy => ThenOrderBy != null;
	}
}
