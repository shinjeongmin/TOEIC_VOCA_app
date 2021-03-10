using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VocabularyDataBase
{
    private static List<VocabularyFormat> vocabularyLists = new List<VocabularyFormat>();

    public static void SetVocaFromGoogleSheet(string sheets)
    {
        string[] split_sheets = sheets.Split('\n');
        // 시트 한 줄 씩 파싱
        foreach (string oneline in split_sheets)
        {
            string[] split_oneline = oneline.Split('\t');
            VocabularyFormat vocabularyFormat = 
                new VocabularyFormat(int.Parse(split_oneline[0]), split_oneline[1], split_oneline[2], (VocabularyFormat.CheckClear)int.Parse(split_oneline[3]));
            vocabularyLists.Add(vocabularyFormat);
        }
    }

    public static List<VocabularyFormat> GetVocabularyLists()
    {
        return vocabularyLists;
    }
}