using Unity.VisualScripting;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    [Serialize] public GameObject TargetObject;

    public void ChangeObjectVisibility(bool isVisible)
    {
        TargetObject.SetActive(isVisible);
    }

    public void OnExit()
    {
        Debug.Log("Выход");
        Application.Quit(0);
    }
}