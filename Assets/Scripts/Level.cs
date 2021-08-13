using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Operator[] supportedOperators = default;

    [SerializeField] [Range(4, 16)] private int numberOfNumbers = 12;

    [SerializeField] private NumbersContainer numbersContainer;

    [SerializeField] private Formula formula;
    [SerializeField] private Clock clock;
    [SerializeField] private Score score;

    [SerializeField] private int min;

    [SerializeField] private int max;
    [SerializeField] private int clockMax = 99;
    [SerializeField] private int clockFirstThreshold = 75;
    [SerializeField] private int clockSecondThreshold = 25;

    private ScoreRate scoreRate;
    private float validValue;
    private Stats stats;

    private void Start()
    {
        stats = SaveLoadLocalFile.Load();
        
        StartNewRound();
        Number.RaiseClickEvent += OnValueSelected;
        Clock.RaiseReachedZero += OnClockEnds;
        Clock.RaiseReachedFirstThreshold += OnReachedFirstThreshold;
        Clock.RaiseReachedSecondThreshold += OnReachedSecondThreshold;
        score.SetInitScore(stats.score); 
    }

    private void StartNewRound()
    {
        scoreRate = ScoreRate.Max;
        validValue = formula.Generate(supportedOperators, min, max);
        numbersContainer.Init(numberOfNumbers, validValue);
        clock.RestartTimer(clockMax, clockFirstThreshold, clockSecondThreshold);
    }

    private void OnValueSelected(float value)
    {
        if (value != validValue)
        {
            return;
        }

        score.IncreaseScore(scoreRate);
        UpdateAndSaveStats();
        StartNewRound();
    }
    
    private void OnReachedSecondThreshold()
    {
        scoreRate = ScoreRate.Min;
    }

    private void OnReachedFirstThreshold()
    {
        scoreRate = ScoreRate.Med;
    }
    
    private void OnClockEnds()
    {
        score.DecreaseScore();
        UpdateAndSaveStats();
        StartNewRound();
    }

    private void UpdateAndSaveStats()
    {
        stats.score = score.Value;
        SaveLoadLocalFile.Save(stats);
    }
    
    private void OnDisable()
    {
        Number.RaiseClickEvent -= OnValueSelected;
        Clock.RaiseReachedFirstThreshold -= OnReachedFirstThreshold;
        Clock.RaiseReachedSecondThreshold -= OnReachedSecondThreshold;
    }
}