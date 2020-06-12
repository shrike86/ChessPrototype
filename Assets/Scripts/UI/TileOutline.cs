using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.UI
{
    public class TileOutline : MonoBehaviour
    {
        public new MeshRenderer renderer;

        private void Start()
        {
            renderer = GetComponent<MeshRenderer>();
        }

        public void UpdateRendererMaterial(Material newMat)
        {
            renderer.material = newMat;
        }
    }
}