using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite IconImage;
    public string IconName;
    public UnityEvent OnClick;

    public void Start()
    {
        transform.Find("Image").GetComponent<Image>().sprite = IconImage;
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = IconName;
    }

    public void AddListener(UnityAction action)
    {
        OnClick.AddListener(action);
    }
}