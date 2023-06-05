using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Meme Character", menuName = "Character/Meme")]
public class MemeCharacter : ScriptableObject
{
    public string memeName;
    public Sprite sprite;
    public byte life;
    public int attackPower;
    public int weight;
}