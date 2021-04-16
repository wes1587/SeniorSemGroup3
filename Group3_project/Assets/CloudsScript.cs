using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsScript : MonoBehaviour
{
    private float _speed;
    private float _endPosX;

    
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));

        if( transform.position.x > _endPosX) //this if is used to destroy the cloud
        {
            Destroy(gameObject);
        }
    }

    public void StartFloating(float speed, float endPosX)
    {

        _speed = speed;
        _endPosX = endPosX;
    }
}
