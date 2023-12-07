using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterStates states;
    CharacterController Controller;
    Animator anim ;
    public float Speed = 5;
    Transform cam;
    float gravity = 10;
    float verticalVelocity = 10;
    public float jumpValue = 10; 

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        anim = GetComponentInChildren<Animator>();
        states = GetComponent<CharacterStates>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isSprint = Input.GetKey(KeyCode.LeftShift);
        float sprint = isSprint ? 1.7f : 1;

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        anim.SetFloat("Speed", Mathf.Clamp( moveDirection.magnitude,0,0.5f) + (isSprint ? 0.5f : 0));


        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }


        if(Controller.isGrounded)
        { 
            if (Input.GetAxis("Jump") > 0)
                verticalVelocity = jumpValue;
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;



        // rotation of character
        if (moveDirection.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        moveDirection = cam.TransformDirection(moveDirection);

        moveDirection = new Vector3(moveDirection.x * Speed * sprint, verticalVelocity, moveDirection.z * Speed * sprint);
                

        //Movement
        Controller.Move(moveDirection * Time.deltaTime );

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            //Debug.Log("Health increased!");
            GetComponent<CharacterStates>().ChangeHealth(20);
            FindObjectOfType<audioManager>().Play("CollectHeart");
            Instantiate(LevelManager.instance.Particles[1], other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Item"))
        {
            LevelManager.instance.levelItems++;
            Debug.Log("items: " + LevelManager.instance.levelItems);
            FindObjectOfType<audioManager>().Play("CollectItem");
            Instantiate(LevelManager.instance.Particles[0], other.transform.position, other.transform.rotation);
            Destroy(other.gameObject); 
        }



    }




    public void DoAttack()
    {
        transform.Find("Colider").GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(HideCollider());
    }

    IEnumerator HideCollider()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("Colider").GetComponent<BoxCollider>().enabled = false;

    }


}
