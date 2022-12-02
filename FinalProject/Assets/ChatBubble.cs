using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake() {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Message").GetComponent<TextMeshPro>();
    }

    private void Start() {
        Setup("Hello World!");
    }

    private void Setup(string text) {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textsize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(0.1f, 0.05f);
        backgroundSpriteRenderer.size = (textsize + padding);

        backgroundSpriteRenderer.transform.localPosition = new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f);

    }
}
