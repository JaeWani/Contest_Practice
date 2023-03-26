using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float ScrollSpeed;
    [SerializeField] Material BGMaterial;
    Vector2 vec;
    private void Start() 
    {
        vec = new Vector2(0,0);
    }

    void Update()
    {
        vec.y += ScrollSpeed * Time.deltaTime;
        vec.x = 0;
        BGMaterial.mainTextureOffset = vec;
    }
}
