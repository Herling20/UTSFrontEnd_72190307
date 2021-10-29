using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UTS.Models;

namespace UTS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/Employees");
            return result;
        }

        public async Task<Employee> GetById(int id)
        {
            var results = await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return results;
        }
    }
}