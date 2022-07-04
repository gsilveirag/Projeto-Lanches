using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(10, ErrorMessage = "O tamanho minimo e de {1}.")]
        [MaxLength(20, ErrorMessage = "O tamanho maximo é de {1}")]
        [Display(Name = "Nome do Lanche")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe uma descricao da categoria")]
        [MinLength(10, ErrorMessage = "O tamanho minimo e de {1}.")]
        [MaxLength(100, ErrorMessage = "O tamanho maximo é de {1}")]
        [Display(Name = "Descricao Curta do Lanche")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Informe uma descricao detalhada da categoria")]
        [MinLength(50, ErrorMessage = "O tamanho minimo e de {1}.")]
        [MaxLength(300, ErrorMessage = "O tamanho maximo é de {1}")]
        [Display(Name = "Descricao Detalhada")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preco da categoria")]
        [StringLength(100, ErrorMessage = "O Tamanho maximo é 100 caracteres")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99, ErrorMessage ="O valor deve estar entre R$1,00 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name="Caminho Imagem Normal.")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura.")]
        public string ImagemThumbnailUrd { get; set; }
        public bool IsLanchePreferido { get; set; }
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
