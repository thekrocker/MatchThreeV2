using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MatchThree
{
    public class Board : MonoBehaviour
    {
        [Header("Board Settings")]
        [SerializeField] private BoardData boardData;

        [Header("Tile")]
        [SerializeField] private GameObject tilePrefab;
        [Header("Game Pieces")] 
        [SerializeField] private GameObject[] gamePieces;

        
        private Tile[,] _allTiles;
        private GamePiece[,] _allGamePieces;
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
                    _allTiles[i, j].Init(i,j, this);
                    tileGO.transform.parent = tiles.transform;
                }
            }
        }

        private GameObject GetRandomGamePiece()
        {
            int randomIdx = Random.Range(0, gamePieces.Length);
            return gamePieces[randomIdx];
        }

        private void PlaceGamePiece(GamePiece piece, int x, int y)
        {
            piece.transform.position = new Vector3(x, y, 0);
            piece.transform.rotation = Quaternion.identity;
            piece.SetCoordinates(x,y);
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
                    PlaceGamePiece(gamePieceGO.GetComponent<GamePiece>(), i,j);
                    gamePieceGO.transform.parent = gamePieceHolder.transform;
                }
            }
        }
        
    }
}
