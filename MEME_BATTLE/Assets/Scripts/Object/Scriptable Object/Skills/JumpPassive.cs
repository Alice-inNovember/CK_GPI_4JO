using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Jump Passive")]
public class JumpPassive : PassiveSkill
{
    [SerializeField]
    private int value;

    public override void Execute(Player player) => player.AddJumpForce(value);
}
