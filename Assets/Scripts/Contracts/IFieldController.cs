using UnityEngine;
using SnakeGame.Core;

namespace SnakeGame.Contracts
{
    public interface IFieldController : IGameLogicSubscriber
    {
        void Init();
        void ToStart();
        void SetCell(Coordinate coordinate, CellType cellType, Sprite sprite);
        Coordinate GetSnakeStartCoordinate();
        Coordinate GetWallCoordinate();
        Coordinate GetMouseCoordinate();
    }
}
