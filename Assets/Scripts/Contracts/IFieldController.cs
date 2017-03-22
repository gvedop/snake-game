using UnityEngine;
using SnakeGame.Core;

namespace SnakeGame.Contracts
{
    public interface IFieldController : IGameLogicSubscriber
    {
        void Init();
        Coordinate GetCoordinateFreeCell();
        void SetCell(Coordinate coordinate, CellType cellType, Sprite sprite);
    }
}
