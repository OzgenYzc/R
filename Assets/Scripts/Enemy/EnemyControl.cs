/*
 * Düşmanların belirli hareketleri olacak.
 * Uyuyan veya bir işle meşgul olan düşmanlar belli yükseklikteki sese tepki verebilecekler.
 * Bunların dışında düşmanlar herhangi bir ses duymasalar bile bulundukları yerden kalkabilecekler.Örneğin tuvalete gitmek ya da gece uyanıp televizyon izlemek gibi.
 * Bu düşmanlar televizyon başına geçtiğinde  uyuklayabilecekler.
 * Karakterimizin evde saklanabileceği yerler olacak.Çünkü ışıklar açıldığı zaman düşmanların görüş açısı büyüyecek.
 * Ev halkının ruh hali olacak ruh haline göre ev içinde davranışları değişkenlik gösterebilecek.(Örneğin ; bilgisayar oynayan bir genç oyunda sinirlendiği zaman yerinden kalkıp su içmeye gidebilecek.
   Ya da odasında ses yapıp ailesinden birilerini uyandırabilir.)
 *Karakterlerin ismi ve tipleri random olacak.
 * 
 * 
 * 
 * 
 * Oyun başladığında Init ile çağrılacak.
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyControl : MonoBehaviour
{
	public static EnemyControl instance;
	public enum Type { Teen, Gamer, Woman, Man, Elderly, Baby };
	public enum Mood { Angry, Habitant, Weary }
	public Type type;
	public Mood mood;

	Enemy _enemy;
	public GameObject enemyPrefab;
//	public GameObject enemyObject;
	private string[] randomTypeArr;
	private string[] randomMoodArr;
	public string moodString;
	public string typeString;
	public string enemyPosition;
	GameObject enemyObject;

	public List<String> enemyTypeList;

	private void Awake()
	{
		instance = this;

	
	}

	
	public void Init()
	{
		EnemysSpawnControl();
		EnemysMood();
	}
	public IEnumerator LineUpPool()
	{
		int level = UnityEngine.Random.Range(0, 15);
		switch (level)
		{


			case 1:
				for (int i = 0; i < 1; i++)
				{
					//		EnemysType();
					EnemysSpawnControl();
					yield return new WaitForSeconds(1.0f);
				}
					break;
			default:
				for (int i = 0; i < 1; i++)
				{
					//			EnemysType();
					EnemysSpawnControl();
				//	yield return new WaitForSeconds(1.0f);
				}
				break;

		}
		

	}
	public void EnemysSpawnControl()
	{
		typeString = RandomType();
		
		Enum.TryParse(typeString, out type);
		enemyTypeList.Add(typeString);

		for(int i = 0; i < enemyTypeList.Count; i++)
		{

			if (enemyTypeList[i] == typeString)
			{
				
				enemyTypeList.Remove(typeString);
				typeString = RandomType();

				Enum.TryParse(typeString, out type);
				enemyTypeList.Add(typeString);

			}
		}
		
		
		

		moodString = RandomMood();
		Enum.TryParse(moodString, out mood);




	//	GameObject enemyObject = new GameObject();

		Debug.Log("Type : " + type);
		
		switch (type)
		{
			case Type.Teen:
				enemyObject = Instantiate(enemyPrefab, BuildingManager.instance.teenageBedRoom.position, Quaternion.identity);

				_enemy = enemyObject.GetComponent<Enemy>();
				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.name = "Albert";
				_enemy.enemyPosition = "teenageBedRoom";
				Debug.Log("Spawn : " + type);
				break;
			case Type.Gamer:
				enemyObject = Instantiate(enemyPrefab, BuildingManager.instance.frontofComputer.position, Quaternion.identity);

				_enemy = enemyObject.GetComponent<Enemy>();

				_enemy.mood = mood.ToString();
				_enemy.name = "Melo";
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "frontOfComputer";
				Debug.Log("Spawn : " + type);
				break;
			case Type.Woman:
				enemyObject = Instantiate(enemyPrefab, BuildingManager.instance.sofa.position, Quaternion.identity);
				_enemy = enemyObject.GetComponent<Enemy>();

				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "Sofa";
				_enemy.name = "Sarah";
				Debug.Log("Spawn : " + type);
				break;
			case Type.Man:
				int rndKitchen = UnityEngine.Random.RandomRange(0 , 1);
				enemyObject = Instantiate(enemyPrefab, BuildingManager.instance.kitchen[rndKitchen].position, Quaternion.identity);
				_enemy = enemyObject.GetComponent<Enemy>();

				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.name = "Killy";
				_enemy.enemyPosition = "Kitchen";//+ BuildingManager.instance.kitchen[rndKitchen].name;
				Debug.Log("Spawn : " + type);
				break;
			case Type.Elderly:
				enemyObject = Instantiate(enemyPrefab, BuildingManager.instance.edlerlyBed.position, Quaternion.identity);
				_enemy = enemyObject.GetComponent<Enemy>();

				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "ElderlyBed";
				_enemy.name = "Alonso";
				Debug.Log("Spawn : " + type);
				break;
			case Type.Baby:
				enemyObject = Instantiate(enemyPrefab, BuildingManager.instance.cradle.position, Quaternion.identity);
				_enemy = enemyObject.GetComponent<Enemy>();

				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "Cradle";
				_enemy.name = "Jonothan";
				Debug.Log("Spawn : " + type);
				break;
			default:
				break;

		}
	}
	public void EnemysMood()
	{

		typeString = RandomType();
		Enum.TryParse(typeString, out type);
		
		Debug.Log("Mood : " + mood);
		moodString = RandomMood();
		Enum.TryParse(moodString, out mood);
		GameObject enemyObject = enemyPrefab;

		_enemy = enemyObject.GetComponent<Enemy>();

		switch (mood)
		{
			case Mood.Habitant:
				Instantiate(_enemy, BuildingManager.instance.frontofComputer.position, Quaternion.identity);

				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "frontOfComputer";
				break;
			case Mood.Angry:
				Instantiate(_enemy, BuildingManager.instance.sofa.position, Quaternion.identity);
				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "Sofa";
				break;
			case Mood.Weary:
				Instantiate(_enemy, BuildingManager.instance.bed.position, Quaternion.identity);
				_enemy.mood = mood.ToString();
				_enemy.type = type.ToString();
				_enemy.enemyPosition = "Bed";
				break;
			default:
				break;



		}

	}


	public string RandomType()
	{
		randomTypeArr = new string[]
			 {
				 "Teen",
				 "Gamer",
				 "Woman",
				 "Man",
				 "Elderly",
				 "Baby",
			 };
		
		return randomTypeArr[UnityEngine.Random.Range(0, randomTypeArr.Length)];
	}
	public string RandomMood()
	{

		randomMoodArr = new string[]
	{
			"Angry",
			"Habitant",
			"Weary"
	};
		Debug.Log("Rann: " + randomMoodArr.Length);

		return randomMoodArr[UnityEngine.Random.Range(0, randomMoodArr.Length)];

	}
}

