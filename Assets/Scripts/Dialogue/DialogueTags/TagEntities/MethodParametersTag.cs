using UnityEngine;

public class MethodParametersTag : MonoBehaviour, ITag
{
    public static string currentParameters;

    public void Calling(string value)
    {
        currentParameters = value;
    }
}
