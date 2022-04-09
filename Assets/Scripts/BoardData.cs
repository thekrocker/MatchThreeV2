using UnityEngine;

namespace MatchThree
{
    [CreateAssetMenu(fileName = "BoardData", menuName = "Board/BoardData", order = 0)]
    public class BoardData : ScriptableObject
    {
        public int width;
        public int height;
        public int boardMargin;
    }
}