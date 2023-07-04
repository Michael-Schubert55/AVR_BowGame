using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IngameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;
    public GameObject menu;
    public InputActionProperty showButton;
    public GameObject rayInteractorLeft;
    public GameObject rayInteractorRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
            rayInteractorLeft.SetActive(!rayInteractorLeft.activeSelf);
            rayInteractorRight.SetActive(!rayInteractorRight.activeSelf);

            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }

    public void ActivateExternal()
    {
        menu.SetActive(!menu.activeSelf);
        rayInteractorLeft.SetActive(!rayInteractorLeft.activeSelf);
        rayInteractorRight.SetActive(!rayInteractorRight.activeSelf);

        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }
}
