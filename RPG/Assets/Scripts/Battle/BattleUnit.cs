using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] bool isPlayerUnit;
    [SerializeField] BattleHud hud;


    public BattleHud Hud { get { return hud; } }
    public bool IsPlayerUnit { get { return isPlayerUnit; } }
    public Pokemon Pokemon { get; set; }

    Image image;
    Vector2 originalPos;
    Color originalColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        originalColor = image.color;
    }
    public void Setup(Pokemon pokemon)
    {
        Pokemon = pokemon;
        if (isPlayerUnit) { GetComponent<Image>().sprite = Pokemon.Base.BackSprite; }
        else { GetComponent<Image>().sprite = Pokemon.Base.FrontSprite; }

        hud.SetData(pokemon);

        image.color = originalColor;
        PlayEnterAnimation();
    }

    public void PlayEnterAnimation()
    {
        if (isPlayerUnit) image.transform.localPosition = new Vector2(-500f, originalPos.y);
        else image.transform.localPosition = new Vector2(500f, originalPos.y);

        image.transform.DOLocalMoveX(originalPos.x, 1f);

        var sequence = DOTween.Sequence();
        sequence.Append(image.material.DOColor(originalColor, 0.1f));
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if (isPlayerUnit) sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 50f, 0.25f));
        else sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));

        sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
    }

    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.material.DOColor(Color.red, 0.1f));
        sequence.Append(image.material.DOColor(originalColor, 0.1f));
    }

    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(image.material.DOFade(0f, 0.5f));
    }
}
