using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    [Header("Var's de boxes para movimento")]
    public GameObject bckBox;
    public GameObject fwdBox;
	public PlayerBehaviour player;
    public Rigidbody2D playerRbd;
	bool moving;
    bool uping;
    bool downing;
	// Use this for initialization
	void Start () {
		moving = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxisRaw("Horizontal") == 1)
        {
            bckBox.SetActive(false);
            fwdBox.SetActive(true);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            bckBox.SetActive(true);
            fwdBox.SetActive(false);
        }
		if (moving) {
			MoveCamera ();
		}
        if (downing)
        {
            DownCamera();
        }
        if (uping)
        {
            UpCamera();
        }
        if (playerRbd.velocity.y <= 0)
        {
            uping = false;
        }
        if (playerRbd.velocity.y >= 0)
        {
            downing = false;
        }
    }
    //********************************************
	public void MoveCamera()
    {
        
		transform.Translate(new Vector3((Input.GetAxisRaw("Horizontal") * player.speed) * Time.deltaTime , 0, 0));
		//transform.SetPositionAndRotation(new Vector3(player.transform.position.x + space, 0,-10), new Quaternion(0,0,0,0));
    }
    public void UpCamera()
    {

        //transform.Translate(new Vector3((Input.GetAxisRaw("Horizontal") * player.speed) * Time.deltaTime, 0, 0));
        transform.SetPositionAndRotation(new Vector3(transform.position.x, player.transform.position.y - 3.3f, -10), new Quaternion(0,0,0,0));
        
    }
    public void DownCamera()
    {

        transform.SetPositionAndRotation(new Vector3(transform.position.x, player.transform.position.y + 3.3f, -10), new Quaternion(0, 0, 0, 0));
        //transform.SetPositionAndRotation(new Vector3(player.transform.position.x + space, 0,-10), new Quaternion(0,0,0,0));
    }
    public void SetMoving(bool moveng){
		moving = moveng;
	}
    public void SetUping(bool moveng)
    {
       uping = moveng;
    }
    public void SetDowning(bool moveng)
    {
        downing = moveng;
    }
}
