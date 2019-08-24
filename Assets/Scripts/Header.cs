using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Header : MonoBehaviour
{

	public enum State { MainMenu,Game};
	public State state;


	// Start is called before the first frame update
	void Start()
    {
		switch (state)
		{
			case State.MainMenu:
			GameManager.instance.timerText.gameObject.SetActive(false);
				break;
			case State.Game:
				GameManager.instance.timerText.gameObject.SetActive(true);
				break;
			default:
				break;


		}
    }

   
}
