#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

[InitializeOnLoad]
public static class AssemblyUnlocker
{
    static AssemblyUnlocker()
    {
        // Подпишемся на событие окончания компиляции
        CompilationPipeline.compilationFinished += OnCompilationFinished;
        EditorApplication.update += OnEditorUpdate;
    }

    private static void OnEditorUpdate()
    {
        // Если редактор не компилирует в данный момент, отпускаем блокировку
        if (!EditorApplication.isCompiling)
        {
            // Попробуем разблокировать
            EditorApplication.UnlockReloadAssemblies();
        }
    }

    private static void OnCompilationFinished(object obj)
    {
        // Когда сборка завершена — убедимся, что лок снят
        EditorApplication.UnlockReloadAssemblies();
    }
}
#endif
