using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Additional Attack")]
public class AdditionalAttack : PassiveSkill
{
    [SerializeField]
    private int value;

    public override void Execute(Player player) => player.AddAttack(value);
}