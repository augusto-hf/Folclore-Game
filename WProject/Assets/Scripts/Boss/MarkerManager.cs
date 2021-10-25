using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    //Sendo colocado em cada parte do corpo da cobra ele adiciona marcadores na sua lista
    public class Marker
    {
        public Vector3 position;//posição do marcador
        public Quaternion rotation; //rotação...

        public Marker(Vector3 pos, Quaternion rot)
        {//basicaente essa é a variavel que representa um marcador
            position = pos;
            rotation = rot;
        }
    }
    //lista de todos os marcadores
    public List<Marker> markerList = new List<Marker>();
     
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        UpdateMarkerList();
    }
    public void UpdateMarkerList()
    {//adiciona marcadores na lista
        markerList.Add(new Marker(transform.position, transform.rotation));
    }
    public void ClearMarketList()
    {
        markerList.Clear();
        markerList.Add(new Marker(transform.position, transform.rotation));
    }
}
