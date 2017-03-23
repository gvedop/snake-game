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
        private int xStartPostion = 8;
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

        public void ToStart()
        {
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    _cells[y][x].SetCellType(CellType.Normal, sprite);
                } 
            }
        }

        public CellType GetCellType(Coordinate coordinate)
        {
            if (coordinate.X < 0 ||
                coordinate.X >= xCount ||
                coordinate.Y < 0 ||
                coordinate.Y >= yCount)
                return CellType.Border;
            return _cells[coordinate.Y][coordinate.X].CellType;
        }

        public CellType GetCellType(int x, int y)
        {
            if (x < 0 ||
                x >= xCount ||
                y < 0 ||
                y >= yCount)
                return CellType.Border;
            return _cells[y][x].CellType;
        }

        public void SetCellToNormal(Coordinate coordinate)
        {
            _cells[coordinate.Y][coordinate.X].SetCellType(CellType.Normal, sprite);
        }

        public void SetCell(Coordinate coordinate, CellType cellType, Sprite sprite)
        {
            _cells[coordinate.Y][coordinate.X].SetCellType(cellType, sprite);
        }

        public Coordinate GetSnakeStartCoordinate()
        {
            return new Coordinate(xStartPostion, yStartPostion);
        }

        public Coordinate GetWallCoordinate()
        {
            var x = 0;
            var y = 0;
            if (TryGetWallRandomCoordinateCell(out x, out y) || TryGetWallRandomCoordinateCell(out x, out y))
            {
                return new Coordinate(x, y);
            }
            else
            {
                var xx = 0;
                var yy = 0;
                if (TryGetWallNextPositionFreeCell(x, y, out xx, out yy))
                    return new Coordinate(xx, yy);
                else if (TryGetWallNextPositionFreeCell(0, 0, out xx, out yy))
                    return new Coordinate(xx, yy);
                else
                    return new Coordinate(0, 0);
            }
        }

        public Coordinate GetMouseCoordinate()
        {
            var x = 0;
            var y = 0;
            if (TryGetMouseRandomCoordinateCell(out x, out y) || TryGetMouseRandomCoordinateCell(out x, out y))
            {
                return new Coordinate(x, y);
            }
            else
            {
                var xx = 0;
                var yy = 0;
                if (TryGetMouseNextPositionFreeCell(x, y, out xx, out yy))
                    return new Coordinate(xx, yy);
                else if (TryGetMouseNextPositionFreeCell(0, 0, out xx, out yy))
                    return new Coordinate(xx, yy);
                else
                    return new Coordinate(0, 0);
            }
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

        private bool IsWallCellFree(int x, int y)
        {
            if (_cells[y][x].CellType != CellType.Normal)
                return false;
            if (GetCellType(x, y + 1) == CellType.Snake)
                return false;
            var res = 0;
            if (IsRightCellFree(x, y))
                res++;
            if (IsRightCellFree(x + 1, y))
                res++;
            if (IsRightCellFree(x + 2, y))
                res++;
            if (IsLeftCellFree(x, y))
                res++;
            if (IsLeftCellFree(x - 1, y))
                res++;
            if (IsLeftCellFree(x - 2, y))
                res++;
            if (IsUpCellFree(x, y))
                res++;
            if (IsUpCellFree(x, y + 1))
                res++;
            if (IsDownCellFree(x, y))
                res++;
            if (IsDownCellFree(x, y - 1))
                res++;
            return res >= 6;
        }

        private bool TryGetWallRandomCoordinateCell(out int x, out int y)
        {
            x = UnityEngine.Random.Range(0, xCount);
            y = UnityEngine.Random.Range(0, yCount);
            return IsWallCellFree(x, y);
        }

        private bool TryGetWallNextPositionFreeCell(int x, int y, out int resX, out int resY)
        {
            resY = y;
            resX = x;
            while (resY < yCount)
            {
                while (resX < xCount)
                {
                    if (IsWallCellFree(resX, resY))
                        return true;
                    resX++;
                }
                resX = 0;
                resY++;
            }
            return false;
        }

        private bool IsMouseCellFree(int x, int y)
        {
            if (_cells[y][x].CellType != CellType.Normal)
                return false;
            var res = 0;
            if (IsRightCellFree(x, y))
                res++;
            if (IsLeftCellFree(x, y))
                res++;
            if (IsUpCellFree(x, y))
                res++;
            if (IsDownCellFree(x, y))
                res++;
            return res >= 2;
        }

        private bool TryGetMouseRandomCoordinateCell(out int x, out int y)
        {
            x = UnityEngine.Random.Range(0, xCount);
            y = UnityEngine.Random.Range(0, yCount);
            return IsMouseCellFree(x, y);
        }

        private bool TryGetMouseNextPositionFreeCell(int x, int y, out int resX, out int resY)
        {
            resY = y;
            resX = x;
            while (resY < yCount)
            {
                while (resX < xCount)
                {
                    if (IsMouseCellFree(resX, resY))
                        return true;
                    resX++;
                }
                resX = 0;
                resY++;
            }
            return false;
        }

        private bool IsRightCellFree(int x, int y)
        {
            x = x + 1;
            return x < xCount && _cells[y][x].CellType == CellType.Normal;
        }

        private bool IsLeftCellFree(int x, int y)
        {
            x = x - 1;
            return x >= 0 && _cells[y][x].CellType == CellType.Normal;
        }

        private bool IsUpCellFree(int x, int y)
        {
            y = y + 1;
            return y < yCount && _cells[y][x].CellType == CellType.Normal;
        }

        private bool IsDownCellFree(int x, int y)
        {
            y = y - 1;
            return y >= 0 && _cells[y][x].CellType == CellType.Normal;
        }

        private bool IsCellFree(int x, int y)
        {
            return _cells[y][x].CellType == CellType.Normal;
        }
    }
}
