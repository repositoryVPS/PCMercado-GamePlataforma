using System.Collections;
using System.Collections.Generic;
using Core.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject player;

    [Header("Enemies")]
    public List<GameObject> enemies;

}
