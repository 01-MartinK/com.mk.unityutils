using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalHandler : MonoBehaviour
{
    public GameObject pawnModal;
    public GameObject itemModal;
    public GameObject entityModal;

    public void ShowPawnModal()
    {
        pawnModal.SetActive(true);
    }

    public void HidePawnModal()
    {
        pawnModal.SetActive(false);
    }
}
