using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1f;

    Rigidbody2D myRigidBody2D;
    BoxCollider2D myBoxCollider2D;
    Animator animator;

    bool isInInteractionRadius;
    [SerializeField] GameObject interactionObject;

    bool frozen;
    [SerializeField] float waitTime = 2;
    bool canSelectNextOption = true;

    bool inMenu = false;
    bool inInventory = false;

    Inventory inventory;

    [SerializeField] int dollars = 100;

    [SerializeField] Clothes shirt;
    [SerializeField] Clothes pants;
    [SerializeField] Clothes hat;

    [SerializeField] GameObject body;
    [SerializeField] GameObject arm1;
    [SerializeField] GameObject arm2;
    [SerializeField] GameObject leg1;
    [SerializeField] GameObject leg2;
    [SerializeField] GameObject crotch;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        CheckForInput();
        MovePlayer();
    }

    void MovePlayer()
    {
        if (!frozen)
        {
            float movementX = Input.GetAxis("Horizontal");
            float movementY = Input.GetAxis("Vertical");

            if ((int)movementX > 0 & (int)movementY > 0)
            {
                AnimateSelfAndClothes("isWalkingRight");
            }
            else if ((int)movementX < 0 & (int)movementY < 0)
            {
                AnimateSelfAndClothes("isWalkingLeft");
            }
            else if ((int)movementX < 0 & (int)movementY > 0)
            {
                AnimateSelfAndClothes("isWalkingLeft");
            }
            else if ((int)movementX > 0 & (int)movementY < 0)
            {
                AnimateSelfAndClothes("isWalkingRight");
            }
            else if ((int)movementX > 0 & (int)movementY == 0)
            {
                AnimateSelfAndClothes("isWalkingRight");
            }
            else if ((int)movementX == 0 & (int)movementY > 0)
            {
                AnimateSelfAndClothes("isWalkingUp");
            }
            else if ((int)movementX < 0 & (int)movementY == 0)
            {
                AnimateSelfAndClothes("isWalkingLeft");
            }
            else if ((int)movementX == 0 & (int)movementY < 0)
            {
                AnimateSelfAndClothes("isWalkingDown");
            }
            else if((int)movementX == 0 & (int)movementY == 0)
            {
                AnimateSelfAndClothes("isIdle");
            }
            myRigidBody2D.velocity =
            new Vector2(movementX * movementSpeed, movementY * movementSpeed);
            

        }
    }


    void AnimateSelfAndClothes(string direction)
    {
        animator.SetTrigger(direction);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<speech>())
        {
            collider.gameObject.GetComponent<speech>().Standby();
            interactionObject = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<speech>())
        {
            collider.gameObject.GetComponent<speech>().Idle();
        }
    }

    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (myBoxCollider2D.IsTouching(FindObjectOfType<speech>().GetComponent<PolygonCollider2D>()))
            {
                if (!inMenu)
                {
                    Freeze();
                    interactionObject.GetComponent<speech>().UpdateText();
                }
                else if (inMenu)
                {
                    FindObjectOfType<Shop>().LeaveShop();
                    frozen = false;
                    inMenu = false;
                }
            }

            else
            {
                if (!inInventory)
                {
                    Freeze();
                    inventory.ConstructInventoryMenu();
                    inInventory = true;
                }
                else if (inInventory)
                {
                    inventory.LeaveInventory();
                    inInventory = false;
                    frozen = false;
                }
            }
        }

    }
    



    private void Freeze()
    {
        frozen = true;
        myRigidBody2D.velocity = new Vector2(0, 0);
    }

    public void SetInMenu(bool isInMenu)
    {
        inMenu = isInMenu;
    }

    public int GetDollars()
    {
        return dollars;
    }

    public void RemoveDollars(int amount)
    {
        dollars -= amount;
    }

    public void SetPants(Clothes pants)
    {
        leg1.GetComponent<SpriteRenderer>().sprite = pants.GetLeg();
        leg2.GetComponent<SpriteRenderer>().sprite = pants.GetLeg();
        crotch.GetComponent<SpriteRenderer>().sprite = pants.GetCrotch();
    }

    public void SetShirt(Clothes shirt)
    {
        body.GetComponent<SpriteRenderer>().sprite = shirt.GetBody();
        arm1.GetComponent<SpriteRenderer>().sprite = shirt.GetArm();
        arm2.GetComponent<SpriteRenderer>().sprite = shirt.GetArm();
    }

}

