using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Formula : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public float Generate(Operator[] supportedOperators, int min, int max)
    {
        var operand1 = Random.Range(min, max);
        var operand2 = Random.Range(min, max);

        var selectedOperator = supportedOperators[Random.Range(0, supportedOperators.Length)];
        (string formulaText, float result) = selectedOperator switch
        {
            Operator.Add => GenerateAddition(operand1, operand2),
            Operator.Deduct => GenerateDeduction(operand1, operand2),
            Operator.Multiply => GenerateMultiplication(operand1, operand2),
            Operator.Divide => GenerateDivision(operand1, operand2),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        text.text = formulaText;

        return result;
    }

    private static (string, float) GenerateAddition(float op1, float op2)
    {
        return ($"{op1} + {op2}", op1 + op2);
    }
    
    private static (string, float) GenerateDeduction(float op1, float op2)
    {
        return ($"{op1} - {op2}", op1 - op2);
    }
    
    private static (string, float) GenerateMultiplication(float op1, float op2)
    {
        return ($"{op1} * {op2}", op1 * op2);
    }
    
    private static (string, float) GenerateDivision(float op1, float op2)
    {
        return ($"{op1} / {op2}", op1 / op2);
    }
}