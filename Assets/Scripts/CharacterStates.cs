using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStates : MonoBehaviour
{
    private const string Format = "{ 0.##}";
    [SerializeField]
    float maxHealth = 100;
    public float power = 10;
    //int killScore = 200;
    


    public float currentHealth { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //currScore = 0;
    }

    public void ChangeHealth(float value)
    {
        //currentHealth += value;
        
           

        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
        Debug.Log("Current Health " + currentHealth + "/" + maxHealth);
        if (transform.CompareTag("Enemy"))
            transform.Find("Canvas").GetChild(1).GetComponent<Image>().fillAmount = currentHealth / maxHealth;
        else if (transform.CompareTag("Player"))
        {
            LevelManager.instance.MainCanvas.Find("PnlStats").Find("ImageHealthBar").GetComponent<Image>().fillAmount = currentHealth / maxHealth;
            LevelManager.instance.MainCanvas.Find("PnlStats").Find("TxtHealth").GetComponent<TextMeshProUGUI>().text =
                string.Format("{0:0.##}%", (currentHealth / maxHealth) * 100);
        }


            if (currentHealth <= 0)
        {
            Die();
            

        }

            
    }

    void Die()
    {
        if (transform.CompareTag("Player"))
        {
            //game over
            //LevelManager.instance.EndGame();
            LevelManager.instance.GameOver();
            Destroy(gameObject);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;



        }
        else if (transform.CompareTag("Enemy"))
        {
            //currScore += 15;
            //LevelManager.instance.score += killScore;
            UiManager.instance.Score+=10;
            UiManager.instance.UpdateScoreUI();
            Destroy(gameObject);
            //addScore();
            /*LevelManager.instance.MainCanvas.Find("PnlStats").Find("Score").GetComponent<TextMeshProUGUI>().text =
                string.Format("Score: {0:0.##}",currScore + addScore(amount) );*/
            FindObjectOfType<audioManager>().Play("EnemyDie");
            //Destroy Enemy
            Instantiate(LevelManager.instance.Particles[2], transform.position, transform.rotation);

        }
    }

    //public int addScore(int amount) => currScore += amount;



}
