using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMeshRenderLayer2D : MonoBehaviour
{
    private MeshRenderer renderer;

    public string renderLayerName;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = renderLayerName;
    }
}
