using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitParticlesOnTile : MonoBehaviour
{

    public ParticleSystem ptcl;
    public string tileTag;

    void Start()
    {
        ptcl.Stop();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == tileTag)
        {
            ptcl.Play();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == tileTag)
        {
            ptcl.Stop();
        }
    }
}
