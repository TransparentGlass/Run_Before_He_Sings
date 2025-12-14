using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartAnim : MonoBehaviour
{
    [SerializeField] private Sprite brokenHeartSprite;

    private Image img;
    private RectTransform rt;
    private Sprite fullHeartSprite;

    void Awake()
    {
        img = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        fullHeartSprite = img.sprite;
    }

    public void PlayBreakAnim()
    {
        StopAllCoroutines();
        StartCoroutine(BreakAnim());
    }

    IEnumerator BreakAnim()
    {
        // swap to broken heart
        img.sprite = brokenHeartSprite;

        float time = 0f;
        float duration = 0.25f;

        Vector3 startScale = Vector3.one;
        Vector3 endScale = Vector3.one * 1.4f;

        Color startColor = img.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            rt.localScale = Vector3.Lerp(startScale, endScale, t);
            img.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                Mathf.Lerp(1f, 0f, t)
            );

            yield return null;
        }

        // reset for reuse
        img.enabled = false;
        img.sprite = fullHeartSprite;
        img.color = startColor;
        rt.localScale = Vector3.one;
    }
}
