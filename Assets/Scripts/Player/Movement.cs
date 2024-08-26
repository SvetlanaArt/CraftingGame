using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

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
            if (IsClickInGame())
            {
                ToCursor();
            }
        }

        private static bool IsClickInGame()
        {
            return Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();
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

