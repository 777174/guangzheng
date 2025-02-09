using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiemian : MonoBehaviour
{
    public RectTransform RectTransform;
    public CanvasGroup CanvasGroup;
    private int FadeTime = 1;
    // Start is called before the first frame update
    public void PanelFadeIn()
    {
        this.gameObject.SetActive(true);
        CanvasGroup.alpha = 0f;
        RectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        RectTransform.DOAnchorPos(new Vector2(0f, 0f), FadeTime, false).SetEase(Ease.OutElastic);
        CanvasGroup.DOFade(1, FadeTime);

    }

    public void PanelFadeOut()
    {
        CanvasGroup.alpha = 1f;
        RectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        RectTransform.DOAnchorPos(new Vector2(0f, -1000f), FadeTime, false).SetEase(Ease.InOutQuint);
        CanvasGroup.DOFade(1, FadeTime);
    }
}
