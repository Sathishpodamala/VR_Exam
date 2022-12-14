using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPallet : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject colorpallet;
    [SerializeField]private List<Button> colorButtons=new List<Button>();
    [SerializeField]private MaterialChanger changer;
    public static ColorPallet instance;
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        instance =this;
    }
    #endregion Unity Methods

    #region Public Methods
    public void OnColorSelected(int index)
    {
        if(changer)
        {
            changer.ChangeColor(colorButtons[index].image.color);
        }
    }

    public void Enablepallet()
    {
        colorpallet.SetActive(true);
    }

    public void DisablePallet()
    {
        colorpallet.SetActive(false);
        changer=null;
    }

    public void SetMaterialChanger(MaterialChanger changer)
    {
        this.changer = changer;
    }
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
    
}
