using UnityEngine;
using UnityEngine.UI;

public class DialogueMethods : MonoBehaviour
{
    [SerializeField] private Button _linkButton;

    public void ShowBouttonWithLink()
    {
        var url = MethodParametersTag.currentParameters;

        _linkButton.gameObject.SetActive(true);

        _linkButton.onClick.RemoveAllListeners();
        _linkButton.onClick.AddListener(() => Application.OpenURL(url));
    }

    public void HideButton()
    {
        _linkButton.onClick.RemoveAllListeners();

        _linkButton.gameObject.SetActive(false);
    }
}
