using DocumentFormat.OpenXml.Office2010.Excel;
using estacionamentoApp.Data;
using estacionamentoApp.Dto;
using estacionamentoApp.Models;
using estacionamentoApp.Services.EnderecoService;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Services.FilialService
{
    public class FilialService : IFilialInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IEnderecoInterface _endereco;
        public FilialService(ApplicationDbContext context, IEnderecoInterface enderecoInterface)
        {
            _context = context;
            _endereco = enderecoInterface;
        }
        public async Task<ResponseModel<List<FilialListDto>>> BuscarFiliais()
        {
            ResponseModel<List<FilialListDto>> response = new ResponseModel<List<FilialListDto>>();

            try
            {
                //Filtra os clientes para exibir apenas os clientes com ativo = TRUE
                var filiais = await _context.Filial
                .Include(end => end.Endereco)
                .Include(emp => emp.Empresa)
                .Where(c => c.Ativo)
                .ToListAsync();


                var filiaisDto = filiais.Select(f => new FilialListDto
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    NomeFantasia = f.NomeFantasia,
                    InscricaoEstadual = f.InscricaoEstadual,
                    Cnpj = f.Cnpj,
                    EmpresaId = f.EmpresaId,
                    EmpresaNome = f.Empresa.Nome,
                    EnderecoId = f.EnderecoId,
                    Cep = f.Endereco.Cep,
                    Rua = f.Endereco.Rua,
                    Bairro = f.Endereco.Bairro,
                    Cidade = f.Endereco.Cidade,
                    Estado = f.Endereco.Estado,
                    Pais = f.Endereco.Pais
                }).ToList();

                response.Dados = filiaisDto;
                response.Mensagem = "Dados coletados com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<FilialCadastroDto>> BuscarFilialPorId(long? id)
        {
            ResponseModel<FilialCadastroDto> response = new ResponseModel<FilialCadastroDto>();

            try
            {
                if (id == null)
                {
                    response.Mensagem = "Filial não localizado!";
                    response.Status = false;
                    return response;
                }
                var filial = await _context.Filial
                    .Include (end => end.Endereco)
                    .Include (emp => emp.Empresa)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (filial == null)
                {
                    response.Mensagem = "Filial não encontrado com esse id!";
                    response.Status = false;
                    return response;
                }
                var filialDto = new FilialCadastroDto
                {
                    Id = filial.Id,
                    Nome = filial.Nome,
                    NomeFantasia = filial.NomeFantasia,
                    InscricaoEstadual = filial.InscricaoEstadual,
                    Cnpj = filial.Cnpj,
                    EmpresaId = filial.EmpresaId,
                    EnderecoId = filial.EnderecoId,
                    Cep = filial.Endereco.Cep,
                    Rua = filial.Endereco.Rua,
                    Bairro = filial.Endereco.Bairro,
                    Cidade = filial.Endereco.Cidade,
                    Estado = filial.Endereco.Estado,
                    Pais = filial.Endereco.Pais,
                };

                response.Dados = filialDto;
                response.Status = true;
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

            public async Task<ResponseModel<FilialModel>> CadastrarFilial(FilialCadastroDto filialDto)
            {
                ResponseModel<FilialModel> response = new ResponseModel<FilialModel>();
                try
                {
                    //Set os dados do endereço para ser salvo
                    var endereco = new EnderecoModel()
                    {
                        Cep = filialDto.Cep,
                        Rua = filialDto.Rua,
                        Bairro = filialDto.Bairro,
                        Cidade = filialDto.Cidade,
                        Estado = filialDto.Estado,
                        Pais = filialDto.Pais,
                    };
                    //Salvando primeiro o endereço
                    var enderecoFilial = _context.Endereco.Add(endereco);
                    await _context.SaveChangesAsync();

                    //Set nos dados da filial para ser salva OBS: set no endereço cadastrado anteriormente
                    var filial = new FilialModel()
                    {
                        Nome = filialDto.Nome,
                        NomeFantasia = filialDto.NomeFantasia,
                        InscricaoEstadual = filialDto.InscricaoEstadual,
                        Cnpj = filialDto.Cnpj,
                        EnderecoId = enderecoFilial.Entity.Id,
                        EmpresaId = filialDto.EmpresaId,
                    };
                    _context.Filial.Add(filial);
                    await _context.SaveChangesAsync();
                    response.Mensagem = "Usuário Cadastrado com sucesso!";

                    return response;

                }
                catch (Exception ex)
                {
                    response.Mensagem = ex.Message;
                    response.Status = false;
                    return response;
                }
            }

        public async Task<ResponseModel<FilialModel>> EditarFilial(FilialCadastroDto filialDto)
        {
            ResponseModel<FilialModel> response = new ResponseModel<FilialModel>();

            try
            {
                // Buscar o modelo de domínio (FilialModel) diretamente do banco
                var filial = await _context.Filial
                    .Include(f => f.Endereco)
                    .FirstOrDefaultAsync(f => f.Id == filialDto.Id);

                if (filial == null)
                {
                    response.Mensagem = "Filial não encontrada!";
                    response.Status = false;
                    return response;
                }

                // Atualizar endereço
                filial.Endereco.Cep = filialDto.Cep;
                filial.Endereco.Rua = filialDto.Rua;
                filial.Endereco.Bairro = filialDto.Bairro;
                filial.Endereco.Cidade = filialDto.Cidade;
                filial.Endereco.Estado = filialDto.Estado;
                filial.Endereco.Pais = filialDto.Pais;

                // Atualizar dados da filial
                filial.Nome = filialDto.Nome;
                filial.NomeFantasia = filialDto.NomeFantasia;
                filial.InscricaoEstadual = filialDto.InscricaoEstadual;
                filial.Cnpj = filialDto.Cnpj;
                filial.EmpresaId = filialDto.EmpresaId;

                // Salvar mudanças
                _context.Filial.Update(filial);
                await _context.SaveChangesAsync();

                response.Mensagem = "Edição realizada com sucesso!";
                response.Status = true;
                response.Dados = filial;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public async Task<ResponseModel<FilialModel>> RemoveFilial(long? id)
        {
            ResponseModel<FilialModel> response = new ResponseModel<FilialModel>();
            try
            {
                var filial = await _context.Filial.FirstOrDefaultAsync(f => f.Id == id);
                if (filial == null)
                {
                    response.Mensagem = "Filial não encontrada para exclusão!";
                    response.Status = false;
                    return response;
                }

                filial.Ativo = false;
                _context.Update(filial);
                await _context.SaveChangesAsync();

                response.Mensagem = "Remoção realizada com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
