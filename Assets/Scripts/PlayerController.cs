using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How Fast Ship Move")][SerializeField]float controlspeed;
    [Tooltip("x axis range on screen")][SerializeField] float xRange = 5f;
    [Tooltip("y axis range on screen")] [SerializeField] float yRange = 5f;
    [Header("position based turning factor")]
    [SerializeField]float postionPitchFactor = -2f;
    [SerializeField] float postionYawFactor = 2f;
    [Header("input based turning factor")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float horizontalMove;
    float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotaion();
    }

    private void ProcessRotaion()
    {
        float pitchDuetoPostion = transform.localPosition.y * postionPitchFactor;
        float pitchDuetoControl = verticalMove * controlPitchFactor;
        float pitch = pitchDuetoPostion +pitchDuetoControl;


        float yaw = transform.localPosition.x * postionYawFactor;
       
        
        float roll = horizontalMove * controlRollFactor;
        
        
        
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(pitch,-15,25),yaw,roll);
    }

    private void ProcessTranslation()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");


        float xOffset = horizontalMove * Time.deltaTime * controlspeed;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);


        float yOffset = verticalMove * Time.deltaTime * controlspeed;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange-3f, yRange-4.8f);


        transform.localPosition = new Vector3(
            clampedXpos,
            clampedYpos,
            transform.localPosition.z);
    }
}
