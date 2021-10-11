using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Battleship : MonoBehaviour
{

    public ConstantForce frc;
    [Range(0.5f, 5f)]
    public float verticalSensitivity = 1;
    [Range(0.5f, 5f)]
    public float horizontalSensitivity = 1;

    AudioSource src;
    Rigidbody rig;

    // Use this for initialization
    void Start()
    {
        src = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        float hor = GameObject.FindObjectOfType<ArduinoDataHandler>().Horizontal;
        frc.relativeTorque = new Vector3(Input.GetAxis("Mouse Y") * 1500f * verticalSensitivity, hor * 1500f, -Input.GetAxis("Mouse X") * 1500f * horizontalSensitivity) * Mathf.Clamp01(rig.velocity.magnitude / 100f);
        frc.relativeForce = new Vector3(0, 0, Mathf.Clamp(hor, -0.1f, 1f) * 21500f);

        src.volume = 0.03f + Mathf.Clamp01(rig.velocity.magnitude / 100f) / 9f;
        src.pitch = 1f + Mathf.Clamp01(rig.velocity.magnitude / 100f) / 5f;
    }
}
