using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_50on : MonoBehaviour
{
    public Sprite AIM_SPRITE = null;
    public GameObject SR_50on = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SR_50on.GetComponent<SpriteRenderer>().sprite= AIM_SPRITE;
    }
}
