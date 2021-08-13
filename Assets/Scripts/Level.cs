using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private Operator[] supportedOperators = default;
    
        [SerializeField][Range(4, 16)] 
        private int numberOfNumbers = 12;

        [SerializeField] 
        private Gameplay gameplay;
        
        [SerializeField] 
        private Formula formula;

        [SerializeField] 
        private int min;
        
        [SerializeField] 
        private int max;
        
        public void Start()
        {
            formula.Generate(supportedOperators, min, max);
            gameplay.Init(numberOfNumbers, 0);
        }
    }
}