using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player { get; private set; }


    public void SetPlayer()
    {
        player = new GameObject("Player").AddComponent<Player>();
    }
}
