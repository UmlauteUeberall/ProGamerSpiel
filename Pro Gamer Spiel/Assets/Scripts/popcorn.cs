using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    class popcorn : AEntity
    {
        static int m_PopcornCounter =0;

        public GameObject   m_PopcornPrefab;
        public float        m_SpawnInterval;
        public int          m_MaxSpawns;
        public float        m_AttackDistance;
        public float        m_ExplodeDistance;
        public float        m_movementSpeed;

        private float       m_SpawnTimer;
        private GameObject  m_Player;
        private AEntity     m_PlayerScript;

        protected override void Awake()
        {
            m_PopcornCounter++;
        }

        GameObject Player()
        {
            if (m_Player==null)
            {
                m_Player = GameObject.FindGameObjectWithTag("Player");
                AEntity m_PlayerScript = m_Player.GetComponent<AEntity>();
            }
            return m_Player;
        }

        void Explode()
        {
            if (Player())
            {
                m_PlayerScript.TakeDamage(0.1f);
            }
        }

        void Start()
        {
            m_SpawnTimer = Time.realtimeSinceStartup + m_SpawnInterval;
        }

        void Update()
        {
            if (m_SpawnTimer < Time.realtimeSinceStartup && m_PopcornCounter < m_MaxSpawns)
            {
                GameObject go = Instantiate(m_PopcornPrefab, transform.position, Quaternion.identity) as GameObject;
                m_SpawnTimer = Time.realtimeSinceStartup + m_SpawnInterval;
            }

            if (Player()!= null)
            {
                float dist = Vector3.Distance(transform.position, Player().transform.position);
                if (dist < m_AttackDistance)
                {
                    transform.LookAt(Player().transform);
                    transform.position += transform.forward * Time.deltaTime * m_movementSpeed;
                    if (dist < m_ExplodeDistance)
                    {
                        Explode();
                    }
                }
            }
        }

        void OnDestroy()
        {
            m_PopcornCounter--;
        }
    }
}
