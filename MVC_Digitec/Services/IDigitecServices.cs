using MVC_Digitec.Models;

namespace MVC_Digitec.Services
{
    public interface IDigitecServices
    {
        public Task<List<ItemM>> GetItems();

        public Task<ItemM> PostItem(ItemM item);

        Task<ItemM> PutItem(ItemM item);

        Task<ItemM> GetItem(int id);
        Task<List<EmployeeM>> GetEmployees();
    }
}
