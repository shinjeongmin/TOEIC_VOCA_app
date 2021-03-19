using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class VocabularyFormat
{
    public enum CheckClear{ YET,CLEAR }

    public int index;
    public string vocabulary;
    public string meaning;
    public CheckClear check;
    public string day;

    public VocabularyFormat(string _index, string _vocabulary,string _meaning, string _check, string _day)
    {
        index = int.Parse(_index);
        vocabulary = _vocabulary;
        meaning = _meaning;
        check = (VocabularyFormat.CheckClear)int.Parse(_check);
        day = _day;
    }
}