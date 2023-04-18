using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour
{
    private Vector3 initialScale;

    public float scaleFactor = 2f;

    public float animationDuration = 1f;

    private void Awake()
    {
        initialScale = transform.localScale;

        transform.DOScale(initialScale * scaleFactor, animationDuration)
            .OnComplete(() => transform.localScale = initialScale * scaleFactor);
    }


}
