using System;
using System.Xml.Linq;

class Program
{
    static char[,] grid = new char[5, 5];

    static void Main()
    {

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                grid[i, j] = 'X';

        grid[1, 1] = 'i';
        grid[4, 4] = 'f';
        grid[3, 4] = '-';
        grid[3, 3] = '-';
        grid[3, 1] = '-';
        grid[3, 0] = '-';

        Map.Mostrar(grid);

        Node inicio = Map.Encontrar(grid, 'i');
        Node fim = Map.Encontrar(grid, 'f');


        AStar.Executar(grid, inicio, fim);

        Console.WriteLine("\n||----------------------||------------------||\n");
        Map.Mostrar(grid);
    }
}
