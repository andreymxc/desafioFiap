using DWFIAP.WebApp.DTOs;
using DWFIAP.WebApp.Models;
using DWFIAP.WebApp.Tools;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DWFIAP.WebApp.Controllers
{
    public class TurmaController : Controller
    {
        Uri baseAddress = new Uri(Configuration.Config.BaseUrlApi);
        HttpClient client;

        public TurmaController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<TurmaViewModel> modelList = new List<TurmaViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/turma").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<RequestResponseDTO<List<TurmaViewModel>>>(data).data;
            }

            return View(modelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TurmaViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                string message = string.Empty;

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/turma", content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<RequestResponseDTO<TurmaViewModel>>(responseContent);
                
                if (responseObj.isSuccess)
                    return RedirectToAction("Index");

                message += responseObj.message;

                if (responseObj.Errors != null)
                    message += string.Join(";", responseObj.Errors.Select(x => x.Message + "\n").ToArray());

                throw new FiapValidationException(message);
            }
            catch (FiapValidationException ex)
            {
                ViewBag.ErrorMessage = "Erro de ao realizar cadastro: \n" + ex.Message;
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/turma/{id}").Result;

            var turma = new TurmaViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                turma = JsonConvert.DeserializeObject<RequestResponseDTO<TurmaViewModel>>(data).data;
            }

            return View(turma);
        }

        [HttpPost]
        public IActionResult Edit(TurmaViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                string message = string.Empty;

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/turma", content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<RequestResponseDTO<TurmaViewModel>>(responseContent);

                if (responseObj.isSuccess)
                    return RedirectToAction("Index");

                message += responseObj.message;

                if (responseObj.Errors != null)
                    message += string.Join(";", responseObj.Errors.Select(x => x.Message + "\n").ToArray());

                throw new FiapValidationException(message);
            }
            catch (FiapValidationException ex)
            {
                ViewBag.ErrorMessage = "Erro de ao realizar cadastro: \n" + ex.Message;
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/turma/{id}").Result;

            var aluno = new TurmaDetailsViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                aluno = JsonConvert.DeserializeObject<RequestResponseDTO<TurmaDetailsViewModel>>(data).data;
            }

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Delete(TurmaViewModel model)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"/turma/{model.Id}").Result;

            var turma = new TurmaViewModel();

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            throw new Exception("Erro ao excluir turma: " + response.RequestMessage);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/turma/{id}").Result;

            var turma = new TurmaViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                turma = JsonConvert.DeserializeObject<RequestResponseDTO<TurmaViewModel>>(data).data;
            }

            return View(turma);
        }
    }
}
