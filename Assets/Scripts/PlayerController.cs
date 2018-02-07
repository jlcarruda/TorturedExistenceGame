using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Platformer2DUserControl platformerController;
    private Animator animator;
    private float mana;
    private float maxMana;
    private float manaRegen = 0.2f;

    public float Mana
    {
        get
        {
            return mana;
        }

        set
        {
            mana = value;
        }
    }

    public float MaxMana
    {
        get
        {
            return maxMana;
        }

        set
        {
            maxMana = value;
        }
    }

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        platformerController = GetComponent<Platformer2DUserControl>();
        mana = 100;
        maxMana = 100;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            teleportToBody();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            killNPC();
        }

        mana += manaRegen;
	}

    void teleportToBody()
    {
        if(mana >= 20)
        {
            // We will need to cast a ray from the camera to the point where the mouse was clicked
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                mana -= 20;
                NPCController npcController = hit.collider.gameObject.GetComponent<NPCController>();
                //NPCController npcController = hit.transform.gameObject.GetComponent<NPCController>();

                if (npcController.IsDead)
                {
                    var pos = transform.position;
                    transform.position = npcController.transform.position;
                    npcController.transform.position = pos;
                }
            }
        }
    }

    void killNPC()
    {
        if(mana >= 50)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                mana -= 50;
                NPCController npcController = hit.collider.gameObject.GetComponent<NPCController>();
                npcController.IsDead = true;
            }
        }
    }

    public void kill()
    {
        Destroy(platformerController);
        Destroy(GetComponent<SpriteRenderer>());
    }
}
