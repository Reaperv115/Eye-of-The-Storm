using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerScore = 0;
    public int pointsperKill = 1;

    TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("points").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = playerScore.ToString();
    }
}
