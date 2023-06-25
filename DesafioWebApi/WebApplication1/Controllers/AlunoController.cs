using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using DWFIAP.WebApp.DTOs;
using DWFIAP.WebApp.Models;

namespace DWFIAP.WebApp.Controllers
{
    public class AlunoController : Controller
    {
        Uri baseAddress = new Uri(Configuration.Config.BaseUrlApi);
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
            try
            {
                string data = JsonConvert.SerializeObject(model);
                string message = string.Empty;

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/aluno", content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoViewModel>>(responseContent);

                if (responseObj.isSuccess)
                    return RedirectToAction("Index");

                message += responseObj.message;

                if (responseObj.Errors != null)
                    message += string.Join(";", responseObj.Errors.Select(x => x.Message + "\n").ToArray());
                
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro de ao realizar cadastro: \n" + ex.Message;
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
                aluno.Senha = string.Empty;
            }

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Edit(AlunoViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                string message = string.Empty;

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/aluno", content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoViewModel>>(responseContent);

                if (responseObj.isSuccess)
                    return RedirectToAction("Index");

                message += responseObj.message;

                if (responseObj.Errors != null)
                    message += string.Join(";", responseObj.Errors.Select(x => x.Message + "\n").ToArray());

                throw new Exception(message);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erro de ao editar cadastro: \n" + ex.Message;
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/aluno/{id}").Result;

            var aluno = new AlunoDetailsViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                aluno = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoDetailsViewModel>>(data).data;
            }

            return View(aluno);
        }


        [HttpPost]
        public IActionResult Delete(AlunoViewModel model)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"/aluno/{model.Id}").Result;

                var aluno = new AlunoViewModel();

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                throw new Exception("Erro ao excluir aluno!");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
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
