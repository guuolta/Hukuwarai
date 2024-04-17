using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using TMPro;
using UnityEngine;

public class StartUIView : ViewBase
{
    [SerializeField]
    private TMP_Text _startText;

    Sequence _sequence;

    protected override void Awake()
    {
        SetLoopAnimation(Ct);
    }

    private void SetLoopAnimation(CancellationToken ct)
    {
        _sequence = DOTween.Sequence()
            .SetAutoKill(false)
            .SetLink(this.gameObject);

        _sequence
            .Append(_startText
                .DOFade(0, AnimationTime / 2)
                .SetEase(Ease.InSine))
            .Append(_startText
                .DOFade(1, AnimationTime / 2)
                .SetEase(Ease.OutSine))
            .SetLoops(-1, LoopType.Restart)
            .ToUniTask(cancellationToken: ct);
    }

    public async UniTask ShowAsync(CancellationToken ct)
    {
        if (CanvasGroup.alpha == 1)
            return;

        await CanvasGroup
            .DOFade(1, AnimationTime)
            .SetEase(Ease.InSine)
            .ToUniTask(cancellationToken: ct);
        _sequence.Restart();
    }

    public async UniTask HideAsync(CancellationToken ct)
    {
        if(CanvasGroup.alpha == 0)
            return;

        await CanvasGroup
            .DOFade(0, AnimationTime)
            .SetEase(Ease.OutSine)
            .ToUniTask(cancellationToken: ct);
        _sequence.Pause();
    }
}
