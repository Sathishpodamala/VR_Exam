using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialChanger : MonoBehaviour
{
    #region Variables
    [SerializeField]private MeshRenderer meshRenderer;
     private Material material;

    #endregion Variables

    #region Unity Methods
    private void Start()
    {
        if(meshRenderer == null)
            meshRenderer = GetComponent<MeshRenderer>();
        material=meshRenderer.material;
    }
    #endregion Unity Methods

    #region Public Methods
    public void ChangeColor(Color color)
    {
       material.color=color;
    }
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
    
}
