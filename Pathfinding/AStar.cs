using System;
using System.Collections.Generic;

namespace Quoridor.Pathfinding
{
    public class AStar
    {
        public List<IPathfindingNode> path => _path;

        private IPathfindingNode _goal;
        private List<IPathfindingNode> _openSet;
        private List<IPathfindingNode> _closedSet;
        private List<IPathfindingNode> _path;
        private IPathfindingNode _currentTile;
        private IPathfindingNode _currentTileNeighbour;
        private float _tempG;
        private bool _newPathDiscovered;
        
        public void DoAStar(IPathfindingNode start, IPathfindingNode goal)
        {
            _goal = goal;

            ResetLists();

            _openSet.Add(start);

            StartAlgorithm();
        }

        private void StartAlgorithm()
        {
            while (OpenSetHasTiles())
            {
                GetNearestToTheGoalTile();

                if (_currentTile == _goal)
                {
                    AddTilesToPath();
                    break;
                }

                _openSet.Remove(_currentTile);
                _closedSet.Add(_currentTile);

                CheckCurrentTileNeighbors();
            }
        }

        private void CheckCurrentTileNeighbors()
        {
            foreach (IPathfindingNode neighbour in _currentTile.GetPathfindingNeighbours())
            {
                _currentTileNeighbour = neighbour;

                if (!_closedSet.Contains(_currentTileNeighbour))
                    ProcessCurrentTileNeighbour();
            }
        }

        private void ProcessCurrentTileNeighbour()
        {
            _tempG = _currentTile.g + 1;
            _newPathDiscovered = false;

            CheckCurrentTileNeighborG();

            if (_newPathDiscovered)
                CalculateCurrentTileNeighbourF();
        }

        private void CheckCurrentTileNeighborG()
        {
            if (_openSet.Contains(_currentTileNeighbour))
            {
                if (_tempG < _currentTileNeighbour.g)
                    AssignNewCurrentTileNeighborGAndPath();
            }
            else
            {
                AssignNewCurrentTileNeighborGAndPath();
                _openSet.Add(_currentTileNeighbour);
            }
        }

        private void AssignNewCurrentTileNeighborGAndPath()
        {
            _currentTileNeighbour.g = _tempG;
            _newPathDiscovered = true;
        }

        private void CalculateCurrentTileNeighbourF()
        {
            _currentTileNeighbour.h = CalculateHeuristic(_currentTileNeighbour, _goal);
            _currentTileNeighbour.f = _currentTileNeighbour.g + _currentTileNeighbour.h;
            _currentTileNeighbour.parent = _currentTile;
        }

        private void AddTilesToPath()
        {
            _path.Add(_currentTile);
            while (_currentTile.parent != null)
            {
                _path.Add(_currentTile.parent);
                _currentTile = _currentTile.parent;
            }
        }

        private void GetNearestToTheGoalTile()
        {
            int lowestIndex = 0;
            for (int i = 0; i < _openSet.Count; i++)
            {
                IPathfindingNode tile = _openSet[i];

                if (tile.f < _openSet[lowestIndex].f)
                    lowestIndex = i;
            }
            _currentTile = _openSet[lowestIndex];
        }

        private bool OpenSetHasTiles()
        {
            return _openSet.Count > 0;
        }

        private void ResetLists()
        {
            _openSet = new List<IPathfindingNode>();
            _closedSet = new List<IPathfindingNode>();
            _path = new List<IPathfindingNode>();
        }

        private float CalculateHeuristic(IPathfindingNode neighbor, IPathfindingNode goal)
        {
            return Dist((int) neighbor.position.Y, (int) neighbor.position.Y, 
                        (int) goal.position.X, (int) goal.position.Y);
        }

        private float Dist(int aX, int aY, int bX, int bY) {
            return MathF.Sqrt(MathF.Pow(bX - aX, 2) + MathF.Pow(bY - aY, 2));
        }
    }
}