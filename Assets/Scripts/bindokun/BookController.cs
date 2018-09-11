using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(AudioSource))]
public class BookController : MonoBehaviour
{

    private AudioSource audioSource;
    public GameObject bookMaskPanel;
    public GameObject butterfly;
    public GameObject girl;
    public GameObject boySprite;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ConfigManager configMgr = ConfigManager.GetInstance;
    }

    //IEnumerator DropBook(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    gameObject.GetComponent<Rigidbody>().useGravity = true;
    //}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "groud")
        {
            audioSource.Play();
        }
    }

    public void OnClickBook()
    {

        GameObject curActiveObj = null;
        GameObject nextActiveObj = null;

        // find show
        foreach (Transform transform in bookMaskPanel.GetComponentInChildren<Transform>())
        {
            if (curActiveObj == null && transform.gameObject.activeSelf)
            {
                curActiveObj = transform.gameObject;
            }
            else if (curActiveObj != null && nextActiveObj == null)
            {
                nextActiveObj = transform.gameObject;
            }
            transform.gameObject.SetActive(false);
        }
        if (nextActiveObj != null)
        {
            nextActiveObj.SetActive(true);
            bookMaskPanel.SetActive(true);
        }
        else
        {
            bookMaskPanel.SetActive(false);
            Destroy(GetComponent<Rigidbody>());
            GetComponent<Collider>().isTrigger = true;

            Camera.main.gameObject.GetComponent<BlurBackground>().enabled = false;
            GameObject.Find("CharacterCamera").GetComponent<BlurBackground>().enabled = false;
          
            // 处理蝴蝶 和人和精灵
            butterfly.SetActive(true);
            Camera.main.gameObject.GetComponent<SmoothFollow>().target = butterfly.transform;
            GameObject.Find("CharacterCamera").GetComponent<SmoothFollow>().target = butterfly.transform;
            girl.GetComponent<NewGrilController>().DisableMoving();
            boySprite.GetComponent<SpriteController>().DisableMoving();
        }
    }
}
