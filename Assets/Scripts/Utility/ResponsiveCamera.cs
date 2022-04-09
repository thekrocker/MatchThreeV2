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
            _cam.transform.position = new Vector3((float)(boardData.width - 1) / 2, (float) (boardData.height - 1) / 2, -10f);
            var aspectRatio = (float) Screen.width / (float) Screen.height;

            var verticalSize = boardData.height / 2f + (float)boardData.boardMargin;
            var horizontalSize = (boardData.width / 2f + (float)boardData.boardMargin) / aspectRatio;
            _cam.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
        }
    }
}