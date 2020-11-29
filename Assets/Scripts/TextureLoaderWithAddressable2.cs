using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class TextureLoaderWithAddressable2 : MonoBehaviour
{
    private Texture tex = null;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        this.material = this.GetComponent<Renderer>().material;
        StartCoroutine(this.LoadTexture());
    }

    //コルーチンにすることで、前の処理を必ず待ってから次の処理に進むときなどで有効になる
    private IEnumerator LoadTexture()
    {
        //Addressable Groupからリソースを読み込み
        //読み込み後のcallbackを設定
        Addressables.LoadAssetAsync<Texture>("player2").Completed += (handle => {
            this.tex = handle.Result;
        });

        do
        {
            yield return null;
        }
        while (this.tex == null);

        if(this.tex != null)
        {
            this.material.mainTexture = this.tex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //destroyされたらリソースを解放
    private void OnDestroy()
    {
        Addressables.Release(this.tex);
    }
}
