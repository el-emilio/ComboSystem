using UnityEngine;
using System.Collections;

public class ThirdCombo : MonoBehaviour
{
    public Animator SecondOne;

    private int combo = 0;
    private float limit = 0.5f;
    private float lastTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Time.time - lastTime > limit)
            {
                combo = 0;
            }

            combo = combo + 1;
            lastTime = Time.time;

            if (combo == 3)
            {
                SecondOne.SetTrigger("Combo3");
                combo = 0;
            }
        }
    }
}
