using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Next Button Pressed");
        currentScene += 1;
        if (currentScene > 2) currentScene = 0;
        SceneManager.LoadScene(currentScene);

    }
}
