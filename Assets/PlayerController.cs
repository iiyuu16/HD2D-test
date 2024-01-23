using UnityEngine;

namespace ClearSky
{
    public class PlayerController : MonoBehaviour
    {
        public float movePower = 5f;

        private Rigidbody rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Run();
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.back;

                transform.localScale = new Vector3(1, 1, direction);
                    anim.SetBool("isRun", true);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.forward;

                transform.localScale = new Vector3(1, 1, direction);
                    anim.SetBool("isRun", true);
            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }


    }
}
