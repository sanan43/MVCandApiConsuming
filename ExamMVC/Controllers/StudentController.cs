using ExamMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ExamMVC.Controllers
{
    public class StudentController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7055/api");
        private readonly HttpClient _client;
        

        public StudentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentsVM> Studentlist = new List<StudentsVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Students/GetStudents").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Studentlist = JsonConvert.DeserializeObject<List<StudentsVM>>(data);
            }
            return View(Studentlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentsVM studentsVM)
        {

            string data = JsonConvert.SerializeObject(studentsVM);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Students/Create", content).Result;
            if (response.IsSuccessStatusCode) { return RedirectToAction("Index"); }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentsVM student = new StudentsVM();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Students/GetStudentById?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentsVM>(data);
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(StudentsVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Students/Update", content).Result;

            if (response.IsSuccessStatusCode) { return RedirectToAction("Index"); }
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentsVM lesson = new StudentsVM();
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Students/Update/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                lesson = JsonConvert.DeserializeObject<StudentsVM>(data);
            }
            return View(lesson);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Students/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
