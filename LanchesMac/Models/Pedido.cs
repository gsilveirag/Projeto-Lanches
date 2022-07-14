using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome.")]
        [StringLength(50)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o seu endereco.")]
        [StringLength(100)]
        [Display(Name = "Endereco")]
        public string Endereco1 { get; set; }

        [Required(ErrorMessage = "Informe o complemento do seu endereco.")]
        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP.")]
        [StringLength(10)]
        [Display(Name = "Cep")]
        public int Cep { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(30)]
        public int Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone.")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Informe o seu email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
        ErrorMessage = "O email nao possui um formato correto.")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do Pedido")]
        public decimal PedidoTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Itens no Pedido")]
        public int TotalItensPedido { get; set; }

        [Display(Name = "Data do Pedido")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true )]
        [DataType(DataType.Text)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data Envio Pedido")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Text)]
        public DateTime? PedidoEntregeEm { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set; }

    }
}
