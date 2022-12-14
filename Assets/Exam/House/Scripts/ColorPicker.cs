using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

public class ColorPicker : MonoBehaviour
{
    #region Variables

    [SerializeField] private InputActionProperty InputActionProperty;
    [SerializeField] private float rayDistance = 2f;
    private bool isTriggerPressed;

    public Sprite Sprite;
    public Image colorWheel;
    public Transform controller;
    public MaterialChanger materialChanger;
    #endregion Variables

    #region Unity Methods
    private void OnEnable()
    {
        InputActionProperty.action.performed += Action_performed;
        InputActionProperty.action.canceled += Action_performed;
    }

    private void OnDisable()
    {
        InputActionProperty.action.performed -= Action_performed;
        InputActionProperty.action.canceled -= Action_performed;
    }

    void Update()
    {
        if (isTriggerPressed)
        {
            Ray ray = new Ray(controller.position, controller.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,rayDistance) && hit.collider.gameObject == colorWheel.gameObject)
            {

                //var color = colorWheel.sprite.texture.GetPixel((int)hit.textureCoord.x, (int)hit.textureCoord.y);
                var color=Sprite.texture.GetPixel((int)hit.textureCoord.x, (int)hit.textureCoord.y);
                materialChanger.ChangeColor(color);
            }
        }
    }
    #endregion Unity Methods

    #region Public Methods
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    private void Action_performed(InputAction.CallbackContext obj)
    {
        isTriggerPressed = obj.performed;
        Debug.Log("ColorPicker: "+isTriggerPressed);
    }
    #endregion Callbacks



}
