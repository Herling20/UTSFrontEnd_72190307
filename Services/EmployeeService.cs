using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using UTS.Models;

namespace UTS.Services
{
    public class EmployeeService : IEmployeeService
    {
        HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Employee> Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Delete(int id)
        {
            throw new NotImplementedException();
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

        public async Task<Employee> Update(int id, Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employees/{id}", employee);
            if(response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }
            else
            {
                throw new Exception("Gagal Update Employee");
            }
        }
    }
}