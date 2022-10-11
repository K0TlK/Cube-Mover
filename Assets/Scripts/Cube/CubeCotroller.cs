using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCotroller : MonoBehaviour
{
    private static Color startColor = Color.white;
    private static Color endColor = Color.black;

    public void Init(Vector3 endPos, float speed)
    {
        Material cubeMaterial = GetComponent<Renderer>().material;
        cubeMaterial.color = startColor;
        cubeMaterial.DOColor(endColor, speed);
        transform.DOMove(endPos, speed);
        Destroy(gameObject, speed + 0.1f);
    }
}
