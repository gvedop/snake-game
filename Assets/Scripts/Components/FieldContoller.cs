using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Assets.Scripts.Components
{
    public class FieldContoller : MonoBehaviour
    {
        private GameObject[][] _cells;

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

        private void Start()
        {
            GenerateField();
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
            _cells = new GameObject[yCount][];
            for (int h = 0; h < yCount; h++)
            {
                //var xw = -(newCellWidth * widthCount / 2 - (newCellWidth / 2));
                var xw = center.x - (newCellWidth * xCount / 2 - (newCellWidth / 2));
                _cells[h] = new GameObject[xCount];
                for (int w = 0; w < xCount; w++)
                {
                    var go = new GameObject(string.Format("Cell_{0}_{1}", w, h));
                    var sr = go.AddComponent<SpriteRenderer>();
                    sr.sprite = sprite;
                    go.transform.parent = transform;
                    go.transform.position = new Vector2(xw, yh);
                    go.transform.rotation = Quaternion.identity;
                    go.transform.localScale = new Vector3(cellScaleWidth, cellScaleHeight, 1);
                    
                    _cells[h][w] = go;
                    xw += newCellWidth;
                }
                yh -= newCellHeight;
            }
        }
    }
}
