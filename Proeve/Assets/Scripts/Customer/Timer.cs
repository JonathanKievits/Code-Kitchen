using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool NextActivation(float sec)
    {
        StartCoroutine(WaitTime(sec));
        return true;
    }

    private IEnumerator WaitTime(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
