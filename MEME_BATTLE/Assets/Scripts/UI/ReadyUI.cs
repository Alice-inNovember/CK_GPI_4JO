using UnityEngine;
using UnityEngine.UI;

public class ReadyUI : MonoBehaviour
{
    [SerializeField]
    private Image decisionMeme;

    public void SetMeme(Sprite sprite) => decisionMeme.sprite = sprite;
}
