using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarController : MonoBehaviour {

    public PlayerController pController;
    private Image content;
	// Use this for initialization
	void Start () {
        content = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        content.fillAmount = (pController.Mana / pController.MaxMana);
	}
}
