-- tbl_client
DROP TABLE IF EXISTS tbl_client;
CREATE TABLE tbl_client (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  CategoryId INT(11) DEFAULT NULL,
  ClientName VARCHAR(50) DEFAULT NULL,
  ClientNumber VARCHAR(20) DEFAULT NULL,
  ClientEmail VARCHAR(50) DEFAULT NULL,
  CompanyName VARCHAR(100) DEFAULT NULL,
  CompanyAddress VARCHAR(100) DEFAULT NULL,
  CompanyNumber VARCHAR(20) DEFAULT NULL,
  CompanyEmail VARCHAR(50) DEFAULT NULL,
  GSTIN VARCHAR(15) DEFAULT NULL,
  PANNo VARCHAR(12) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_client_category
DROP TABLE IF EXISTS tbl_client_category;
CREATE TABLE tbl_client_category (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  CategoryName VARCHAR(100) DEFAULT NULL,
  CategoryDetails VARCHAR(100) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_dashboard;
DROP TABLE IF EXISTS tbl_dashboard;
CREATE TABLE tbl_dashboard (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  PartialViewName VARCHAR(100) DEFAULT NULL,
  Description VARCHAR(255) DEFAULT NULL,
  SortOrder INT(11) DEFAULT NULL,
  DivCssClass VARCHAR(20) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);
		

-- tbl_licence_type
DROP TABLE IF EXISTS tbl_licence_type;
CREATE TABLE tbl_licence_type (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  TypeName VARCHAR(50) DEFAULT NULL,
  LicenceTypeDetails VARCHAR(100) DEFAULT NULL,
  NumberOfLicence INT(100) DEFAULT NULL,
  IsScalingEligible BIT(1) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_license_parameter
DROP TABLE IF EXISTS tbl_license_parameter;
CREATE TABLE tbl_license_parameter (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  ParameterId INT(11) DEFAULT NULL,
  LicenseTypeId INT(11) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_log_activity
DROP TABLE IF EXISTS tbl_log_activity;
CREATE TABLE tbl_log_activity (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  MacAddress VARCHAR(50) DEFAULT NULL,
  BrowserType VARCHAR(50) DEFAULT NULL,
  Browser VARCHAR(255) DEFAULT NULL,
  BrowserVersion VARCHAR(50) DEFAULT NULL,
  DNS VARCHAR(50) DEFAULT NULL,
  SessionID VARCHAR(100) DEFAULT NULL,
  IPAddress VARCHAR(50) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  Controller VARCHAR(50) DEFAULT NULL,
  Action VARCHAR(50) DEFAULT NULL,
  RouteId VARCHAR(100) DEFAULT NULL,
  AbsoluteUri VARCHAR(512) DEFAULT NULL,
  HttpVerbs VARCHAR(10) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_log_login
DROP TABLE IF EXISTS tbl_log_login;
CREATE TABLE tbl_log_login (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserName VARCHAR(100) DEFAULT NULL,
  Password VARCHAR(1000) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_mc_data_on_hold
DROP TABLE IF EXISTS tbl_mc_data_on_hold;
CREATE TABLE tbl_mc_data_on_hold (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  CaseType VARCHAR(25) DEFAULT NULL,
  Purpose VARCHAR(25) DEFAULT NULL,
  EffectedData VARCHAR(8000) DEFAULT NULL,
  EffectedRowId INT(11) DEFAULT NULL,
  CreatedUserId INT(11) DEFAULT NULL,
  CreatedUserTypeId INT(11) DEFAULT NULL,
  IsApproved BIT(1) DEFAULT NULL,
  ApproveRejectUserId INT(11) DEFAULT NULL,
  ApproveRejectUserTypeId INT(11) DEFAULT NULL,
  ApproveRejectRemarks VARCHAR(255) DEFAULT NULL,
  ApproveRejectDate DATETIME DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_menu_group
DROP TABLE IF EXISTS tbl_menu_group;
CREATE TABLE tbl_menu_group (
  Id int NOT NULL AUTO_INCREMENT,
  Icon varchar(50) NOT NULL,
  DisplayText varchar(50) NOT NULL,
  PRIMARY KEY (Id)
);

-- tbl_menu_list
DROP TABLE IF EXISTS tbl_menu_list;
CREATE TABLE tbl_menu_list (
  Id int NOT NULL AUTO_INCREMENT,
  MenuGroupId int DEFAULT NULL,
  Icon varchar(50) DEFAULT NULL,
  DisplayText varchar(50) DEFAULT NULL,
  Controller varchar(50) DEFAULT NULL,
  ActionResult varchar(50) DEFAULT NULL,
  IsReport bit(1) DEFAULT NULL,
  IsForAdmin bit(1) DEFAULT NULL,
  IsForWorkflow bit(1) DEFAULT NULL,
  Description varchar(100) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_parameters
DROP TABLE IF EXISTS tbl_parameters;
CREATE TABLE tbl_parameters (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  FieldName VARCHAR(255) DEFAULT NULL,
  DataType VARCHAR(63) DEFAULT NULL,
  IsRequired BIT(1) DEFAULT NULL,
  Fieldlength VARCHAR(5) DEFAULT NULL,
  ListData LONGTEXT DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_password
DROP TABLE IF EXISTS tbl_password;
CREATE TABLE tbl_password (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserId INT(11) DEFAULT NULL,
  PasswordHash VARCHAR(256) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  ActivationDate DATETIME DEFAULT NULL,
  PasswordSalt VARCHAR(256) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PasswordText VARCHAR(1000) DEFAULT NULL,
  IsChangeable BIT(1) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_password_reset_request
DROP TABLE IF EXISTS tbl_password_reset_request;
CREATE TABLE tbl_password_reset_request (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserName VARCHAR(100) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  IsCanceled BIT(1) DEFAULT NULL,
  CanceledDate DATETIME DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_password_security_questions
DROP TABLE IF EXISTS tbl_password_security_questions;
CREATE TABLE tbl_password_security_questions (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserId INT(11) DEFAULT NULL,
  QuestionEnumNo INT(11) DEFAULT NULL,
  Question VARCHAR(255) DEFAULT NULL,
  Answer VARCHAR(255) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_product
DROP TABLE IF EXISTS tbl_product;
CREATE TABLE tbl_product (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  ProductName VARCHAR(100) DEFAULT NULL,
  ProductDetails VARCHAR(1000) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_product_features
DROP TABLE IF EXISTS tbl_product_features;
CREATE TABLE tbl_product_features (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  ProductId INT(11) DEFAULT NULL,
  FeaturesName VARCHAR(255) DEFAULT NULL,
  FeaturesDetails TEXT DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_product_module
DROP TABLE IF EXISTS tbl_product_module;
CREATE TABLE tbl_product_module (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  ProductId INT(11) DEFAULT NULL,
  ModuleName VARCHAR(255) DEFAULT NULL,
  ModuleDetails TEXT DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request
DROP TABLE IF EXISTS tbl_request;
CREATE TABLE tbl_request (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestNo VARCHAR(255) DEFAULT NULL,
  RequestDate DATETIME DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  ClientId INT(11) DEFAULT NULL,
  LicenceTypeId INT(11) DEFAULT NULL,
  ProductId INT(11) DEFAULT NULL,
  LicenceNo VARCHAR(15) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_acknowledgement
DROP TABLE IF EXISTS tbl_request_acknowledgement;
CREATE TABLE tbl_request_acknowledgement (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(255) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  Remarks VARCHAR(8000) DEFAULT NULL,
  StateId INT(11) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_acknowledgement_docs
DROP TABLE IF EXISTS tbl_request_acknowledgement_docs;
CREATE TABLE tbl_request_acknowledgement_docs (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  AcknowledgementId INT(11) DEFAULT NULL,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(255) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  FileName VARCHAR(255) NOT NULL,
  MimeType VARCHAR(50) NOT NULL,
  Description VARCHAR(255) NOT NULL,
  FileData MEDIUMBLOB DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_claim
DROP TABLE IF EXISTS tbl_request_claim;
CREATE TABLE tbl_request_claim (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(255) DEFAULT NULL,
  NextUserTypeId INT(11) DEFAULT NULL,
  ClaimUserId INT(11) DEFAULT NULL,
  ClaimDate DATETIME DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  AssignDate DATETIME DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_features
DROP TABLE IF EXISTS tbl_request_features;
CREATE TABLE tbl_request_features (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(100) DEFAULT NULL,
  FeaturesId INT(11) DEFAULT NULL,
  ProductId INT(11) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_parameter
DROP TABLE IF EXISTS tbl_request_parameter;
CREATE TABLE tbl_request_parameter (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(100) DEFAULT NULL,
  ParamId INT(11) DEFAULT NULL,
  ParamValue VARCHAR(1000) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_restrict
DROP TABLE IF EXISTS tbl_request_restrict;
CREATE TABLE tbl_request_restrict (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(100) DEFAULT NULL,
  RestrictTo VARCHAR(100) DEFAULT NULL,
  RestrictVal VARCHAR(100) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_request_status
DROP TABLE IF EXISTS tbl_request_status;
CREATE TABLE tbl_request_status (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(255) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  IsApproved BIT(1) DEFAULT NULL,
  ApproveRejectDate DATETIME DEFAULT NULL,
  Remarks VARCHAR(255) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_s_state
DROP TABLE IF EXISTS tbl_s_state;
CREATE TABLE tbl_s_state (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  Name VARCHAR(100) DEFAULT NULL,
  IsPositive BIT(1) DEFAULT NULL,
  IsNegative BIT(1) DEFAULT NULL,
  IsHold BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_user
DROP TABLE IF EXISTS tbl_user;
CREATE TABLE tbl_user (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserTypeId INT(11) DEFAULT NULL,
  FullName VARCHAR(255) DEFAULT NULL,
  UserName VARCHAR(100) DEFAULT NULL,
  Email VARCHAR(50) DEFAULT NULL,
  Mobile VARCHAR(15) DEFAULT NULL,
  Address VARCHAR(255) DEFAULT NULL,
  Designation VARCHAR(100) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_userdashboard
DROP TABLE IF EXISTS tbl_userdashboard;
CREATE TABLE tbl_userdashboard (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  DashboardId INT(11) DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_usermenu
DROP TABLE IF EXISTS tbl_usermenu;
CREATE TABLE tbl_usermenu (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  MenuId INT(11) DEFAULT NULL,
  UserId INT(11) DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_usertype
DROP TABLE IF EXISTS tbl_usertype;
CREATE TABLE tbl_usertype (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserTypeName VARCHAR(100) NOT NULL,
  UserTypeDetails VARCHAR(1000) NOT NULL,
  IsActive BIT(1) NOT NULL,
  TransactionDate DATETIME NOT NULL,
  SessionId VARCHAR(100) NOT NULL,
  PRIMARY KEY (Id)
);

-- tbl_wf_process
DROP TABLE IF EXISTS tbl_wf_process;
CREATE TABLE tbl_wf_process (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  LicenceTypeId INT(11) DEFAULT NULL,
  ProcessName VARCHAR(50) NOT NULL,
  ProcessCode VARCHAR(50) NOT NULL,
  IsInitial BIT(1) NOT NULL,
  IsEnd BIT(1) NOT NULL,
  Description VARCHAR(1000),
  SessionId VARCHAR(100) NOT NULL,
  TransactionDate DATETIME NOT NULL,
  IsActive BIT(1) NOT NULL,
  PRIMARY KEY (Id)
);

-- tbl_wf_process_assign
DROP TABLE IF EXISTS tbl_wf_process_assign;
CREATE TABLE tbl_wf_process_assign (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  WFProcessId INT(11) DEFAULT NULL,
  StateId INT(11) DEFAULT NULL,
  FromUserTypeId INT(11) DEFAULT NULL,
  ToUserTypeId INT(11) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  ActivityStartDate DATETIME DEFAULT NULL,
  ActivityEndDate DATETIME DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);

-- tbl_xml_download
DROP TABLE IF EXISTS tbl_xml_download;
CREATE TABLE tbl_xml_download (
  Id INT(11) NOT NULL AUTO_INCREMENT,
  UserId INT(11) DEFAULT NULL,
  UserTypeId INT(11) DEFAULT NULL,
  RequestId INT(11) DEFAULT NULL,
  RequestNo VARCHAR(255) DEFAULT NULL,
  IsActive BIT(1) DEFAULT NULL,
  SessionId VARCHAR(100) DEFAULT NULL,
  TransactionDate DATETIME DEFAULT NULL,
  PRIMARY KEY (Id)
);