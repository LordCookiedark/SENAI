using System;

static class Map
{
    public static Node Encontrar(char[,] grid, char alvo)
    {
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                if (grid[i, j] == alvo)
                    return new Node(i, j, 0, 0, null);

        return null;
    }

    public static void Mostrar(char[,] grid)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
