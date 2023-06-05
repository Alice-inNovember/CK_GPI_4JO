using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PassiveType
{
    Start,  // ������ �� �� ���� �����ϴ� ��ų
    Update  // ��������� �����ϴ� ��ų (��: ���Ǻ� ��ų)
}

public abstract class PassiveSkill : ScriptableObject
{
    public string skillName;
    public Sprite sprite;
    public PassiveType type;

    public abstract void Execute(Player player);
}