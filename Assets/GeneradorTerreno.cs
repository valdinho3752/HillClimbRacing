using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GeneradorTerreno : MonoBehaviour
{
    public SpriteShapeController shape;
    public int escala = 1000;
    public int numPuntos = 150;
    
    public int dimensionCurvas = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        float distanciaPuntos = (float)escala / (float)numPuntos;
        shape.spline.SetPosition(2,shape.spline.GetPosition(2) + Vector3.right*escala);
        shape.spline.SetPosition(3,shape.spline.GetPosition(3) + Vector3.right*escala);//alargamos el terrno a nuestro gusto
        for(int i = 0; i < numPuntos;i++){
            float xPos = shape.spline.GetPosition(i+1).x + distanciaPuntos;//definimos nuestro nuevo punto oteniendo la posicion del vertice 1 y le sumamos una distancia definida 
            shape.spline.InsertPointAt(i+2,new Vector3(xPos, dimensionCurvas * Mathf.PerlinNoise(i*Random.Range(5.0f,15.0f),0)));//anhdimos el punto en esa posicion y lo elevamos aleatoriamente con una dimension ya definida
        }

        for(int i = 2; i < numPuntos + 2; i++){
            shape.spline.SetTangentMode(i,ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(i,new Vector3(-1,0,0));
            shape.spline.SetRightTangent(i,new Vector3(1,0,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
