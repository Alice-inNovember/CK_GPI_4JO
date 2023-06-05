using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PassiveType
{
    Start,  // 시작할 때 한 번만 실행하는 스킬
    Update  // 계속적으로 실행하는 스킬 (예: 조건부 스킬)
}

public abstract class PassiveSkill : ScriptableObject
{
    public string skillName;
    public Sprite sprite;
    public PassiveType type;

    public abstract void Execute(Player player);
}