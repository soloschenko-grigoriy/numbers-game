using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    private RectTransform container;

    [SerializeField] 
    private Number numberPrefab;
    
    // Start is called before the first frame update
    public void Init(int numberOfNumbers, float validValue)
    {
        var validIndex = Random.Range(0, numberOfNumbers);
        for (var i = 0; i < numberOfNumbers; i++)
        {
            var number = Instantiate(numberPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            number.transform.SetParent(container);
            number.SetValue(i == validIndex ? validValue : Random.Range(0, 9999));
        }
    }

    public void NumberClicked()
    {
        Debug.Log("number clicked");
    }
}
