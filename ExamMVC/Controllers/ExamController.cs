using ExamMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging.EventSource;
using Newtonsoft.Json;
using System.Text;

namespace ExamMVC.Controllers
{
    public class ExamController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7055/api");
        private readonly HttpClient _client;

        public ExamController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ExamVM> Examlist = new List<ExamVM>();

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Exams/GetExams").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Examlist = JsonConvert.DeserializeObject<List<ExamVM>>(data);

            }

            return View(Examlist);

        }
        [HttpGet]
        public IActionResult Create()
        {

            List<StudentsVM> studentlist = new List<StudentsVM>();
            List<LessonsVM> lessonlist = new List<LessonsVM>();
            HttpResponseMessage responseStudent = _client.GetAsync(_client.BaseAddress + "/Students/GetStudents").Result;

            HttpResponseMessage responseLesson = _client.GetAsync(_client.BaseAddress + "/Lessons/GetLessons").Result;

            string data = responseStudent.Content.ReadAsStringAsync().Result;
            studentlist = JsonConvert.DeserializeObject<List<StudentsVM>>(data);

            string data1 = responseLesson.Content.ReadAsStringAsync().Result;
            lessonlist = JsonConvert.DeserializeObject<List<LessonsVM>>(data1);


            return View(new ExamEditVM { Students = studentlist, Lessons = lessonlist });
        }
        [HttpPost]
        public IActionResult Create(ExamEditVM examEditVM)
        {

            string data = JsonConvert.SerializeObject(examEditVM.Exam);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Exams/Create", content).Result;
            if (response.IsSuccessStatusCode) { return RedirectToAction("Index"); }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ExamVM exam = new ExamVM();
            List<StudentsVM> studentlist = new List<StudentsVM>();
            List<LessonsVM> lessonlist = new List<LessonsVM>();
            HttpResponseMessage responseStudent = _client.GetAsync(_client.BaseAddress + "/Students/GetStudents").Result;
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Exams/GetExamById?id=" + id).Result;
            HttpResponseMessage responseLesson = _client.GetAsync(_client.BaseAddress + "/Lessons/GetLessons").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                exam = JsonConvert.DeserializeObject<ExamVM>(data);

            }
            if (response.IsSuccessStatusCode)
            {
                string data = responseStudent.Content.ReadAsStringAsync().Result;
                studentlist = JsonConvert.DeserializeObject<List<StudentsVM>>(data);

            }
            if (response.IsSuccessStatusCode)
            {
                string data = responseLesson.Content.ReadAsStringAsync().Result;
                lessonlist = JsonConvert.DeserializeObject<List<LessonsVM>>(data);

            }
            return View(new ExamEditVM { Students = studentlist, Exam = exam, Lessons = lessonlist });
        }
        [HttpPost]
        public IActionResult Edit(ExamEditVM model)
        {
            string data = JsonConvert.SerializeObject(model.Exam);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Exams/Update", content).Result;
            if (response.IsSuccessStatusCode) { return RedirectToAction("Index"); }
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ExamVM exam = new ExamVM();
            HttpResponseMessage response = _client.GetAsync(baseAddress + "/Exams/Update/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                exam = JsonConvert.DeserializeObject<ExamVM>(data);
            }
            return View(exam);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Exams/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
