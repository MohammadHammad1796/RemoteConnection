using RemoteServices.Models;

namespace RemoteServices.Services
{
    public interface IEmployeesManagementService
    {
        EmployeesActionResult GetAll();

        EmployeeActionResult GetById(int id);

        ActionResult Delete(int id);

        InsertResult Add(InsertEmployee employee);

        ActionResult Update(Employee employee);
    }
}