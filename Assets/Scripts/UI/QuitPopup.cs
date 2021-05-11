using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//종료 팝업에 대한 CS
public class QuitPopup : MonoBehaviour//QuitPopup class 정의?
{
    public GameObject Popup_Quit;//Popup_Quit 게임 내 오브젝트 생성
    public GameObject QuitYes;//QuitYes 게임 내 오브젝트 생성(버튼...인건가?)
    public GameObject QuitNo;//QuitNo 게임 내 오브젝트 생성

    private void Start()
    {
        DontDestroyOnLoad(this);//this에 해당하는 것은 씬이 변경되어도 그대로 유지
        QuitYes.GetComponent<Button>().onClick.AddListener(Quit);//QuitYes에 대한 버튼 형식의 클릭 이벤트 설정(끝낸다?)
        QuitNo.GetComponent<Button>().onClick.AddListener(NotQuit);//QuitYes에 대한 버튼 형식의 클릭 이벤트 설정(안 끝낸다?)
    }

    private void Update()
    {
#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)//이건 음... 무슨의미지(본인의 생각: 안드로이드 환경이면?)
#endif
        {
            if (Input.GetKey(KeyCode.Escape))//Input이 종료를 의미한다면
            {
                Popup_Quit.SetActive(true);//Popup_Quit를 실행시킨다?
            }
        }
    }

    private void Quit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        //UnityEditor는 위 함수가 작동하지 않아서 false로 설정을 해야한다 그말인 것 같음.
        UnityEditor.EditorApplication.isPlaying = false; //강제 종료를 해준다
#endif
        Application.Quit();
    }

    private void NotQuit()
    {
        Popup_Quit.SetActive(false);//Popup_Quit를 실행시키지 않는다
    }
}
