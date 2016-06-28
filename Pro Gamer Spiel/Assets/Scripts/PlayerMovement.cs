using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public float m_MovementSpeed = 5;
    public float m_RunMovementSpeed = 7.5f;
    public float m_JumpForce = 1;
    public float m_Gravity = 9.81f;

    float m_ySpeed = 0f;
    CharacterController m_charController;

    // Use this for initialization
    void Start()
    {
        m_charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
                                    0,
                                    Input.GetAxis("Vertical"));

        // Spieler rennt, wenn LeftShit gedrückt wird
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= m_RunMovementSpeed * Time.deltaTime;
        }
        else // Ansonsten geht der Spieler mit normaler Geschwindigkeit
        {
            move *= m_MovementSpeed * Time.deltaTime;
        }
        transform.Translate(move);

        // Wenn der Spieler nicht auf dem Boden ist, fällt er
        if (!m_charController.isGrounded)
        {
            m_ySpeed -= m_Gravity * Time.deltaTime;
        }
        else if (m_charController.isGrounded && Input.GetKey(KeyCode.Space))    // Ist der Spieler auf dem Boden kann er Springen
        {
            m_ySpeed = m_JumpForce;
        }
        else
        {
            move.y = 0f;
        }
        move.y = m_ySpeed;
        m_charController.Move(transform.TransformDirection(move));
    }
}
