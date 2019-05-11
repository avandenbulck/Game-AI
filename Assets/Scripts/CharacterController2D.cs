using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float maxVelocity;

    Transform trans;
    // Start is called before the first frame update
    void Awake()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxisRaw("Horizontal");
        float deltaY = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector2(deltaX, deltaY);

        if(inputDirection.magnitude > 0)
        {
            trans.position += inputDirection.normalized * maxVelocity * Time.deltaTime;
        }
    }
}
