using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCommand : MonoBehaviour
{
    public CommandBlock CommandBlock;
    public AnimationScript _animation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //_animation.IsFinished(true, 2);
            CommandBlock.Apply();
        }
    }
}
