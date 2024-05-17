using UnityEngine;

public class GetWord : MonoBehaviour
{
    public DisplayWord[] displayword;
    
    private void Start() {
        displayword = GetComponentsInChildren<DisplayWord>();
    }
}
