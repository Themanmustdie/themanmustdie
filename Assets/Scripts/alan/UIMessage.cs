using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Common;

public class UIMessage : MonoBehaviour
{
    public Text Title;
    public Text Content;//这个是Content下的text
    public Button Sure;
    public Button Cancle;
    void Start()
    {
        Sure.onClick.AddListener(MessageBox.Sure);
        Cancle.onClick.AddListener(MessageBox.Cancle);
        Title.text = MessageBox.TitleStr;
        Content.text = MessageBox.ContentStr;
    }
}