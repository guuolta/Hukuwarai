using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HukuwaraiPosChecker : SingletonObjectBase<HukuwaraiPosChecker>
{
    [SerializeField]
    private RectTransform _faceRectTransform;
    private float faceRangeX;
    private float faceRangeY;

    protected override void Init()
    {
        base.Init();
        GetFaceRange(_faceRectTransform, out faceRangeX, out faceRangeY);
    }

    private void GetFaceRange(RectTransform rectTransform, out float rangeX, out float rangeY)
    {
        rangeX = Mathf.Abs(rectTransform.anchoredPosition.x) + rectTransform.sizeDelta.x / 2;
        rangeX *= 0.9f;
        rangeY = Mathf.Abs(rectTransform.anchoredPosition.y) + rectTransform.sizeDelta.y / 2;
        rangeY *= 0.9f;
    }

    public bool CheckPos(RectTransform partRectTransform)
    {
        float partRangeX;
        float partRangeY;
        GetPartRange(partRectTransform, out partRangeX, out partRangeY);

        return partRangeX < faceRangeX && partRangeY < faceRangeY;
    }

    private void GetPartRange(RectTransform rectTransform, out float rangeX, out float rangeY)
    {
        rangeX = Mathf.Abs(rectTransform.anchoredPosition.x) - rectTransform.sizeDelta.x / 2;
        rangeY = Mathf.Abs(rectTransform.anchoredPosition.y) - rectTransform.sizeDelta.y / 2;
    }
}
