using UnityEngine;

public class ButtonAnimationRot : MonoBehaviour {
    
    [SerializeField] float speed = 1;
    [SerializeField] float amplitude = 2;

    float baseRot;

    private void Start() {

        baseRot = transform.eulerAngles.z;
    }


    void Update() {

        float delta = baseRot + amplitude * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(0, 0, delta);
    }
}
