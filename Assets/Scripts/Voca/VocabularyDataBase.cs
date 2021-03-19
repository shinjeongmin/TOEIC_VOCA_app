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
        foreach (string oneRow in split_sheets)
        {
            string[] split_oneRow = oneRow.Split('\t');
            VocabularyFormat vocabularyFormat =
                new VocabularyFormat(
                    split_oneRow[0],
                    split_oneRow[1],
                    split_oneRow[2],
                    split_oneRow[3],    
                    split_oneRow[4]
                );
            vocabularyLists.Add(vocabularyFormat);
        }
    }

    public static List<VocabularyFormat> GetVocabularyLists()
    {
        return vocabularyLists;
    }

    public static string GetVocabularyDay(int idx)
    {
        return vocabularyLists[idx].day;
    }

    public static void SetVocabularyDay(int idx, string _day)
    {
        vocabularyLists[idx].day = _day;
    }
}