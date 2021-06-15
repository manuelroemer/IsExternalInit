# Changelog

# v1.0.1

Fixed issue where code is not used by every TFM.

This is because this then ends up breaking actual stable code
and the ones provided at runtime was exposed to not supposed
to be usable by projects.

# v1.0.0

The initial release.

This release provides support for the `IsExternalInit` class.

Furthermore, the following compiler directives are supported in the source file:

* `ISEXTERNALINIT_DISABLE`
* `ISEXTERNALINIT_INCLUDE_IN_CODE_COVERAGE`
