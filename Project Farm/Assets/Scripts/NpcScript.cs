using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    [SerializeField]
    string[] dialogue = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < dialogue.Length; i++)
            {
                print(dialogue[i]);
            }
        }
    }
}
