using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SoundSynthesis : MonoBehaviour
{
    private static HttpClient httpClient = new HttpClient();
    private static AudioSource _audioSource;

    private const string _iamToken = "123";
    private const string _folderId = "123";

#if UNITY_EDITOR
    private static string _filePath = Path.Combine(Application.streamingAssetsPath, "speech.mp3");
#elif UNITY_ANDROID
    private static string _filePath = Application.persistentDataPath + "/speech.mp3";
#endif

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        DialogueWindow.OnDispayLine += Synthesis;

        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _iamToken);
    }

    private static void Synthesis(string text)
    {
        _ = TextToSpeechRequest(text);
    }

    private static async Task TextToSpeechRequest(string text)
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
        UriBuilder uriBuilder = new UriBuilder(path);
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(uriBuilder.Uri, AudioType.MPEG))
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
