using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{

    public TextMeshProUGUI soundText;
    // Start is called before the first frame update
    void Start()
    {
        if (GamerManager.mute)
            soundText.text = "/";
        else
            soundText.text = "";
    }

    public void ToggleMute()
    {
        if (GamerManager.mute)
        {
            GamerManager.mute = false;
            soundText.text = "";
        }
        else
        {
            GamerManager.mute = true;
            soundText.text = "/";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    
}
