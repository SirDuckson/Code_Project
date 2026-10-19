using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectcontrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 90f;
    [SerializeField] private float sprint = 10f;
    [SerializeField] private float sneak = 5f;
    [SerializeField] bool isSneak;
    [SerializeField] GameObject player;
    [SerializeField]
    private energy Energy;
    [SerializeField] float SprintUse = 10f;

    // Update is called once per frame
    private void Start()
    {
        Energy = GameObject.FindAnyObjectByType<energy>();
    }
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleSprint();
        HandleSneak();
       

    }
    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

   
    }

    void HandleRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    void HandleSprint()
    {
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Energy.CurrentEnergy > 10f))
        {
            transform.Translate(Vector3.forward * sprint * Time.deltaTime);
            Energy.UseEnergy(SprintUse);
        }
          

        
    }

    void HandleSneak()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isSneak = true;
        }
        else
        {
            isSneak = false;
        }
        if (isSneak)
        {
            Sneaking();
        }
        else
        {
            NotSneaking();
        }
    }

    public void Sneaking()
    {
        player.transform.localScale = new Vector3(1, 0.5f, 1);
    }
    public void NotSneaking()
    {
        player.transform.localScale = new Vector3(1, 1, 1);
    }

}


