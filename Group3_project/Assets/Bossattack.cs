using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossattack : MonoBehaviour
{
    public GameObject Rock;
    public Transform rockPos;
    public int damage = 10;


    void Start()
    {
        StartCoroutine(throwRock());
    }

    IEnumerator throwRock()
    {
        while (true)
        {
            Rthrow();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Rthrow()
    {
        {

            GameObject Rball = Instantiate(Rock, rockPos.position, Quaternion.identity);
            Rball.GetComponent<Rigidbody>().AddForce(rockPos.right * Random.Range(100, 400));
            Destroy(Rball, 6);
        }
    }
}
