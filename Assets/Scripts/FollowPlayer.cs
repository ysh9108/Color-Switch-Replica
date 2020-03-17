using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Camera camera;

    public Transform player;

    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }

        if (OutOfCamera(player))
        {
            Debug.Log("Not Visible");
            SceneController.ReloadScene();
        }
    }

    /// <summary>
    /// 오브젝트가 화면 밖으로 벗어났는지 확인하는 메소드입니다.
    /// </summary>
    /// <param name="targetPosition">오브젝트의 위치를 의미합니다.</param>
    /// <returns>True : 화면 밖, False : 화면 안</returns>
    bool OutOfCamera(Transform targetPosition)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(targetPosition.position);
        return !(screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1);

    }
}
