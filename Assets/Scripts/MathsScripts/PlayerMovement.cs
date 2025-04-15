using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float playerSpeed;
    //public float horizontalSpeed = 20f;
    public float rightLimit = 40f;
    public float leftLimit = -40f;

    bool buttonLeftPressed=false;
    bool buttonRightPressed=false;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PointerDownLeft()
    {
        buttonLeftPressed = true;
    }
    public void PointerUpLeft()
    {
        buttonLeftPressed = false;
    }
    public void PointerDownRight()
    {
        buttonRightPressed = true;
    }
    public void PointerUpRight()
    {
        buttonRightPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager == null || gameManager.health <= 0)
            return;

        float forwardSpeed = gameManager.runnerSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);
        float sideSpeed = gameManager.horizontalSpeed;


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || buttonLeftPressed)
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
            }
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || buttonRightPressed)
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * -1);
            }
        }


    }

}
