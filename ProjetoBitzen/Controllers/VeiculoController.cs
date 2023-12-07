using Microsoft.AspNetCore.Mvc;
using ProjetoBitzen.Models;
using ProjetoBitzen.Persistencia;
using ProjetoBitzen.Repository;
using System.Drawing;

namespace ProjetoBitzen.Controllers
{
    public class VeiculoController : Controller
    {
        private IVeiculoRepository _iVeiculoRepository;
        public VeiculoController(IVeiculoRepository iVeiculoRepository)
        {
            _iVeiculoRepository = iVeiculoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _iVeiculoRepository.ObterVeiculo();
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
                var motorista = await _iVeiculoRepository.ObterVeiculoId(Id);
                return View(motorista);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Veiculo veiculo)
        {

            try
            {
                if (veiculo.Id == 0)
                {
                    veiculo.DataCadastroAlteracao = DateTime.Now;
                    await _iVeiculoRepository.Criar(veiculo);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            veiculo.DataCadastroAlteracao = DateTime.Now;
                            await _iVeiculoRepository.Atualizar(veiculo);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(veiculo);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IActionResult> Apagar(int? id)
        {
            var motorista = await _iVeiculoRepository.ObterVeiculoId(id);
            return View(motorista);
        }

        [HttpDelete, ActionName("ConfirmaApagar")]
        public async Task<IActionResult> ConfirmaApagar(Int64 id)
        {
            await _iVeiculoRepository.Apagar(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
