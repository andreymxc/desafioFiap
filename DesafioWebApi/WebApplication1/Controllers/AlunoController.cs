using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AlunoController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5096/api");
        HttpClient client;

        public AlunoController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<AlunoViewModel> modelList = new List<AlunoViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/aluno").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<RequestResponseDTO<List<AlunoViewModel>>>(data).data;
            }

            return View(modelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AlunoViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/aluno", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/aluno/{id}").Result;

            var aluno = new AlunoViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                aluno = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoViewModel>>(data).data;
            }

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Edit(AlunoViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/aluno", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(AlunoViewModel model)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"/aluno/{model.Id}").Result;

            var aluno = new AlunoViewModel();

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            throw new Exception("Erro ao excluir aluno");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/aluno/{id}").Result;

            var aluno = new AlunoViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                aluno = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoViewModel>>(data).data;
            }

            return View(aluno);
        }
    }
}
