using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FacePartView : UIBase
{
    public async UniTask ShowAsync(CancellationToken ct)
    {
        await CanvasGroup.DOFade(1, AnimationTime)
            .SetEase(Ease.InSine)
            .ToUniTask(cancellationToken: ct);

        ChangeInteractive(true);
    }

    public async UniTask HideAsync(CancellationToken ct)
    {
        await CanvasGroup.DOFade(0, AnimationTime)
            .SetEase(Ease.OutSine)
            .ToUniTask(cancellationToken: ct);
        
        ChangeInteractive(false);
    }
}
