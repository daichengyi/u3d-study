using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;

    private float inputX;
    private float inputY;
    private Vector2 movementInput;

    public float speed;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Movement();//����֡�����ƶ�
    }

    private void LateUpdate()
    {
        //�������
    }

    private void PlayerInput()
    {
        // if(inputX == 0)
        inputX = Input.GetAxisRaw("Horizontal");
        // if(inputY == 0)
        inputY = Input.GetAxisRaw("Vertical");

        //����б�����ƶ��ٶ�
        if (inputX != 0 && inputY != 0) {
            inputX = inputX * 0.6f;
            inputY = inputY * 0.6f;
        }

        movementInput = new Vector2(inputX, inputY);
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput *speed * Time.deltaTime);
    }
}
