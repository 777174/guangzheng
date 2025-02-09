using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yoyo : MonoBehaviour
{
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.DOFade(1,1.25f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
