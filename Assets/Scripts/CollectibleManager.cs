using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    public int mapCount;
    public Text mapText;
    public PLAYER_MOV player;
    public PLAYER_MOV shield;
    public PLAYER_MOV currentHealth;
    [SerializeField]bool run = false;

    private void Update()
    {
        mapText.text = mapCount.ToString();

        if(mapCount >= 2)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                run = true;
                player.SetSpeed(16);
            }else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                run = false;
                player.SetSpeed(8);
            }
        }

        if(mapCount >= 4 && !shield.shieldActive)
        {
            shield.ShieldActive(5f);
            currentHealth.isImmune = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !shield.shieldActive)
        {
            shield.ShieldActive(5.0f); // El escudo estará activo por 5 segundos
            currentHealth.isImmune = true; // El jugador será inmune al daño mientras el escudo esté activo
        }
    }

}
