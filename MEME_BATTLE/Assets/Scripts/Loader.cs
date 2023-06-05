using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
	private InputManager _inputManager = new InputManager();
	void Start()
	{
		_inputManager.SetDefault();
		SceneManager.LoadScene("MainMenu");
	}
}
