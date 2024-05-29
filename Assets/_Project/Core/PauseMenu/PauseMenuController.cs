using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEditor;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the PauseMenu canvas")]
    private GameObject _canvas;

    [Space]
    [SerializeField, Range(0, 2), Tooltip("How long the fade in and out lasts")]
    private float _fadeDuration = 0.2f;

    private bool _paused = false;
    private float _previousTimeScale = 1f;

    private void Start()
    {
        if (_canvas)
            _canvas.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        // Only consider the initial press
        if (!context.started) return;

        if (!_paused)
            Pause();
        else
            Resume();
    }

    public void Pause()
    {
        _paused = true;
        _previousTimeScale = Time.timeScale;
        Time.timeScale = 0.00001f;              // Tiny value rather than 0 to prevent bugs

        // If the canvas is assigned, and it has a CanvasGroup
        if (_canvas != null && _canvas.TryGetComponent(out CanvasGroup canvasGroup))
        {
            // Turn the canvas on
            _canvas.SetActive(true);

            // Kill any active tweens on the canvas
            DOTween.Kill(_canvas);

            // Fade the canvas in
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1, _fadeDuration)
                .SetUpdate(UpdateType.Normal, true);
        }
    }

    public void Resume()
    {
        _paused = false;
        Time.timeScale = _previousTimeScale;

        // If the canvas is assigned, and it has a CanvasGroup
        if (_canvas != null && _canvas.TryGetComponent(out CanvasGroup canvasGroup))
        {
            // Turn the canvas on
            _canvas.SetActive(true);

            // Kill any active tweens on the canvas
            DOTween.Kill(_canvas);

            // Fade the canvas out, and set it inactive when finished
            canvasGroup.alpha = 1;
            canvasGroup.DOFade(0, _fadeDuration)
                .SetUpdate(UpdateType.Normal, true)
                .OnComplete(() => _canvas.SetActive(false));
        }
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER
        Application.OpenURL("www.nyan.cat");
    #else
        Application.Quit();
    #endif
    }

    public void RestartScene(float delay)
    {
        StopAllCoroutines();
        StartCoroutine(RestartSceneCoroutine(delay));
    }

    private IEnumerator RestartSceneCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
