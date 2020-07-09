using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    Vector3 rotation;
    Transform rotate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 20* Time.deltaTime;

        if(Input.GetKey(KeyCode.A))
            {
            gameObject.transform.Rotate(0, -x, 0);

        }
        if (Input.GetKey(KeyCode.D))
            {
            gameObject.transform.Rotate(0, x, 0);

            }
    }
}
