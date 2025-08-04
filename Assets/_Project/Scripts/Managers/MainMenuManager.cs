using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [Header("Injected Dependencies")]
    [Space]
    [Header("UI Panels")]
    [Tooltip("")]
    [SerializeField] private RectTransform _mainMenuRectTransform;
    [Tooltip("")]
    [SerializeField] private RectTransform _optionsMenuRectTransform;
    [Space]
    [Header("Tween Values")]
    [Tooltip("")]
    [SerializeField] private float _durationScale_Panel;
    [Tooltip("")]
    [SerializeField] private float _durationMoving_Panel;
    [Tooltip("")]
    [SerializeField] private Vector3 _scaleDownVector_Panel;
    [Tooltip("")]
    [SerializeField] private float _positionXAway_Panel;
    
    void Start()
    {
        _optionsMenuRectTransform.anchoredPosition = new Vector3(_positionXAway_Panel,_optionsMenuRectTransform.anchoredPosition.y);
        _optionsMenuRectTransform.gameObject.SetActive(false);
        _mainMenuRectTransform.localScale = Vector3.zero;
        StartCoroutine(ScaleUpRectTransform());
    }



    public void PlayButtonClicked(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }
    
    public void OptionButtonClicked()
    {
        StartCoroutine(OptionSequenceCoroutine());
    }

    public void MainMenuButtonClicked()
    {
        StartCoroutine(MainMenuSequenceCoroutine());
    }


    private IEnumerator MainMenuSequenceCoroutine()
    {
        yield return StartCoroutine(OptionsPanelMoveAway());
        yield return StartCoroutine(ScaleUpRectTransform());
    }
    
    private IEnumerator OptionSequenceCoroutine()
    {
        yield return StartCoroutine(ScaleDownRectTransform());
        yield return StartCoroutine(OptionsPanelMoveInside());
    }
    
    
    private IEnumerator ScaleUpRectTransform()
    {
        _mainMenuRectTransform.gameObject.SetActive(true);
        yield return AnimationUI.TweenVec3(
            _mainMenuRectTransform.localScale, 
            new Vector3(1.0f, 1.0f, 1.0f), 
            _durationScale_Panel,
            val => _mainMenuRectTransform.localScale = val,
            AnimationUI.EaseInOutCubic
            );
    }
    
    private IEnumerator ScaleDownRectTransform()
    {
        yield return AnimationUI.TweenVec3(
            _mainMenuRectTransform.localScale, 
            _scaleDownVector_Panel, 
            _durationScale_Panel,
            val => _mainMenuRectTransform.localScale = val,
            AnimationUI.EaseInOutCubic
        );
        _mainMenuRectTransform.gameObject.SetActive(false);
    }
    
    private IEnumerator OptionsPanelMoveAway()
    {
        yield return AnimationUI.TweenFloat(
            _optionsMenuRectTransform.anchoredPosition.x, 
            _positionXAway_Panel, 
            _durationMoving_Panel,
            val => {
                Vector3 pos = _optionsMenuRectTransform.anchoredPosition;
                pos.x = val;                                      
                _optionsMenuRectTransform.anchoredPosition = pos;
            },
            AnimationUI.EaseInOutCubic
        );
        _optionsMenuRectTransform.gameObject.SetActive(false);
    }

    private IEnumerator OptionsPanelMoveInside()
    {
        _optionsMenuRectTransform.gameObject.SetActive(true);
        yield return AnimationUI.TweenFloat(
            _optionsMenuRectTransform.anchoredPosition.x, 
            0f, 
            _durationMoving_Panel,
            val => {
                Vector2 anchoredPos = _optionsMenuRectTransform.anchoredPosition;
                anchoredPos.x = val;
                _optionsMenuRectTransform.anchoredPosition = anchoredPos;
            },
            AnimationUI.EaseInOutCubic
        );
    }
    
    
    
    
}
