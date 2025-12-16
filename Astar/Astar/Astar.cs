using System;
using System.Collections.Generic;
using System.Xml.Linq;

static class AStar
{
    public static void Executar(char[,] grid, Node inicio, Node fim)
    {
        List<Node> abertos = new List<Node>();
        List<Node> fechados = new List<Node>();

        abertos.Add(inicio);

        while (abertos.Count > 0)
        {
            Node atual = abertos[0];
            foreach (Node n in abertos)
                if (n.F < atual.F)
                    atual = n;

            abertos.Remove(atual);
            fechados.Add(atual);

            if (atual.X == fim.X && atual.Y == fim.Y)
            {
                MarcarCaminho(grid, atual);
                return;
            }

            int[,] movimentos = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            for (int i = 0; i < 4; i++)
            {
                int nx = atual.X + movimentos[i, 0];
                int ny = atual.Y + movimentos[i, 1];

                if (nx < 0 || ny < 0 || nx >= 5 || ny >= 5)
                    continue;

                if (grid[nx, ny] == '-')
                    continue;

                if (fechados.Exists(n => n.X == nx && n.Y == ny))
                    continue;

                int g = atual.G + 1;
                int h = Heuristica(nx, ny, fim.X, fim.Y);

                if (!abertos.Exists(n => n.X == nx && n.Y == ny))
                    abertos.Add(new Node(nx, ny, g, h, atual));
            }
        }
    }

    static int Heuristica(int x, int y, int fx, int fy)
    {
        return Math.Abs(x - fx) + Math.Abs(y - fy);
    }

    static void MarcarCaminho(char[,] grid, Node node)
    {
        while (node.Pai != null)
        {
            if (grid[node.X, node.Y] == 'X')
                grid[node.X, node.Y] = 'o';

            node = node.Pai;
        }
    }
}
