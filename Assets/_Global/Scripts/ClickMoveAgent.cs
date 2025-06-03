using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickMoveAgent : MonoBehaviour
{
    NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // @Speed: dont use infinite raycast distance for normal games...
            if (Physics.Raycast(ray, out RaycastHit hit))
                _agent.SetDestination(hit.point);
        }
    }
}
