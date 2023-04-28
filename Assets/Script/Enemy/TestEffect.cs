using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffect : MonoBehaviour
{

    ParticleSystem m_ParticleSystem;

    public float m_Speed = 1;


    private float m_TotalTime = 0;
    private�@Vector3 tmp;
    private ParticleSystem.Particle[] m_Particles;
    private Transform player;


    void Start()
    {
        //�R���|�[�l���g���擾
        m_ParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // "Player" �I�u�W�F�N�g���������� Transform �R���|�[�l���g���擾
        player = GameObject.Find("Player").transform;

        // �K�v�ȏꍇ�̂ݔz����쐬���Ȃ���
        int maxParticles = m_ParticleSystem.main.maxParticles;
        if (m_Particles == null || m_Particles.Length < maxParticles)
        {
            m_Particles = new ParticleSystem.Particle[maxParticles];
        }

        // ���݂̃p�[�e�B�N�����擾����
        int particleNum = m_ParticleSystem.GetParticles(m_Particles);

        ////�p�[�e�B�N���ЂƂЂƂ̏���
        //for (int i = 0; i < particleNum; i++)
        //{
        //    tmp = m_Particles[i].position;

        //    m_Particles[i].position = tmp;
        //}


        // �ЂƂЂƂ̃p�[�e�B�N�����v���C���[�̍��W��
        //�v���C���[�̌��݈ʒu����^�[�Q�b�g�ʒu�ւ̃x�N�g�����v�Z
        Vector3 direction = player.position - tmp;

        //�x�N�g���̒����i�����j���v�Z
        float distance = direction.magnitude;

        //�x�N�g���̐��K���i������1�ɂ���j���Ĉړ�����������
        Vector3 moveDirection = direction.normalized;

        //�ړ�����
        tmp += moveDirection * m_Speed * Time.deltaTime;
        // �ύX��K�p����
        m_ParticleSystem.SetParticles(m_Particles, particleNum);

        m_TotalTime += Time.deltaTime;
    }

    private void OnTrigerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //���g���폜
            Destroy(gameObject);

        }
    }
}
