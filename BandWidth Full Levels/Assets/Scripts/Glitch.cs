using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material glitch;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<Renderer>();
        glitch = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //Creates a pulsing glitch effect
        float lineness = Mathf.PingPong(Time.time, 1);
        glitch.SetFloat("_LineSize", lineness);
    }
}
