using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CollectibleManager : MonoBehaviour
{
    public int mapCount;
    public Text mapText;
    public PLAYER_MOV player;
    //public PLAYER_MOV shield;
    //public PLAYER_MOV currentHealth;
    //public Image shieldImage;
    [SerializeField]bool run = false;
    //[SerializeField] bool jumphigh = false;



    private void Start()
    {
        //shieldImage.gameObject.SetActive(false);
    }
    private void Update()
    {
        mapText.text = mapCount.ToString();

        if(mapCount >= 6)
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

        /*if(mapCount >= 6)
        {
            
        }*/

        /*if(mapCount >= 4 && !shield.shieldActive)
        {
            shield.ShieldActive(5f);
            currentHealth.isImmune = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) && !shield.shieldActive)
        {
            shield.ShieldActive(5.0f); // El escudo estará activo por 5 segundos
            currentHealth.isImmune = true; // El jugador será inmune al daño mientras el escudo esté activo
        }*/
    }

    /*private void ActivateShield(float duration)
    {
        shield.ShieldActive(duration);
        currentHealth.isImmune = true;
        StartCoroutine(ShowShieldImage(duration));
    }

    private IEnumerator ShowShieldImage(float duration)
    {
        shieldImage.gameObject.SetActive(true); // Activar el GameObject que contiene la imagen del escudo
        yield return new WaitForSeconds(duration);
        shieldImage.gameObject.SetActive(false); // Desactivar el GameObject después de la duración del escudo
        currentHealth.isImmune = false; // Desactivar la inmunidad después de que el escudo desaparezca
    }*/

}
