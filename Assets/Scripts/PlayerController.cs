using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioSource jumpSound;
    private Rigidbody2D rb;
    public float jumpForce;
    private float yRange = 4.0f;
    public TMP_Text gameOverText; // UI Game Over Text
    public TMP_Text scoreText; // UI Score Text
    public GameObject restartButton;
    private bool isGameOver = false; // Oyunun bitip bitmediğini kontrol eder
    private int score = 0; // Borudan geçiş sayısı

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        gameOverText.gameObject.SetActive(false); // Başta kapalı olduğunu belirtir.
        restartButton.SetActive(false); // Başlangıçta butonu gizler
        UpdateScoreText(); // Başlangıçta skoru günceller
    }

    // Update is called once per frame
    void Update()
    {
         // R tuşuna basıldığında oyunu yeniden başlat
        if (Input.GetKeyDown(KeyCode.R)){
            RestartGame();
        }
        if (isGameOver) return; // Oyun bitince diğer kontrolleri atlatır

        if(Input.GetKeyDown(KeyCode.Space)) {
         jumpSound.Play();
          rb.linearVelocity = (Vector2.up * jumpForce);          
        }

        if (transform.position.y > yRange) {

            transform.position = new Vector2( transform.position.x, yRange);
        }
        
        if (transform.position.y < -yRange) {

            transform.position = new Vector2( transform.position.x, -yRange);
        }

       

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Obstacle")) { // Çarpışma algılarsa

            Debug.Log("Game Over!");
            gameOverText.gameObject.SetActive(true); // Game over yazısını aktifleştirir
            Time.timeScale = 0; // Oyunu durdurur.
            restartButton.gameObject.SetActive(true);
            isGameOver = true;
        }

        else if (other.gameObject.CompareTag("ScoreZone")) // Borulardan geçiş kontrolü
        {
            score++; //geçiş sayısını artırır
            UpdateScoreText();

        }
        
    }

        void UpdateScoreText() {

            scoreText.text = "Score: " + score; // Skoru UI'da gösterir
        }
        public void RestartGame() {

            Time.timeScale = 1; // Zamanı normalleştirir.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Aynı sahneyi tekrarlar
        }

}
