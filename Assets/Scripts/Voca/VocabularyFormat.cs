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

    public VocabularyFormat(int _index, string _vocabulary,string _meaning, CheckClear _check)
    {
        index = _index;
        vocabulary = _vocabulary;
        meaning = _meaning;
        check = _check;
    }
}