using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camracontroller : MonoBehaviour
{
    public Transform playertarget;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playertarget.position;
        transform.rotation = playertarget.rotation;
    }
}
