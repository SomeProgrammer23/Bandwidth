using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    public class TempAIController : MonoBehaviour
    {
        [SerializeField] float m_MovingTurnSpeed = 360;
        [SerializeField] float m_StationaryTurnSpeed = 180;

        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding

        private Transform target;                                    // target to aim for
        float m_TurnAmount;
        float m_ForwardAmount;
        Vector3 m_GroundNormal;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();

            agent.updateRotation = false;
            agent.updatePosition = true;
            target = GameObject.Find("FPSController").transform;
            //m_IsGrounded = true;
        }


        private void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                Move(agent.desiredVelocity);
                this.GetComponent<Animator>().SetBool("isWalking",true);
            }
            else
            {
                Move(Vector3.zero);
                this.GetComponent<Animator>().SetBool("isWalking", false);
            }
                
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void Move(Vector3 move)
        {

            // convert the world relative moveInput vector into a local-relative
            // turn amount and forward amount required to head in the desired
            // direction.
            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);
            move = Vector3.ProjectOnPlane(move, m_GroundNormal);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);
            m_ForwardAmount = move.z;

            ApplyExtraTurnRotation();

        }
        void ApplyExtraTurnRotation()
        {
            // help the character turn faster (this is in addition to root rotation in the animation)
            float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
            transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
        }
    }
}

