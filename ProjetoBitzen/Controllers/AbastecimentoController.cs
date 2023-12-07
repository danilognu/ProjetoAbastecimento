using Microsoft.AspNetCore.Mvc;
using ProjetoBitzen.Models;
using ProjetoBitzen.Persistencia;
using ProjetoBitzen.Repository;
using System.Drawing;

namespace ProjetoBitzen.Controllers
{
    public class AbastecimentoController : Controller
    {

        private IAbastecimentoRepository _iAbastecimentoRepository;
        private IVeiculoRepository _iVeiculoRepository;
        private IMotoristaRepository _iMotoristaRepository;
        public AbastecimentoController(IAbastecimentoRepository iAbastecimentoRepository, IVeiculoRepository iVeiculoRepository, IMotoristaRepository iMotoristaRepository)
        {
            _iAbastecimentoRepository = iAbastecimentoRepository;
            _iVeiculoRepository = iVeiculoRepository;
            _iMotoristaRepository = iMotoristaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _iAbastecimentoRepository.ObterAbastecimento();
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
                var motorista = await _iAbastecimentoRepository.ObterAbastecimentoId(Id);
                return View(motorista);
            }

        }

        [HttpPost]
        public async Task<string> Criar(Abastecimento abastecimento)
        {

            try
            {
                var veiculo = await _iVeiculoRepository.ObterVeiculoId(abastecimento.VeiculoId);
                if(abastecimento.QuantidadeAbastecida > veiculo.CapacidadeTanque)
                {
                    return "Quantidade abastecida é menor que a capacidade do tanque do veículo ";
                }

                if (abastecimento.TipoCombustivel != veiculo.TipoCombustivel)
                {
                    return "Conbustivel não compativel com o veiculo";
                }

                if (abastecimento.Id == 0)
                {
                    abastecimento.DataCadastroAlteracao = DateTime.Now;
                    await _iAbastecimentoRepository.Criar(abastecimento);
                    return "OK";
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            abastecimento.DataCadastroAlteracao = DateTime.Now;
                            await _iAbastecimentoRepository.Atualizar(abastecimento);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        return "OK";
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IActionResult> Apagar(int? id)
        {
            var abastecimento = await _iAbastecimentoRepository.ObterAbastecimentoId(id);
            return View(abastecimento);
        }

        [HttpDelete, ActionName("ConfirmaApagar")]
        public async Task<IActionResult> ConfirmaApagar(Int64 id)
        {
            await _iAbastecimentoRepository.Apagar(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<string> ListaVeiculos()
        {
            string retorno = "<option value=''>Selecione</option>";
            var result = await _iVeiculoRepository.ObterVeiculo();
            foreach (var item in result)
            {
                retorno += "<option value='" + item.Id + "'>" + item.Nome + "</option>";
            }
            return retorno;
        }
        //
        [HttpGet]
        public async Task<string> ListaMotoristas()
        {
            string retorno = "<option value=''>Selecione</option>";
            var result = await _iMotoristaRepository.ObterMotoristas();
            foreach (var item in result)
            {
                retorno += "<option value='" + item.Id + "'>" + item.Nome + "</option>";
            }
            return retorno;
        }
    }
}
