using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumbersContainer : MonoBehaviour
{
    [SerializeField] 
    private Number numberPrefab;

    private Number[] numbers = Array.Empty<Number>();

    public void Init(int numberOfNumbers, float validValue)
    {
        Array.ForEach(numbers, number => number.Kill());
        numbers = new Number[numberOfNumbers];
        
        var validIndex = Random.Range(0, numberOfNumbers);
        for (var i = 0; i < numberOfNumbers; i++)
        {
            var number = Instantiate(numberPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            number.transform.SetParent(transform);
            number.SetValue(i == validIndex ? validValue : Random.Range(0, 99));
            numbers[i] = number;
        }
    }
}
