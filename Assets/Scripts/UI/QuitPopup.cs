using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitPopup : MonoBehaviour
{
    public GameObject Popup_Quit;
    public GameObject QuitYes;
    public GameObject QuitNo;

    private void Start()
    {
        DontDestroyOnLoad(this);
        QuitYes.GetComponent<Button>().onClick.AddListener(Quit);
        QuitNo.GetComponent<Button>().onClick.AddListener(NotQuit);
    }

    private void Update()
    { 
#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)
#endif
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Popup_Quit.SetActive(true);
            }
        }
    }

    private void Quit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void NotQuit()
    {
        Popup_Quit.SetActive(false);
    }
}
