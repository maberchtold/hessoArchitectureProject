namespace WebAPI_Digitec.Extension
{
    public static class ConverterExtensions
    {
        public static DAL.Models.Item ToDAL(this WebAPI_Digitec.Models.ItemM itemM)
        {
            return new DAL.Models.Item
            {
                ItemId = itemM.Id,
                Name = itemM.Name,
                Description = itemM.Description,
                Price = itemM.Price,
                EmployeeId = itemM.EmployeeId
            };
        }

        public static WebAPI_Digitec.Models.ItemM ToModel(this DAL.Models.Item item)
        {
            return new WebAPI_Digitec.Models.ItemM
            {
                Id = item.ItemId,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                EmployeeId = item.EmployeeId
            };
        }

        public static WebAPI_Digitec.Models.EmployeeM ToModel(this DAL.Models.Employee employee)
        {
            return new WebAPI_Digitec.Models.EmployeeM
            {
                EmployeeId = employee.EmployeeId,
                Lastname = employee.Lastname,
                Firstname = employee.Firstname
            };
        }
    }
}
