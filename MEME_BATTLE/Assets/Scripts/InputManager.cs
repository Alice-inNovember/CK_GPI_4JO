using System;
using System.Collections.Generic;
using UnityEngine;

public enum EKey
{
	Null,
	Left,
	Right,
	Jump,
	Action1,
	Cnt
}
public class InputManager : Singleton<InputManager>
{
	public static Dictionary<EKey, KeyCode> Player01 = new Dictionary<EKey, KeyCode>();
	public static Dictionary<EKey, KeyCode> Player02 = new Dictionary<EKey, KeyCode>();
	

	public void SetDefault()
	{
		Player01.Add(EKey.Left, KeyCode.A);
		Player01.Add(EKey.Right, KeyCode.D);
		Player01.Add(EKey.Jump, KeyCode.W);
		Player01.Add(EKey.Action1, KeyCode.LeftControl);
		Player02.Add(EKey.Left, KeyCode.LeftArrow);
		Player02.Add(EKey.Right, KeyCode.RightArrow);
		Player02.Add(EKey.Jump, KeyCode.UpArrow);
		Player02.Add(EKey.Action1, KeyCode.RightArrow);
	}

	public void SetInput(EKey key, KeyCode code, bool player)
	{
		Dictionary<EKey, KeyCode> op = player ? Player01 : Player02;

		if (!op.ContainsKey(key))
			return;
		op[key] = code;
	}
}
