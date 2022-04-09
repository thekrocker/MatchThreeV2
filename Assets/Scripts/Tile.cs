using System;
using UnityEngine;

namespace MatchThree
{
    public class Tile : MonoBehaviour
    {
        public int _xIndex;
        public int _yIndex;
        private Board _board;
        public void Init(int x, int y, Board board)
        {
            _xIndex = x;
            _yIndex = y;
            _board = board;
        }


        private void OnMouseDown()
        {
            _board.ClickTile(this);
        }

        private void OnMouseEnter()
        {
            _board.DragTile(this);
        }

        private void OnMouseUp()
        {
            _board.ReleaseTile();
        }
    }
}
