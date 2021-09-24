using UnityEngine;

public class PlayerScipt2D : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 jumpHeight;

    private bool canJump = true;
    private ChangeScenes changeScenes;
    private Rigidbody2D rb;

    private void Start() {
        changeScenes = FindObjectOfType<ChangeScenes>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            canJump = true;
        }
        else {
            canJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "deathTrigger") {
            changeScenes.DiedInDream();
        }
    }
}
