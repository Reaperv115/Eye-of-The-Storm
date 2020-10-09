using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneControl : MonoBehaviour
{
    [System.Serializable]
    public class WeaponClass_Demo //Class for Scene Demonstration! 
    {
        public Transform Weapon; //Weapon Transform
        public Material[] materials; //Weapon's Materials/Skins
        public Sprite[] icon; //Skin Icons for Buttons
        public int skinIndex; //Selected Skin
    }
    public Vector3 camStartPos;

    private Vector2 MousePos;
    private Vector2 oldMousePos;
    private Vector3 targetPos;
    private Vector3 weaponTargetRot;
    public WeaponClass_Demo[] weapons;
    public Image[] buttonImage;
    private int weaponSelected;
    void Start()
    {
        targetPos = transform.position;
        weaponTargetRot = weapons[weaponSelected].Weapon.eulerAngles;
        SelectWeapon(weaponSelected);
        oldMousePos = MousePos;
    }
    public void SelectWeapon(int w)
    {
        for (int i=0;i< buttonImage.Length;i++)
        {
            buttonImage[i].sprite = weapons[w].icon[i];
        }
        weapons[weaponSelected].Weapon.gameObject.SetActive(false);
        weapons[w].Weapon.gameObject.SetActive(true);
        weapons[w].Weapon.eulerAngles = weapons[weaponSelected].Weapon.eulerAngles;
        weapons[w].Weapon.position = weapons[weaponSelected].Weapon.position;
        weaponSelected = w;
        SetWeaponType(weapons[weaponSelected].skinIndex);
    }
    public void SetWeaponType(int t)
    {
        weapons[weaponSelected].skinIndex = t;
        Renderer[] rends = weapons[weaponSelected].Weapon.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.sharedMaterial = weapons[weaponSelected].materials[t];
        }
    }
    void Update()
    {
        MousePos =  Input.mousePosition;
        weaponTargetRot.y += (oldMousePos.x - MousePos.x) * 20f * Time.deltaTime;
        weapons[weaponSelected].Weapon.eulerAngles = new Vector3(85,Mathf.LerpAngle(weapons[weaponSelected].Weapon.eulerAngles.y , weaponTargetRot.y, 10f * Time.deltaTime),0);

        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel"); //3rd Axis
        targetPos.y += (MousePos.y - oldMousePos.y) * Time.deltaTime;
        targetPos.z += ScrollWheel * 850f * Time.deltaTime;
        float coef = 1f / 13f * (transform.position.z + 19f);
        targetPos.y = Mathf.Clamp(targetPos.y ,- 9f * coef, 9f * coef);
        targetPos.z = Mathf.Clamp(targetPos.z, -19f, -6f);
        transform.position = Vector3.Lerp(transform.position,targetPos, 10f * Time.deltaTime);

        oldMousePos = MousePos;
    }
}
