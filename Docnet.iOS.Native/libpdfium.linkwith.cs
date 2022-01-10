using System;
using ObjCRuntime;

[assembly: LinkWith("libpdfium.a", LinkTarget.ArmV7 | LinkTarget.Simulator64, ForceLoad = true, IsCxx = true, Frameworks = "CoreAudio AudioToolbox", LinkerFlags = "-lstdc++ -lz")]
