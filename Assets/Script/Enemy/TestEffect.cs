using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffect : MonoBehaviour
{

    ParticleSystem m_ParticleSystem;

    public float m_Speed = 1;


    private float m_TotalTime = 0;
    private　Vector3 tmp;
    private ParticleSystem.Particle[] m_Particles;
    private Transform player;


    void Start()
    {
        //コンポーネントを取得
        m_ParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // "Player" オブジェクトを検索して Transform コンポーネントを取得
        player = GameObject.Find("Player").transform;

        // 必要な場合のみ配列を作成しなおす
        int maxParticles = m_ParticleSystem.main.maxParticles;
        if (m_Particles == null || m_Particles.Length < maxParticles)
        {
            m_Particles = new ParticleSystem.Particle[maxParticles];
        }

        // 現在のパーティクルを取得する
        int particleNum = m_ParticleSystem.GetParticles(m_Particles);

        ////パーティクルひとつひとつの処理
        //for (int i = 0; i < particleNum; i++)
        //{
        //    tmp = m_Particles[i].position;

        //    m_Particles[i].position = tmp;
        //}


        // ひとつひとつのパーティクルをプレイヤーの座標に
        //プレイヤーの現在位置からターゲット位置へのベクトルを計算
        Vector3 direction = player.position - tmp;

        //ベクトルの長さ（距離）を計算
        float distance = direction.magnitude;

        //ベクトルの正規化（長さを1にする）して移動方向を決定
        Vector3 moveDirection = direction.normalized;

        //移動する
        tmp += moveDirection * m_Speed * Time.deltaTime;
        // 変更を適用する
        m_ParticleSystem.SetParticles(m_Particles, particleNum);

        m_TotalTime += Time.deltaTime;
    }

    private void OnTrigerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //自身を削除
            Destroy(gameObject);

        }
    }
}
