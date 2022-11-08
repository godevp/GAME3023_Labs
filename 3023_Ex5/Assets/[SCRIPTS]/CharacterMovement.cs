using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4.0f;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal") ;
        var moveY = Input.GetAxisRaw("Vertical");
        if (moveX != 0.0f)
        {
            moveX = (moveX > 0.0f) ? 1.0f : -1.0f;
        }
        
        if(moveY != 0.0f)
        {
            moveY = (moveY > 0.0f) ? 1.0f : -1.0f;
        }
      

        if (moveY == 0)
        {
            _animator.SetBool("MoveYZero", true);
        }
        else
        {
            _animator.SetBool("MoveYZero", false);
        }
        if (moveX == 0)
        {
            _animator.SetBool("MoveXZero", true);
        }
        else
        {
            _animator.SetBool("MoveXZero", false);
        }

        _animator.SetFloat("MoveY", moveY);
        _animator.SetFloat("MoveX", moveX);


        transform.Translate(moveX * Time.deltaTime * _speed, moveY * Time.deltaTime * _speed, 0);
    }
}
