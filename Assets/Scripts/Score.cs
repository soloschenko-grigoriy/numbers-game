using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI text;
    public int Value { get; private set; }

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetInitScore(int v)
    {
        Value = v;
        SetText();
    }

    public void IncreaseScore(ScoreRate rate)
    {
        switch (rate)
        {
            case ScoreRate.Min:
                ++Value;
                break;
            case ScoreRate.Med:
                Value += 3;
                break;
            case ScoreRate.Max:
                Value += 5;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rate), rate, null);
        }

        SetText();
    }

    public void DecreaseScore()
    {
        Value = Mathf.Max(0, Value - 2);
        SetText();
    }


    private void SetText()
    {
        text.text = Value.ToString();
    }
}