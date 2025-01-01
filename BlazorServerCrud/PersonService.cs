using BlazorServerCrud.Models;

namespace BlazorServerCrud
{
	public class PersonService : IPersonService
	{
		private readonly DatabaseContext _context;

		public PersonService(DatabaseContext context)
        {
			_context = context; 
        }
        public bool AddUpdate(Person person)
		{
			try
			{
				if (person.Id == 0)
				{
					_context.Add(person);

				}
				else
				{
					_context.Person.Update(person);
					_context.SaveChanges();
				}
				return true;
			}
			catch(Exception ex)
				{
				return false;
			}
		}

		public bool Delete(int id)
		{
			try
			{
				var person = FindById(id);
				if (person == null)
				{
					return false;
				}
					
				_context.Person.Remove(person);
				_context.SaveChanges();
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}

		public Person FindById(int id)
		{
			return _context.Person.Find(id);
		}

		public List<Person> GetAll()
		{
			return _context.Person.ToList();
		}
	}
}
