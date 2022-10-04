using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4.0f;
 

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        var moveY = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        transform.Translate(moveX, moveY, 0);
    }
}
