﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocaViewManager : MonoBehaviour //VocaViewManager 정의, 이것도 모노로 되어있음 
{
    private int curVocaIdx = 0;
    public GameObject ViewPanel_voca;//유니티 상에서 Scene에 존재하는 오브젝트(약간 버튼 같은건가?)를 선언, 이름이 ViewPanel_voca
    public GameObject ViewPanel_mean;//오브젝트 선언, 이름이 ViewPanel_mean
    public GameObject PrevBtn;//오브젝트 선언, 이름이 PrevBtn
    public GameObject NextBtn;//오브젝트 선언, 이름이 NextBtn
    public GameObject ViewPanel_day;//오브젝트 선언, 이름이 ViewPanel_day

    public void Initialize()//시작시?
    {
        PrevBtn.GetComponent<Button>()//아까 선언한 오브젝트 PrevBtn에게 버튼 컴포넌트를 부여한다
            .onClick.AddListener(PrevVoca);//클릭 이벤트는 PrevVoca 실행
        NextBtn.GetComponent<Button>()//아까 선언한 오브젝트 PrevBtn에게 버튼 컴포넌트를 부여한다
            .onClick.AddListener(NextVoca);//클릭 이벤트는 NextVoca 실행
        SetVoca2ViewPanel();//SetVoca2ViewPanel()를 실행
        InitVocaDay();//InitVocaDay()를 실행
    }

    private void SetVoca2ViewPanel()
    {
        // 단어 및 뜻 설정
        ViewPanel_voca.GetComponent<Text>().text//아까 선언한 오브젝트 ViewPanel_voca에게 텍스트 컴포넌트를 부여한다
            = VocabularyDataBase.GetVocabularyLists()[curVocaIdx].vocabulary;
        ViewPanel_mean.GetComponent<Text>().text
            = VocabularyDataBase.GetVocabularyLists()[curVocaIdx].meaning;
        // 단어 일차 설정
        ViewPanel_day.GetComponent<Text>().text
            = VocabularyDataBase.GetVocabularyDay(curVocaIdx);
    }

    /// <summary>
    /// 일차가 설정되지 않은 단어들의 각각 몇일차 단어들인지 지정
    /// </summary>
    private void InitVocaDay()
    {
        for (int i = 1; i < VocabularyDataBase.GetVocabularyLists().Count; i++)
        {
            // 엑셀의 빈칸의 경우 비어있지는 않은 공백으로 판단됨
            if (string.IsNullOrWhiteSpace(VocabularyDataBase.GetVocabularyDay(i)))
            {
                VocabularyDataBase.SetVocabularyDay(i, VocabularyDataBase.GetVocabularyDay(i - 1));
            }
        }
    }

    private void NextVoca()
    {
        try
        {
            curVocaIdx++;
            SetVoca2ViewPanel();
        }
        catch (Exception e)
        {
            curVocaIdx = VocabularyDataBase.GetVocabularyLists().Count - 1;
            Debug.LogWarning("Last VOCA" + curVocaIdx);
        }
    }

    private void PrevVoca()
    {
        try
        {
            curVocaIdx--;
            SetVoca2ViewPanel();
        }
        catch (Exception e)
        {
            curVocaIdx = 0;
            Debug.LogWarning("First VOCA" + curVocaIdx);
        }
    }
}
