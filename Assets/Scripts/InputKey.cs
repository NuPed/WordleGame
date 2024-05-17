using UnityEngine;
using TMPro;
using System.Collections;

public class InputKey : MonoBehaviour
{
    [Header("Word Input")]
    public string word = "";
    public string[] wordData = { };
    private string randomWord;
    private int alphabetCount = 0;
    private int rowIndex = 0;
    public int guessCount = 0;
    public GetWord[] getWords;
    public Score score;
    public GameObject notInData;
    [SerializeField] TextMeshProUGUI answerText;

    private void Start() 
    {
        RandomWord();
        notInData.SetActive(false);
    }

    private void RandomWord()
    {
        randomWord = wordData[Random.Range(0, wordData.Length)];
        answerText.text = randomWord;
        // Debug.Log("randomWord: " + randomWord);
    }

    // Adds letter to word
    public void alphabetFunction(string alphabet)
    {
        if(alphabetCount < 5)
        {
            getWords[rowIndex].displayword[alphabetCount].SetContainerText(alphabet[0]);
            alphabetCount++;
            word += alphabet;
        }  
    }

    // Deletes letter
    public void DeleteWord()
    {
        if(alphabetCount > 0)
        {
            alphabetCount--;
            getWords[rowIndex].displayword[alphabetCount].SetContainerText('\0');
            word = word.Substring(0, word.Length - 1);
        }
    }

    public void Submit()
    {
        // find is word in data
        bool isInData = false;
        for(int i = 0; i < wordData.Length; i++)
        {
            if(wordData[i] == word)
            {
                isInData = true;
                break;
            } else {
                isInData = false;
            }
        }

        // if word in data and alphabetCount = 5
        if(isInData && alphabetCount == 5)
        {
            // if less than 6 times of guess
            if(rowIndex < randomWord.Length)
            {
                if(word == randomWord)
                {
                    // Correct Answer
                    guessCount++;
                    CheckAlphabet(word);
                    score.Win();
                    score.RevealAnswer(randomWord);
                    score.CountText(guessCount);
                } else if (word != randomWord) {
                    //Wrong answer
                    guessCount++;
                    CheckAlphabet(word);
                    rowIndex++;
                    alphabetCount = 0;
                    word = "";
                }
            } 
            // if more than or equal 6 times of guess
            else if (rowIndex >= randomWord.Length) {
                //Wrong and replay button
                if(word == randomWord)
                {
                    // Correct Answer
                    guessCount++;
                    CheckAlphabet(word);
                    score.Win();
                    score.RevealAnswer(randomWord);
                    score.CountText(guessCount);
                } else if (word != randomWord) {
                    guessCount++;
                    CheckAlphabet(word);
                    score.Lose();
                    score.RevealAnswer(randomWord);
                    score.CountText(guessCount);
                }
            }
        } 
        // if word not in data and alphabetCount = 5
        else if(!isInData && alphabetCount == 5) {
            notInData.SetActive(true);
            StartCoroutine(DisappearAfter(5));
        }

    }

    public void CheckAlphabet(string word)
    {
        string containsWord = word;
        for(int i = 0; i < word.Length; i++)
        {
                if(randomWord[i] == containsWord[i])
                {
                    //Change box to green when correct
                    containsWord = containsWord.Replace(containsWord[i], '\0');
                    getWords[rowIndex].displayword[i].GetComponent<UnityEngine.UI.Image>().color = new Color(0.6789216f, 1, 0.5330188f, 1);
                }
                else if(randomWord.Contains(containsWord[i]))
                {
                    //Change box to yellow when correct but not in right position
                    getWords[rowIndex].displayword[i].GetComponent<UnityEngine.UI.Image>().color = Color.yellow;  
                }
                else if(!randomWord.Contains(containsWord[i]))
                {
                    //Change box to gray when not correct
                    getWords[rowIndex].displayword[i].GetComponent<UnityEngine.UI.Image>().color = Color.gray;  
                }        
        }
    }

    // Delay
    IEnumerator DisappearAfter(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        notInData.SetActive(false);
    }
}
