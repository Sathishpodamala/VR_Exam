using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RaySelector : MonoBehaviour
{
    #region Variables
    [SerializeField] private InputActionProperty InputActionProperty;
    [SerializeField] private float rayDistance = 1f;
    private bool isSelectPressed;
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

    private void Update()
    {
        if (isSelectPressed)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, rayDistance))
            {
                Debug.Log(hitInfo.collider.name);

                if(hitInfo.collider.TryGetComponent<MaterialChanger>(out MaterialChanger materialChanger))
                {
                    if (materialChanger != null)
                    {
                        ColorPallet.instance.SetMaterialChanger(materialChanger);
                        ColorPallet.instance.Enablepallet();
                    }
                }
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
        isSelectPressed = obj.performed;
    }
    #endregion Callbacks

}
