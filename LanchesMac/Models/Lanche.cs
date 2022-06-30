﻿namespace LanchesMac.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        public string Name { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrd { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
    }
}