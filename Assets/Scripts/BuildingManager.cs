using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	public static BuildingManager instance;

	[Header("SpawnPoints - in House")]
	public Transform sofa;
	public Transform bed;
	public Transform edlerlyBed;
	public Transform teenageBedRoom;
	public Transform frontofComputer;
	public Transform cradle;
	public Transform[] kitchen = new Transform[2];

	

	private void Awake()
	{
		instance = this;
	}
}
