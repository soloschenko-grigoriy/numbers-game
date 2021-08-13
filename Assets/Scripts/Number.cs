using System;
using TMPro;
using UnityEngine;

public class Number : MonoBehaviour
{
    public static event EventHandler<float> RaiseClickEvent;
    
    private TextMeshProUGUI text;
    private float value;
    
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetValue(float value)
    {
        this.value = value;
        text.text = value.ToString();
    }

    public void OnClick()
    {
        RaiseClickEvent(this, value);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
