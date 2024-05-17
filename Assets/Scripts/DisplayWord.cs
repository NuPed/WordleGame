using TMPro;
using UnityEngine;

public class DisplayWord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI containerText;
    internal object displayword;

    public char alphabet;

    private void Start()
    {
        containerText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetContainerText(char alphabet)
    {
        this.alphabet = alphabet;
        containerText.text = alphabet.ToString();
    }
}
