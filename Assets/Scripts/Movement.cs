using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Tooltip("Player Speed")]
    [SerializeField] float moveSpeed;
    [SerializeField] DialogueOngoing dialogue;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        // Speed not set
        if (moveSpeed == 0)
        {
            Debug.LogWarning("moveSpeed == 0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dialogue.dialogueOngoing);
        // Freeze movement if dialogue is ongoing
        if (dialogue.dialogueOngoing)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else { // Unfreeze movement otherwise
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // Get keybaord inputs
        Vector2 _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Add velocity
        _rb.velocity = _moveDirection * moveSpeed;
    }
}
