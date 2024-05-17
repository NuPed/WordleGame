using UnityEngine;

public class SetActiveAnswer : MonoBehaviour
{
    public GameObject answerGameobject;

    private void Start() {
        answerGameobject.SetActive(false);
    }

    public void ShowAnswer()
    {
        if(answerGameobject.activeSelf)
            answerGameobject.SetActive(false);

        else
            answerGameobject.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
