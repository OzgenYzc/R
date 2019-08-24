using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Game : MonoBehaviour
{
	float chapterTimer=0;
    // Start is called before the first frame update
    void Start()
    {
		ChapterTimer();
		//	EnemyControl.instance.Init();
		StartCoroutine(EnemyControl.instance.LineUpPool());
	}

    // Update is called once per frame
    void Update()
    {


	
	}

	private void OnEnable()
	{
	}

	void ChapterTimer()
	{

		chapterTimer++;
		GameManager.instance.timerText.text = chapterTimer.ToString();

		Invoke("ChapterTimer", 1.0f);
	}
}
