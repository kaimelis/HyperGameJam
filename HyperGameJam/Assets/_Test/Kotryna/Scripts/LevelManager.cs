using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public SceneReference currentScene;
    public SceneReference nextScene;
    public SceneReference mainMenuScene;

    //private void OnGUI()
    //{
    //    DisplayLevel(nextScene);
    //    DisplayLevel(mainMenuScene);
    //    Display(GetCurrentScene());
    //}

    public void DisplayLevel(SceneReference scene)
    {
        GUILayout.Label(new GUIContent("Scene name Path: " + scene));
        if (GUILayout.Button("Load " + scene))
        {
            SceneManager.LoadScene(scene);
        }
    }

    public void Display(string scene)
    {
        GUILayout.Label(new GUIContent("Scene name Path: " + scene));
        if (GUILayout.Button("Load " + scene))
        {
            SceneManager.LoadScene(scene);
        }
    }
    
    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
