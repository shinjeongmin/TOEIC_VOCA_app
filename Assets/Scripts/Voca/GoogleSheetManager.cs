using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class GoogleSheetManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1ltFxS1DMgJx_frkA7nLJFRx0uVQxyBeZGHam2iUXgBU/export?format=tsv&range=A2:D";

    public UnityEvent onUIManager_Initialize;
    public UnityEvent onCheckVocalLists2Inspector;

    IEnumerator Start()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.isDone) { 
                print("Complete Load Sheet");
                VocabularyDataBase.SetVocaFromGoogleSheet(www.downloadHandler.text);

                Initialize_onFunctions();
            }
            else print("404 Error. Not Response from Web");
        }
    }

    private void Initialize_onFunctions()
    {
        onCheckVocalLists2Inspector.Invoke();
        onUIManager_Initialize.Invoke();
    }
}
