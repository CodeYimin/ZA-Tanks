using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Utility;

namespace Map
{
    internal struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    internal enum Side
    {
        Right,
        Left,
        Up,
        Down,
    }
    
    public static class MazeGenerator
    {
        private static List<Side> GetUnvisitedSides(Position p, bool[,] visited)
        {
            List<Side> unvisited = new List<Side>();

            int width = visited.GetLength(0);
            int height = visited.GetLength(1);

            if (p.X < width - 1 && !visited[p.X + 1, p.Y]) unvisited.Add(Side.Right);
            if (p.X > 0 && !visited[p.X - 1, p.Y]) unvisited.Add(Side.Left);
            if (p.Y < height - 1 && !visited[p.X, p.Y + 1]) unvisited.Add(Side.Up);
            if (p.Y > 0 && !visited[p.X, p.Y - 1]) unvisited.Add(Side.Down);

            return unvisited;
        }

        public static void RandomlyRemoveWalls(bool[,] horizontalWalls, bool[,] verticalWalls, float percentage)
        {
            for (int i = 0; i < horizontalWalls.GetLength(0); i++)  
            {
                for (int j = 0; j < horizontalWalls.GetLength(1); j++)  
                {
                    if (Random.value < percentage / 100)
                    {
                        horizontalWalls[i, j] = false;
                    }
                }
            }
            
            for (int i = 0; i < verticalWalls.GetLength(0); i++)  
            {
                for (int j = 0; j < verticalWalls.GetLength(1); j++)  
                {
                    if (Random.value < percentage / 100)
                    {
                        verticalWalls[i, j] = false;
                    }
                }
            }
        }
        
        public static void Generate(int width, int height, out bool[,] horizontalWalls, out bool[,] verticalWalls)
        {
            // 0,0 is the top wall of the bottom left cell
            horizontalWalls = new bool [width, height - 1];
            // 0,0 is the right wall of the bottom left cell
            verticalWalls = new bool [width - 1, height];

            Util.Fill2DArray(verticalWalls, true);
            Util.Fill2DArray(horizontalWalls, true);

            Stack<Position> positionStack = new Stack<Position>();
            bool [,] visited = new bool [width, height];
            
            positionStack.Push(new Position(0, 0));
            visited[positionStack.Peek().X, positionStack.Peek().Y] = true;
            
            while (positionStack.Count > 0)
            {
                Position currentPos = positionStack.Peek();
                List<Side> unvisitedSides = GetUnvisitedSides(currentPos, visited);
                
                if (unvisitedSides.Count > 0)
                {
                    int randIndex = Random.Range(0, unvisitedSides.Count);
                    Side randSide = unvisitedSides[randIndex];

                    switch (randSide)
                    {
                        case Side.Up:
                            visited[currentPos.X, currentPos.Y + 1] = true;
                            positionStack.Push(new Position(currentPos.X, currentPos.Y + 1));
                            horizontalWalls[currentPos.X, currentPos.Y] = false;
                            break;
                        case Side.Down:
                            visited[currentPos.X, currentPos.Y - 1] = true;
                            positionStack.Push(new Position(currentPos.X, currentPos.Y - 1));
                            horizontalWalls[currentPos.X, currentPos.Y - 1] = false;
                            break;
                        case Side.Left:
                            visited[currentPos.X - 1, currentPos.Y] = true;
                            positionStack.Push(new Position(currentPos.X - 1, currentPos.Y));
                            verticalWalls[currentPos.X - 1, currentPos.Y] = false;
                            break;
                        case Side.Right:
                            visited[currentPos.X + 1, currentPos.Y] = true;
                            positionStack.Push(new Position(currentPos.X + 1, currentPos.Y));
                            verticalWalls[currentPos.X, currentPos.Y] = false;
                            break;
                    }
                }
                else
                {
                    positionStack.Pop();
                }
            }
        }
        public static void PrintToConsole(bool[,] horizontalWalls, bool[,] verticalWalls)
        {
            Debug.Log("Horizontal Walls");
            StringBuilder sb = new StringBuilder();
            for (int j = horizontalWalls.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i < horizontalWalls.GetLength(0); i++)
                {
                    sb.Append(horizontalWalls[i, j]);
                    sb.Append(' ');
                }

                sb.AppendLine();
            }
            Debug.Log(sb.ToString());
       
            Debug.Log("Vertical Walls");
            sb = new StringBuilder();
            for (int j = verticalWalls.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i < verticalWalls.GetLength(0); i++)
                {
                    sb.Append(verticalWalls[i, j]);
                    sb.Append(' ');
                }

                sb.AppendLine();
            }
            Debug.Log(sb.ToString());
        }
    }
}