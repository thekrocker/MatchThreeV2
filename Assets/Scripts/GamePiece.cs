using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MatchThree
{
    public class GamePiece : MonoBehaviour
    {
        public int _xIndex;
        public int _yIndex;


        public void SetCoordinates(int x, int y)
        {
            _xIndex = x;
            _yIndex = y;
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(((int)transform.position.x + 1), (int)transform.position.y);

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(((int)transform.position.x - 1), (int)transform.position.y);
            }

            
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
