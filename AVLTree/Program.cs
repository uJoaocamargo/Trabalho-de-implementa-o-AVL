using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();
        
        // Verifica se foi passado um argumento com o caminho do arquivo
        if (args.Length == 0)
        {
            Console.WriteLine("Por favor, forneça o caminho do arquivo de entrada como argumento.");
            return;
        }

        string filePath = args[0];
        
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            
            foreach (string line in lines)
            {
                string[] parts = line.Trim().Split(' ');
                string command = parts[0].ToUpper();

                switch (command)
                {
                    case "I":
                        if (parts.Length == 2 && int.TryParse(parts[1], out int insertValue))
                            tree.Insert(insertValue);
                        break;
                    
                    case "R":
                        if (parts.Length == 2 && int.TryParse(parts[1], out int removeValue))
                            tree.Remove(removeValue);
                        break;
                    
                    case "B":
                        if (parts.Length == 2 && int.TryParse(parts[1], out int searchValue))
                            Console.WriteLine(tree.Search(searchValue) ? "Valor encontrado" : "Valor não encontrado");
                        break;
                    
                    case "P":
                        Console.WriteLine($"Árvore em pré-ordem: {tree.PreOrder()}");
                        break;
                    
                    case "F":
                        Console.WriteLine("Fatores de balanceamento:");
                        Console.WriteLine(tree.BalanceFactors());
                        break;
                    
                    case "H":
                        Console.WriteLine($"Altura da árvore: {tree.GetHeight() - 1}");
                        break;
                    
                    default:
                        Console.WriteLine($"Comando inválido: {command}");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar o arquivo: {ex.Message}");
        }
    }
}