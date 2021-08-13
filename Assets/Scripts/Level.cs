using DefaultNamespace;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Operator[] supportedOperators = default;

    [SerializeField] [Range(4, 16)] private int numberOfNumbers = 12;

    [SerializeField] private NumbersContainer numbersContainer;

    [SerializeField] private Formula formula;
    [SerializeField] private Clock clock;

    [SerializeField] private int min;

    [SerializeField] private int max;
    [SerializeField] private int clockMax = 99;

    private float validValue;

    private void Start()
    {
        StartNewRound();
        Number.RaiseClickEvent += OnValueSelected;
        Clock.RaiseReachedZero += OnClockEnds;
    }

    private void StartNewRound()
    {
        validValue = formula.Generate(supportedOperators, min, max);
        numbersContainer.Init(numberOfNumbers, validValue);
        clock.RestartTimer(clockMax);
    }

    private void OnValueSelected(float value)
    {
        if (value == validValue)
        {
            StartNewRound();
        }
    }
    
    private void OnClockEnds()
    {
        StartNewRound();
    }
    
    private void OnDisable()
    {
        Number.RaiseClickEvent -= OnValueSelected;
    }
}