using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {
    public float moveSpeed = 1f;
    public float fadeSpeed = 1f;

    [SerializeField]private TMP_Text damageText;

    private void Awake() {

    }

    public void SetDamage(int damage) {
        damageText.text = damage.ToString();
    }

    private void Update() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, damageText.color.a - fadeSpeed * Time.deltaTime);
        if (damageText.color.a <= 0) {
            Destroy(gameObject);
        }
    }
}