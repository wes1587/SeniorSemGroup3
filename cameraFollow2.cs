
using UnityEngine;

public class cameraFollow2 : MonoBehaviour
{
    public Transform character;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = character.position + offset;
    }
}
