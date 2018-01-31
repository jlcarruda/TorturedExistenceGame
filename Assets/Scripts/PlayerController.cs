using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public LayerMask layerMask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            teleportToBody();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            kill();
        }
	}

    void teleportToBody()
    {
        // We will need to cast a ray from the camera to the point where the mouse was clicked
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            NPCController npcController = hit.collider.gameObject.GetComponent<NPCController>();
            if (npcController.IsDead)
            {
                var pos = transform.position;
                transform.position = npcController.transform.position;
                npcController.transform.position = pos;
            }
        }
    }

    void kill()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null)
        {
            NPCController npcController = hit.collider.gameObject.GetComponent<NPCController>();
            npcController.IsDead = true;
        }
    }
}
