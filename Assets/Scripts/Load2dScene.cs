using UnityEngine;
using UnityEngine.SceneManagement;

public class Load2DScene : MonoBehaviour
{
    [SerializeField] private string sceneName = "2DGameScene";
    
    private void Start()
    {
        // Load the 2D scene additively in the background
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
