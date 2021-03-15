using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidHandling : MonoBehaviour
{
    public GameObject Popup_Quit;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
            }
        }
    }
}
