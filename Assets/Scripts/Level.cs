
using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Operator[] supportedOperators = default;

    [SerializeField] [Range(4, 16)] private int numberOfNumbers = 12;

    [SerializeField] private NumbersContainer numbersContainer;

    [SerializeField] private Formula formula;

    [SerializeField] private int min;

    [SerializeField] private int max;

    private float validValue;
    
    private void Start()
    {
        StartNewRound();
        Number.RaiseClickEvent += OnValueSelected;
    }

    private void StartNewRound()
    {
        validValue = formula.Generate(supportedOperators, min, max);
        numbersContainer.Init(numberOfNumbers, validValue);
    }

    private void OnValueSelected(object sender, float value)
    {
        if (value == validValue)
        {
            StartNewRound();
        }
    }
    
    private void OnDisable()
    {
        Number.RaiseClickEvent -= OnValueSelected;
    }
}