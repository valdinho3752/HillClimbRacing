using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorGasolina : MonoBehaviour
{
    public static ControladorGasolina instancia;

    [SerializeField] private Image imgGasolina;
    [SerializeField] private float velocidadDrenado = 10f;
    [SerializeField] private float maxGasolina = 100f;

    private float cantidadActual;
    
    private void Awake() {
        if(instancia == null){
            instancia = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        cantidadActual = maxGasolina;
        ActualizarUI();
    }

    // Update is called once per frame
    void Update()
    {
        cantidadActual -= Time.deltaTime * velocidadDrenado;
        ActualizarUI();

        if(cantidadActual <= 0){
            GameManager.instancia.GameOver();
        }
    }
    
    private void ActualizarUI(){
        imgGasolina.fillAmount = (cantidadActual / maxGasolina);
    }
}
