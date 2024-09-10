[![CI Pipeline](https://github.com/JicoDotNet/Software-Licensing-Module-ERP-Net8.0/actions/workflows/build.yml/badge.svg)](https://github.com/JicoDotNet/Software-Licensing-Module-ERP-Net8.0/actions/workflows/build.yml)
[![CD Pipeline](https://github.com/JicoDotNet/Software-Licensing-Module-ERP-Net8.0/actions/workflows/deploy.yml/badge.svg?branch=master)](https://github.com/JicoDotNet/Software-Licensing-Module-ERP-Net8.0/actions/workflows/deploy.yml)

# Software Licensing Module ERP

## Table of Contents
- [Overview & Description](#overview--description)
  - [Features](#features)
  - [Benefits](#benefits)
- [Usage](#usage)
  - [Screenshots](#screenshots)
- [Demo](#demo)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Tech Stack](#tech-stack)
  - [Installation](#installation)
  - [Deployment](#deployment)
- [Authors and Acknowledgment](#authors-and-acknowledgment)
  - [Contributors](#contributors)
- [Contributing](#contributing)
- [Versioning & Change log](#versioning--change-log)
- [License](#license)
- [Contact](#contact)
- [Project Status](#project-status)

## Overview & Description

**Software Licensing Module Erp** is a web-based application designed to manage software licenses efficiently. Built with ASP.NET .NET 8.0 MVC and MySQL, it offers a comprehensive solution for handling user roles, license requisitions, and workflow processes.

### Features
1. **User Management**: 
   - User Groups, User management (Add, Edit, Delete, Password management)
   - UserGroup-wise Menu/Page and Dashboard Management
2. **Password Management**: 
   - Forget Password and Change Password functionalities
3. **Master Data Management**:
   - License Type, Product, Client Category, and Client management
4. **Workflow Management**:
   - Workflow based on User Group and License Type with states: Approve, Reject, OnHold
5. **Maker Checker**: 
   - Assignments for master data and workflow processes
6. **Parameter Mapping**: 
   - Parameters mapped with License Type
7. **License Requisition**:
   - Initiate new or renewal license requisitions, with workflow-based transitions
8. **XML Generation**:
   - XML generated upon approval; downloadable by the initiator
   - XML format is predefined
9. **Reports**:
   - User Report, User Activity, Login Report, Maker Checker Report, License Report, Workflow Movement, Status Report, Turnaround Time, XML Download
10. **Dashboard**:
    - Group Wise User Graph (Bar Chart), Master Data Count, License Request Graph, Client Wise Approved License Request Graph
11. **Notification System**:
    - License Expiry Alerts

### Benefits
- **Efficient License Management**: Streamlined processes for license requisition and approval.
- **Enhanced User Control**: Detailed user and group management features.
- **Comprehensive Reporting**: In-depth reports and analytics to monitor and track license and user activities.

## Usage

### Screenshots
![Dashboard Screenshot](link-to-screenshot)  
![Reports Screenshot](link-to-screenshot)  

## Demo
A live demo of the application can be accessed 
- URL - [https://Software-Licensing-Module-ERP.azurewebsites.net](https://software-licensing-module-erp.azurewebsites.net/)
- Username: admin
- Password: admin

## Getting Started

### Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://dev.mysql.com/downloads/)
- [Visual Studio](https://visualstudio.microsoft.com/) or another compatible IDE

### Tech Stack
- **Backend**: ASP.NET .NET 8.0 MVC
- **Database**: MySQL

### Installation
1. Set up the MySQL database and update the connection string in `appsettings.json`.

### Deployment
- Build and publish the application using the following command:
    
- Deploy the application to your web server or hosting environment.

## Authors and Acknowledgment
- **Soubhik Nandy** - [@JicoDotNet](https://github.com/JicoDotNet) - Code Owner

## Contributing
This project is a collaborative effort that can involve various forms of participation. Here’s a guide on how you can contribute:

**Submitting Bug Reports**
- **Identify the Bug:** Clearly describe the issue you’ve encountered. Include details such as the context in which the bug occurred, steps to reproduce it, and the expected vs. actual results.
- **Check Existing Issues:** Before submitting a new bug report, search the project’s issues to ensure it hasn’t been reported already.
- **Use the Template:** Follow any issue template provided by the project. This often includes specific details the maintainers need.
- **Include Logs and Screenshots:** If applicable, add logs and screenshots to help maintainers understand the problem.

**Feature Requests**
- **Suggesting Enhancements**: Propose new features or improvements to existing ones. Explain the benefits and potential impact on the project.
- **Discuss in Issues:** Use the project’s issues section to discuss ideas with maintainers and other contributors.
- **Be Patient:** Remember that maintainers are often volunteers. It may take time for them to respond to your request.

**Pull Requests**
- **Fork the Repository:** Create your own copy of the project to work on.
- **Create a Branch:** Make a new branch in your fork for your changes.
- **Make Changes:** Implement your bug fix or feature, adhering to the project's coding standards.
- **Write Tests:** If the project has tests, add tests for your changes to ensure they work as expected.
- **Pull Request:** Submit a pull request to the original repository. Fill in the provided PR template with details of your changes.
- **Code Review:** Be open to feedback and make requested changes during the code review process.

Remember to always read the project’s [CONTRIBUTING.md](/CONTRIBUTING.md) file, as it will contain specific guidelines tailored to the project’s needs. You are open to contributing. 
Happy contributing! 🚀

## Versioning & Change log
Check the [CHANGELOG.md](CHANGELOG.md) for version history and updates.

## License
This project is licensed under the MIT License - see the [`LICENSE`](/LICENSE) file for details.
- [MIT License Details](https://choosealicense.com/licenses/mit/)

## Contact
Anyone can contact us regarding this project.
> Email: `github.connect@soubhiknandy.com`

## Project Status
The project is currently in the `alpha` stage; active development is in progress.
> This project was built and developed in 2019. In August 2024 it is migrated from Azure DevOps to Github.
