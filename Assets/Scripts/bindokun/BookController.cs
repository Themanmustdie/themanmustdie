using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BookController : MonoBehaviour
{

    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ConfigManager configMgr = ConfigManager.GetInstance;
        float delaySec = float.Parse(configMgr.GetPara("Scene1-BookDropDelay"));
        StartCoroutine(DropBook(delaySec));
    }

    IEnumerator DropBook(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Play Audios");
        audioSource.Play();
    }
}
