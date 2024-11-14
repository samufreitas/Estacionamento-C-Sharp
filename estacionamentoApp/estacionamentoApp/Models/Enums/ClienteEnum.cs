using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace estacionamentoApp.Models.Enus
{
    public enum ClienteEnum
    {
        [Display(Name = "Selecione o tipo de cliente")]
        None = 0,

        [Display(Name = "Pessoa Física")]
        PF = 1,

        [Display(Name = "Pessoa Jurídica")]
        PJ = 2
    }
    
}
