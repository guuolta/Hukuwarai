using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class UIBase : GameObjectBase
{
    [Header("押せないときの透明度")]
    [Range(0f, 1f)]
    [SerializeField]
    private float _disInteractiveColor = 0f;
    /// <summary>
    /// アニメーションの時間
    /// </summary>
    [Header("アニメーションの時間")]
    [Range(0f, 10f)]
    [SerializeField]
    protected float AnimationTime = 0.1f;

    private RectTransform _rectTransform;
    public RectTransform RectTransform
    {
        get
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();

            return _rectTransform;
        }
    }

    private CanvasGroup _canvasGroup;
    public CanvasGroup CanvasGroup
    {
        get
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }

            return _canvasGroup;
        }
    }

    /// <summary>
    /// UIを押せるようにするか設定
    /// </summary>
    /// <param name="isInteractive">押せるか</param>
    public void ChangeInteractive(bool isInteractive)
    {
        CanvasGroup.interactable = isInteractive;
        CanvasGroup.blocksRaycasts = isInteractive;
        if (isInteractive)
        {
            CanvasGroup.alpha = 1f;
        }
        else
        {
            CanvasGroup.alpha = _disInteractiveColor;
        }
    }
}
