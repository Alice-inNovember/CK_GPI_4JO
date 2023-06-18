using TMPro;
using UnityEngine;
using Slider = UnityEngine.UIElements.Slider;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverObj;
        [SerializeField] private TextMeshProUGUI gameOverText;


        [SerializeField] private GameObject p1LifeObj;
        [SerializeField] private GameObject p2LifeObj;

        [SerializeField] private TextMeshProUGUI p1HitCntText;
        [SerializeField] private TextMeshProUGUI p2HitCntText;

        private void Start()
        {
            gameOverObj.SetActive(false);
        }

        //화면 UI에 맞은 수 표시
        //맞을시 호출 cnt=맞은횟수 isP1=플래이어
        public void SetHitCountNbr(int cnt, bool isPlayer1)
        {
            if (isPlayer1 == true)
                p1HitCntText.text = (cnt * 23.8 - (cnt / 4.2)).ToString() + "%";
            else
                p2HitCntText.text = (cnt * 23.8 - (cnt / 4.2)).ToString() + "%";
        }

        public void SetDisplayLife(int life, bool isPlayer1)
        {
            if (isPlayer1)
                p1LifeObj.GetComponent<UnityEngine.UI.Slider>().value = life;
            else
                p2LifeObj.GetComponent<UnityEngine.UI.Slider>().value = life;
        }

        public void GameOver(bool isPlayer1)
        {
            if (isPlayer1)
                gameOverText.text = "Player " + "1" + " WIN";
            else
                gameOverText.text = "Player " + "2" + " WIN";
            gameOverObj.SetActive(true);
        }
    }
}