// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingMovement : MonoBehaviour
{
    // Starting/ending points of the buildingPair.
    private Vector2 startPos, resetPoint;

    // End/Start of movement points, reset once here.
    [SerializeField] private float startX, resetX;

    // How fast the buildinPair moves.
    [SerializeField] private float moveSpeed; 

    /// <summary> coroutine <c>MoveAcross</c> moves the buildingPair across the screen then back agian. </summary>
    private IEnumerator MoveAcross()
    {
        // Update start Y & feed that to resetPoint. 
        startPos = new Vector2(startPos.x, Random.Range(-12, 1));
        resetPoint = new Vector2(resetX, startPos.y);

        // Update positon.
        transform.position = new Vector2(transform.position.x, startPos.y);

        // Move across cam view before reaching end point.
        while (true)
        {
            // Move towards the new pos.
            transform.position = Vector2.MoveTowards(transform.position, resetPoint,               
                moveSpeed * Time.deltaTime);

            // When resetPoint is reached, reset positon.         
            if (transform.position.x <= resetPoint.x) 
            {
                // Update start Y & feed that to resetPoint. 
                startPos = new Vector2(startPos.x, Random.Range(-12, 1));
                resetPoint = new Vector2(resetX, startPos.y);

                // Reset pos.
                transform.position = startPos;            
            }

            // Satisfys return req.
            yield return null;
        }
    }

    void Start()
    {
        // Sets ref to start pos.
        startPos = new Vector2(startX, transform.position.y);

        // Update resetPoint to incorp start Y.
        resetPoint = new Vector2(resetX, transform.position.y);

        // Begin starting move rotation.
        StartCoroutine(MoveAcross());
    }
}
