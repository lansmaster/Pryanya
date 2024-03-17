using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpeakerTag)), RequireComponent(typeof(MethodTag)), RequireComponent(typeof(CooldownTag))]
public class Tags : MonoBehaviour
{
    private readonly Dictionary<string, ITag> _map = new ();

    private void Start()
    {
        _map.Add("speaker", GetComponent<SpeakerTag>());
        _map.Add("method", GetComponent<MethodTag>());
        _map.Add("cooldown", GetComponent<CooldownTag>());
        _map.Add("methodParameters", GetComponent<MethodParametersTag>());
    }

    public ITag GetValue(string key)
    {
        return _map.GetValueOrDefault(key);
    }
}
