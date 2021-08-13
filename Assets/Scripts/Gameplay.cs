using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField][Range(4, 16)] 
    private int numberOfNumbers = 12;

    [SerializeField]
    private RectTransform container;

    [SerializeField] 
    private Number numberPrefab;
    
    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < numberOfNumbers; i++)
        {
            Instantiate(numberPrefab, new Vector3(0, 0, 0), Quaternion.identity)
                .transform.SetParent(container);
        }
    }

    public void NumberClicked()
    {
        Debug.Log("number clicked");
    }
}
