using estacionamentoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace estacionamentoApp.Map
{
    public class VeiculoMap : IEntityTypeConfiguration<VeiculoModel>
    {
        public void Configure(EntityTypeBuilder<VeiculoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cliente);
        }
    }
}
