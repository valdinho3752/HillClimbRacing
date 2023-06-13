using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducir : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RuedaDelanteraRB;
    [SerializeField] private Rigidbody2D RuedaTraceraRB;
    [SerializeField] private float velocidad = 150f;

    private float movimiento;

    // Start is called before the first frame update
    void Start()
    {
        movimiento = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        RuedaDelanteraRB.AddTorque(-movimiento * velocidad * Time.fixedDeltaTime);
        RuedaTraceraRB.AddTorque(-movimiento * velocidad * Time.fixedDeltaTime);
    }
}
