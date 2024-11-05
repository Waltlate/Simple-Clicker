using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AbstractButton : MonoBehaviour
{
    protected Button button = default;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    protected virtual void OnButtonClick() => Debug.Log("Button click");

    protected virtual void OnDestroy() => button.onClick.RemoveListener(OnButtonClick);
}
