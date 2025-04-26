using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour

{
    [SerializeField] private float typewriterSpeed = 50f;

    public bool IsRunning {  get; private set; }

    //pause and wait for punctuation
    private readonly List<Punctuation> punctuations = new List<Punctuation>()
    {
        new Punctuation(new HashSet<char>(){'.','!','?' }, 0.4f),
        new Punctuation(new HashSet<char>(){',',';',':' }, 0.2f)
    };

    private Coroutine typingCoroutine;
    
    
    // "Driver Method"
    // responsible for running the co-routine TypeText
    public void Run(string textToType, TMP_Text textLabel)
    {
      
        typingCoroutine = StartCoroutine(TypeText2(textToType, textLabel));
    }

    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        IsRunning = false; 
    }


    //responsible for typing the text
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        //set text lable to textToType
        //use TMPtext veature text.MaxVisibleCharaters, set to 0 initial
        //4-26-25 advice from Roosevelt

        /*test the layout needed for the TMP version of this
         * textLabel = textToType;
         * IsRunning = true;
         * 
         * 
         * 
        */

        IsRunning = true;
        textLabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            
            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;
                
                textLabel.text = textToType.Substring(0, i+1);
                //set above to i+1 for MaxVisibleCharacters

                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i +1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        //at end set MaxVisibleCharacters to what it is supposed to be, which is the length of the string
        IsRunning = false;
        
        //label will be set from outside now! 1-10-25
        //textLabel.text = textToType;

    }

    private IEnumerator TypeText2(string textToType, TMP_Text textLabel)
    {
        //4-26-25 updated by Roosevelt to use TMPro maxVisibleCharacters instead of stubstring

        IsRunning = true;
        textLabel.maxVisibleCharacters = 0;
        textLabel.text = textToType;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;


            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLabel.maxVisibleCharacters = i;
             
                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        IsRunning = false;
        textLabel.maxVisibleCharacters = textToType.Length;


    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (Punctuation punctuationCategory in punctuations)
        {
            if (punctuationCategory.Punctuations.Contains(character))
            {
                waitTime = punctuationCategory.WaitTime; 
                return true;

            }
        }

        waitTime = default(float); 
        return false;
    }


    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;

        public Punctuation(HashSet<char> punctuations, float waitTime)
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }

    }

}
