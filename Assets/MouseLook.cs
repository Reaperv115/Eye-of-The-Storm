using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseSens = 100f;
    [SerializeField]
    Transform playerBody;

    float xRotation = 0.0f;

    public Transform hand;
    public GameObject currentWeapon, previousWeapon;

    GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentWeapon = Resources.Load<GameObject>("energy hammer");
        currentWeapon = Instantiate(currentWeapon, hand.transform.position, hand.transform.rotation, hand);
        GameObject.Find("Mystery Box").GetComponent<TheBox>().arsenal.Add(currentWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        currentWeapon.transform.position = hand.transform.position;
        currentWeapon.transform.rotation = hand.transform.rotation;
        currentWeapon.transform.SetParent(transform);

        if (previousWeapon != null)
        {
            previousWeapon.transform.parent = transform;
            previousWeapon.gameObject.SetActive(false);
        }
        
        
        
    }
}
