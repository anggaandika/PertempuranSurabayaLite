using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public Image backGround;
    public Image karakter;
    public VideoPlayer video;
    public GameObject palceHolderVideo;
    public GameObject Player;
    public Animator animator;
    public Queue<string> sentences;
    private double currentTime;
    private double totalTime;
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        Times();
        if (Input.GetKey(KeyCode.Escape))
        {
            palceHolderVideo.SetActive(false);
        }
        if(video)
        {
            if (totalTime - 5 <= currentTime)
            {
                video.Stop();
                palceHolderVideo.SetActive(false);
            }
        }
    }
    
    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();
        Player.SetActive(false);

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            DisplayNextSentences();
        }
        video.clip = dialog.video;
        backGround.sprite = dialog.backGround;
        if (dialog.backGround != null)
            this.karakter.sprite = dialog.karakter;
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialoug();
            palceHolderVideo.SetActive(true);
            return;
        }
        String sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (String sentence)
    {
        dialogText.text = "";
        foreach (Char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    private void EndDialoug()
    {
        animator.SetBool("IsOpen", false);
        Player.SetActive(true);
    }
    
    private void Times()
    {
        if (video.isPlaying)
        {
            double tiems = video.time;
            double total = video.clip.length;
            currentTime = tiems;
            totalTime = total;
        }
    }
}
