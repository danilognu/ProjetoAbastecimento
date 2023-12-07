using Microsoft.AspNetCore.Mvc;
using ProjetoBitzen.Models;
using ProjetoBitzen.Repository;
using System.Drawing;

namespace ProjetoBitzen.Controllers
{
    public class MotoristaController : Controller
    {

        private IMotoristaRepository _iMotoristaRepository;
        public MotoristaController(IMotoristaRepository iMotoristaRepository)
        {
            _iMotoristaRepository = iMotoristaRepository;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _iMotoristaRepository.ObterMotoristas();
            return View(result);
        }

        public async Task<IActionResult> Criar(int? Id)
        {
            if (Id == null)
            {
                return View();
            }
            else
            {
                var motorista = await _iMotoristaRepository.ObterMotoristasId(Id);
                return View(motorista);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Motorista motorista)
        {
            if(motorista.Id == 0)
            {
                motorista.DataCadastroAlteracao = DateTime.Now;
                await _iMotoristaRepository.Criar(motorista);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        motorista.DataCadastroAlteracao = DateTime.Now;
                        await _iMotoristaRepository.Atualizar(motorista);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(motorista);
        }


        public async Task<IActionResult> Editar(int? id)
        {
            var motorista = await _iMotoristaRepository.ObterMotoristasId(id);
            return View(motorista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    motorista.Id = id;
                    motorista.DataCadastroAlteracao = DateTime.Now;
                    await _iMotoristaRepository.Atualizar(motorista);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        public async Task<IActionResult> Apagar(int? id)
        {
            var motorista = await _iMotoristaRepository.ObterMotoristasId(id);
            return View(motorista);
        }

        [HttpDelete, ActionName("ConfirmaApagar")]
        public async Task<IActionResult> ConfirmaApagar(Int64 id)
        {
            await _iMotoristaRepository.Apagar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
