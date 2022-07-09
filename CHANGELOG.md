# Changelog

# v1.0.3

This release addresses issues with the .NET 6.0.300 SDK where the source files are no longer
available when running certain builds. The underlying issue is most likely a bug in the .NET SDK
itself (see https://github.com/dotnet/sdk/issues/25758) for details), but this package version
might find a workaround.
Big thanks to https://github.com/gtbuchanan for coming up with and making the fix!


# v1.0.2

Fixed compilation errors occuring in several projects after the release of the .NET 6 SDK.

Thanks to [@SWeini](https://github.com/SWeini) for the PR ([#11](https://github.com/manuelroemer/IsExternalInit/pull/11))!


# v1.0.1

Fixed issue where code is not used by every TFM.

This is because this then ends up breaking actual stable code
and the ones provided at runtime was exposed to not supposed
to be usable by projects.

Thanks to [@AraHaan](https://github.com/AraHaan) for the PR ([#6](https://github.com/manuelroemer/IsExternalInit/pull/6))!


# v1.0.0

The initial release.

This release provides support for the `IsExternalInit` class.

Furthermore, the following compiler directives are supported in the source file:

* `ISEXTERNALINIT_DISABLE`
* `ISEXTERNALINIT_INCLUDE_IN_CODE_COVERAGE`
