
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
	

	public Text countText;
	private int count;

	public Camera FPcam;


	public LayerMask kiwiMask;
	//public GameObject Menu;

	public GameObject pausePanel;



	// Start is called before the first frame update
	void Start()
	{
		

		//cam = Camera.main;

		count = 0;
		SetCountText();

		//Ray ray;

		pausePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(1)) 
		{
			Ray ray = FPcam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

				//Debug_Draws the raycast
				Debug.DrawRay(transform.position, transform.position, Color.red, 6, false);


			//Score System
			if (Physics.Raycast(ray, out hit, 1000f))
			{
				Debug.Log("We hit " + hit.collider.name + " " + hit.point);

				if (hit.collider.gameObject.tag == "Common")
				{
					Debug.Log("Common");
					count = count + 100;
					SetCountText();
				}
				if (hit.collider.gameObject.tag == "Rare")
				{
					Debug.Log("Rare!");
					count = count + 250;
					SetCountText();
				}
				if (hit.collider.gameObject.tag == "Legendary")
				{
					Debug.Log("LEGENDARY!!!");
					count = count + 1000;
					SetCountText();
				}
			}
		}
		//}
	}

	void FixedUpdate()
	{
		
		if (Input.GetKeyDown(KeyCode.F)) //Change to Keycode.Escape
		{
			//Menu.SetActive(!Menu.activeInHierarchy);
			if (!pausePanel.activeInHierarchy)
			{
				PauseGame();
			}
			else
			{
				if (pausePanel.activeInHierarchy)
				{
					ContinueGame();
				}
			}
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

	}

	private void PauseGame()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}

	private void ContinueGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}
}