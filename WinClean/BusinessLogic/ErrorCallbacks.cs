﻿using Scover.WinClean.BusinessLogic.Scripts;

namespace Scover.WinClean.BusinessLogic;

/// <summary>Callback called when a filesystem error occurs.</summary>
/// <param name="e">The filesystem exception that occured.</param>
public delegate bool FSErrorCallback(FileSystemException e);
/// <summary>
/// Callback called when the script timeout has been reached and the script is unlikely to finish executing.
/// </summary>
/// <param name="script">The hung script.</param>
/// <returns>
/// <see langword="true"/> if the script should be allowed to keep executing, or <see langword="false"/> if
/// its associated process tree should be terminated.
/// </returns>
public delegate bool HungScriptCallback(Script script);

/// <summary>Callback called a script could not be created because it has invalid or missing data.</summary>
/// <param name="exception">The exception that caused the error.</param>
/// <param name="source">The source of the script.</param>
/// <returns>A <see cref="InvalidScriptDataAction"/> value.</returns>
public delegate InvalidScriptDataAction InvalidScriptDataCallback(Exception exception, string source);

public enum InvalidScriptDataAction
{
    /// <summary>Attempt to reload the script</summary>
    Reload,

    /// <summary>Ignore this script.</summary>
    Ignore,

    /// <summary>Remove this script.</summary>
    Remove,
}