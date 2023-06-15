using App1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1.Contracts;
public interface IDataService
{
    IEnumerable<Employee> GetAll();
    Task<Employee> GetByIdAsync(int id);
    Task UpsertAsync(Employee employee);
    Task DeleteAsync(int id);
}
