using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Move Speed Passive")]
public class MoveSpeedPassive : PassiveSkill
{
    [SerializeField]
    private int value;

    public override void Execute(Player player) => player.AddMoveSpeed(value);
}
