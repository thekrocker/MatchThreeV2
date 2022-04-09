using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MatchThree
{
    [CreateAssetMenu(fileName = "BoardData", menuName = "Board/BoardData", order = 0)]
    public class BoardData : ScriptableObject
    {
        [Title("Board Size")]
        [SerializeField] private int width;
        [SerializeField] private int height;
        
        public int Width
        {
            get => width;
            set => width = Mathf.Clamp(value, 1, 50);
        }

        public int Height
        {
            get => height;
            set => height = Mathf.Clamp(value, 1, 50);
        }

        private void OnValidate()
        {
            Width = width;
            Height = height;
        }

        [Title("Screen Margin")]
        public int boardMargin;
        

    }
}