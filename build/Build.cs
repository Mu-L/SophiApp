using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    private static readonly string ProjectName = "SophiApp";
    private readonly AbsolutePath ProjectDirectory = RootDirectory / "src" / ProjectName;
    private readonly AbsolutePath PublishDirectory = RootDirectory / ProjectName / ProjectName;
    private const string WIN10X64 = "win10-x64";


    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = Configuration.Release; // IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            EnsureCleanDirectory(PublishDirectory);
            DotNetTasks.DotNetClean(c => c.SetProject(ProjectDirectory));
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore(configurator => configurator
            .SetProjectFile(ProjectDirectory)
            .SetRuntime(WIN10X64));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            MSBuildTasks.MSBuild(configuration => configuration
            .SetProjectFile(ProjectDirectory)
            .SetOutDir(PublishDirectory));

            //DotNetTasks.DotNetPublish(configurator => configurator
            //.SetProject(ProjectDirectory)
            //.SetConfiguration(Configuration)
            //// .SetPublishSingleFile(true)
            //// .SetPublishReadyToRun(true)
            //// .SetPublishTrimmed(true)
            //// .SetSelfContained(true)
            //.SetRuntime(WIN10X64)
            //// .SetProperty("IncludeNativeLibrariesForSelfExtract", true)
            //// .SetProperty("AssemblyVersion", Version.Parse(ActiveTag))
            //.SetOutput(PublishDirectory));
            //// .EnableNoRestore());
        });
}
