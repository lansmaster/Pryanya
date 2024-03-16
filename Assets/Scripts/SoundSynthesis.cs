using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SoundSynthesis : MonoBehaviour
{
    private static HttpClient httpClient = new HttpClient();
    private static AudioSource _audioSource;

    private const string _iamToken = "t1.9euelZrLnseWk82WlJCZnYuUlcmcm-3rnpWak4uUxpuPl53Lx4-ejpiMmpPl8_drVipQ-e9UEUkP_d3z9ysFKFD571QRSQ_9zef1656VmpPMxpaTlomOys6KyYqLm5ue7_zF656VmpPMxpaTlomOys6KyYqLm5ue.v16FxA6doSlsfZS0N28e4pgwHBAVTLOYuWkUL4AIqFyR2VfzcXPYJk-bRdUsJ1EZx6DD6_uJMRaqV5vVbWumAg";
    private const string _folderId = "b1g89ongs1c7kp1112oc";
    private static string _filePath = Path.Combine(UnityEngine.Application.streamingAssetsPath, "speech.mp3");

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        DialogueWindow.OnDispayLine += Synthesis;

        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _iamToken);
    }

    private static void Synthesis(string text)
    {
        _ = Tts(text);
    }

    private static async Task Tts(string text)
    {
        var values = new Dictionary<string, string>
        {
            { "text", $"{text}" },
            { "lang", "ru-RU" },
            { "voice", "zahar" },
            { "folderId", _folderId },
            { "format", "mp3" },
            { "sampleRateHertz", "48000" }
        };
        var content = new FormUrlEncodedContent(values);
        var response = await httpClient.PostAsync("https://tts.api.cloud.yandex.net/speech/v1/tts:synthesize", content);

        var responseBytes = await response.Content.ReadAsByteArrayAsync();
        
        File.WriteAllBytes(_filePath, responseBytes);

        var audioClip = await LoadClip(_filePath);

        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private static async Task<AudioClip> LoadClip(string path)
    {
        AudioClip clip = null;
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            uwr.SendWebRequest();

            try
            {
                while (!uwr.isDone) await Task.Delay(5);

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.Log($"{uwr.error}");
                }
                else
                {
                    clip = DownloadHandlerAudioClip.GetContent(uwr);
                }
            }
            catch (Exception err)
            {
                Debug.Log($"{err.Message}, {err.StackTrace}");
            }
        }

        return clip;
    }
}
