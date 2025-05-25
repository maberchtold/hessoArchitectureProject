using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Digitec.Business
{
    public class ComputationHelper : IComputationHelper
    {
        private readonly DigitecContext _repo;
        public ComputationHelper(DigitecContext repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _repo.Items.ToListAsync();
        }

        public async Task<Item> PostItem(Item item)
        {
            // step 4
            //Add item in DBContext
            Employee emp = _repo.Employees.First();
            item.Employee = emp;
            item.EmployeeId = emp.EmployeeId;
            _repo.Items.Add(item);
            await _repo.SaveChangesAsync();
            // return Item
            return item;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _repo.Items.FindAsync(id);
        }

        public async Task<Item> PutItem(Item item)
        {
            var entity = _repo.Items.Find(item.ItemId);
            if (entity == null)
            {
                return null;
            }
            Employee emp = _repo.Employees.Find(item.EmployeeId);
            item.Employee = emp;
            _repo.Entry(entity).CurrentValues.SetValues(item);
            await _repo.SaveChangesAsync();

            return item;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _repo.Employees.ToListAsync();
        }
    }
}
