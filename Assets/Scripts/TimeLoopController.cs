using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLoopController : MonoBehaviour
{
    public static TimeLoopController instance;

    public GameObject player;
    public List<stringToInt> sceneToZoneMap = new List<stringToInt>();
    // State Managers
    public TreeSM TreeSM = new TreeSM();

    private int zone;
    private List<BaseSM> SMs = new List<BaseSM>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        instance.player = GameObject.FindGameObjectWithTag("Player");

        instance.calculateZone(SceneManager.GetActiveScene().name);

        // manually add states to list of states
        instance.SMs.Add(instance.TreeSM);
        // make sure the starting states are set
        foreach (BaseSM SM in instance.SMs)
        {
            SM.reset();
        }
    }



    public static void teleport(string targetScene, float spawnX)
    {
        // change player x pos regarless of what happens
        instance.player.gameObject.transform.position = new Vector2(spawnX, instance.player.transform.position.y);
        // check if the target scene is not the current scene
        if (targetScene != SceneManager.GetActiveScene().name)
        {
            instance.calculateZone(targetScene);
            SceneManager.LoadScene(targetScene);
        }
    }

    public void NextState(string targetAndInput)
    {
        /* since the event system allows up to a single parameter this will have
         * to take in its two parameters (the target state machine and the 
         * input to that state machine) as a single string separated by a 
         * space.
         */
        string[] splitInput = targetAndInput.Split(' ');
        string targetSM = splitInput[0];
        string input = splitInput[1];
        foreach(BaseSM SM in instance.SMs)
        {
            if(SM.name == targetSM)
            {
                SM.nextState(input);
                return;
            }
        }
        Debug.LogWarning("Attempted to access a state machine that isn't in the list. " +
            "TargetSM: " + targetSM + ". Input: " +input);
    }

    protected void calculateZone(string inputScene)
    {
        foreach(stringToInt si in instance.sceneToZoneMap)
        {
            if(inputScene == si.str)
            {
                instance.zone = si.integer;
                Debug.Log(instance.zone);
                return;
            }
        }
        Debug.LogWarning("Unable to map scene to zone. Scene: " + inputScene);
    }
}
