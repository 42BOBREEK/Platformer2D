#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using System;
using System.IO;

[InitializeOnLoad]
public static class CompilationDiagnostics
{
    private static readonly string LogPath = "Assets/Editor/CompilationLog.txt";

    static CompilationDiagnostics()
    {
        CompilationPipeline.compilationStarted += OnCompilationStarted;
        CompilationPipeline.compilationFinished += OnCompilationFinished;
        AssemblyReloadEvents.beforeAssemblyReload += OnBeforeReload;
        AssemblyReloadEvents.afterAssemblyReload += OnAfterReload;

        Log("=== Diagnostics initialized ===");
    }

    private static void OnCompilationStarted(object context)
    {
        Log("🟡 Compilation started");
    }

    private static void OnCompilationFinished(object context)
    {
        Log("🟢 Compilation finished");
    }

    private static void OnBeforeReload()
    {
        Log("🔒 Before assembly reload");
    }

    private static void OnAfterReload()
    {
        Log("🔓 After assembly reload");
    }

    private static void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        string line = $"[{timestamp}] {message}";
        Debug.Log(line);
        try
        {
            File.AppendAllText(LogPath, line + Environment.NewLine);
        }
        catch (Exception e)
        {
            Debug.LogWarning($"Failed to write log: {e.Message}");
        }
    }
}
#endif
