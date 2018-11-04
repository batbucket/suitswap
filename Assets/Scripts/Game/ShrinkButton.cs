using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShrinkButton : Button {

    private static readonly Vector3 SHRINK_SCALE = new Vector3(.8f, .8f, 1);
    private Vector3 initialScale;

    public override void OnPointerDown(PointerEventData eventData) {
        if (interactable) {
            SoundManager.Instance.Play(SoundManager.Instance.click);
            initialScale = targetGraphic.transform.localScale;
            targetGraphic.transform.localScale = SHRINK_SCALE;
            onClick.Invoke();
        }
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData) {
        if (interactable) {
            targetGraphic.transform.localScale = initialScale;
        }
        base.OnPointerUp(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData) {
        // Do nothing
    }
}
