using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAwareness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarnessDistance;
    private Transform _player;

    // Start is called before the first frame update
    private void Awake()
    {
        _player = FindObjectOfType<player_Kale_Man>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarnessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
