using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //色を点滅させる用
        if (controller.IsInvicible())
        {
            Material material = GetComponent<Renderer>().material;
            float level = Mathf.Abs(Mathf.Sin(Time.deltaTime * 10));
            GetComponent<Renderer>().material.color = new Color(material.color.r, material.color.g, material.color.b, level);
        }
    }
    
}
