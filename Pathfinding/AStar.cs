using System;
using System.Collections.Generic;
using Quoridor.Core;

namespace Quoridor.Pathfinding
{
    public class AStar
    {
        public List<Tile> path => _path;

        private List<Tile> _path;
        public void DoAStar(Tile start, Tile goal)
        {
            List<Tile> openSet = new List<Tile>();
            List<Tile> closedSet = new List<Tile>();
            _path = new List<Tile>(); 

            openSet.Add(start);

            while (openSet.Count > 0)
            {
                int lowestIndex = 0;
                for (int i = 0; i < openSet.Count; i++)
                {
                    Tile tile = openSet[i];

                    if(tile.f < openSet[lowestIndex].f)
                        lowestIndex = i;
                }
                Tile current = openSet[lowestIndex];

                if(current == goal)
                {
                    Tile end = current;
                    path.Add(end);
                    while (end.parent != null)
                    {
                        path.Add(end.parent);
                        end = end.parent;
                    }
                    break;
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (Tile neighbor in current.GetNeighbours())
                {
                    if(!closedSet.Contains(neighbor))
                    {
                        float tempG = current.g + 1;
                        bool newPath = false;

                        if(openSet.Contains(neighbor))
                        {    
                            if(tempG < neighbor.g)
                            {
                                neighbor.g = tempG;
                                newPath = true;
                            }
                        }
                        else
                        {
                            neighbor.g = tempG;
                            openSet.Add(neighbor);
                            newPath = true;
                        }

                        if(newPath)
                        {
                            neighbor.h = CalculateHeuristic(neighbor, goal);
                            neighbor.f = neighbor.g + neighbor.h;
                            neighbor.parent = current;
                        }
                    }
                    else continue;
                }
            }
        }

        private float CalculateHeuristic(Tile neighbor, Tile goal)
        {
            return Dist((int) neighbor.position.Y, (int) neighbor.position.Y, 
                        (int) goal.position.X, (int) goal.position.Y);
        }

        private float Dist(int aX, int aY, int bX, int bY) {
            return MathF.Sqrt(MathF.Pow(bX - aX, 2) + MathF.Pow(bY - aY, 2));
        }
    }
}