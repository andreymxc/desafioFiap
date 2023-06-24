using DWFIAP.WebApp.DTOs;
using DWFIAP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace DWFIAP.WebApp.Controllers
{
    public class AlunoTurmaController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5096/api");
        HttpClient client;

        AlunoTurmaViewModel viewModel = new AlunoTurmaViewModel();
        public AlunoTurmaController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<AlunoTurmaViewModel> modelList = new List<AlunoTurmaViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AlunoTurma").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<RequestResponseDTO<List<AlunoTurmaViewModel>>>(data).data;
            }

            return View(modelList);

        }

        private void LoadCreateViewModel()
        {
            var alunos = GetAllAlunos();
            var turmas = GetAllTurmas();

            viewModel = new AlunoTurmaViewModel();

            viewModel.Alunos = alunos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });

            viewModel.Turmas = turmas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
        }

        public IActionResult Create()
        {
            LoadCreateViewModel();
            return View(viewModel);
        }
              
        [HttpPost]
        public IActionResult Create(AlunoTurmaViewModel viewModel)
        {
            try
            {
                string message = string.Empty;

                var alunoTurmaDto = new AlunoTurmaDTO()
                {
                    Aluno_Id = viewModel.Aluno_Id,
                    Turma_Id = viewModel.Turma_Id,
                };

                string data = JsonConvert.SerializeObject(alunoTurmaDto);

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/AlunoTurma", content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;
                
                var responseObj = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoTurmaDTO>>(responseContent);

                if (responseObj?.isSuccess == false)
                {
                    message += responseObj.message;

                    if (responseObj.Errors != null)
                        message += string.Join(" ;", responseObj.Errors.Select(x => x.Message + "\n").ToArray());

                    throw new Exception(message);
                }

                return RedirectToAction("Index");              
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            LoadCreateViewModel();
            return View(viewModel);
        }

        public List<AlunoViewModel> GetAllAlunos()
        {
            List<AlunoViewModel> modelList = new List<AlunoViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/aluno").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<RequestResponseDTO<List<AlunoViewModel>>>(data).data;
            }

            return modelList;
        }

        public List<TurmaViewModel> GetAllTurmas()
        {
            List<TurmaViewModel> modelList = new List<TurmaViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/turma").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<RequestResponseDTO<List<TurmaViewModel>>>(data).data;
            }

            return modelList;
        }
    }
}
