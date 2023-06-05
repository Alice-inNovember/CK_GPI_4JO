using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] private GameObject inputFieldOBJ;
    
    private TMP_InputField _inputField;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _inputField = inputFieldOBJ.GetComponent<TMP_InputField>();
    }

    public void OnSelect()
    {
        _inputField.text = "";
    }
    
    public void OnEdit()
    {
        if(_inputField.text.Length > 1)
            _inputField.text = "";
    }
}
