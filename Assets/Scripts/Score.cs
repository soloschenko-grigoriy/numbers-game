using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Score : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private int value;
        
        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetInitScore(int v)
        {
            value = v;
            SetText();
        }

        public void IncreaseScore(ScoreRate rate)
        {
            switch (rate)
            {
                case ScoreRate.Min: ++value;
                    break;
                case ScoreRate.Med: value += 3;
                    break;
                case ScoreRate.Max:
                    value += 5;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rate), rate, null);
            }
            
            SetText();
        }

        public void DecreaseScore()
        {
            value = Mathf.Max(0, value - 2);
            SetText();
        }
        

        private void SetText()
        {
            text.text = value.ToString();
        }
    }
}

public enum ScoreRate
{
    Min,
    Med,
    Max
}