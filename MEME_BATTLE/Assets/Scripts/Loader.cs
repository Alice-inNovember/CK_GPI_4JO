using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
	private InputManager _inputManager;
	void Start()
	{
		_inputManager = new InputManager();
		_inputManager.SetDefault();
		SceneManager.LoadScene("BattleScene");
	}
}
