using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //public float slots = 100;

    public Text levelScore;
    public int score = 0;

    private void Update()
    {
        levelScore.text = score.ToString();
    }
}
