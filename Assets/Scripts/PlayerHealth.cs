using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    public int maxLife;

    public Sprite emptyLife;
    public Sprite fullLife;
    public Image[] hearts;

    void Update()
    {

    }

    private void TakeDamage(int auch)
    {
        life -= auch;
    }
}
