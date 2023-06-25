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
        Uri baseAddress = new Uri(Configuration.Config.BaseUrlApi);
        HttpClient client;

        AlunoTurmaRelacaoViewModel _viewModel = new AlunoTurmaRelacaoViewModel();
        public AlunoTurmaController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<AlunoTurmaRelacaoViewModel> modelList = new List<AlunoTurmaRelacaoViewModel>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AlunoTurma").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<RequestResponseDTO<List<AlunoTurmaRelacaoViewModel>>>(data).data;
            }

            return View(modelList);

        }

        private void LoadCreateViewModel()
        {
            var alunos = GetAllAlunos();
            var turmas = GetAllTurmas();

            _viewModel = new AlunoTurmaRelacaoViewModel();

            _viewModel.Alunos = alunos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });

            _viewModel.Turmas = turmas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
        }

        public IActionResult Create()
        {
            LoadCreateViewModel();
            return View(_viewModel);
        }
              
        [HttpPost]
        public IActionResult Create(AlunoTurmaRelacaoViewModel model)
        {
            try
            {
                string message = string.Empty;

                var alunoTurmaDto = new AlunoTurmaDTO()
                {
                    Aluno_Id = model.Aluno_Id,
                    Turma_Id = model.Turma_Id,
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
            return View(_viewModel);
        }

        [HttpPost]
        public IActionResult Delete(AlunoTurmaViewModel model1)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"/AlunoTurma/aluno/{model1.Aluno_Id}/turma/{model1.Turma_Id}").Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                throw new Exception("Erro ao excluir aluno!");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(model1);
        }

        [HttpGet]
        public IActionResult Delete(int Aluno_Id, int Turma_Id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/AlunoTurma/Aluno/{Aluno_Id}/Turma/{Turma_Id}").Result;

            var viewModel = new AlunoTurmaViewModel();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<RequestResponseDTO<AlunoTurmaViewModel>>(data).data;
            }

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
