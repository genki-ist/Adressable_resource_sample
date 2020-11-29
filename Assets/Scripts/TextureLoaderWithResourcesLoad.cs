using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureLoaderWithResourcesLoad : MonoBehaviour
{
    private Texture tex = null;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        this.material = this.GetComponent<Renderer>().material;
        this.LoadTexture();
    }

    //普通にResources.Load
    private void LoadTexture()
    {
        this.tex = Resources.Load("player") as Texture;

        if(this.tex != null)
        {
            this.material.mainTexture = this.tex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
