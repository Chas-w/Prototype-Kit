using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System; 
using UnityEngine.Windows.Speech; 
public class VoiceControl : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> actions = new Dictionary<string,Action>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actions.Add("forward", Forward);
        //actions.Add("up", Up);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        keywordRecognizer.Start();
    }
    
    void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    void Forward()
    {
        Debug.Log("Going Forward");
    }
}
