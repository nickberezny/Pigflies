using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigManager : Singleton<PigManager>
{
    List<GameObject> _PigCollective;
    public int _numberOfPigs { private set; get; }
    private int _weight;
    private Rigidbody2D _playerRB;

    protected override void Awake()
    {
        base.Awake();
        _PigCollective = new List<GameObject>();
        _playerRB = GetComponent<Rigidbody2D>();
        _weight = (int)_playerRB.mass;
    }

    public void AddPig(GameObject pig, Rigidbody2D attachedBody)
    {
        if(pig.tag != "Player")
        {
            SpringJoint2D joint = pig.AddComponent<SpringJoint2D>();
            
            joint.connectedBody = attachedBody;
            joint.dampingRatio = 1f;
            joint.frequency = 10000;
            _PigCollective.Add(pig);
            ChangeWeight(pig.GetComponent<PigBasic>()._weight);
            pig.transform.position = new Vector3(pig.transform.position.x, pig.transform.position.y, 0);

            _numberOfPigs = CountPigs();
            HUD.Instance.SetScoreText(_numberOfPigs);
        }

        CameraManager.Instance.SetDepth(7f + (float)_numberOfPigs/5f);
    }

    public void RemovePig(GameObject pig)
    {
        ChangeWeight(-pig.GetComponent<PigBasic>()._weight);
        _PigCollective.Remove(pig);
        //Destroy(pig);
        _numberOfPigs = CountPigs();
        HUD.Instance.SetScoreText(_numberOfPigs);

        CameraManager.Instance.SetDepth(7f + (float)_numberOfPigs / 5f);
    }

    private void ChangeWeight(int change)
    {
        _weight += change;
        _playerRB.mass = _weight;
    }

    private int CountPigs()
    {
        int count = 0;
        foreach(Transform child in transform)
        {
            if (child.gameObject.tag == "Pig") count++;
        }
        return count;
    }

}
