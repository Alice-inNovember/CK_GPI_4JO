using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomKeybindUI : MonoBehaviour
{
    private InputManager _inputManager;
    private bool _active;
    
    [SerializeField] private bool player2;
    [SerializeField] private EKey key;
    [SerializeField] private TextMeshProUGUI buttonLbl;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = new InputManager();
        buttonLbl.text = _inputManager.GetInput(key, !player2).ToString();
    }
    void Update()
    {
        if (_active)
        {
            buttonLbl.text = "Waiting...";
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    _inputManager.SetInput(key, keyCode, !player2);
                    buttonLbl.text = keyCode.ToString();
                    _active = false;
                }
            }
        }
    }

    public void ReBindStartB()
    {
        _active = true;
    }
}
