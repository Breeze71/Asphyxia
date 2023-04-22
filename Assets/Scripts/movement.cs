using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private InputProvider inputProvider;
    private Rigidbody2D rb;
    
    [Header("Movement")]
    public float moveSpeed = 5f;
    public bool canMove = true;

    [Header("Animations")]
    private Animator anim;
    private bool isFlip = true;


    private void OnEnable()
    {
        inputProvider = new InputProvider();

        // inputProvider.P1Grab += GrabFunction;
        inputProvider.Enable();
    }
    private void OnDisable() 
    {
        // inputProvider.P1Grab -= GrabFunction;
        inputProvider.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //pickUpItem = gameObject.GetComponent<PickUpItem>();
        //pickUpItem.Direction = new Vector3(0 , -1); // 初始方位
        anim.SetFloat("moveX" , 0);
        anim.SetFloat("moveY" , -1);
    }
    
    private void Update() 
    {
        if(canMove)
        {
            rb.velocity = inputProvider.Walk() * moveSpeed;
        }
        //playerAnim();
    }

    private void playerAnim()
    {
        if(inputProvider.Walk() == Vector2.zero)
        {
            anim.SetBool("walking" , false);
            return;
        }
                                // 回傳整數，避免有介於兩者之間的判斷問題 (0.5,0.5) 要算右還是上
        anim.SetFloat("moveX" , Mathf.Round( inputProvider.Walk().x ));
        anim.SetFloat("moveY" , Mathf.Round( inputProvider.Walk().y ));
        anim.SetBool("walking" , true);

        if(inputProvider.Walk().x > 0 && isFlip)
        {
            flip();
        }
        if(inputProvider.Walk().x < 0 && !isFlip)
        {
            flip();
        }
    }

    private void flip()
    {
        transform.Rotate(Vector2.up , 180);
        isFlip = !isFlip;
    }
}
