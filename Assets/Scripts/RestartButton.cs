using UnityEngine;
using UnityEngine.SceneManagement; // ���볡�����������ռ�

public class RestartButton : MonoBehaviour
{
    // ���¿�ʼ��Ϸ�ķ���
    public void RestartGame()
    {
        // ��ȡ��ǰ����������
        string currentSceneName = SceneManager.GetActiveScene().name;

        // ���¼��ص�ǰ����
        SceneManager.LoadScene(currentSceneName);
    }
}
