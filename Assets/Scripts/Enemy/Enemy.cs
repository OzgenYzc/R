using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
	public static Enemy instance;
	public string name;
	public int age;
	public string mood;
	public string type;
	public string enemyPosition;
	//	public EnemyControl.Mood _mood;
	//	public EnemyControl.Type _type;
	private NavMeshAgent navMeshAgent;


	private void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();

		if (enemyPosition == "Bed" || enemyPosition
			=="Cradle" ||  enemyPosition=="ElderlyBed" || enemyPosition=="TeenageBed")
		{
			gameObject.GetComponent<FieldOfView>().viewAngle = 0;

		}

		

	}

	public void Update()
	{
		StartCoroutine(EnemyScenario.instance.Father(navMeshAgent, enemyPosition));
		//EnemyScenario.instance.Father(1);
		//	transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Bed").transform.position, 100.0f * Time.deltaTime);


	}
	

}
