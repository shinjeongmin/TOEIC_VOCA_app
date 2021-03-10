using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVocaList2Inspector : MonoBehaviour
{
    public List<VocabularyFormat> view_vocabularyLists = new List<VocabularyFormat>();

    public void Set()
    {
        view_vocabularyLists = VocabularyDataBase.GetVocabularyLists();
    }
}