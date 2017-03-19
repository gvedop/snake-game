using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Assets.Scripts.Components
{
    public class FieldContoller : MonoBehaviour
    {
        [SerializeField]
        private GameObject cell;
        [SerializeField]
        private RectTransform panel;
        [SerializeField]
        private int xCount = 10;
        [SerializeField]
        private int yCount = 10;

        private GameObject[][] _cells;
        private Vector2[][] _coordinates;

        public Vector2 GetCoordinate(int x, int y)
        {
            return _coordinates[y][x];
        }

        public GameObject GetCell(int x, int y)
        {
            return _cells[y][x];
        }

        private void Start()
        {
            GenerateField();
        }

        private void GenerateField()
        {
            var spriteRenderer = cell.GetComponent<SpriteRenderer>();

            var cellSize = spriteRenderer.bounds.size;

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

            var WorldCorners = new Vector3[4];
            panel.GetWorldCorners(WorldCorners);

            var ScreenToWorldPoint = new Vector3[4];
            for (int i = 0; i < 4; i++)
                ScreenToWorldPoint[i] = Camera.main.ScreenToWorldPoint(WorldCorners[i]);
            var center = new Vector2(
                ScreenToWorldPoint[1].x + (ScreenToWorldPoint[2].x - ScreenToWorldPoint[1].x) / 2,
                ScreenToWorldPoint[1].y + (ScreenToWorldPoint[0].y - ScreenToWorldPoint[1].y) / 2);

            var yh = center.y + (newCellHeight * yCount / 2 - (newCellHeight / 2));
            _cells = new GameObject[yCount][];
            _coordinates = new Vector2[yCount][];
            for (int h = 0; h < yCount; h++)
            {
                //var xw = -(newCellWidth * widthCount / 2 - (newCellWidth / 2));
                var xw = center.x - (newCellWidth * xCount / 2 - (newCellWidth / 2));

                for (int w = 0; w < xCount; w++)
                {
                    _cells[h] = new GameObject[xCount];
                    _coordinates[h] = new Vector2[xCount];
                    var coordinate = new Vector2(xw, yh);
                    var go = Instantiate(cell, coordinate, Quaternion.identity, transform);
                    

                    go.transform.localScale = new Vector3(cellScaleWidth, cellScaleHeight, 1);
                    
                    go.name = string.Format("Cell_{0}_{1}", w, h);
                    _cells[h][w] = go;
                    _coordinates[h][w] = coordinate;
                    xw += newCellWidth;

                }
                yh -= newCellHeight;
            }
        }
    }
}
