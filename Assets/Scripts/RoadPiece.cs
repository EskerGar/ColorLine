using System;
using UnityEngine;

public class RoadPiece : MonoBehaviour
{
        [SerializeField] private Material passMaterial;
        
        private MeshRenderer _meshRenderer;

        public void Passed()
        {
                _meshRenderer.material = passMaterial;
        }
        
        private void Awake()
        {
                _meshRenderer = GetComponent<MeshRenderer>();
        }
        

}