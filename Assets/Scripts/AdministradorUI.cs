using UnityEngine;
using System.Collections;

public class AdministradorUI : MonoBehaviour 
{



	public void CambiarEscena(string escena)

	{
		Application.LoadLevel (escena); 
	}

	public void Salir()
	{
		Application.Quit ();
		Debug.Log ("SalirApp");
	}
}
