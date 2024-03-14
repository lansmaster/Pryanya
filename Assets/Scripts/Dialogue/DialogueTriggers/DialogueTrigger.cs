using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;

    private DialogueController _dialogueController;

    private void Start()
    {
        _dialogueController = GetComponent<DialogueController>();

        //_dialogueController.EnterDialogueMode(_inkJSON);
    }
}
