using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] public float MovementSpeed;
    private CharacterController charController;
    public GameObject projectile;
    // Start is called before the first frame update
    private void Awake()
    {
        charController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        shooting();
    }
    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * MovementSpeed * Time.deltaTime;
        float vertInput = Input.GetAxis(verticalInputName) * MovementSpeed * Time.deltaTime;

        Vector3 fowardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(fowardMovement + rightMovement);
    }
    private void shooting() {
        if (Input.GetKeyDown(KeyCode.A))
        {

            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        }
    }
}
