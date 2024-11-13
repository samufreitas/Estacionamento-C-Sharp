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

        public DbSet<ClienteModel> cliente { get; set; }

        public DbSet<VeiculoModel> veiculo { get; set; }

        public DbSet<EmpresaModel> empresa { get; set; }

        public DbSet<EnderecoModel> endereco { get; set; }

        public DbSet<FilialModel> filial { get; set; }

        public DbSet<EstacionamentoModel> estacionamento { get; set; }

        public DbSet<VeiculoEstacionamentoModel> veiculoEstacionamentoModels { get; set; }


    }
}
