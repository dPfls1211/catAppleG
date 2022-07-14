using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oController : MonoBehaviour
{
    public GameManger gameManger;
    public GameObject appleCre = null;
    public Transform targetApplePosition;
    public Transform appleBucket;
    public Transform deadAppleBucket;
    // GameObject apples;
    public Animator animator;

    public AudioClip button;
    AudioSource aud;

    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>();
        appleCre = GameObject.Find("Appless");
    }
    public IEnumerator dealy()
    {
        Apple targetApple = targetApplePosition.GetComponentInChildren<Apple>();
        yield return new WaitForSeconds(0.2f);
        Destroy(targetApple.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Apple targetApple = targetApplePosition.GetComponentInChildren<Apple>();
        AppleCreate script = appleCre.GetComponent<AppleCreate>();
        if (targetApple != null)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //
                if (targetApple.isDead == true)
                {
                    animator.SetTrigger("Right"); //고양이 왼쪽손이 움직임
                    aud.PlayOneShot(button);
                    gameManger.upScore();
                    targetApple.transform.position = Vector2.Lerp(targetApple.transform.position, deadAppleBucket.position, 1f);
                    StartCoroutine((dealy()));
                   // Destroy(targetApple.gameObject);
                    script.SortApple();
                    script.CreatApple();
                }
                else
                {
                    animator.SetTrigger("Fault");
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (targetApple.isDead == false)
                {
                    animator.SetTrigger("Left"); //고양이 오른쪽손이 움직임
                    aud.PlayOneShot(button);
                    gameManger.upScore();
                    targetApple.transform.position = Vector2.Lerp(targetApple.transform.position, appleBucket.position, 1f);
                    StartCoroutine((dealy()));
                   // Destroy(targetApple.gameObject);
                    script.SortApple();
                    script.CreatApple();
                }
                else
                {
                    animator.SetTrigger("Fault");
                }
            }
        }


    }
}