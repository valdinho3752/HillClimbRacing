using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducir : MonoBehaviour
{
    public WheelJoint2D ruedaDelantera;
    public WheelJoint2D ruedaTrasera;
    public float velocidad = 650;

    private Coroutine reduccionCorutina;

    // Start is called before the first frame update
    void Start()
    {
        if (ruedaDelantera == null)
            ruedaDelantera = GetComponentInChildren<WheelJoint2D>();

        if (ruedaTrasera == null)
            ruedaTrasera = GetComponentInChildren<WheelJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Control de la flecha izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CambiarVelocidadRueda(ruedaDelantera, velocidad);
            CambiarVelocidadRueda(ruedaTrasera, velocidad);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ruedaDelantera.useMotor = false;
            ruedaTrasera.useMotor = false;
            //CambiarVelocidadRueda(ruedaDelantera, 0f);
            //CambiarVelocidadRueda(ruedaTrasera, 0f);
        }

        //Control de la flecha derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CambiarVelocidadRueda(ruedaDelantera, -velocidad);
            CambiarVelocidadRueda(ruedaTrasera, -velocidad);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ruedaDelantera.useMotor = false;
            ruedaTrasera.useMotor = false;
            //CambiarVelocidadRueda(ruedaDelantera, 0f);
            //CambiarVelocidadRueda(ruedaTrasera, 0f);
        }
    }

    private void CambiarVelocidadRueda(WheelJoint2D rueda, float nuevaVelocidad)
    {
        JointMotor2D motor = rueda.motor;
        motor.motorSpeed = nuevaVelocidad;
        rueda.motor = motor;
    }
}