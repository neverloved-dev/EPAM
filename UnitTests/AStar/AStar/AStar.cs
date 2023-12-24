using System;
using System.Collections.Generic;

namespace AStar
{
    public class AStar
    {
        private class Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int F { get; set; }
            public int G { get; set; }
            public int H { get; set; }
            public Node Parent { get; set; }

            public Node(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private readonly int[,] grid;
        private readonly int width;
        private readonly int height;

        public AStar(int[,] grid)
        {
            this.grid = grid;
            width = grid.GetLength(1);
            height = grid.GetLength(0);
        }

        public List<(int, int)> FindPath((int, int) start, (int, int) end)
        {
            Node startNode = new Node(start.Item1, start.Item2);
            Node endNode = new Node(end.Item1, end.Item2);

            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                Node currentNode = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].F < currentNode.F || openList[i].F == currentNode.F && openList[i].H < currentNode.H)
                    {
                        currentNode = openList[i];
                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode.X == endNode.X && currentNode.Y == endNode.Y)
                {
                    return GetPath(currentNode);
                }

                List<Node> neighbors = GetNeighbors(currentNode);
                foreach (Node neighbor in neighbors)
                {
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbor = currentNode.G + GetDistance(currentNode, neighbor);
                    if (newMovementCostToNeighbor < neighbor.G || !openList.Contains(neighbor))
                    {
                        neighbor.G = newMovementCostToNeighbor;
                        neighbor.H = GetDistance(neighbor, endNode);
                        neighbor.F = neighbor.G + neighbor.H;
                        neighbor.Parent = currentNode;

                        if (!openList.Contains(neighbor))
                        {
                            openList.Add(neighbor);
                        }
                    }
                }
            }

            return null;
        }

        private List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();

            int[] dx = { 0, 0, 1, -1 }; // East, West, South, North
            int[] dy = { 1, -1, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                int newX = node.X + dx[i];
                int newY = node.Y + dy[i];

                if (newX >= 0 && newX < width && newY >= 0 && newY < height && grid[newY, newX] == 0)
                {
                    neighbors.Add(new Node(newX, newY));
                }
            }

            return neighbors;
        }

        private int GetDistance(Node a, Node b)
        {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);
            return dx + dy;
        }

        private List<(int, int)> GetPath(Node endNode)
        {
            List<(int, int)> path = new List<(int, int)>();
            Node currentNode = endNode;
            while (currentNode != null)
            {
                path.Add((currentNode.X, currentNode.Y));
                currentNode = currentNode.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}