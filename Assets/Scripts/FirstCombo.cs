using UnityEngine;
using System.Collections;

public class FirstCombo : MonoBehaviour
{
    public Animator FirstOne;
    public AudioClip comboSound;          // <- arrastra combo1_sound aquí
    private AudioSource audioSource;

    //↑↑↓↓QA

    private int comboUp = 0;
    private int comboDown = 0;
    private int comboQ = 0;
    private int comboA = 0;

    private float limit = 3.0f;
    private float lastTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (comboUp == 2 || Time.time - lastTime > limit)
            {
                Reiniciar();
            }

            comboUp = comboUp + 1;
            lastTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && comboUp == 2 && comboDown < 2)
        {
            if (Time.time - lastTime > limit)
            {
                Reiniciar();
            }
            else
            {
                comboDown = comboDown + 1;
                lastTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && comboDown == 2 && comboQ == 0)
        {
            if (Time.time - lastTime > limit)
            {
                Reiniciar();
            }
            else
            {
                comboQ = 1;
                lastTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && comboQ == 1)
        {
            if (Time.time - lastTime > limit)
            {
                Reiniciar();
            }
            else
            {
                FirstOne.SetTrigger("Combo1");
                if (comboSound != null) audioSource.PlayOneShot(comboSound);
                Reiniciar();
            }
        }
    }

    void Reiniciar()
    {
        comboUp = 0;
        comboDown = 0;
        comboQ = 0;
        comboA = 0;
    }
}