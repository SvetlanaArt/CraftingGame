using UnityEngine;
using UnityEngine.AI;

namespace CraftingUnit.Player
{
    /// <summary>
    /// Player movement
    /// </summary>
    public class Movement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent navMeshAgent;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ToCursor();
            }
        }

        private void ToCursor()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                navMeshAgent.destination = hit.point;
            }
        }
    }
}

