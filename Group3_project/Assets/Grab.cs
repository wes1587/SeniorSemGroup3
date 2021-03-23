using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform holdParent;
    public Transform grabDetect;
    public float moveForce;
    public float pickUpRange;

    private GameObject BoxHolder;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (BoxHolder == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(grabDetect.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }

            else
            {
                DropObject();
            }
        }

        if (BoxHolder != null)
        {
            MoveObject();
        }
    }

        void MoveObject()
        {
            if (Vector3.Distance(BoxHolder.transform.position, holdParent.position) > 0.1f)
            {
                Vector3 moveDirection = (holdParent.position - BoxHolder.transform.position);
                BoxHolder.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
            }
        }

        void PickupObject(GameObject pickObj)
        {
            if (pickObj.GetComponent<Rigidbody>())
            {
                Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
                objRig.useGravity = false;
                objRig.drag = 10;

                objRig.transform.parent = holdParent;
                BoxHolder = pickObj;
            }
        }

        void DropObject()
        {
            Rigidbody heldRig = BoxHolder.GetComponent<Rigidbody>();
            heldRig.useGravity = true;
            heldRig.drag = 1;

            BoxHolder.transform.parent = null;
            BoxHolder = null;
        }
    }