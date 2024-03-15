using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class LocationDetector : MonoBehaviour
{
//    [SerializeField] private TextMeshProUGUI _test;

//    private void Start()
//    {
//#if UNITY_ANDROID
//        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
//        {
//            Permission.RequestUserPermission(Permission.FineLocation);
//        }
//#elif UNITY_IOS
//                  PlayerSettings.iOS.locationUsageDescription = "Details to use location";
//#endif
//        StartCoroutine(StartLocationService());
//    }
//    private IEnumerator StartLocationService()
//    {
//        if (!Input.location.isEnabledByUser)
//        {
//            _test.text = "User has not enabled location";
//            yield break;
//        }
//        Input.location.Start();
//        while (Input.location.status == LocationServiceStatus.Initializing)
//        {
//            yield return new WaitForSeconds(1);
//        }
//        if (Input.location.status == LocationServiceStatus.Failed)
//        {
//            _test.text = "Unable to determine device location";
//            yield break;
//        }
//        _test.text = $"horizontalAccuracy: {Input.location.lastData.horizontalAccuracy}\n" +
//            $"verticalAccuracy: {Input.location.lastData.verticalAccuracy}\n" +
//            $"altitude: {Input.location.lastData.altitude}\n" +
//            $"latitude: {Input.location.lastData.latitude}\n" +
//            $"longitude: {Input.location.lastData.longitude}\n" +
//            $"timestamp: {Input.location.lastData.timestamp}";
//    }

//    private void Update()
//    {
//        _test.text = $"horizontalAccuracy: {Input.location.lastData.horizontalAccuracy}\n" +
//            $"verticalAccuracy: {Input.location.lastData.verticalAccuracy}\n" +
//            $"altitude: {Input.location.lastData.altitude}\n" +
//            $"latitude: {Input.location.lastData.latitude}\n" +
//            $"longitude: {Input.location.lastData.longitude}\n" +
//            $"timestamp: {Input.location.lastData.timestamp}";
//    }
}
