using DAL.Models;

namespace WebAPI_Digitec.Business
{
    public interface IComputationHelper
    {

        Task<IEnumerable<Item>> GetItems();

        Task<Item> GetItem(int id);

        Task<Item> PostItem(Item item);
        Task<Item> PutItem(Item item);
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
