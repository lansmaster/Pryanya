using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMethods : MonoBehaviour
{
    [SerializeField] private Button _linkButton;

    [Header("Спрайты персонажа")]
    [SerializeField] private SpriteRenderer _characterSpriteRenderer;
    [SerializeField] private Sprite _1_1, _1_2, _2_1, _2_2, _3_1;

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

    public void SwitchSprite()
    {
        Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite> { 
            { "1_1", _1_1 }, 
            { "1_2", _1_2 }, 
            { "2_1", _2_1 }, 
            { "2_2", _2_2 }, 
            { "3_1", _3_1 } 
        };

        var currentSprite = sprites.GetValueOrDefault(MethodParametersTag.currentParameters);
        _characterSpriteRenderer.sprite = currentSprite;
    }
}
