using DocumentFormat.OpenXml.Bibliography;
using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace estacionamentoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {    
        }

        public DbSet<ClienteModel> Cliente { get; set; }

        public DbSet<VeiculoModel> Veiculo { get; set; }

        public DbSet<EmpresaModel> Empresa { get; set; }

        public DbSet<EnderecoModel> Endereco { get; set; }

        public DbSet<FilialModel> Filial { get; set; }

        public DbSet<EstacionamentoModel> Estacionamento { get; set; }

        public DbSet<VeiculoEstacionamentoModel> VeiculoEstacionamento { get; set; }


    }
}
