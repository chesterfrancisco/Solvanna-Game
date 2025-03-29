using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public Rigidbody monsRigid;
    public Transform monsTrans, playTrans;
    public int monSpeed;

    void FixedUpdate()
    {
        monsRigid.linearVelocity = transform.forward * monSpeed * Time.deltaTime;
    }

    private void Update()
    {
        monsTrans.LookAt(playTrans);
    }

}
