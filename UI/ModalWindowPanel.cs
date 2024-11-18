using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalWindowPanel : MonoBehaviour
{
    [Header("Header")]
    [SerializeField]
    private TextMeshProUGUI header;
    [Header("Content")]
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private Image imageBox;
    [Header("Footer")]
    [SerializeField]
    private TextMeshProUGUI footer;
    [SerializeField]
    private Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(Close);
    }

    public void ShowAsEvent(string titleText, string contentText, Sprite imageToShow)
    {
        header.text = titleText;
        content.text = contentText;
        if (imageToShow)
        {
            transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(320, 480);
            imageBox.gameObject.SetActive(true);
            imageBox.sprite = imageToShow;
        }
        gameObject.SetActive(true);
    }

    public void Close()
    {
        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(320, 240);
        imageBox.gameObject.SetActive(false);
        imageBox.sprite = null;
        gameObject.SetActive(false);
    }
}
