
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetScene; // Название сцены, на которую нужно перейти

    void Start()
    {
        // Здесь можно добавить логику инициализации
    }

    public void ChangeScene()
    {
        // Плавная смена сцены с использованием fade эффекта
        StartCoroutine(FadedSceneChange());
    }

    private IEnumerator FadedSceneChange()
    {
        // Задаем камеру, которая будет использоваться для эффекта fade
        Camera mainCamera = Camera.main;

        // Устанавливаем фоновое изображение для эффекта fade
        Texture fadeTexture = Resources.Load<Texture>("fade"); // Замените на путь к вашей текстуре
        mainCamera.backgroundColor = new Color(fadeTexture.grayscale(0.5f));

        // Плавное затемнение
        float t = 0f;
        float duration = 2f; // Длительность эффекта fade
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            mainCamera.backgroundColor = new Color(fadeTexture.grayscale(t));
            yield return null;
        }

        // Загружаем целевую сцену
        SceneManager.LoadScene(targetScene);
    }

    // Метод для проверки, что сцена загружена
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Опционально: код, который выполняется после загрузки сцены
        Debug.Log("Сцена загружена: " + scene.name);
    }
}
