using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button moveButton; 
    public Transform objectToMove; 

    private bool isMoving = false;
    private Vector3 targetPosition = Vector3.zero; 

    void Start()
    {
       
        moveButton.onClick.AddListener(MoveObjectOnClick);
    }

    void Update()
    {
        if (isMoving)
        {
            float moveSpeed = 5f;
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);

            if (objectToMove.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    void MoveObjectOnClick()
    {
        if (!isMoving)
        {

            targetPosition = new Vector3(
                Random.Range(-5f, 5f), 
                objectToMove.position.y, 
                Random.Range(-5f, 5f)  
            );


            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}