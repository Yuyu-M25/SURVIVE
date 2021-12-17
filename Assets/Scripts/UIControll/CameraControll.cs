using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �J�����̓�����R���g���[������N���X
public class CameraControll : MonoBehaviour
{
    GameObject player;
    Vector3 vec;

    // �U���p�̕ϐ�
    bool is_shake = false;
    float elapsed = 0f;

    void Start()
    {
        // �v���C���[���擾
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        vec.y = transform.position.y;
        vec.z = transform.position.z;

    }

    private void LateUpdate()
    {
        if (player != null && !is_shake)
        {
            // �`��O�Ɉʒu���X�V
            vec.x = player.transform.position.x;

            transform.position = vec;
        }
    }


    public IEnumerator Shake(float duration, float magnitude)
    {
        // �U�������Ȃ��I�v�V�����������ꍇ�͑���~
        if (!OptionData.current_options.is_play_shake)
            yield break;

        elapsed = 0f;

        if (is_shake)
            yield break;

        is_shake = true;

        while(elapsed < duration) 
        {

            vec.x = player.transform.position.x;

            transform.position = vec + Random.insideUnitSphere * magnitude;
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = vec;
        is_shake = false;
    }




}