#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

[InitializeOnLoad]
static class AssemblyLockWatcher
{
    // Таймаут (секунд) — через сколько считаем, что reload "завис"
    const double ReloadTimeoutSeconds = 5.0;

    // Внутреннее состояние
    static double compileFinishedTime = 0.0;
    static bool waitingForReload = false;
    static bool subscribed = false;

    static AssemblyLockWatcher()
    {
        // Подписываемся один раз
        if (!subscribed)
        {
            CompilationPipeline.compilationStarted += OnCompilationStarted;
            CompilationPipeline.compilationFinished += OnCompilationFinished;
            AssemblyReloadEvents.beforeAssemblyReload += OnBeforeAssemblyReload;
            AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReload;
            EditorApplication.update += OnEditorUpdate;
            subscribed = true;
            Debug.Log("[AssemblyLockWatcher] initialized");
        }
    }

    static void OnCompilationStarted(object context)
    {
        // Началась компиляция — сбрасываем состояние ожидания
        waitingForReload = false;
        compileFinishedTime = 0.0;
        //Debug.Log("[AssemblyLockWatcher] compilation started");
    }

    static void OnCompilationFinished(object context)
    {
        // Компиляция завершилась — теперь ожидаем, что скоро начнётся reload
        compileFinishedTime = EditorApplication.timeSinceStartup;
        waitingForReload = true;
        //Debug.Log("[AssemblyLockWatcher] compilation finished; waiting for assembly reload...");
    }

    static void OnBeforeAssemblyReload()
    {
        // Важно: если reload начался — отменяем таймаутное действие
        waitingForReload = false;
        compileFinishedTime = 0.0;
        //Debug.Log("[AssemblyLockWatcher] before assembly reload");
    }

    static void OnAfterAssemblyReload()
    {
        // Всё успешно перезагрузилось — ничего не делаем
        waitingForReload = false;
        compileFinishedTime = 0.0;
        //Debug.Log("[AssemblyLockWatcher] after assembly reload");
    }

    static void OnEditorUpdate()
    {
        if (!waitingForReload) return;

        var elapsed = EditorApplication.timeSinceStartup - compileFinishedTime;
        if (elapsed < ReloadTimeoutSeconds) return;

        // Таймаут сработал — пытаемся "освободить" заблокированные ассамбли
        waitingForReload = false;
        compileFinishedTime = 0.0;

        try
        {
            Debug.LogWarning($"[AssemblyLockWatcher] assembly reload not started within {ReloadTimeoutSeconds}s — attempting to UnlockReloadAssemblies() to recover.");
            // Попытка разблокировки и пересканирования ассетов
            EditorApplication.UnlockReloadAssemblies();
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
            // Неблокирующий лог; не открываем диалоги — это editor-only helper
            Debug.Log("[AssemblyLockWatcher] UnlockReloadAssemblies() called and AssetDatabase.Refresh() requested.");
        }
        catch (Exception ex)
        {
            Debug.LogError("[AssemblyLockWatcher] failed to unlock assemblies: " + ex);
        }
    }
}
#endif
