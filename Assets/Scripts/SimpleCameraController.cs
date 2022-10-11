using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    private bool isPlaying = false;
    public void UpdatePos(float delta)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            transform.DOMoveZ(transform.position.z + delta, 1.0f).OnComplete(() => { isPlaying = false; });
        }
    }
}
