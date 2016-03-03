using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    public Text livesLabel;
    public Text scoreLabel;
    public Text gameOverLabel;
    public Text finalScoreLabel;
    public PlayerController player;
    public Button restartButton;


    
    //private instance variables
    private int _scoreValue;
    private int _livesValue;



    //getters and setters
    public int ScoreValue
    {
        get
        {
            return _scoreValue;
        }

        set
        {
            _scoreValue = value;
            this.scoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return _livesValue;
        }

        set
        {
            _livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }

            else {
                this.livesLabel.text = "Lives: " + this._livesValue;
            }

        }
    }

    // Use this for initialization
    void Start () {
		this._GenerateTanks ();
        this._initialize();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}

    //private methods
   
    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.gameOverLabel.enabled = false;
        this.finalScoreLabel.enabled = false;
        this.restartButton.gameObject.SetActive(false);
    }
    private void _endGame()
    {
        this.finalScoreLabel.text = "Final Score:" + this._scoreValue;
        this.gameOverLabel.enabled = true;
        this.finalScoreLabel.enabled = true;
         this.restartButton.gameObject.SetActive(true);
        this.player.gameObject.SetActive(false);
        this.livesLabel.enabled = false;
        this.scoreLabel.enabled = false;
       

    }
    //Public Method
    public void RestarButtonClicked()
    {
        Application.LoadLevel("Main");
    }
}
