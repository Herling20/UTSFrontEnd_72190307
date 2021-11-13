using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTS.Models;

namespace UTS.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetById(int id);

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(int id, Employee employee);

        Task<Employee> Delete(int id);

    }
}