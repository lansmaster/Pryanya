using UnityEngine;

[RequireComponent (typeof(DialogueMethods))]
public class MethodTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        DialogueMethods dialogueMethods = GetComponent<DialogueMethods>();

        var method = dialogueMethods.GetType().GetMethod(value);

        method.Invoke(dialogueMethods, parameters: null);
    }
}