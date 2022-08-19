# IsExternalInit [![Nuget](https://img.shields.io/nuget/v/IsExternalInit)](https://www.nuget.org/packages/IsExternalInit)

_Use C# 9's init and record features in older target frameworks._

[:running: Quickstart](#quickstart) &nbsp; | &nbsp; [:package: NuGet](https://www.nuget.org/packages/isexternalinit)

<hr/>

_You may also want to check out my [Nullable](https://github.com/manuelroemer/Nullable)
project which provides support for .NET's nullable reference type attributes for older target frameworks._

<hr/>


C# 9 added support for the `init` and `record` keywords. When using C# 9 with target frameworks
<= .NET 5.0, using these new features is not possible because the compiler is missing the
`IsExternalInit` class, hence making the features unavailable for any target framework prior to
.NET 5.

Luckily, this problem can be solved by re-declaring the `IsExternalInit` class as an
`internal class` in your own project. The compiler will use this custom class definition and thus
allow you to use both the `init` keywords and `record`s in any project.

This repository hosts the code for the ["IsExternalInit" NuGet Package](https://www.nuget.org/packages/IsExternalInit)
which, when referenced, automatically adds the `IsExternalInit` class to the referenced project(s).

The code for the `IsExternalInit` class is added **at compile time** and gets **built into the referencing project**.
This means that the resulting project **does not have an explicit dependency** on the `IsExternalInit`
package, because the code is not distributed as a standard library.


## Compatibility

IsExternalInit is currently compatible with the following target frameworks:

* .NET Standard >= 1.0
* .NET Framework >= 2.0


## Quickstart

> :warning: **Important:** <br/>
> You **must** use a C# version >= 9.0 with the `IsExternalInit` package - otherwise, your project won't compile.

The steps below assume that you are using the **new SDK `.csproj`** style.
Please find installation guides and notes for other project types (for example `packages.config`)
[here](https://github.com/manuelroemer/Nullable/wiki).

1. **Reference the package** <br/>
   Add the package to your project, for example via:

   ```sh
   Install-Package IsExternalInit

   --or--

   dotnet add package IsExternalInit
   ```
2. **Ensure that the package has been added as a development dependency** <br/>
   Open your `.csproj` file and ensure that the new package reference looks similar to this:

   ```xml
   <PackageReference Include="IsExternalInit" Version="<YOUR_VERSION>" PrivateAssets="all" />

   <!-- NuGet, by default, uses this style. This is also acceptable. -->
   <PackageReference Include="IsExternalInit" Version="<YOUR_VERSION>">
     <PrivateAssets>all</PrivateAssets>
     <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
   </PackageReference>
   ```

   This is especially important for libraries that are published to NuGet, because without this,
   the library will have an **explicit dependency** on the `IsExternalInit` package.
3. **Build the project** <br/>
   Ensure that the project compiles. If a build error occurs, you will most likely have to update
   the C# language version.

Afterwards, you can immediately start using the attributes.


## Compiler Constants

The [included C# file](https://github.com/manuelroemer/IsExternalInit/blob/master/src/IsExternalInit/IsExternalInit.cs)
makes use of some compiler constants that can be used to enable or disable certain features.

### `ISEXTERNALINIT_DISABLE`

If the `ISEXTERNALINIT_DISABLE` constant is defined, the `IsExternalInit` class is excluded from the build.
This can be used to conditionally exclude code of this package from the build if it is not required.

In most cases, this should not be required, because the package automatically excludes the code
from target frameworks that already support the `IsExternalInit` class.


### `ISEXTERNALINIT_INCLUDE_IN_CODE_COVERAGE`

Because the `IsExternalInit` class is added as source code, it could appear in code coverage reports.
By default, this is disabled via the [`ExcludeFromCodeCoverage`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.excludefromcodecoverageattribute?view=netcore-3.0)
and [`DebuggerNonUserCode`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggernonusercodeattribute?view=netcore-3.0)
attributes.

By defining the `ISEXTERNALINIT_INCLUDE_IN_CODE_COVERAGE` constant, the [`ExcludeFromCodeCoverage`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.excludefromcodecoverageattribute?view=netcore-3.0)
and [`DebuggerNonUserCode`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggernonusercodeattribute?view=netcore-3.0)
attributes are not applied and the `IsExternalInit` class may therefore appear in code coverage reports.


## Building

Because the package consists of source files, building works differently than a normal .NET project.
In essence, no build has to be made at all. Instead, the `*.cs` files are packaged into a NuGet package via a `.nuspec` file.

The solution contains a `_build` project which automatically performs these tasks though. You can then
find the resulting NuGet package file in the `artifacts` folder.


## Contributing

I don't expect this package to require many changes, but if something is not working for you or
if you think that the source file should change, feel free to create an issue or Pull Request.
I will be happy to discuss and potentially integrate your ideas!


## License

See the [LICENSE](./LICENSE) file for details.
