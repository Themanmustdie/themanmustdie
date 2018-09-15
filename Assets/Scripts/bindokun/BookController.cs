using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(AudioSource))]
public class BookController : MonoBehaviour
{

    private AudioSource dropSound;
    private AudioSource openBookSound;
    public GameObject bookMaskPanel;
    public GameObject butterfly;
    public GameObject girl;
    public GameObject boySprite;

    private CameraManager cameraMgr;
    // Use this for initialization
    void Start()
    {
        dropSound = GetComponents<AudioSource>()[0];
        openBookSound = GetComponents<AudioSource>()[1];
        ConfigManager configMgr = ConfigManager.GetInstance;
        cameraMgr = GameObject.Find("EverySceneNeed").GetComponent<CameraManager>();
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
        if (collision.gameObject.name == "groud")
        {
            dropSound.Play();
        }
    }

    public void OnClickBook()
    {

        Debug.Log("clicked");

        GameObject curActiveObj = null;
        GameObject nextActiveObj = null;

        // find show
        foreach (Transform transform in bookMaskPanel.GetComponentInChildren<Transform>(true))
        {
            if (curActiveObj == null && transform.gameObject.activeSelf)
            {
                curActiveObj = transform.gameObject;
            }
            else if (curActiveObj != null && nextActiveObj == null)
            {
                nextActiveObj = transform.gameObject;
            }
        }
        // 设置所有子节点inactive
        foreach (Transform transform in bookMaskPanel.GetComponentInChildren<Transform>(true))
        {
            transform.gameObject.SetActive(false);
        }
        
        if (nextActiveObj != null)
        {
            // 说明还有东西要弹出来
            nextActiveObj.SetActive(true);
            openBookSound.Play();
        }
        else
        {
            bookMaskPanel.SetActive(false);
            Destroy(GetComponent<Rigidbody>());
            GetComponent<Collider>().isTrigger = true;

            cameraMgr.BlurBackground(false);
          
            // 处理蝴蝶 和人和精灵
            butterfly.SetActive(true);
            cameraMgr.ChangeTarget(butterfly);
            girl.GetComponent<NewGrilController>().DisableMoving();
            boySprite.GetComponent<SpriteController>().DisableMoving();
        }
    }
}
