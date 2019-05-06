﻿using System;
using System.Runtime.InteropServices;

namespace Dhcp.Callout.Native
{
    internal static class Win32Api
    {
        /// <summary>
        /// Loads the specified module into the address space of the calling process.
        /// The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpFileName">The name of the module. This can be either a library module (a .dll file)
        /// or an executable module (an .exe file). The name specified is the file name of the module and
        /// is not related to the name stored in the library module itself, as specified by the LIBRARY
        /// keyword in the module-definition (.def) file.
        /// If the string specifies a full path, the function searches only that path for the module.
        /// If the string specifies a relative path or a module name without a path, the function uses a
        /// standard search strategy to find the module; for more information, see the Remarks.
        /// If the function cannot find the module, the function fails. When specifying a path, be sure to
        /// use backslashes (\), not forward slashes(/). For more information about paths, see Naming a File or Directory.
        /// If the string specifies a module name without a path and the file name extension is omitted,
        /// the function appends the default library extension .dll to the module name.To prevent the function
        /// from appending .dll to the module name, include a trailing point character (.) in the module name string.</param>
        /// <returns>If the function succeeds, the return value is a handle to the module.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="hModule">A handle to the DLL module that contains the function or variable. The LoadLibrary,
        /// LoadLibraryEx, LoadPackagedLibrary, or GetModuleHandle function returns this handle. The GetProcAddress
        /// function does not retrieve addresses from modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.
        /// For more information, see LoadLibraryEx.</param>
        /// <param name="lpProcName">The function or variable name, or the function's ordinal value. If this parameter
        /// is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails,
        /// the return value is zero. To get extended error information, call the GetLastError function.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count.
        /// When the reference count reaches zero, the module is unloaded from the address space of the calling
        /// process and the handle is no longer valid.
        /// </summary>
        /// <param name="hModule">
        /// A handle to the loaded library module. The LoadLibrary, LoadLibraryEx,
        /// GetModuleHandle, or GetModuleHandleEx function returns this handle.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails,
        /// the return value is zero. To get extended error information, call the GetLastError function.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
}
