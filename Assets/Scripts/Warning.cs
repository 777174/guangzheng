using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Warning : MonoBehaviour
{
    public CanvasGroup group;
    // Start is called before the first frame update
    public void ShowPanel()
    {
        Debug.Log("777");
        group.DOFade(1, 1f);
        group.DOFade(0, 1f).SetDelay(3f);
    
    }
    
}
