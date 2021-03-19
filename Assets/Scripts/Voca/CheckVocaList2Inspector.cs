using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inspector로 VOCA데이터 확인용 스크립트
/// </summary>
public class CheckVocaList2Inspector : MonoBehaviour
{
    public List<VocabularyFormat> view_vocabularyLists = new List<VocabularyFormat>();

    public void Set()
    {
        view_vocabularyLists = VocabularyDataBase.GetVocabularyLists();
    }
}