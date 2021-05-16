using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VocabularyDataBase
{
    private static List<VocabularyFormat> vocabularyLists = new List<VocabularyFormat>(); //VocabularyForamat 리스트에 vocabularyLists 동적할당
    private static int max_DayCount;
    public static void SetVocaFromGoogleSheet(string sheets)//sheets를 매개변수로 하는 SetVocaFromGoogleSheet 정의
    {
        string[] split_sheets = sheets.Split('\n');//sheet를 \n이 나올 때마다 분할해서 배열에 넣어줌
        // 시트 한 줄 씩 파싱
        foreach (string oneRow in split_sheets)//foreach는 split_sheets(배열)에 있는 인자를 차례대로 oneRow에 넣어줌
        {
            string[] split_oneRow = oneRow.Split('\t');//셀이 오른쪽으로 넘어갈때마다 Split?
            VocabularyFormat vocabularyFormat =
                new VocabularyFormat(
                    split_oneRow[0],
                    split_oneRow[1],
                    split_oneRow[2],
                    split_oneRow[3],    
                    split_oneRow[4]
                );//vocabularyFormat은 형식을 split_oneRow의 각각의 원소를 순서대로 담는 형식으로 한다.
            vocabularyLists.Add(vocabularyFormat);//저장
        }
    }

    public static List<VocabularyFormat> GetVocabularyLists()
    {
        return vocabularyLists;
    }

    public static string GetVocabularyDay(int idx)//GetVocabularyDay 선언
    {
        return vocabularyLists[idx].day;//단어에 해당하는 day를 리턴해줌
    }

    public static void SetVocabularyDay(int idx, string _day)
    {
        vocabularyLists[idx].day = _day;//??????
    }
    public static void Find_MaxDay()
    {
        int standard = 0, temp = 0;
        for (int i = 0; i < 100; i++)
        {
            string a = VocabularyDataBase.GetVocabularyDay(i);
            a = a.Replace("day", "");
            temp=int.Parse(a);
            if(standard<temp)
            {
                max_DayCount = temp;
            }
        }
    }
    public static int GetMaxDay()
    {
        return max_DayCount;
    }
}