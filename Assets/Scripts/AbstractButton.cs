using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractButton : MonoBehaviour
{
    protected Button button = default;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    protected virtual void OnDestroy() => button.onClick.RemoveListener(OnButtonClick);
}
