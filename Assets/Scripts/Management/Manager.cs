// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // The player's current score.
    private int playerScore;

    #region Properties

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
