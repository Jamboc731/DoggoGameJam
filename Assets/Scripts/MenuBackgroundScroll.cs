using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBackgroundScroll : MonoBehaviour {

    public float scrollSpeed = 0.5f;

    public GameObject background;

    public Renderer backRend;

	// Use this for initialization
	void Start () {
        backRend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        backRend.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed / 2, Time.time * scrollSpeed / -2);
	}
}
