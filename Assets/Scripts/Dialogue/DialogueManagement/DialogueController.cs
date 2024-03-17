using Ink.Runtime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DialogueWindow)), RequireComponent(typeof(DialogueTag))]
public class DialogueController : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private DialogueWindow _dialogueWindow;
    private DialogueTag _dialogueTag;

    public Story CurrentStory { get; private set; }
    private Coroutine _displayLineCoroutine;

    private void Awake()
    {
        _dialogueTag = GetComponent<DialogueTag>();
        _dialogueWindow = GetComponent<DialogueWindow>();

        _dialogueTag.Init();
        _dialogueWindow.Init();
    }

    private void Start()
    {
        _dialogueWindow.SetActive(false);

        nextButton.onClick.AddListener(ContinueStory);
    }

    private void Update()
    {
        if (_dialogueWindow.IsStatusAnswer == true || _dialogueWindow.IsPlaying == false || _dialogueWindow.CanContinueToNextLine == false)
        {
            nextButton.gameObject.SetActive(false);
            return;
        }

        nextButton.gameObject.SetActive(true);
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        CurrentStory = new Story(inkJSON.text);

        _dialogueWindow.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialugeMode()
    {
        yield return new WaitForSeconds(_dialogueWindow.CoolDownNewLettew);

        _dialogueWindow.SetActive(false);
        _dialogueWindow.ClearText();
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue == false)
        {
            StartCoroutine(ExitDialugeMode());
            return;
        }

        if (_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }

        _displayLineCoroutine = StartCoroutine(_dialogueWindow.DisplayLine(CurrentStory));

        try
        {
            _dialogueTag.HandleTags(CurrentStory.currentTags);
        }
        catch (ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void MakeChoice(int choiceIndex) // Повесил на кнопки
    {
        _dialogueWindow.MakeChoice();

        CurrentStory.ChooseChoiceIndex(choiceIndex);

        ContinueStory();
    }
}
