# Software Licensing Module ERP

## Table of Contents of Change Log
- [Version 2.5.2](#version-252)
- [Version 2.5.1](#version-251)
- [Version 2.5.0](#version-250)
- [Version 2.4.0](#version-240)
- [Version 2.3.0](#version-230)
- [Version 1.0.0](#version-100)

## Version 2.5.2
### New Features
- N/A
### Changed/Breaking/Removed Features
- N/A
### Fixed Bug
- Added a validation for Dadabase is not running or stopped.
### Maintenance
- N/A

## Version 2.5.1
### New Features
- N/A
### Changed/Breaking/Removed Features
- N/A
### Fixed Bug
- Maker Checker bug fix
### Maintenance
- Class name change for Maker Checker

## Version 2.5.0
### New Features
- Workflow Diagram is introduced in graph
- User Detail view is introduced
### Changed/Breaking/Removed Features
- `DisplayDateFormat` is changed to **dd-MMM-yyyy, hh:mmtt**
- remove unwanted required field from User, Client page
### Fixed Bug
- nullable check for entity
- User Email domain bug fix
### Maintenance
- sp_Get_WF_State.sql refactor
- tbl_wf_process.sql - `Description` will be null

## Version 2.4.0
### New Features
- `System.Security.Cryptography.Aes` encryption algorithm is implemented
- new 256-bit encryption is introduced
### Changed/Breaking/Removed Features
- Cookie value is encrypted
### Fixed Bug
- N/A
### Maintenance
- CI/CD Implemented
- `DefaultEncryptionKey` is initialized in Base Controller from `appsettings.json`
- Default Data Sql for Insertion is changed based on new algorithm

## Version 2.3.0
### New Features
- Implemented all features
### Changed/Breaking/Removed Features
- N/A
### Fixed Bug
- Bug fix
### Maintenance
- Deployment & First Release from Github

## Version 1.0.0
### New Features
- Initial Code, migrated from Azure DevOps
### Changed/Breaking/Removed Features
- N/A
### Fixed Bug
- N/A
### Maintenance
- N/A