using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialGravity : MonoBehaviour
{
    private Vector2 _gravityAngle;
    public Vector2 gravityAngle
    {
        get
        {
            return _gravityAngle;
        }
        set
        {
            if (value.GetType() == typeof(Vector2) || value.GetType() == typeof(Vector3))
            {                
                _gravityAngle = GravityVectorModifier(value);
                //Debug.Log("gravity unit vector after modification is " + _gravityAngle);
            }
            else
            {
                //Debug.Log("you cannot see the gravity angle to <" + value + "> as it is not a vector2");
            }
        }
    }
    public int gravityStrength = 600;
    private float yHeight = -0.5f;
    private float leftX;
    private float rightX;
    private float accelX;
    private float speed = 120;

    public Vector2 accelVector = new Vector2();

    public Rigidbody2D playerRb;
    private void Start()
    {
        rightX = Mathf.Cos(Mathf.Asin(yHeight));
        //Debug.Log(rightX);
        leftX = -Mathf.Cos(Mathf.Asin(yHeight));
        //Debug.Log(leftX);
    }

    // Update is called once per frame
    void Update()
    {
        accelX = Input.acceleration.x * 4;
        accelVector.x = accelX;
        accelVector.y = -1;
        
        Gravity();
        gravityStrength += 1;
    }

    void Gravity()
    {
        if (Singleton.Instance.isSlidered == true)

        {

            playerRb.AddForce(gravityAngle * gravityStrength * Time.deltaTime);

        }

        else if (Singleton.Instance.isTilted == true)

        {

            playerRb.AddForce(accelVector * gravityStrength * Time.deltaTime);



        }

        else if (Singleton.Instance.isTouched == true)

        {

            //touch gravity code

        }
    }

    Vector2 GravityVectorModifier(Vector2 newVector)
    {
        Vector2 returnThis = Vector2.down;        
        Vector2 unitVector = newVector.normalized;
        //Debug.Log(unitVector);
        //Debug.Log(unitVector.y);
        //Debug.Log(unitVector.x);

        //gets the unit vector and converts it to a vector in the accepted range
        if (unitVector.y > -0.707f)
        {
            //if the vector is angled to far up on y axis it sets it to -0.707( sin(45) )
            returnThis = new Vector2(returnThis.x, -yHeight);
            //Debug.Log("y to large");
        }
        else
        {
            //if its not larger that the limit it passes it to the retrurn value
            returnThis = new Vector2(returnThis.x, unitVector.y);
            //Debug.Log("y within range");
        }

        if (unitVector.x < -0.707)
        {
            //tests if the x is out of the accepted range the in the negative zone
            returnThis = new Vector2(leftX, returnThis.y);
            //Debug.Log("x to small");
        }
        else if(unitVector.x > 0.707)
        {
            //tests if the x is out of the accepted range the in the positive zone
            returnThis = new Vector2(rightX, returnThis.y);
            //Debug.Log("x to large");
        }
        else
        {
            //if it gets to this then it is assumed that it is in the accepted y range, note it can get to this point even it the y was in the positive
            returnThis = new Vector2(unitVector.x, returnThis.y);
            //Debug.Log("x within range");
        }
        return returnThis;
    }
    
    //uses this for modifying turn angle with 
    public void ChangeGravityAngleSlider(float value)
    {
        // getting angle from 0 (note rangeis from -45 to -135 degrees
        float angle = 0;
        if (value < 0)
        {
            angle = Mathf.Deg2Rad* (-90 - 45 * Mathf.Abs(value));
            //Debug.Log(-90 - 45 * value);
            //Debug.Log(angle);
        }
        else if ( value > 0)
        {
            angle = Mathf.Deg2Rad*(-90 + 45 * value);
            //Debug.Log(-90 + 45 * Mathf.Abs(value));
            //Debug.Log(angle);
            //Debug.Log(angle);

        }
        else if(value == 0)
        {
            angle =  Mathf.Deg2Rad * (-90);
        }
        gravityAngle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }








}
