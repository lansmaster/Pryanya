using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    //[SerializeField] private TextAsset _inkJSON;

    //private DialogueController _dialogueController;
    //private DialogueWindow _dialogueWindow;
    //private PlayerActions _playerActions;
    //private Animator _animator;

    //private void Start()
    //{
    //    _animator = GetComponent<Animator>();

    //    _playerActions = Player.Instance.Actions;
    //    _dialogueController = FindObjectOfType<DialogueController>();
    //    _dialogueWindow = FindObjectOfType<DialogueWindow>();
    //}

    //public void TriggerAction()
    //{
    //    _playerActions.PlayerApproachedTheCharacter += EnableEmission;

    //    if (Input.GetKeyDown(KeyCode.E) && !_dialogueWindow.IsPlaying)
    //    {
    //        _dialogueController.EnterDialogueMode(_inkJSON);
    //    }
    //}

    //private void EnableEmission(bool enable)
    //{
    //    if (enable)
    //    {
    //        _animator.SetBool("Emission", true);
    //    }
    //    else
    //    {
    //        _playerActions.PlayerApproachedTheCharacter -= EnableEmission;
    //        _animator.SetBool("Emission", false);
    //    }
    //}
}
