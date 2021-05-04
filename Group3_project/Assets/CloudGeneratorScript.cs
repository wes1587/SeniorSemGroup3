using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=DvAmw-YXrG0&t=21s
//video tutorial used for the clouds generator

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval; //frequency that clouds will spawn

    [SerializeField]
    GameObject endpoint;

    Vector3 startPos;

    
    void Start()
    {
        //the transform position of this obejct is the start point
        startPos = transform.position;

        //when the object generator starts it is going to call this functions attempt spawn after the born interval
        //1.5 seconds, this invoke is slower but it is easier for begginers, there is no problem for small projects 
        Invoke("AttemptSpawn", spawnInterval);
        
    }

    void SpawnCloud()
    {
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);


        //random the y position of clouds so it will look more natural
        float startY = UnityEngine.Random.Range(startPos.y - 8f, startPos.y + 8);
        cloud.transform.position = new Vector3(startPos.x,startY,startPos.z);

        //random the size of the clouds
        float scale = UnityEngine.Random.Range(0.8f, 1.5f);
        cloud.transform.localScale = new Vector2(scale, scale);

        //random speed 
        float speed = UnityEngine.Random.Range(2.0f, 3.0f);
        cloud.GetComponent<CloudsScript>().StartFloating(speed, endpoint.transform.position.x);

        
        
    }

    //instead of just calling this method, we can create a function which later allow us to check if the
    //game is still play, how many clouds we have on screen, check if character is still alive...
    void AttemptSpawn()
    {
        SpawnCloud();
        Invoke("AttemptSpawn", spawnInterval);
    }
}
