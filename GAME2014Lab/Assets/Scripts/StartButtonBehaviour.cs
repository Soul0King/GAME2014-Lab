using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class StartButtonBehaviour : MonoBehaviour
{
    private SoundManager sm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sm = FindAnyObjectByType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClick()
    {
        Debug.Log("Start Button Pressed");
        SceneManager.LoadScene("Play");
    }
    public void PlaySelectSFX()
    {
        sm.PlaySelectSFX();
    }
}
