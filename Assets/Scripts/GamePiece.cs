using System.Collections;
using System.Collections.Generic;
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
    }
}
