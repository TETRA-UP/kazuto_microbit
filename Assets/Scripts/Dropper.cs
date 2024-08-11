using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] public GameObject[] fruitsPrefabs;


    //?t???[?c?????????I?u?W?F?N?g?????????x
    float speed = 0.05f;
    float defaultPos;
    [SerializeField]
    AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Component??????
        audioSource = GetComponent<AudioSource>();
        defaultPos = transform.position.x;
        Pop();
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + speed;
        if (x > defaultPos + 5.0f || x < defaultPos - 5.0f)
        {
            speed *= -1;
        }
        //?????????????v???O??????????????????
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void Pop()
    {
        //???????????????_???????????i?[????????
        int randomlndex = UnityEngine.Random.Range(0, fruitsPrefabs.Length);
        //?t???[?c??????
        Instantiate(fruitsPrefabs[randomlndex], transform.position, Quaternion.identity, transform);
        
        audioSource.PlayOneShot(sound);
    }
}