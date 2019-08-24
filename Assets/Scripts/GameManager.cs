using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[Header("Header")]
	public TextMeshProUGUI timerText;
	// Start is called before the first frame update

	private void Awake()
	{
		instance = this;
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
