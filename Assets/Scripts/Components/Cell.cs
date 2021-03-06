﻿using UnityEngine;
using SnakeGame.Core;

namespace SnakeGame.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Cell: MonoBehaviour
    {
        private SpriteRenderer _spriteRender;
        private CellType _cellType = CellType.Normal;

        public CellType CellType
        {
            get { return _cellType; }
        }

        public void SetCellType(CellType cellType, Sprite sprite)
        {
            _cellType = cellType;
            _spriteRender.sprite = sprite;
        }
        
        private void Awake()
        {
            _spriteRender = GetComponent<SpriteRenderer>();
        }
    }
}
