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


        public void SetCoordinates(int x, int y)
        {
            xIndex = x;
            yIndex = y;
        }
        

        private bool _isMoving;
        private void Move(int destinationX, int destinationY)
        {
            if (_isMoving) return;
            _isMoving = true;
            transform.DOMove(new Vector3(destinationX, destinationY, 0), 0.5f).SetEase(Ease.Linear).OnComplete(() => _isMoving = false);
            
        }
    }
}
