using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    // Reference to the Question UI Panel
    public GameObject questionPanel;

    // References to the TextMeshProUGUI components
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI choiceAText;
    public TextMeshProUGUI choiceBText;

    // References to the Buttons
    public Button choiceAButton;
    public Button choiceBButton;

    // Question structure
    [System.Serializable]
    public struct Question
    {
        public string question;
        public string choiceA;
        public string choiceB;
        public bool isChoiceACorrect;
        public float extinguishPowerChange; // Positive for correct, negative for incorrect
    }

    // Array of questions
    public Question[] questions;

    // Reference to GameManager
    private GameManager gameManager;

    // Current question index
    private int currentQuestionIndex = 0;

    void Start()
    {
        gameManager = GameManager.Instance;
        questionPanel.SetActive(false); // Hide at start
        // Subscribe to button events
        choiceAButton.onClick.AddListener(OnChoiceAClicked);
        choiceBButton.onClick.AddListener(OnChoiceBClicked);
        // Start the first question
        StartCoroutine(StartQuestionSequence());
    }

    IEnumerator StartQuestionSequence()
    {
        while (currentQuestionIndex < questions.Length && !gameManager.levelEnded)
        {
            yield return new WaitForSeconds(5f); // Wait for 5 seconds before showing a question
            ShowQuestion();
            // Wait until the player answers
            yield return new WaitUntil(() => !questionPanel.activeSelf);
            currentQuestionIndex++;
        }

        // After all questions, end the level
        if (!gameManager.levelEnded)
            gameManager.EndLevel();
    }

    void ShowQuestion()
    {
        if (!gameManager.levelEnded){
        if (currentQuestionIndex >= questions.Length)
            return;

        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.question;
        choiceAText.text = currentQuestion.choiceA;
        choiceBText.text = currentQuestion.choiceB;
        questionPanel.SetActive(true);
        gameManager.PauseLevel();
        }
    }

    void OnChoiceAClicked()
    {
        ProcessAnswer(true);
    }

    void OnChoiceBClicked()
    {
        ProcessAnswer(false);
    }

    void ProcessAnswer(bool isChoiceAClicked)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        bool isCorrect = isChoiceAClicked ? currentQuestion.isChoiceACorrect : !currentQuestion.isChoiceACorrect;

        if (isCorrect)
        {
            gameManager.IncreaseExtinguishPower(currentQuestion.extinguishPowerChange);
        }
        else
        {
            gameManager.DecreaseExtinguishPower(currentQuestion.extinguishPowerChange);
        }

        // Hide the question panel after answering
        questionPanel.SetActive(false);
        gameManager.ResumeLevel();
    }
}
