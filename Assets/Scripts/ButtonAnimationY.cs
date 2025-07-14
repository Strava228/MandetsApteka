using UnityEngine;

public class ButtonAnimationY : MonoBehaviour {
    
    [SerializeField] float speed = 1;
    [SerializeField] float amplitude = 2;

    float baseY;

    private void Start() {

        baseY = transform.localPosition.y;
    }


    void Update() {

        float delta = amplitude * Mathf.Sin(Time.time * speed);
        Vector3 pos = transform.localPosition;
        pos.y = baseY + delta;
        transform.localPosition = pos;
    }
}
