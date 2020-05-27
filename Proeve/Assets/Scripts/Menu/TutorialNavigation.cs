using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNavigation : MonoBehaviour
{
    private int ScreenCount;
    [SerializeField] private List<GameObject> TutorialScreens;
    [SerializeField] private GameObject Buttons;
    void Start()
    {
        
    }

    // Update is called once per frame

    public void NextScreen()
    {
        ScreenCount += 1;
    }
    public void PreviousScreen()
    {
        ScreenCount -= 1;
    }
    public void OnClick()
    {
        switch (ScreenCount)
        {
            case 0:
                TutorialScreens[0].gameObject.SetActive(true);
                TutorialScreens[1].gameObject.SetActive(false);
                TutorialScreens[2].gameObject.SetActive(false);
                break;
            case 1:
                TutorialScreens[0].gameObject.SetActive(false);
                TutorialScreens[1].gameObject.SetActive(true);
                TutorialScreens[2].gameObject.SetActive(false);
                break;
            case 2:
                TutorialScreens[0].gameObject.SetActive(false);
                TutorialScreens[1].gameObject.SetActive(false);
                TutorialScreens[2].gameObject.SetActive(true);
                break;
            case 3:
                ScreenCount = 2;
                break;
            case -1:
                ScreenCount = 0;
                break;
        }
    }
    public void Exit()
    {

    }
}
