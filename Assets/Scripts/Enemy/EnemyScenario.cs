using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public  class EnemyScenario : MonoBehaviour
{
	public static EnemyScenario instance;
	private void Awake()
	{
		instance = this;
	}



	public IEnumerator Father(NavMeshAgent navMeshAgent,string enemyPosition)
	{
		if (enemyPosition == "Bed" || enemyPosition=="ElderlyBed" || enemyPosition=="TeenageBed")
			
		{
			yield return new WaitForSeconds(5.0f);
			if (GameObject.Find("Sofa").transform.position.x != gameObject.transform.position.x)
			{
				yield return new WaitForSeconds(2.0f);

				Debug.Log("Local : " + GameObject.Find("Bed").transform.localPosition + "	Pos" + GameObject.Find("Bed").transform.position + "	Loc" +
					gameObject.transform.localPosition + "	Pos" + gameObject.transform.position);



				navMeshAgent.SetDestination(GameObject.Find("Sofa").transform.position);

			}

		}
		else if (enemyPosition == "Kitchen")
		{
			yield return new WaitForSeconds(5.0f);

			if (GameObject.Find("Bed").transform.position.x != gameObject.transform.position.x)
			{
				yield return new WaitForSeconds(2.0f);

				Debug.Log("Local : " + GameObject.Find("Bed").transform.localPosition + "	Pos" + GameObject.Find("Bed").transform.position + "	Loc" +
					gameObject.transform.localPosition + "	Pos" + gameObject.transform.position);



				navMeshAgent.SetDestination(GameObject.Find("Bed").transform.position);

			}
		}


		Invoke("Father", 0.1f);
	}
	//FatherScenario
}
