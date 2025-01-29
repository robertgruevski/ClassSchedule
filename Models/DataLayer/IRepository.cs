namespace ClassSchedule.Models.DataLayer
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> List(QueryOptions<T> options);
		T? Get(int id); // Get Type by ID
		T? Get(QueryOptions<T> options); // Get Type with LINQ query
		void Insert(T entity); // Create
		void Update(T entity); // Update
		void Delete(T entity); // Delete
		void Save(T entity); // Save
	}
}
