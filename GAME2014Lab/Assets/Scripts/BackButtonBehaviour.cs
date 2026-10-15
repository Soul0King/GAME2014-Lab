using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Back Button Pressed");
        SceneManager.LoadScene(currentScene - 1);
    }
}
