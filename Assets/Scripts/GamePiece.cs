using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MatchThree
{
    public class GamePiece : MonoBehaviour
    {
        public int xIndex;
        public int yIndex;

        private Board _board;
        
        public void InitBoard(Board board)
        {
            _board = board;
        }

        public void SetCoordinates(int x, int y)
        {
            xIndex = x;
            yIndex = y;
        }
        

        private bool _isMoving;
        public void Move(int destinationX, int destinationY, float swapTime)
        {
            if (_isMoving) return;
            _isMoving = true;
            transform.DOMove(new Vector3(destinationX, destinationY, 0), swapTime).SetEase(Ease.Linear).OnComplete(action: () =>
            {
                _isMoving = false;
                _board.PlaceGamePiece(this, destinationX, destinationY);
            });
            
        }
    }
}
