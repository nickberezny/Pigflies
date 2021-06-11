using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] GameObject PlayerPrefab;

    public GameObject _player {get; private set;}

    public void CreatePlayer(Vector3 position)
    {
        _player = Instantiate(PlayerPrefab, position, Quaternion.identity);
    }

}
