using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class RestartButton : MonoBehaviour
{
    // 重新开始游戏的方法
    public void RestartGame()
    {
        // 获取当前场景的名称
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneName);
    }
}
