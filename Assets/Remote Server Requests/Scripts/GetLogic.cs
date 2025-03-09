﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OldStats;
using UnityEngine.SceneManagement;

public class GetLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonAPIS.instance.OnGetRequestSuccess += OnGetRequestSeccessFunc;
        JsonAPIS.instance.OnGetRequestFail += OnGetRequestFailFunc;

#if UNITY_ANDROID
        JsonAPIS.instance.GetRequest();
#endif
    }

    public void OnGetRequestSeccessFunc()
    {
        Debug.Log("OnGetRequestSeccessFunc");
        StatisticsJsonFile.Instance.data.session_start_time = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        LoadMainMenuRPC();
    }

    public void OnGetRequestFailFunc()
    {
        Debug.Log("OnGetRequestFailFunc");
        GetRequestFailRPC();
    }

    public void LoadMainMenuRPC()
    {
        StatisticsJsonFile.Instance.data.session_start_time = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        SceneManager.LoadScene(2);
    }

    public void GetRequestFailRPC()
    {
#if UNITY_ANDROID
        SceneManager.LoadScene(0);
#else 
        Application.Quit();        
#endif
    }
    IEnumerator DesktopUnAuthorized()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(6);
        Application.Quit();
    }
    private void OnDestroy()
    {
        JsonAPIS.instance.OnGetRequestSuccess -= OnGetRequestSeccessFunc;
        JsonAPIS.instance.OnGetRequestSuccess -= OnGetRequestFailFunc;
    }
}
