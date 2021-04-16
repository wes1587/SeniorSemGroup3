using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval; //frequency that clouds will spawn

    [SerializeField]
    GameObject endpoint;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; //the transform position of this obejct is the start point

        Invoke("AttemptSpawn", spawnInterval);
        //when the object generator starts it is going to call this functions attempt spawn after the born interval
        //1.5 seconds, this invoke is slower but it is easier for begginers, there is no problem for small projects 
    }

    void SpawnCloud()
    {
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        cloud.transform.position = startPos;
    }

    //instead of just calling this method, we can create a function which later allow us to check if the
    //game is still play, how many clouds we have on screen, check if character is still alive...
    void AttemptSpawn()
    {
        SpawnCloud();
    }
}
