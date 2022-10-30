using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI name;

    private Dictionary<string, int> HighScoreBillBoard;
    private string currentPlayerName;
    private int currentPlayerPoint;

    private void Start()
    {
        currentPlayerPoint = Int32.Parse(FileHandler.Instance.readProcess());
        HighScoreBillBoard = FileHandler.Instance.readHighScore();
    }

    public void CheckHighScore()
    {
        currentPlayerName = name.text;
        HighScoreBillBoard.Add(currentPlayerName, currentPlayerPoint);
        var newHighScore = HighScoreBillBoard.OrderByDescending(x => x.Value);
    }
}
