using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int curVocaIdx = 0;
    public GameObject ViewPanel_voca;
    public GameObject ViewPanel_mean;
    public GameObject PrevBtn;
    public GameObject NextBtn;

    public void Initialize()
    {
        PrevBtn.GetComponent<Button>()
            .onClick.AddListener(PrevVoca);
        NextBtn.GetComponent<Button>()
            .onClick.AddListener(NextVoca);
        SetVoca2ViewPanel();
    }

    private void SetVoca2ViewPanel()
    {
        ViewPanel_voca.GetComponent<Text>().text
            = VocabularyDataBase.GetVocabularyLists()[curVocaIdx].vocabulary;
        ViewPanel_mean.GetComponent<Text>().text 
            = VocabularyDataBase.GetVocabularyLists()[curVocaIdx].meaning;
    }

    private void NextVoca()
    {
        try
        {
            curVocaIdx++;
            SetVoca2ViewPanel();
        }
        catch(Exception e)
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
