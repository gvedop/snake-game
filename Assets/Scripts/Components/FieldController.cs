using System;
using UnityEngine;
using SnakeGame.Core;
using SnakeGame.Contracts;

namespace SnakeGame.Components
{
    [DisallowMultipleComponent]
    public class FieldController : MonoBehaviour, IFieldController
    {
        [SerializeField]
        private Cell cellPrefab;
        [SerializeField]
        private Sprite sprite;
        [SerializeField]
        private RectTransform panel;
        [SerializeField]
        private int xCount = 17;
        [SerializeField]
        private int yCount = 21;
        [SerializeField]
        private int xStartPostion = 9;
        [SerializeField]
        private int yStartPostion = 20;

        private IGameLogic _gameLogic;
        private Cell[][] _cells;
        
        public void SubscribeToGameLogic(IGameLogic gameLogic)
        {
            if (gameLogic == null)
                throw new ArgumentNullException("gameLogic");
            _gameLogic = gameLogic;
        }

        public void UnsubscribeFromGameLogic()
        {
            _gameLogic = null;
        }

        public void Init()
        {
            GenerateField();
        }

        public Coordinate GetCoordinateFreeCell()
        {
            var x = 0;
            var y = 0;
            if (TryGetRandomCoordinateCell(out x, out y) || TryGetRandomCoordinateCell(out x, out y))
            {
                return new Coordinate(x, y);
            }
            else 
            {
                var xx = 0;
                var yy = 0;
                if (TryGetNextPositionFreeCell(x, y, out xx, out yy))
                    return new Coordinate(xx, yy);
                else if (TryGetNextPositionFreeCell(0, 0, out xx, out yy))
                    return new Coordinate(xx, yy);
                else
                    return new Coordinate(0, 0);
            }
        }

        public void SetCell(Coordinate coordinate, CellType cellType, Sprite sprite)
        {
            _cells[coordinate.Y][coordinate.X].SetCellType(cellType, sprite);
        }

        private void GenerateField()
        {
            //var spriteRenderer = cell.GetComponent<SpriteRenderer>();
            
            //var cellSize = spriteRenderer.bounds.size;
            var cellSize = new Vector2(50f, 50f);

            var realWidth = panel.rect.width * 2f;
            var realHeight = panel.rect.height * 2f;

            var scaleWidth = realWidth / cellSize.x;
            var scaleHeight = realHeight / cellSize.y;

            var newCellWidth = scaleWidth / xCount * cellSize.x;
            var newCellHeight = scaleHeight / yCount * cellSize.y;
            
            if (newCellHeight > newCellWidth)
                newCellHeight = newCellWidth;
            else
                newCellWidth = newCellHeight;
            
            var cellScaleWidth = realWidth / cellSize.x / xCount;
            var cellScaleHeight = realHeight / cellSize.y / yCount;
            
            if (cellScaleHeight > cellScaleWidth)
                cellScaleHeight = cellScaleWidth;
            else
                cellScaleWidth = cellScaleHeight;

            var worldCorners = new Vector3[4];
            panel.GetWorldCorners(worldCorners);

            var screenToWorldPoint = new Vector3[4];
            for (int i = 0; i < 4; i++)
                screenToWorldPoint[i] = Camera.main.ScreenToWorldPoint(worldCorners[i]);
            var center = new Vector2(
                screenToWorldPoint[1].x + (screenToWorldPoint[2].x - screenToWorldPoint[1].x) / 2,
                screenToWorldPoint[1].y + (screenToWorldPoint[0].y - screenToWorldPoint[1].y) / 2);

            var yh = center.y + (newCellHeight * yCount / 2 - (newCellHeight / 2));
            _cells = new Cell[yCount][];
            for (int h = 0; h < yCount; h++)
            {
                //var xw = -(newCellWidth * widthCount / 2 - (newCellWidth / 2));
                var xw = center.x - (newCellWidth * xCount / 2 - (newCellWidth / 2));
                _cells[h] = new Cell[xCount];
                for (int w = 0; w < xCount; w++)
                {
                    var cell = Instantiate(cellPrefab, new Vector2(xw, yh), Quaternion.identity, transform);
                    cell.name = string.Format("Cell_{0}_{1}", w, h);
                    cell.transform.localScale = new Vector3(cellScaleWidth, cellScaleHeight, 1);
                    cell.SetCellType(CellType.Normal, sprite);
                    _cells[h][w] = cell;
                    xw += newCellWidth;
                }
                yh -= newCellHeight;
            }
        }

        private bool IsCellFree(int x, int y)
        {
            return _cells[y][x].CellType == CellType.Normal;
        }

        private bool TryGetRandomCoordinateCell(out int x, out int y)
        {
            x = UnityEngine.Random.Range(0, xCount);
            y = UnityEngine.Random.Range(0, yCount);
            return IsCellFree(x, y);
        }

        private bool TryGetNextPositionFreeCell(int x, int y, out int resX, out int resY)
        {
            resY = y;
            resX = x;
            while (resY < yCount)
            {
                while (resX < xCount)
                {
                    if (IsCellFree(resX, resY))
                        return true;
                    resX++;
                }
                resX = 0;
                resY++;
            }
            return false;
        }
    }
}
