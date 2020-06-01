using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class playerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}
public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;
    private Transform tr;
    //[SerializeField] private float moveSpeed = 10.0f;
    public float moveSpeed = 10.0f;

    public float rotSpeed = 80.0f;

    public playerAnim playerAnim;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");


        Debug.Log("h = " + h.ToString());
        Debug.Log("v = " + v.ToString());

        //tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime,Space.Self);

        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        if (v >= 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f); //Front Run anime
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f); //Back Run anime

        }
        else if (h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f); //Right Run anime

        }
        else if (h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f); //Left Run anime

        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f); //stop Idle anime
        }
    }
}
