using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    //this will be the id of the customer
    public int CustomerNumber;
    //this is the order script for the right customer
    public Order OrderRight;
    //this is the order script for the Middle customer
    public Order OrderMiddle;
    //this is the order script for the Left customer
    public Order OrderLeft;

    private Animator _animation;
    private bool _walking = false;
    private bool _walkBack = false;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_walking && !_walkBack)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 1.5f);
        } 
        else if(_walkBack)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 1.5f);
        }
        
    }

    public void IsFinished(bool _finished, int _whichCustomer)
    {
        if (_whichCustomer == CustomerNumber)
        {
            if (_finished)
            {
                _animation.SetBool("IsFinished", true);
                _walkingClass();
            }
            else
                _animation.SetBool("IsFinished", false);
        }
    }

    private void _walkingClass()
    {
        _walking = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        
    }
    private void OnCollisionEnter(Collision _collision)
    {

        if (_walkBack)
        {
            if (_collision.gameObject.name == "Seat1" && CustomerNumber == 3)
            {
                _walkBack = false;
                _walking = false;
                _animation.SetBool("IsFinished", false);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
                OrderRight.GenerateOrder();
            }
            else if (_collision.gameObject.name == "Seat2" && CustomerNumber == 2)
            {
                _walkBack = false;
                _walking = false;
                _animation.SetBool("IsFinished", false);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
                OrderMiddle.GenerateOrder();
            }
            else if (_collision.gameObject.name == "Seat3" && CustomerNumber == 1)
            {
                _walkBack = false;
                _walking = false;
                _animation.SetBool("IsFinished", false);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
                OrderLeft.GenerateOrder();
            }
        }
        if(_collision.gameObject.name == "ReturnWall")
            _walkBack = true;

    }
}
