using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteShadow : MonoBehaviour
{
    Renderer renderer;


    public bool recieveShadows;
    public bool castShadows;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();

        renderer.receiveShadows = recieveShadows;

        if(castShadows)
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
