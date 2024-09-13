using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float _speed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddRelativeForce(Vector3.forward * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 检测到子弹碰到带有 "Enemy" 标签的物体
        if (other.CompareTag("Other"))
        {
            Destroy(gameObject); // 碰到敌人，子弹提前消失
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject); // 如果没有碰到敌人，5秒后自动销毁
    }

    // 这个方法可以保证每个子弹都在5秒后自动消失
    void OnEnable()
    {
        StartCoroutine(Kill());
    }

}
