using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class GrajoDeath : MonoBehaviour
{
    public float timeOutsideValidZone = 2f;
    public Color deathColor;
    public GameObject canvas;

    public Image healthBar;
    public float resistance = 4f;

    private SpriteRenderer spriteRenderer;
    private bool firstTime = true;
    private Coroutine deathCoroutine;

    private float healthStep,alpha, alphaStep;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthStep = 1f / resistance;
        healthBar.fillAmount = 0;
        alphaStep = 1f / (resistance * 1.5f);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // El Player colisiona con un obstaculo vertical
        if (collision.gameObject.tag == "VerticalObs")
        {
            PlayerDamage();
            
        }

        // El player colisiona con un obstaculo horizontal
        else if (collision.gameObject.tag == "HorizontalObs")
        {
            PlayerDamage();
        }

        // El player entra de nuevo en la valid zone
        else if (collision.gameObject.tag == "ValidZone")
        {
            if (!firstTime)
            {
                Debug.Log("Entering valid zone");
                StopDamages();
            }
            else
            {
                firstTime = false;
            }

        }
    }
    private void PlayerDamage()
    {
        healthBar.fillAmount = healthBar.fillAmount + healthStep;
        if (healthBar.fillAmount >= 1) KillPlayer("vertical obstacle");
       
        Color color = spriteRenderer.color;
        color.a = color.a - alphaStep;
        spriteRenderer.color = color;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ValidZone")
        {
            Debug.Log("Exit valid zone");
            spriteRenderer.DOColor(deathColor, timeOutsideValidZone).SetEase(Ease.InQuad).Play();
            deathCoroutine = StartCoroutine(KillInThreeSeconds());
        }
    }

    private IEnumerator KillInThreeSeconds()
    {
        yield return new WaitForSeconds(timeOutsideValidZone);
        KillPlayer("\"un frio del carajo\"");
    }

    private void KillPlayer(string deathCause)
    {
        Debug.Log("You died from: " + deathCause + ".");
        Time.timeScale = 0;
        // A�adir UI de muerte
        canvas.SetActive(true);
    }
    private void RestartScene()
    {
        // Reinicia la escena actual
        Time.timeScale = 1; 
        canvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void StopDamages()
    {
        spriteRenderer.color = Color.white;
        StopCoroutine(deathCoroutine);
        DOTween.PauseAll();
    }

}
