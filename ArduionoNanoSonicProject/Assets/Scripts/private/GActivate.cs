using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GActivate : MonoBehaviour
{
    public GameObject frcfld;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Corvette/ForceField/FieldF"))
             frcfld =  GameObject.Find("Corvette/ForceField/FieldF");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
