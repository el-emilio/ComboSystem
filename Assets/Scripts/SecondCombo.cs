using UnityEngine;
using System.Collections;

public class SecondCombo : MonoBehaviour
{
    public Animator REALSecondOne;

    //↑↑↑↓QA

    public int comboUp = 0;
    public int comboDown = 0;
    public int comboQ = 0;
    public int comboA = 0;

    public float limit = 3.0f;

    public float lastTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (comboUp == 3 || Time.time - lastTime > limit)
            {
                Reiniciar();
            }

            comboUp = comboUp + 1;
            lastTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && comboUp == 3 && comboDown < 1)
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

        if (Input.GetKeyDown(KeyCode.Q) && comboDown == 1 && comboQ == 0)
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
                REALSecondOne.SetTrigger("Combo2");
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