using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausing : MonoBehaviour
{
    [SerializeField] private Canvas _canvas = null;
    [SerializeField] private Button _cButton = null;

    void Start()
    {
        //disables the Pausing UI when the script gets executed
        _canvas.enabled = false;
        Button Cancel = _cButton.GetComponent<Button>();
        Cancel.onClick.AddListener(Paused);
    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
            Paused();
    }

    private void Paused()
    {
        //checks if the UI is enabled if so the time/game pauses
        switch (_canvas.enabled)
        {
            case false:
                _canvas.enabled = true;
                Time.timeScale = 0; 
                break;
            default:
                _canvas.enabled = false;
                Time.timeScale = 1;
                break;
        }
    }
}
