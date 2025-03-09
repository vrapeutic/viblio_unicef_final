﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Books : MonoBehaviour
{
    [SerializeField] IntVariable booksNo;
    [SerializeField] GameObject[] books;
    XRInteractionManager xr;
    public static Books instatnce;
    public List<float> bookshights;
    // Start is called before the first frame update
    void Start()
    {
        instatnce = this;
        bookshights = new List<float>();
        xr = FindObjectOfType<XRInteractionManager>();
        for (int i = 0; i < books.Length; i++)
        {
            if (i < booksNo.Value) books[i] = transform.GetChild(i).gameObject;
            else books[i].SetActive(false);
        }
        //xr.allowHover.;
    }

    public void MakeBooksInteractable()
    {
        for (int i = 0; i < books.Length; i++)
        {
            /**/ //            books[i].GetComponent<OVRGrabbable>().enabled = true;
            if (books[i].gameObject.tag != "PutBook")
            {
                books[i].GetComponent<Rigidbody>().useGravity = true;
                books[i].GetComponent<BoxCollider>().enabled = true;
                books[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        xr.gameObject.SetActive(true);
    }
    public void MakeBooksUnInteractable()
    {

        //for (int i = 0; i < books.Length; i++)
        //{
        //    books[i].GetComponent<Rigidbody>().isKinematic = false;
        //    books[i].GetComponent<Rigidbody>().useGravity = true;
        //    books[i].GetComponent<BoxCollider>().enabled = true;
        //    //books[i].GetComponent<XRGrabInteractable>().;
        //}
        MakeBooksUnInteractableOnlevelEnd();
    }
    public void MakeBooksUnInteractableAfterperiod()
    {
        StartCoroutine(MakeBooksUnInteractableAfterperiodIenum());
    }

    IEnumerator MakeBooksUnInteractableAfterperiodIenum()
    {
        yield return new WaitForSeconds(.3f);
        MakeBooksUnInteractableOnlevelEnd();
    }

     void MakeBooksUnInteractableOnlevelEnd()
    {
        //await new WaitForSeconds(2f);

        for (int i = 0; i < books.Length; i++)
        {
            /**/ //                books[i].GetComponent<OVRGrabbable>().enabled = false;
            if (books[i].gameObject.tag != "PutBook")
            {
                books[i].GetComponent<Rigidbody>().useGravity = false;
                books[i].GetComponent<BoxCollider>().enabled = false;
                books[i].GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    public void MakeBooksUnInteractableWhileSelectingThem()
    {
        xr.gameObject.SetActive(false);
        for (int i = 0; i < books.Length; i++)
        {
            /**/ //            books[i].GetComponent<OVRGrabbable>().enabled = true;
            books[i].GetComponent<Rigidbody>().useGravity = true;
            books[i].GetComponent<BoxCollider>().enabled = true;
            books[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
