using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Time Loop")]
    public string timeLoopLevel = "fistLevel";
    public GameObject timeLoopManager;
    public GameObject timeLoopPlayer;
    [Header("Story Loop")]
    public string storyLoopLevel = "firstLevel";

    public void TimeLoopDemo()
    {
        Instantiate(timeLoopPlayer);
        Instantiate(timeLoopManager);
        SceneManager.LoadScene(timeLoopLevel);
    }
}
