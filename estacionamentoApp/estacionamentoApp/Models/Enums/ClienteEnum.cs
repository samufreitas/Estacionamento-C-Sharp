using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models.Enus
{
    public enum ClienteEnum
    {
        [Display(Name = "Pessoa Jurídica")]
        PF = 1,

        [Display(Name = "Pessoa Física")]
        PJ = 2
    }
}
