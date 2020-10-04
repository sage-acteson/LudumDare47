using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLoopController : MonoBehaviour
{
    public static TimeLoopController instance;

    public int state;
    public GameObject player;
    public bool tree_fallen = true;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        state = 0;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public static void teleport(string targetScene, float spawnX)
    {
        // change player x pos regarless of what happens
        instance.player.gameObject.transform.position = new Vector2(spawnX, instance.player.transform.position.y);
        // check if the target scene is not the current scene
        if (targetScene != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
