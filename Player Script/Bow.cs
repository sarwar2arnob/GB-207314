using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Bow : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ArrowCountText;
    [SerializeField]
    int ArrowCount;
    bool HoldingButton;
   [SerializeField] GameObject arrow;
   [SerializeField] float launchForce;
   [SerializeField] Transform shotPoint;
    GameObject Player;
    Animator Anim;
    public int BowNumber;
    public UpgradableStats upgradable;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        SceneManager.sceneLoaded += SceneLoaded;
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim.SetLayerWeight(Anim.GetLayerIndex("Bow 2 Layer"), 100);
    }
    void Update()
    {
        ArrowCountText.text = ArrowCount.ToString();
        Anim.SetLayerWeight(BowNumber, 100);
        if (HoldingButton)
        {
            Vector2 bowPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - bowPosition;
            if (Player.transform.position.x > mousePosition.x && Player.GetComponent<CharacterController2D>().m_FacingRight)
            {
                Player.GetComponent<CharacterController2D>().Flip();
            }else if(Player.transform.position.x < mousePosition.x && !Player.GetComponent<CharacterController2D>().m_FacingRight)
            {
                Player.GetComponent<CharacterController2D>().Flip();
            }
            if (Player.GetComponent<CharacterController2D>().m_FacingRight)
            {
                transform.right = direction;
            }else if (!Player.GetComponent<CharacterController2D>().m_FacingRight)
            {
                transform.right = -direction;
            }
        }
        BowNumber = PlayerPrefs.GetInt("ArrowUpgrade");
    }
    public void Shoot()
    {
        if (ArrowCount != 0)
        {
            FindObjectOfType<AudioManager>().Play("arrow");
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            Anim.SetTrigger("Release");
            if (Player.GetComponent<CharacterController2D>().m_FacingRight)
            {
                newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            }else if (!Player.GetComponent<CharacterController2D>().m_FacingRight)
            {
                newArrow.GetComponent<Rigidbody2D>().velocity = -transform.right * launchForce;
            }
            Anim.ResetTrigger("Tension");
            HoldingButton = false;
            ArrowCount -= 1;
            newArrow.GetComponent<SpriteRenderer>().sprite = upgradable.ArrowSprites[BowNumber];
        }
    }

    public void Tension()
    {
        if (ArrowCount != 0)
        {
            HoldingButton = true;
            Anim.SetTrigger("Tension");
        }
    }
    public void SceneLoaded(Scene scene,LoadSceneMode mode)
    {
        GetComponent<SpriteRenderer>().sprite = upgradable.BowSprites[BowNumber];
    }
}
