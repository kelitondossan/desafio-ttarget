using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DesafioTTarget.Challenges
{
    public class StockMovement
    {
        public static void Execute()
        {
            string json = @"
            {
                ""estoque"": [
                    { ""codigoProduto"": 101, ""descricaoProduto"": ""Caneta Azul"", ""estoque"": 150 },
                    { ""codigoProduto"": 102, ""descricaoProduto"": ""Caderno Universitário"", ""estoque"": 75 },
                    { ""codigoProduto"": 103, ""descricaoProduto"": ""Borracha Branca"", ""estoque"": 200 },
                    { ""codigoProduto"": 104, ""descricaoProduto"": ""Lápis Preto HB"", ""estoque"": 320 },
                    { ""codigoProduto"": 105, ""descricaoProduto"": ""Marcador de Texto Amarelo"", ""estoque"": 90 }
                ]
            }";

            try
            {
                var stockData = JsonSerializer.Deserialize<StockData>(json);
                if (stockData?.estoque == null) return;

                Console.WriteLine("--- Gestão de Estoque ---");
                
                // Display current stock
                Console.WriteLine("Estoque Atual:");
                foreach (var item in stockData.estoque)
                {
                    Console.WriteLine($"ID: {item.codigoProduto} | Produto: {item.descricaoProduto} | Qtd: {item.estoque}");
                }

                Console.WriteLine("\nInforme o ID do produto para movimentação:");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    var product = stockData.estoque.FirstOrDefault(p => p.codigoProduto == productId);
                    if (product != null)
                    {
                        Console.WriteLine($"Produto selecionado: {product.descricaoProduto}");
                        Console.WriteLine("Tipo de movimentação (1 - Entrada, 2 - Saída):");
                        if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
                        {
                            Console.WriteLine("Quantidade:");
                            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                            {
                                if (type == 2) 
                                {
                                    if (product.estoque >= quantity)
                                    {
                                        product.estoque -= quantity;
                                        Console.WriteLine("Saída realizada com sucesso.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Estoque insuficiente.");
                                        return;
                                    }
                                }
                                else 
                                {
                                    product.estoque += quantity;
                                    Console.WriteLine("Entrada realizada com sucesso.");
                                }

                                Console.WriteLine($"\nEstoque Final do Produto '{product.descricaoProduto}': {product.estoque}");
                            }
                            else
                            {
                                Console.WriteLine("Quantidade inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tipo de movimentação inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar estoque: {ex.Message}");
            }
        }
    }

    public class StockData
    {
        public List<Product> estoque { get; set; }
    }

    public class Product
    {
        public int codigoProduto { get; set; }
        public string descricaoProduto { get; set; }
        public int estoque { get; set; }
    }
}
