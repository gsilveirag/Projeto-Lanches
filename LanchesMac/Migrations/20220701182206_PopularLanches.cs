using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laches_Categorias_CategoriaId",
                table: "Laches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laches",
                table: "Laches");

            migrationBuilder.RenameTable(
                name: "Laches",
                newName: "Lanches");

            migrationBuilder.RenameColumn(
                name: "CategoriaName",
                table: "Categorias",
                newName: "CategoriaNome");

            migrationBuilder.RenameIndex(
                name: "IX_Laches_CategoriaId",
                table: "Lanches",
                newName: "IX_Lanches_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lanches",
                table: "Lanches",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lanches_Categorias_CategoriaId",
                table: "Lanches",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrd,ImagemUrl,IsLanchePreferido,Name,Preco)" +
               "VALUES(1,'Pao, hamburguer, ovo, presunto, queijo e batata palha','Delicioso pao de hamburguer com a melhor carne do mercado e queijo de primeira qualidade.',1,'https://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','https://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',0, 'Cheese Salada', 12.50)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrd,ImagemUrl,IsLanchePreferido,Name,Preco)" +
                "VALUES(1,'Pao, hamburguer, ovo','Delicioso pao de hamburguer com a melhor carne do mercado e ovo.',1,'/imagens/lanche03.jpg','/imagens/lanche03.jpg',0, 'Pao com Ovo', 11.50)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrd,ImagemUrl,IsLanchePreferido,Name,Preco)" +
                "VALUES(2,'Pao, frango, salada','Delicioso pao integral com frango e salada de primeira qualidade.',1,'https://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','https://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',1, 'Lanche Natural', 10.50)");
        }


      

      

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        migrationBuilder.Sql("DELETE FROM Lanches");

        migrationBuilder.DropForeignKey(
                name: "FK_Lanches_Categorias_CategoriaId",
                table: "Lanches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lanches",
                table: "Lanches");

            migrationBuilder.RenameTable(
                name: "Lanches",
                newName: "Laches");

            migrationBuilder.RenameColumn(
                name: "CategoriaNome",
                table: "Categorias",
                newName: "CategoriaName");

            migrationBuilder.RenameIndex(
                name: "IX_Lanches_CategoriaId",
                table: "Laches",
                newName: "IX_Laches_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laches",
                table: "Laches",
                column: "LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laches_Categorias_CategoriaId",
                table: "Laches",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
