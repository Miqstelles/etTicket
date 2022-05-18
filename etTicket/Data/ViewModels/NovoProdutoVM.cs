using etTicket.Data;
using etTicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace etTicket.Models
{
    public class NovoProdutoVM
    {
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "Insira o nome do produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Descrição do produto")]
        [Required(ErrorMessage = "Insira a descrição do produto")]
        public string Descrição { get; set; }

        [Display(Name = "Preço in R$")]
        [Required(ErrorMessage = "Insira o preço do produto")]
        public double Valor { get; set; }

        [Display(Name = "Imagem do produto")]
        [Required(ErrorMessage = "Insira a imagem do produto")]
        public string ImageURL { get; set; }

        [Display(Name = "Quantidade do produto")]
        [Required(ErrorMessage = "Insira a quantidade do produto")]
        public int Quantidade { get; set; }
    }
}
