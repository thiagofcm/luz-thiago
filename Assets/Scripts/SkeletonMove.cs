using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMove : MonoBehaviour {

    public float velocidade = 1;
    public List<Vector3> lista = new List<Vector3>();

    int destino;

	// Use this for initialization
	void Start () {
        destino = 0;
        StartCoroutine("MoverAteProximoPonto");
    }

    IEnumerator MoverAteProximoPonto() {
        transform.LookAt(lista[destino]);

        while (transform.position != lista[destino]) { 
            transform.position = Vector3.MoveTowards(transform.position, lista[destino], velocidade * Time.deltaTime);
            yield return null;
        }

        destino++;
        if (destino >= lista.Count) {
            destino = 0;
        }

        StartCoroutine("MoverAteProximoPonto");
    }


	// Update is called once per frame
	void Update () {
		
	}
}
