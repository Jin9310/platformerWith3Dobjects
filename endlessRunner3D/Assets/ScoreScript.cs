using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public Transform player;
    public TMP_Text score;

    void Update()
    {
        score.text = player.position.x.ToString("0") + " m";
    }
}
