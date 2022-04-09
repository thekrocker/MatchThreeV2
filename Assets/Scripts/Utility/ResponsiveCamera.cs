using System;
using UnityEngine;

namespace MatchThree
{
    public class ResponsiveCamera : MonoBehaviour
    {
        [SerializeField] private BoardData boardData;

        private Camera _cam;

        private void Start()
        {
            _cam = Camera.main;
            
            SetupCamera();
        }

        private void SetupCamera()
        {
            _cam.transform.position = new Vector3((float)(boardData.Width - 1) / 2, (float) (boardData.Height - 1) / 2, -10f);
            var aspectRatio = (float) Screen.width / (float) Screen.height;

            var verticalSize = boardData.Height / 2f + (float)boardData.boardMargin;
            var horizontalSize = (boardData.Width / 2f + (float)boardData.boardMargin) / aspectRatio;
            _cam.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
        }
    }
}