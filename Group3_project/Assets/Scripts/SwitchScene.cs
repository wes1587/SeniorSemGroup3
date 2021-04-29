using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("StartTransition");

        //wait for certain amount of seconds
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);


    }

}
