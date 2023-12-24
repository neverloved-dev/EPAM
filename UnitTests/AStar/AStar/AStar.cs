using System;
using System.Collections.Generic;

namespace AStarNamespace
{
    public class AStar
    {
        private readonly int[,] grid;
        private readonly int width;
        private readonly int height;

        private class Node
        {
            public int X { get; }
            public int Y { get; }
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

        public AStar(int[,] grid)
        {
            this.grid = grid;
            width = grid.GetLength(1);
            height = grid.GetLength(0);
        }

        public List<(int, int)> FindPath((int, int) start, (int, int) end)
        {
            if (!IsValidNode(start) || !IsValidNode(end))
            {
                return null; // Invalid start or end node, or obstacles at start/end positions
            }

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
                    if (openList[i].F < currentNode.F || (openList[i].F == currentNode.F && openList[i].H < currentNode.H))
                    {
                        currentNode = openList[i];
                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode.X == endNode.X && currentNode.Y == endNode.Y)
                {
                    return ReconstructPath(currentNode, startNode); // Return the path if the end node is reached
                }

                List<Node> neighbors = GetNeighbors(currentNode);
                foreach (Node neighbor in neighbors)
                {
                    if (closedList.Contains(neighbor) || grid[neighbor.Y, neighbor.X] == 1)
                    {
                        continue;
                    }

                    int tentativeGCost = currentNode.G + GetDistance(currentNode, neighbor);
                    if (!openList.Contains(neighbor) || tentativeGCost < neighbor.G)
                    {
                        neighbor.G = tentativeGCost;
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

            return null; // No path found between the start and end points
        }

        private List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();

            int[] dx = { 0, 0, 1, -1 }; // Define movement changes in x-axis
            int[] dy = { 1, -1, 0, 0 }; // Define movement changes in y-axis

            for (int i = 0; i < dx.Length; i++)
            {
                int neighborX = node.X + dx[i];
                int neighborY = node.Y + dy[i];

                if (IsValidNode((neighborX, neighborY)) && grid[neighborY, neighborX] != 1)
                {
                    neighbors.Add(new Node(neighborX, neighborY));
                }
            }

            return neighbors;
        }

        private bool IsValidNode((int, int) node)
        {
            return node.Item1 >= 0 && node.Item1 < width && node.Item2 >= 0 && node.Item2 < height && grid[node.Item2, node.Item1] != 1;
        }

        private int GetDistance(Node a, Node b)
        {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);
            return dx + dy;
        }

        private List<(int, int)> ReconstructPath(Node currentNode, Node startNode)
        {
            List<(int, int)> path = new List<(int, int)>();
            while (currentNode != startNode)
            {
                path.Add((currentNode.X, currentNode.Y));
                currentNode = currentNode.Parent;
            }
            path.Add((startNode.X, startNode.Y));
            path.Reverse();
            return path;
        }
    }
}
