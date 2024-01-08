using ExamMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.EventSource;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace ExamMVC.Controllers
{
    public class LessonController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7055/api");
        private readonly HttpClient _client;

        public LessonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<LessonsVM> Lessonlist = new List<LessonsVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Lessons/GetLessons").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Lessonlist = JsonConvert.DeserializeObject<List<LessonsVM>>(data); 
            }
            return View(Lessonlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LessonsVM lessonsVM)
        {
           
                string data = JsonConvert.SerializeObject(lessonsVM);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Lessons/Create", content).Result;
                if (response.IsSuccessStatusCode) {  return RedirectToAction("Index"); }
            
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            LessonsVM lessons = new LessonsVM();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Lessons/GetLessonById?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                lessons = JsonConvert.DeserializeObject<LessonsVM>(data);
            }
            return View(lessons);
        }
        [HttpPost]
        public IActionResult Edit(LessonsVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Lessons/Update/", content).Result;
            if (response.IsSuccessStatusCode) { return RedirectToAction("Index"); }
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LessonsVM lesson = new LessonsVM();
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Lessons/Update/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                lesson = JsonConvert.DeserializeObject<LessonsVM>(data);
            }
            return View(lesson);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Lessons/Delete/" +id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }    
    }
}
