using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트

    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        /*      transform.forward는 현재 게임 오브젝트의 z축 방향을 나타내는 Vector3타입 변수
                transform component can be accessed directly as 'transform' variable for convenience.
         */
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 후 스스로 파멸
        Destroy(gameObject, 3f);

    }
    
    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져와서 단순히 playerController 변수로 부르기.
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            if (playerController != null)
            {
                //상대방의 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
                
            }
        }
    }
}
