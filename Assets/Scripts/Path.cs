using UnityEngine;

public class Path : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var roadPiece = other.gameObject.GetComponent<RoadPiece>();
        if(roadPiece != null)
            roadPiece.Passed();
    }
}
