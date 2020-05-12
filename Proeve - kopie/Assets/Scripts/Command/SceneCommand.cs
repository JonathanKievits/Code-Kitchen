using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCommand : MonoBehaviour
{
    public CommandBlock CommandBlock;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CommandBlock.Apply();
        }
    }
}
