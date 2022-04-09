using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MatchThree
{
    public class Board : MonoBehaviour
    {
        [Header("Board Settings")] [SerializeField]
        private BoardData boardData;

        [Header("Tile")] [SerializeField] private GameObject tilePrefab;

        [Header("Game Pieces")] [SerializeField]
        private float swapTime = 0.3f;

        
        [SerializeField] private GameObject[] gamePieces;


        private Tile[,] _allTiles;
        private GamePiece[,] _allGamePieces;

        private Tile _clickedTile;
        private Tile _targetTile;


        void Start()
        {
            _allTiles = new Tile[boardData.width, boardData.height];
            _allGamePieces = new GamePiece[boardData.width, boardData.height];
            SetupTiles();
            FillRandomGamePieces();
        }

        private void SetupTiles()
        {
            var tiles = new GameObject("Tiles")
            {
                transform = { parent = transform }
            };

            for (int i = 0; i < boardData.width; i++)
            {
                for (int j = 0; j < boardData.height; j++)
                {
                    var tileGO = Instantiate(tilePrefab, new Vector3(i, j, 0), Quaternion.identity);

                    tileGO.name = $"Tile ({i},{j})";
                    _allTiles[i, j] = tileGO.GetComponent<Tile>();
                    _allTiles[i, j].Init(i, j, this);
                    tileGO.transform.parent = tiles.transform;
                }
            }
        }

        private GameObject GetRandomGamePiece()
        {
            int randomIdx = Random.Range(0, gamePieces.Length);
            return gamePieces[randomIdx];
        }

        public void PlaceGamePiece(GamePiece piece, int x, int y)
        {
            piece.transform.position = new Vector3(x, y, 0);
            piece.transform.rotation = Quaternion.identity;
            
            if (IsWithinBounds(x, y)) _allGamePieces[x, y] = piece;

            piece.SetCoordinates(x, y);
        }

        private bool IsWithinBounds(int x, int y)
        {
            return (x >= 0 && x < boardData.width && y >= 0 && y < boardData.height);
        }


        private void FillRandomGamePieces()
        {
            var gamePieceHolder = new GameObject("Game Pieces")
            {
                transform = { parent = transform }
            };

            for (int i = 0; i < boardData.width; i++)
            {
                for (int j = 0; j < boardData.height; j++)
                {
                    GameObject gamePieceGO = Instantiate(GetRandomGamePiece(), Vector3.zero, Quaternion.identity);

                    var gamePieceComponent = gamePieceGO.GetComponent<GamePiece>();
                    gamePieceComponent.InitBoard(this);
                    PlaceGamePiece(gamePieceComponent, i, j);
                    gamePieceGO.transform.parent = gamePieceHolder.transform;
                }
            }
        }

        public void ClickTile(Tile tile)
        {
            if (_clickedTile == null) _clickedTile = tile;
        }

        public void DragTile(Tile tile)
        {
            if (_clickedTile != null && IsNextTo(_clickedTile, tile)) _targetTile = tile;
        }

        private const int MAX_SWIPE_PER = 1;
        private bool IsNextTo(Tile start, Tile neighbour)
        {
            if (Mathf.Abs(start._xIndex - neighbour._xIndex) == MAX_SWIPE_PER && start._yIndex == neighbour._yIndex)
            { // If x is neighbour, and y is same.. () => when we horizontally move.
                return true;
            }

            if (Mathf.Abs(start._yIndex - neighbour._yIndex) == MAX_SWIPE_PER && start._xIndex == neighbour._xIndex)
            {// If y is neighbour, and x is same.. () => when we vertically move.
                return true;
            }
            return false;
        }

        public void ReleaseTile()
        {
            if (_clickedTile != null && _targetTile != null)
            {
                SwitchTile(_clickedTile, _targetTile);
            }
            
            _clickedTile = null;
            _targetTile = null;
        }

        private void SwitchTile(Tile clickedTile, Tile targetTile)
        {
            // Switch Game pieces here..
            var clickedPiece = _allGamePieces[clickedTile._xIndex, clickedTile._yIndex];
            var targetPiece = _allGamePieces[targetTile._xIndex, targetTile._yIndex];
            
            clickedPiece.Move(targetTile._xIndex, targetTile._yIndex, swapTime);
            targetPiece.Move(clickedTile._xIndex, clickedTile._yIndex,swapTime);
        }
    }
}