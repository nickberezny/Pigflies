using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    Camera _camera;
    GameObject _player;

    protected override void Awake()
    {

        base.Awake();
        _camera = GetComponent<Camera>();
        SetDepth(7);
    }

    public void SetDepth(float newDepth)
    {
        _camera.orthographicSize = newDepth;
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }

    private void Update()
    {
        if(_player)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
        }
    }
}
