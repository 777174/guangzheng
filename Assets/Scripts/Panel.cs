using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Panel : MonoBehaviour
{
    public RectTransform RectTransform;
    private bool isOpen;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!isOpen )
            {
                RectTransform.DOMoveX(900, 1f);
                isOpen = true;
            }
            else
            {
                RectTransform.DOMoveX(1250, 1f);
                isOpen = false;
            }
            
        }
    }

}
