﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace System.Device.Gpio;

/// <summary>
/// Pointer to an iterator of all GPIO chips available on the device.
/// </summary>
internal class SafeChipIteratorHandle : SafeHandle
{
    public SafeChipIteratorHandle()
        : base(IntPtr.Zero, true)
    {
    }

    protected override bool ReleaseHandle()
    {
        Interop.Libgpiod.gpiod_chip_iter_free(handle);
        return true;
    }

    public override bool IsInvalid => handle == IntPtr.Zero || handle == Interop.Libgpiod.InvalidHandleValue;
}
