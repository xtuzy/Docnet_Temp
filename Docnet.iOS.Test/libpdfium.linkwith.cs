using System;
using ObjCRuntime;

[assembly: LinkWith("libpdfium.a", LinkTarget.ArmV7 | LinkTarget.Simulator64 | LinkTarget.Simulator | LinkTarget.x86_64 | LinkTarget.Arm64, ForceLoad = true, IsCxx = true, SmartLink = true)]
