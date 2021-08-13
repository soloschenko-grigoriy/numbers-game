using TMPro;
using UnityEngine;

public class Number : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetValue(float value)
    {
        text.text = value.ToString();
    }
}
