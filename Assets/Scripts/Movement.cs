using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.right * _speed * Time.deltaTime * - 1);
        }
    }
}
