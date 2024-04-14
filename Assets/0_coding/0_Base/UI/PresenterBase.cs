using UnityEngine;

public class PresenterBase<TView> : UIBase
    where TView : ViewBase
{
    private TView _view;
    protected TView View
    {
        get
        {
            if (_view == null)
                _view = GetComponent<TView>();

            return _view;
        }
    }
}
