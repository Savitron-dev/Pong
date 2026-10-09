using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Transition : MonoBehaviour
{
    [Header("Panels")]
    public RectTransform mainMenuPanel;
    public RectTransform levelSelectionPanel;

    [Header("Main Menu Buttons")]
    public RectTransform[] mainMenuButtons;

    [Header("Difficulty Buttons")]
    public RectTransform[] difficultyButtons;

    [Header("Animation Settings")]
    public float slideDuration = 0.4f;
    public float delayBetweenButtons = 0.12f;
    public float slideDistance = 1920f;

    private bool isAnimating = false;

    void Start()
    {
        // Main menu starts in the center.
        mainMenuPanel.anchoredPosition = Vector2.zero;

        // Position the level panel off-screen to the right.
        levelSelectionPanel.anchoredPosition =
            new Vector2(slideDistance, 0);

        levelSelectionPanel.gameObject.SetActive(false);

        // Hide difficulty buttons initially.
        foreach (RectTransform button in difficultyButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void OpenLevelSelection()
    {
        if (!isAnimating)
        {
            StartCoroutine(ShowLevelSelection());
        }
    }

    IEnumerator ShowLevelSelection()
    {
        isAnimating = true;

        // Slide old menu buttons out one by one.
        foreach (RectTransform button in mainMenuButtons)
        {
            yield return StartCoroutine(
                SlideButton(button, -slideDistance)
            );

            yield return new WaitForSeconds(delayBetweenButtons);
        }

        // Hide the old panel after its buttons leave.
        mainMenuPanel.gameObject.SetActive(false);

        // Activate the new panel.
        levelSelectionPanel.gameObject.SetActive(true);

        // Slide difficulty buttons in one by one.
        foreach (RectTransform button in difficultyButtons)
        {
            button.gameObject.SetActive(true);

            // Start the button off-screen on the right.
            Vector2 targetPosition = button.anchoredPosition;

            button.anchoredPosition =
                targetPosition + new Vector2(slideDistance, 0);

            yield return StartCoroutine(
                SlideToPosition(button, targetPosition)
            );

            yield return new WaitForSeconds(delayBetweenButtons);
        }

        isAnimating = false;
    }

    IEnumerator SlideButton(
        RectTransform button,
        float distance)
    {
        Vector2 startPosition = button.anchoredPosition;

        Vector2 targetPosition =
            startPosition + new Vector2(distance, 0);

        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            elapsed += Time.unscaledDeltaTime;

            float t = Mathf.Clamp01(elapsed / slideDuration);

            // Smooth ease-out movement.
            t = 1f - Mathf.Pow(1f - t, 3f);

            button.anchoredPosition =
                Vector2.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        button.anchoredPosition = targetPosition;
    }

    IEnumerator SlideToPosition(
        RectTransform button,
        Vector2 targetPosition)
    {
        Vector2 startPosition = button.anchoredPosition;

        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            elapsed += Time.unscaledDeltaTime;

            float t = Mathf.Clamp01(elapsed / slideDuration);

            // Smooth ease-out movement.
            t = 1f - Mathf.Pow(1f - t, 3f);

            button.anchoredPosition =
                Vector2.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        button.anchoredPosition = targetPosition;
    }

    public void BackToMainMenu()
    {
        if (isAnimating)
            return;

        mainMenuPanel.gameObject.SetActive(true);
        levelSelectionPanel.gameObject.SetActive(false);

        mainMenuPanel.anchoredPosition = Vector2.zero;

        isAnimating = false;
    }
    public void SelectEasy()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        SceneManager.LoadScene("SinglePlayer");
    }

    public void SelectMedium()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        SceneManager.LoadScene("SinglePlayer");
    }

    public void SelectHard()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        SceneManager.LoadScene("SinglePlayer");
    }
}