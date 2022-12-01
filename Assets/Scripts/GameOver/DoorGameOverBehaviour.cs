using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class DoorGameOverBehaviour : MonoBehaviour {
    public int scenenumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (scenenumber == 666)
                {
                    Debug.Log("saiu");
                    UnityEditor.EditorApplication.isPlaying = false;
                    Application.Quit();
                }
                else
                {
                    SceneManager.LoadScene(scenenumber);
                }
            }
        }
    }
}
