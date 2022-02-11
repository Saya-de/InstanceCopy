using System.Reflection;
using MelonLoader;
using System;

[assembly: AssemblyTitle(InstanceCopy.Main.Name)]
[assembly: AssemblyDescription(InstanceCopy.Main.Description)]
[assembly: AssemblyCompany(InstanceCopy.Main.Company)]
[assembly: AssemblyProduct(InstanceCopy.Main.Name)]
[assembly: AssemblyCopyright("Created by " + InstanceCopy.Main.Author)]
[assembly: AssemblyTrademark(InstanceCopy.Main.Company)]
[assembly: AssemblyVersion(InstanceCopy.Main.Version)]
[assembly: AssemblyFileVersion(InstanceCopy.Main.Version)]
[assembly: MelonInfo(typeof(InstanceCopy.InstanceCopy), InstanceCopy.Main.Name, InstanceCopy.Main.Version, InstanceCopy.Main.Author, InstanceCopy.Main.DownloadLink)]
[assembly: MelonColor(ConsoleColor.DarkGray)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]