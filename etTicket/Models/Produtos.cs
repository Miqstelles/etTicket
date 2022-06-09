using Pinegas.Data;
using Pinegas.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pinegas.Models
{
    public class Produtos : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string NomeProduto { get; set; }
        public string Descrição { get; set; }
        public double Valor { get; set; }
        public string ImageURL { get; set; }
        public int Quantidade { get; set; }

    }
}
