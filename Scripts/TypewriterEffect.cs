using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [Header("Type String")]
    [SerializeField] public string typeString;

    [Header("Container Data")]
    [SerializeField] TMP_Text _textBox;
    [SerializeField] float charactersPerSecond = 20;
    [SerializeField] float interpunctuationDelay;

    Coroutine _typewriterCoroutine; 

    int _currentVisibleCharacterIndex;

    WaitForSeconds _simpleDelay;
    WaitForSeconds _interpunctuationDelay;
    WaitForSeconds _skipDelay; 

    //skip functionality
    public bool CurrentlySkipping { get; private set; }

    /*
    [Header("Skip Options")]
    [SerializeField] bool quickSkip;
    [SerializeField][Min(1)] int skipSpeedup = 5; 
    */


    private void Awake()
    {
        _textBox = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _interpunctuationDelay = new WaitForSeconds(interpunctuationDelay);
       /* _skipDelay = new WaitForSeconds(1/charactersPerSecond * skipSpeedup); 
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        SetText(typeString); 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (_textBox.maxVisibleCharacters != _textBox.textInfo.characterCount)
            {
                Skip();
                //Debug.Log("skip"); 
            }
        }
        */
    }

    /*
    public void Skip()
    {
        if (CurrentlySkipping)
        {
            return;
        }

        CurrentlySkipping = true;

        if (!quickSkip)
        {
            StartCoroutine(routine: SkipSpeedupReset());
            return; 
        }

        StopCoroutine(_typewriterCoroutine);
        _textBox.maxVisibleCharacters = _textBox.textInfo.characterCount;
       
    }

    private IEnumerator SkipSpeedupReset()
    {
        yield return new WaitUntil(() => _textBox.maxVisibleCharacters == _textBox.textInfo.characterCount - 1);
        CurrentlySkipping = false;
    }
       */
    public void SetText(string txt) 
    {
        if(_typewriterCoroutine != null) { StopCoroutine(_typewriterCoroutine); } 

        _textBox.text = txt;
        _textBox.maxVisibleCharacters = 0;
        _currentVisibleCharacterIndex = 0;

        _typewriterCoroutine = StartCoroutine(routine:Typewriter());
    }
 

    private IEnumerator Typewriter()
    {
        TMP_TextInfo textInfo = _textBox.textInfo;

        while (_currentVisibleCharacterIndex < textInfo.characterCount + 1) 
        {
            char character = textInfo.characterInfo[_currentVisibleCharacterIndex].character;
            _textBox.maxVisibleCharacters++;

            if (
                (character == '?' || character == '.' || character == ',' || character == ':'
                || character == ';' || character == '!' || character == '-'))
            {
                yield return _interpunctuationDelay;
            }
            else
            {
                yield return _simpleDelay;
            }
            _currentVisibleCharacterIndex++;
        }

    
    }
}
