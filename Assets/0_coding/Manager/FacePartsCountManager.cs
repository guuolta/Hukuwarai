using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FacePartsCountManager : SingletonObjectBase<FacePartsCountManager>
{
    [SerializeField]
    private List<FacePart> _facePartList;

    private BoolReactiveProperty _isPutAll = new BoolReactiveProperty(false);
    public IReadOnlyReactiveProperty<bool> IsPutAll => _isPutAll;

    private int _partCount;
    private ReactiveProperty<int> _putCount = new ReactiveProperty<int>(0);

    protected override void Awake()
    {
        base.Awake();
        _partCount = _facePartList.Count;
    }

    protected override void Start()
    {
        base.Start();
        SetEventCheckCount();
    }

    private void SetEventCheckCount()
    {
        _putCount
            .TakeUntilDestroy(this)
            .DistinctUntilChanged()
            .Where(count => count >= _partCount)
            .Subscribe(_ =>
            {
                _isPutAll.SetValueAndForceNotify(true);
            });
    }

    public void AddPutCount()
    {
        _putCount.Value++;
    }
}