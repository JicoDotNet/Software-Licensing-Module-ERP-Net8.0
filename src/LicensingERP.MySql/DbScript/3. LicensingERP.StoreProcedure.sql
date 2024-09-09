--
-- Drop procedure `sp_Get_client`
--
DROP PROCEDURE IF EXISTS sp_Get_client;

--
-- Drop procedure `sp_Get_ClientCategory`
--
DROP PROCEDURE IF EXISTS sp_Get_ClientCategory;

--
-- Drop procedure `sp_Get_DashboardData`
--
DROP PROCEDURE IF EXISTS sp_Get_DashboardData;

--
-- Drop procedure `sp_Get_licence_type`
--
DROP PROCEDURE IF EXISTS sp_Get_licence_type;

--
-- Drop procedure `sp_Get_license_parameters`
--
DROP PROCEDURE IF EXISTS sp_Get_license_parameters;

--
-- Drop procedure `sp_Get_Master`
--
DROP PROCEDURE IF EXISTS sp_Get_Master;

--
-- Drop procedure `sp_Get_mc_DataOnHold`
--
DROP PROCEDURE IF EXISTS sp_Get_mc_DataOnHold;

--
-- Drop procedure `sp_Get_menu_list`
--
DROP PROCEDURE IF EXISTS sp_Get_menu_list;

--
-- Drop procedure `sp_Get_parameter`
--
DROP PROCEDURE IF EXISTS sp_Get_parameter;

--
-- Drop procedure `sp_Get_Password`
--
DROP PROCEDURE IF EXISTS sp_Get_Password;

--
-- Drop procedure `sp_Get_password_Reset_Request`
--
DROP PROCEDURE IF EXISTS sp_Get_password_Reset_Request;

--
-- Drop procedure `sp_Get_password_security_questions`
--
DROP PROCEDURE IF EXISTS sp_Get_password_security_questions;

--
-- Drop procedure `sp_Get_product`
--
DROP PROCEDURE IF EXISTS sp_Get_product;

--
-- Drop procedure `sp_Get_product_features`
--
DROP PROCEDURE IF EXISTS sp_Get_product_features;

--
-- Drop procedure `sp_Get_product_module`
--
DROP PROCEDURE IF EXISTS sp_Get_product_module;

--
-- Drop procedure `sp_Get_request`
--
DROP PROCEDURE IF EXISTS sp_Get_request;

--
-- Drop procedure `sp_Get_request_acknowledgement`
--
DROP PROCEDURE IF EXISTS sp_Get_request_acknowledgement;

--
-- Drop procedure `sp_Get_user`
--
DROP PROCEDURE IF EXISTS sp_Get_user;

--
-- Drop procedure `sp_Get_userdashboard`
--
DROP PROCEDURE IF EXISTS sp_Get_userdashboard;

--
-- Drop procedure `sp_Get_usermenu`
--
DROP PROCEDURE IF EXISTS sp_Get_usermenu;

--
-- Drop procedure `sp_Get_usertype`
--
DROP PROCEDURE IF EXISTS sp_Get_usertype;

--
-- Drop procedure `sp_Get_wf_process`
--
DROP PROCEDURE IF EXISTS sp_Get_wf_process;

--
-- Drop procedure `sp_Get_wf_process_assign`
--
DROP PROCEDURE IF EXISTS sp_Get_wf_process_assign;

--
-- Drop procedure `sp_Get_WF_State`
--
DROP PROCEDURE IF EXISTS sp_Get_WF_State;

--
-- Drop procedure `sp_Get_Xml`
--
DROP PROCEDURE IF EXISTS sp_Get_Xml;

--
-- Drop procedure `sp_Log`
--
DROP PROCEDURE IF EXISTS sp_Log;

--
-- Drop procedure `Sp_Login`
--
DROP PROCEDURE IF EXISTS Sp_Login;

--
-- Drop procedure `sp_Rp_Activity`
--
DROP PROCEDURE IF EXISTS sp_Rp_Activity;

--
-- Drop procedure `sp_Rp_MakerChecker`
--
DROP PROCEDURE IF EXISTS sp_Rp_MakerChecker;

--
-- Drop procedure `sp_Rp_Request`
--
DROP PROCEDURE IF EXISTS sp_Rp_Request;

--
-- Drop procedure `sp_Rp_RequestMovement`
--
DROP PROCEDURE IF EXISTS sp_Rp_RequestMovement;

--
-- Drop procedure `sp_Rp_RequestOnHold`
--
DROP PROCEDURE IF EXISTS sp_Rp_RequestOnHold;

--
-- Drop procedure `sp_Rp_RequestPending`
--
DROP PROCEDURE IF EXISTS sp_Rp_RequestPending;

--
-- Drop procedure `sp_Rp_Status`
--
DROP PROCEDURE IF EXISTS sp_Rp_Status;

--
-- Drop procedure `sp_Rp_TAT_License_Generation`
--
DROP PROCEDURE IF EXISTS sp_Rp_TAT_License_Generation;

--
-- Drop procedure `sp_Rp_user`
--
DROP PROCEDURE IF EXISTS sp_Rp_user;

--
-- Drop procedure `sp_Rp_UserLogin`
--
DROP PROCEDURE IF EXISTS sp_Rp_UserLogin;

--
-- Drop procedure `sp_Rp_XmlDownload`
--
DROP PROCEDURE IF EXISTS sp_Rp_XmlDownload;

--
-- Drop procedure `sp_Set_Client`
--
DROP PROCEDURE IF EXISTS sp_Set_Client;

--
-- Drop procedure `sp_Set_ClientCategory`
--
DROP PROCEDURE IF EXISTS sp_Set_ClientCategory;

--
-- Drop procedure `sp_Set_license_parameters`
--
DROP PROCEDURE IF EXISTS sp_Set_license_parameters;

--
-- Drop procedure `sp_Set_license_type`
--
DROP PROCEDURE IF EXISTS sp_Set_license_type;

--
-- Drop procedure `sp_Set_mc_DataOnHold`
--
DROP PROCEDURE IF EXISTS sp_Set_mc_DataOnHold;

--
-- Drop procedure `sp_set_menu_group`
--
DROP PROCEDURE IF EXISTS sp_set_menu_group;

--
-- Drop procedure `sp_set_menu_list`
--
DROP PROCEDURE IF EXISTS sp_set_menu_list;

--
-- Drop procedure `sp_Set_parameters`
--
DROP PROCEDURE IF EXISTS sp_Set_parameters;

--
-- Drop procedure `sp_Set_password`
--
DROP PROCEDURE IF EXISTS sp_Set_password;

--
-- Drop procedure `sp_Set_password_Reset_Request`
--
DROP PROCEDURE IF EXISTS sp_Set_password_Reset_Request;

--
-- Drop procedure `sp_Set_password_security_questions`
--
DROP PROCEDURE IF EXISTS sp_Set_password_security_questions;

--
-- Drop procedure `sp_Set_product`
--
DROP PROCEDURE IF EXISTS sp_Set_product;

--
-- Drop procedure `sp_Set_product_features`
--
DROP PROCEDURE IF EXISTS sp_Set_product_features;

--
-- Drop procedure `sp_Set_product_module`
--
DROP PROCEDURE IF EXISTS sp_Set_product_module;

--
-- Drop procedure `sp_Set_request`
--
DROP PROCEDURE IF EXISTS sp_Set_request;

--
-- Drop procedure `sp_Set_request_acknowledgement`
--
DROP PROCEDURE IF EXISTS sp_Set_request_acknowledgement;

--
-- Drop procedure `sp_Set_request_claim`
--
DROP PROCEDURE IF EXISTS sp_Set_request_claim;

--
-- Drop procedure `sp_Set_request_features`
--
DROP PROCEDURE IF EXISTS sp_Set_request_features;

--
-- Drop procedure `sp_Set_request_parameter`
--
DROP PROCEDURE IF EXISTS sp_Set_request_parameter;

--
-- Drop procedure `sp_Set_request_restrict`
--
DROP PROCEDURE IF EXISTS sp_Set_request_restrict;

--
-- Drop procedure `sp_Set_user`
--
DROP PROCEDURE IF EXISTS sp_Set_user;

--
-- Drop procedure `sp_Set_userdashboard`
--
DROP PROCEDURE IF EXISTS sp_Set_userdashboard;

--
-- Drop procedure `sp_Set_usermenu`
--
DROP PROCEDURE IF EXISTS sp_Set_usermenu;

--
-- Drop procedure `sp_Set_usertype`
--
DROP PROCEDURE IF EXISTS sp_Set_usertype;

--
-- Drop procedure `sp_Set_wf_process`
--
DROP PROCEDURE IF EXISTS sp_Set_wf_process;

--
-- Drop procedure `sp_Set_wf_process_assign`
--
DROP PROCEDURE IF EXISTS sp_Set_wf_process_assign;

DELIMITER $$

--
-- Create procedure `sp_Set_wf_process_assign`
--
CREATE PROCEDURE sp_Set_wf_process_assign(IN p_WFProcessId INT(11), IN p_StateId INT(11), IN p_FromUserTypeId INT(11), IN p_ToUserTypeId VARCHAR(255), IN p_ActivityStartDate DATETIME, IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
IF p_QueryType = 'INSERT' THEN

UPDATE tbl_wf_process_assign AS twp
SET twp.IsActive = 0,
    twp.ActivityEndDate = (p_ActivityStartDate - INTERVAL 1 SECOND)
WHERE twp.IsActive = 1
AND twp.WFProcessId = p_WFProcessId
AND twp.StateId = p_StateId
AND twp.FromUserTypeId = p_FromUserTypeId;

INSERT INTO tbl_wf_process_assign (WFProcessId, StateId, FromUserTypeId, ToUserTypeId, IsActive, ActivityStartDate, ActivityEndDate, SessionId, TransactionDate)
  VALUES (p_WFProcessId, p_StateId, p_FromUserTypeId, p_ToUserTypeId, 1, p_ActivityStartDate, NULL, p_SessionId, NOW());
  
  SET Out_Param = LAST_INSERT_ID();
END IF;
END
$$

--
-- Create procedure `sp_Set_wf_process`
--
CREATE PROCEDURE sp_Set_wf_process(IN p_Id INT(11), IN p_LicenceTypeId INT(11), IN p_ProcessName VARCHAR(50), IN p_ProcessCode VARCHAR(50), IN p_IsInitial BIT(1), IN p_IsEnd BIT(1), IN p_Description VARCHAR(1000), IN p_SessionId VARCHAR(100), IN p_IsActive BIT(1), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_wf_process (LicenceTypeId, ProcessName, ProcessCode, IsInitial, IsEnd, Description, SessionId, IsActive, TransactionDate)
  VALUES (p_LicenceTypeId, p_ProcessName, p_ProcessCode, p_IsInitial, p_IsEnd, p_Description, p_SessionId, p_IsActive, NOW());

      SET Out_Param = Last_Insert_id();
    END IF;
END
$$

--
-- Create procedure `sp_Set_usertype`
--
CREATE PROCEDURE sp_Set_usertype(IN p_Id INT(11), IN p_UserTypeName VARCHAR(100), IN p_UserTypeDetails VARCHAR(1000), IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_usertype (UserTypeName, UserTypeDetails, IsActive, SessionId, TransactionDate)
  VALUES (p_UserTypeName, p_UserTypeDetails, p_IsActive, p_SessionId, NOW());
      SET Out_Param = LAST_INSERT_ID();
ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_usertype
SET UserTypeName = p_UserTypeName,
    UserTypeDetails = p_UserTypeDetails
WHERE Id = p_Id;
      SET Out_Param = p_Id;
      
ELSEIF  p_QueryType = 'DEACTIVATE' THEN
    IF NOT EXISTS ( SELECT
    *
  FROM tbl_user AS user
  WHERE user.IsActive = 1
  AND user.UserTypeId = p_Id) THEN
UPDATE tbl_usertype
SET IsActive = 0
WHERE Id = p_Id;
      SET  Out_Param = p_Id;
    ELSE
      SET  Out_Param = '-2';
    END IF;
END IF;
END
$$

--
-- Create procedure `sp_Set_usermenu`
--
CREATE PROCEDURE sp_Set_usermenu(IN p_MenuId INT(11), IN p_UserTypeId INT(11), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'ASSIGN' THEN

INSERT INTO tbl_usermenu (MenuId, UserTypeId, IsActive, SessionId, TransactionDate)
  VALUES (p_MenuId, p_UserTypeId, 1, p_SessionId, NOW());
    SET Out_Param = LAST_INSERT_ID();
  ELSEIF p_QueryType = 'DEACTIVATE' THEN

UPDATE tbl_usermenu
SET IsActive = 0
WHERE UserTypeId = p_UserTypeId
AND tbl_usermenu.Id <> 1
AND IsActive = 1;
    SET Out_Param = p_UserTypeId;
  END IF;

END
$$

--
-- Create procedure `sp_Set_userdashboard`
--
CREATE PROCEDURE sp_Set_userdashboard(IN p_UserTypeId INT(11), IN p_DashboardId INT(11), IN p_QueryType VARCHAR(20), IN p_SessionId VARCHAR(100), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'ASSIGN' THEN

INSERT INTO tbl_userdashboard (DashboardId, UserTypeId, IsActive, SessionId, TransactionDate)
  VALUES (p_DashboardId, p_UserTypeId, 1, p_SessionId, NOW());
    SET Out_Param = LAST_INSERT_ID();

     ELSEIF p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_userdashboard
SET IsActive = 0
WHERE UserTypeId = p_UserTypeId
AND tbl_userdashboard.Id <> 1
AND IsActive = 1;
    SET Out_Param = p_UserTypeId;
  END IF;

END
$$

--
-- Create procedure `sp_Set_user`
--
CREATE PROCEDURE sp_Set_user(IN p_Id INT(11), IN p_UserTypeId INT(11), IN p_FullName VARCHAR(255), IN p_UserName VARCHAR(100), IN p_Email VARCHAR(50), IN p_Mobile VARCHAR(15), IN p_Address VARCHAR(255), IN p_Designation VARCHAR(100), IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
	DECLARE LIID int DEFAULT 0;
	
	IF p_QueryType = 'INSERT' THEN  
		IF NOT EXISTS( SELECT
    *
  FROM tbl_user AS tu
  WHERE tu.UserName = p_UserName) THEN
-- trans start here

INSERT INTO tbl_user (UserTypeId, FullName, UserName, Email, Mobile, Address, Designation, IsActive, SessionId, TransactionDate)
  VALUES (p_UserTypeId, p_FullName, p_UserName, p_Email, p_Mobile, p_Address, p_Designation, p_IsActive, p_SessionId, NOW());

			SET LIID=LAST_INSERT_ID();

			-- CALL sp_Set_Password(LIID, NULL, NOW(), NULL, p_Password, 1, p_SessionId, 'INSERT', Out_Param);
			SET Out_Param = LIID;
		-- end trans
		ELSE 
			SET Out_Param = -1;
		END IF;
		
	ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_user AS tu
SET tu.FullName = p_FullName,
    tu.Mobile = p_Mobile,
    tu.email = p_Email,
    tu.Address = p_Address,
    tu.Designation = p_Designation
WHERE tu.Id = p_Id;
        SET Out_Param = p_Id;
		
	ELSEIF p_QueryType = 'DEACTIVE' THEN
UPDATE tbl_user AS tu
SET tu.IsActive = 0
WHERE tu.Id = p_Id;
        SET Out_Param = p_Id;

  ELSEIF p_QueryType = 'DELETE' THEN
DELETE
  FROM tbl_user
WHERE Id = p_Id;
        SET Out_Param = p_Id;
    END IF;
END
$$

--
-- Create procedure `sp_Set_request_restrict`
--
CREATE PROCEDURE sp_Set_request_restrict(IN p_RequestId INT(11), IN p_RequestNo VARCHAR(100), IN p_RestrictTo VARCHAR(100), IN p_RestrictVal VARCHAR(100), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), IN Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_request_restrict (RequestId, RequestNo, RestrictTo, RestrictVal, IsActive, SessionId, TransactionDate)
  VALUES (p_RequestId, p_RequestNo, p_RestrictTo, p_RestrictVal, 1, p_SessionId, NOW());
       SET Out_Param = LAST_INSERT_ID();
      END IF;
END
$$

--
-- Create procedure `sp_Set_request_parameter`
--
CREATE PROCEDURE sp_Set_request_parameter(IN p_RequestId INT(11), IN p_RequestNo VARCHAR(100), IN p_ParamId INT(11), IN p_ParamValue VARCHAR(1000), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), IN Out_Param VARCHAR(1000))
BEGIN
 IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_request_parameter (RequestId, RequestNo, ParamId, ParamValue, IsActive, SessionId, TransactionDate)
  VALUES (p_RequestId, p_RequestNo, p_ParamId, p_ParamValue, 1, p_SessionId, NOW());
       SET Out_Param = LAST_INSERT_ID();
      END IF;
END
$$

--
-- Create procedure `sp_Set_request_features`
--
CREATE PROCEDURE sp_Set_request_features(IN p_RequestId INT(11), IN p_RequestNo VARCHAR(100), IN p_FeaturesId INT(11), IN p_ProductId INT(11), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), IN Out_Param VARCHAR(1000))
BEGIN
 IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_request_features (RequestId, RequestNo, FeaturesId, ProductId, IsActive, SessionId, TransactionDate)
  VALUES (p_RequestId, p_RequestNo, p_FeaturesId, p_ProductId, 1, p_SessionId, NOW());
       SET Out_Param = LAST_INSERT_ID();
      END IF;
END
$$

--
-- Create procedure `sp_Set_request_claim`
--
CREATE PROCEDURE sp_Set_request_claim(IN p_RequestId INT, IN p_UserId INT, IN p_UserTypeId INT, IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType ='CLAIM' THEN
    IF EXISTS 
      ( SELECT
    *
  FROM tbl_request_claim
  WHERE RequestId = p_RequestId
  AND NextUserTypeId = p_UserTypeId
  AND IsActive = 1
  AND ClaimUserId IS NULL) THEN

UPDATE tbl_request_claim
SET ClaimUserId = p_UserId,
    ClaimDate = NOW()
WHERE RequestId = p_RequestId
AND NextUserTypeId = p_UserTypeId
AND IsActive = 1
AND ClaimUserId IS NULL;
      SET Out_Param = p_RequestId;
    ELSE
      SET Out_Param = '-1';
    END IF;
  END IF;
END
$$

--
-- Create procedure `sp_Set_request_acknowledgement`
--
CREATE PROCEDURE sp_Set_request_acknowledgement(IN p_RequestId INT, IN p_RequestNo VARCHAR(255), IN p_UserId INT(11), IN p_UserTypeId INT(11), IN p_Remarks VARCHAR(8000), IN p_StateId INT(11), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), 
-- IN p_FileName VARCHAR(255), IN p_MimeType VARCHAR(50), IN p_Description VARCHAR(255), IN p_FileData BLOB, 
OUT Out_Param VARCHAR(1000))
BEGIN

declare p_Id int  default 0;
IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_request_acknowledgement (RequestId, RequestNo, UserId, UserTypeId,
Remarks, StateId, IsActive, SessionId, TransactionDate)
  VALUES (p_RequestId, p_RequestNo, p_UserId, p_UserTypeId, p_Remarks, p_StateId, 1, p_SessionId, NOW());
    SET p_Id = LAST_INSERT_ID();

    -- INSERT INTO tbl_request_acknowledgement_docs (AcknowledgementId, RequestId, RequestNo, UserId, UserTypeId, 
    --     FileName, MimeType, Description, FileData,
    --     IsActive, SessionId, TransactionDate)
    -- VALUES (p_Id, p_RequestId, p_RequestNo, p_UserId, p_UserTypeId, 
    --     p_FileName, p_MimeType, p_Description, p_FileData,     
	-- 	    1, p_SessionId, NOW());

    SET Out_Param = p_Id;

    END IF;
    
END
$$

--
-- Create procedure `sp_Set_request`
--
CREATE PROCEDURE sp_Set_request(IN p_RequestNo VARCHAR(255), IN p_RequestDate DATETIME, IN p_UserTypeId INT(11), IN p_UserId INT(11), IN p_ClientId INT(11), IN p_LicenceTypeId INT(11), IN p_ProductId INT(11), IN p_LicenceNo VARCHAR(15), IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN

  DECLARE p_WFProcessId int(11);
  DECLARE p_NextUserTypeId int(11);
  DECLARE p_RequestId int(11);

IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_request (RequestNo, RequestDate, UserTypeId, UserId, ClientId, LicenceTypeId, ProductId, LicenceNo, IsActive, SessionId, TransactionDate)
  VALUES (p_RequestNo, p_RequestDate, p_UserTypeId, p_UserId, p_ClientId, p_LicenceTypeId, p_ProductId, p_LicenceNo, 1, p_SessionId, NOW());

     SET p_RequestId = LAST_INSERT_ID();
     SET Out_Param = p_RequestId;

  

   
    END IF;
END
$$

--
-- Create procedure `sp_Set_product_module`
--
CREATE PROCEDURE sp_Set_product_module(IN p_Id INT(11), IN p_ProductId INT(11), IN p_ModuleName VARCHAR(255), IN p_ModuleDetails TEXT, IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_product_module (ProductId, ModuleName, ModuleDetails, IsActive, SessionId, TransactionDate)
  VALUES (p_ProductId, p_ModuleName, p_ModuleDetails, p_IsActive, p_SessionId, NOW());
    SET Out_Param = LAST_INSERT_ID();
  END IF;
END
$$

--
-- Create procedure `sp_Set_product_features`
--
CREATE PROCEDURE sp_Set_product_features(IN p_Id INT(11), IN p_ProductId INT(11), IN p_FeaturesName VARCHAR(255), IN p_FeaturesDetails TEXT,  IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
    IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_product_features (ProductId, FeaturesName, FeaturesDetails, IsActive, SessionId, TransactionDate)
  VALUES (p_ProductId, p_FeaturesName, p_FeaturesDetails, p_IsActive, p_SessionId, NOW());
      SET Out_Param = LAST_INSERT_ID();
    ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_product_features
SET ProductId = p_ProductId,
    FeaturesName = p_FeaturesName,
    FeaturesDetails = p_FeaturesDetails
WHERE Id = p_Id;
      SET Out_Param = LAST_INSERT_ID();
    ELSEIF  p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_product_features
SET IsActive = 0
WHERE Id = p_Id;
      SET Out_Param = LAST_INSERT_ID();
    END IF;
END
$$

--
-- Create procedure `sp_Set_product`
--
CREATE PROCEDURE sp_Set_product(IN p_Id INT(11), IN p_ProductName VARCHAR(100), IN p_ProductDetails VARCHAR(1000), IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_product (ProductName, ProductDetails, IsActive, SessionId, TransactionDate)
  VALUES (p_ProductName, p_ProductDetails, p_IsActive, p_SessionId, NOW());
    SET Out_Param = LAST_INSERT_ID();
  ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_product
SET ProductName = p_ProductName,
    ProductDetails = p_ProductDetails
WHERE Id = p_Id;
    SET Out_Param = p_Id;
  ELSEIF  p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_product
SET IsActive = 0
WHERE Id = p_Id;
    SET Out_Param = p_Id;
  END IF;
END
$$

--
-- Create procedure `sp_Set_password_security_questions`
--
CREATE PROCEDURE sp_Set_password_security_questions(IN p_UserId INT(11), IN p_QuestionEnumNo INT(11), IN p_Question VARCHAR(255), IN p_Answer VARCHAR(255), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
    IF p_QueryType = 'INSERT' THEN
-- trans here
UPDATE tbl_password_security_questions AS psq
SET psq.IsActive = 0
WHERE psq.UserId = p_UserId;

INSERT INTO tbl_password_security_questions (UserId, QuestionEnumNo, Question, Answer, IsActive, TransactionDate, SessionId)
  VALUES (p_UserId, p_QuestionEnumNo, p_Question, p_Answer, 1, NOW(), p_SessionId);

    -- CALL sp_Set_Password(p_UserId, NULL, NOW(), NULL, p_Password, 0, p_SessionId, 'INSERT', Out_Param);

    SET Out_Param = LAST_INSERT_ID();
  END IF;
END
$$

--
-- Create procedure `sp_Set_password_Reset_Request`
--
CREATE PROCEDURE sp_Set_password_Reset_Request(IN p_UserName VARCHAR(100), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
    -- trans here
    IF NOT EXISTS( SELECT
    *
  FROM tbl_password_reset_request AS prr
  WHERE prr.UserName = p_UserName
  AND prr.IsActive = 1) THEN

INSERT INTO tbl_password_reset_request (UserName, UserId, IsCanceled, CanceledDate, IsActive, SessionId, TransactionDate)
  VALUES (p_UserName, (SELECT Id FROM tbl_user AS tu WHERE tu.UserName = p_UserName), 0, NULL, 1, p_SessionId, NOW());
      SET Out_Param = LAST_INSERT_ID();
      
    ELSE
      SET Out_Param = '0';
    END IF;
 END IF;
END
$$

--
-- Create procedure `sp_Set_password`
--
CREATE PROCEDURE sp_Set_password(IN p_UserId INT(11), IN p_PasswordHash VARCHAR(255), IN p_ActivationDate DATETIME, IN p_PasswordSalt VARCHAR(256), IN p_IsChangeable BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
-- trans here
UPDATE tbl_password AS tp
SET tp.IsActive = 0
WHERE tp.UserId = p_UserId;

UPDATE tbl_password_reset_request AS req
SET req.IsActive = 0
WHERE req.UserId = p_UserId;

INSERT INTO tbl_password (UserId, PasswordHash, IsActive, ActivationDate, PasswordSalt, SessionId, TransactionDate, PasswordText, IsChangeable)
  VALUES (p_UserId, p_PasswordHash, 1, p_ActivationDate, p_PasswordSalt, p_SessionId, NOW(), NULL, p_IsChangeable);
    
    SET Out_Param = LAST_INSERT_ID();
       
  END IF;

END
$$

--
-- Create procedure `sp_Set_parameters`
--
CREATE PROCEDURE sp_Set_parameters(IN p_Id INT(11), IN p_FieldName VARCHAR(255), IN p_DataType VARCHAR(63), IN p_IsRequired BIT(1), IN p_Fieldlength VARCHAR(5), IN p_ListData LONGTEXT, IN p_SessionId VARCHAR(100), IN p_IsActive BIT(1), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
   IF p_DataType <> 'List' THEN
     SET p_ListData = NULL;
   END IF;
INSERT INTO tbl_parameters (FieldName, DataType, IsRequired, Fieldlength, ListData, SessionId, TransactionDate, IsActive)
  VALUES (p_FieldName, p_DataType, p_IsRequired, p_Fieldlength, p_ListData, p_SessionId, NOW(), 1);
    SET Out_Param = LAST_INSERT_ID();
  ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_parameters
SET FieldName = p_FieldName,
    DataType = p_DataType,
    IsRequired = p_IsRequired,
    Fieldlength = p_Fieldlength,
    ListData = p_ListData
WHERE Id = p_Id;
       SET Out_Param = p_Id;
  ELSEIF  p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_parameters
SET IsActive = 0
WHERE Id = p_Id;
     SET Out_Param = p_Id;
  END IF;
END
$$

--
-- Create procedure `sp_set_menu_list`
--
CREATE PROCEDURE sp_set_menu_list(IN P_Id INT, IN p_MenuGroupId INT, IN p_Icon VARCHAR(50), IN p_DisplayText VARCHAR(50), IN p_Controller VARCHAR(50), 
IN p_ActionResult VARCHAR(50), IN p_IsForAdmin BIT, IN p_Description VARCHAR(100), IN p_IsForWorkflow BIT, IN p_QueryType VARBINARY(20))
BEGIN
  IF p_QueryType='INSERT' THEN
INSERT INTO tbl_menu_list (MenuGroupId, Icon, DisplayText, Controller, ActionResult, IsForAdmin, Description, IsForWorkflow)
  VALUES (p_MenuGroupId, p_Icon, p_DisplayText, p_Controller, p_ActionResult, p_IsForAdmin, p_Description, p_IsForWorkflow);
END IF;
END
$$

--
-- Create procedure `sp_set_menu_group`
--
CREATE PROCEDURE sp_set_menu_group(IN p_Id INT, IN p_Icon VARCHAR(50), IN p_DisplayText VARCHAR(50), IN p_QueryType VARCHAR(20))
    SQL SECURITY INVOKER
BEGIN

IF p_QueryType ='INSERT' THEN

INSERT INTO tbl_menu_group (Icon, DisplayText)
  VALUES (p_Icon, p_DisplayText);

ELSEIF p_QueryType = 'UPDATE' THEN

UPDATE tbl_menu_group
SET Icon = p_Icon,
    DisplayText = p_DisplayText
WHERE Id = p_Id;


-- ELSEIF p_QueryType = 'INACTIVE' THEN
-- 
-- UPDATE tbl_menu_group
-- SET IsActive = p_IsActive
-- WHERE Id = p_Id;


END IF;

END
$$

--
-- Create procedure `sp_Set_mc_DataOnHold`
--
CREATE PROCEDURE sp_Set_mc_DataOnHold(IN p_Id INT(11), IN p_CaseType VARCHAR(25), IN p_Purpose VARCHAR(25), IN p_EffectedData VARCHAR(8000), IN p_EffectedRowId INT(11), IN p_CreatedUserId INT(11), IN p_CreatedUserTypeId INT(11), IN p_ApproveRejectUserId INT(11), IN p_ApproveRejectUserTypeId INT(11), IN p_ApproveRejectRemarks VARCHAR(255), IN p_ApproveRejectDate DATETIME, IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_mc_data_on_hold (CaseType, Purpose, EffectedData, EffectedRowId, CreatedUserId, CreatedUserTypeId,
IsApproved, ApproveRejectUserId, ApproveRejectUserTypeId, ApproveRejectRemarks, ApproveRejectDate, IsActive, SessionId, TransactionDate)

  VALUES (p_CaseType, p_Purpose, p_EffectedData, p_EffectedRowId, p_CreatedUserId, p_CreatedUserTypeId, NULL, NULL, NULL, NULL, NULL, 1, p_SessionId, NOW());

    SET Out_Param = Last_insert_id();

  ELSEIF p_QueryType = 'APPROVE' THEN
UPDATE tbl_mc_data_on_hold
SET IsApproved = 1,
    ApproveRejectUserId = p_ApproveRejectUserId,
    ApproveRejectUserTypeId = p_ApproveRejectUserTypeId,
    ApproveRejectRemarks = p_ApproveRejectRemarks,
    ApproveRejectDate = NOW(),
    IsActive = 0
WHERE Id = p_Id;
    SET Out_Param = p_Id;

    -- SELECT * FROM tbl_mc_data_on_hold WHERE Id = p_Id AND  IsApproved = 1 AND IsActive = 0;
  ELSEIF p_QueryType = 'DECLINE' THEN
UPDATE tbl_mc_data_on_hold
SET IsApproved = 0,
    ApproveRejectUserId = p_ApproveRejectUserId,
    ApproveRejectUserTypeId = p_ApproveRejectUserTypeId,
    ApproveRejectRemarks = p_ApproveRejectRemarks,
    ApproveRejectDate = NOW(),
    IsActive = 0
WHERE Id = p_Id;
    SET Out_Param = p_Id;
  END IF;
END
$$

--
-- Create procedure `sp_Set_license_type`
--
CREATE PROCEDURE sp_Set_license_type(IN p_Id INT, IN p_TypeName VARCHAR(50), IN p_LicenceTypeDetails VARCHAR(100), IN p_NumberOfLicence INT(100), IN p_IsScalingEligible BIT(1), IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
Begin
 
  IF p_QueryType = 'INSERT' THEN
    If not Exists( SELECT
    id
  FROM tbl_licence_type
  WHERE TypeName = p_TypeName) THEN
INSERT INTO tbl_licence_type (TypeName, LicenceTypeDetails, NumberOfLicence, IsScalingEligible, IsActive, SessionId, TransactionDate)
  VALUES (p_TypeName, p_LicenceTypeDetails, p_NumberOfLicence, p_IsScalingEligible, p_IsActive, p_SessionId, NOW());
         SET Out_Param = LAST_INSERT_ID();
    else 
         SET Out_Param = '-1';
    End if;

  ELSEIF p_QueryType = 'UPDATE' THEN
    IF NOT Exists( SELECT
    id
  FROM tbl_licence_type
  WHERE TypeName = p_TypeName) THEN
UPDATE tbl_licence_type
SET TypeName = p_TypeName,
    LicenceTypeDetails = p_LicenceTypeDetails
WHERE Id = p_Id;
    		SET Out_Param = p_Id;

    ELSE
UPDATE tbl_licence_type
SET LicenceTypeDetails = p_LicenceTypeDetails
WHERE Id = p_Id;
      SET Out_Param = p_Id;
    End if;

  ELSEIF p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_licence_type
SET IsActive = 0
WHERE Id = p_Id;

    SET Out_Param = p_Id;
  END IF  ;
END
$$

--
-- Create procedure `sp_Set_license_parameters`
--
CREATE PROCEDURE sp_Set_license_parameters(IN p_LicenseTypeId INT(11), IN p_ParameterId INT(11), p_SessionId varchar(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
  IF p_QueryType = 'INSERT' THEN

INSERT INTO tbl_license_parameter (ParameterId, LicenseTypeId, SessionId, TransactionDate, IsActive)
  VALUES (p_ParameterId, p_LicenseTypeId, p_SessionId, NOW(), 1);

    SET Out_Param = LAST_INSERT_ID();

  ELSEIF p_QueryType = 'DEACTIVATE' THEN

UPDATE tbl_license_parameter
SET IsActive = 0
WHERE LicenseTypeId = p_LicenseTypeId
AND IsActive = 1;
    SET Out_Param = p_LicenseTypeId;
  END IF;
END
$$

--
-- Create procedure `sp_Set_ClientCategory`
--
CREATE PROCEDURE sp_Set_ClientCategory(IN p_Id INT(11), IN p_CategoryName VARCHAR(100), IN p_CategoryDetails VARCHAR(100), OUT Out_Param VARCHAR(1000), IN p_QueryType VARCHAR(255), IN p_IsActive BIT, IN p_SessionId VARCHAR(1000))
BEGIN
	IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_client_category (CategoryName, CategoryDetails, IsActive, SessionId, TransactionDate)
  VALUES (p_CategoryName, p_CategoryDetails, p_IsActive, p_SessionId, NOW());
       SET Out_Param = LAST_INSERT_ID();
      
  ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_client_category
SET CategoryName = p_CategoryName,
    CategoryDetails = p_CategoryDetails
WHERE Id = p_Id;
       SET Out_Param = p_Id;

  ELSEIF  p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_client_category
SET IsActive = 0
WHERE Id = p_Id;

     SET Out_Param = p_Id;
  END IF;
END
$$

--
-- Create procedure `sp_Set_Client`
--
CREATE PROCEDURE sp_Set_Client(IN p_Id INT(11), IN p_CategoryId INT(11), IN p_ClientName VARCHAR(50), IN p_ClientNumber VARCHAR(20), IN p_ClientEmail VARCHAR(50), IN p_CompanyName VARCHAR(100), IN p_CompanyAddress VARCHAR(100), IN p_CompanyNumber VARCHAR(20), IN p_CompanyEmail VARCHAR(50), IN p_GSTIN VARCHAR(15), IN p_PANNo VARCHAR(12), IN p_IsActive BIT(1), IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20), OUT Out_Param VARCHAR(1000))
BEGIN
	IF p_QueryType = 'INSERT' THEN
INSERT INTO tbl_client (CategoryId, ClientName, ClientNumber, ClientEmail, CompanyName, CompanyAddress, CompanyNumber, CompanyEmail, GSTIN, PANNo, IsActive, SessionId, TransactionDate)
  VALUES (p_CategoryId, p_ClientName, p_ClientNumber, p_ClientEmail, p_CompanyName, p_CompanyAddress, p_CompanyNumber, p_CompanyEmail, p_GSTIN, p_PANNo, p_IsActive, p_SessionId, NOW());
       SET Out_Param = LAST_INSERT_ID();
  ELSEIF p_QueryType = 'UPDATE' THEN
UPDATE tbl_client
SET CategoryId = p_CategoryId,
    ClientName = p_ClientName,
    ClientNumber = p_ClientNumber,
    ClientEmail = p_ClientEmail,
    CompanyName = p_CompanyName,
    CompanyAddress = p_CompanyAddress,
    CompanyNumber = p_CompanyNumber,
    CompanyEmail = p_CompanyEmail,
    GSTIN = p_GSTIN,
    PANNo = p_PANNo
WHERE Id = p_Id;
       SET Out_Param = p_Id;
  ELSEIF  p_QueryType = 'DEACTIVATE' THEN
UPDATE tbl_client
SET IsActive = 0
WHERE Id = p_Id;
     SET Out_Param = p_Id;
  END IF;
END
$$

--
-- Create procedure `sp_Rp_XmlDownload`
--
CREATE PROCEDURE sp_Rp_XmlDownload(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(1000) DEFAULT null;
  SET DynamicSql = 'select *, fn_Get_UserFullName(UserId) as FullName from tbl_xml_download txd, tbl_usertype tu where tu.Id = txd.UserTypeId ';
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_UserLogin`
--
CREATE PROCEDURE sp_Rp_UserLogin(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(500) DEFAULT null;
  SET DynamicSql = ' SELECT * FROM tbl_log_login ';
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' WHERE ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_user`
--
CREATE PROCEDURE sp_Rp_user(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(500) DEFAULT null;
  SET DynamicSql = ' SELECT * FROM tbl_user tu, tbl_usertype tut WHERE tu.UserTypeId = tut.Id ';
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_TAT_License_Generation`
--
CREATE PROCEDURE sp_Rp_TAT_License_Generation(IN p_RequestNo VARCHAR(255))
BEGIN
  IF p_RequestNo IS NULL THEN
SELECT
  tbl_request.RequestNo,
  tbl_request.RequestDate,
  tbl_request_status.IsApproved,
  tbl_request_status.ApproveRejectDate,
  tbl_licence_type.TypeName,
  TIMEDIFF(tbl_request_status.ApproveRejectDate, tbl_request.RequestDate) AS TurnAroundTime
FROM tbl_request
  INNER JOIN tbl_request_status
    ON tbl_request.Id = tbl_request_status.Id
  INNER JOIN tbl_licence_type
    ON tbl_licence_type.Id = LicenceTypeId;
ELSE
SELECT
  tbl_request.RequestNo,
  tbl_request.RequestDate,
  tbl_request_status.IsApproved,
  tbl_request_status.ApproveRejectDate,
  tbl_licence_type.TypeName,
  TIMEDIFF(tbl_request_status.ApproveRejectDate, tbl_request.RequestDate) AS TurnAroundTime
FROM tbl_request
  INNER JOIN tbl_request_status
    ON tbl_request.Id = tbl_request_status.Id
  INNER JOIN tbl_licence_type
    ON tbl_licence_type.Id = LicenceTypeId
WHERE tbl_request.RequestNo LIKE CONCAT('%', p_RequestNo, '%');
END IF;
END
$$

--
-- Create procedure `sp_Rp_Status`
--
CREATE PROCEDURE sp_Rp_Status(IN p_WhereClouse VARCHAR(1000))
BEGIN
    DECLARE DynamicSql varchar(1000) DEFAULT null;
    SET DynamicSql = ' SELECT *,fn_Get_UserFullName(UserId) as FullName FROM tbl_request_status ';
    IF p_WhereClouse is not null then      
      SET @DynamicSql = CONCAT(DynamicSql, ' WHERE ', p_WhereClouse);
      PREPARE stmt FROM @DynamicSql;
    END IF;
    EXECUTE stmt;
   
    DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_RequestPending`
--
CREATE PROCEDURE sp_Rp_RequestPending(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(500) DEFAULT null;
  SET DynamicSql = ' SELECT trc.ClaimDate, trc.AssignDate, tr.*, fn_Get_UserTypeName(trc.NextUserTypeId) as UserTypeName, fn_Get_UserFullName(trc.ClaimUserId) as FullName
  FROM tbl_request tr, tbl_licence_type tlt, tbl_client tc, tbl_product tb, tbl_user tu, tbl_request_claim trc where  tr.ProductId = tb.Id and tr.ClientId = tc.Id and tr.LicenceTypeId = tlt.Id and tr.UserId = tu.Id and trc.RequestId = tr.Id and trc.IsActive = 1' ;
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_RequestOnHold`
--
CREATE PROCEDURE sp_Rp_RequestOnHold(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(1000) DEFAULT null;
  SET DynamicSql = 'select *, fn_Get_UserFullName(UserId) as FullName from tbl_request tr, tbl_licence_type tlt, tbl_usertype tut where tr.LicenceTypeId = tlt.Id and tr.UserTypeId = tut.Id and tr.RequestNo NOT IN (Select RequestNo from tbl_request_status) ';
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_RequestMovement`
--
CREATE PROCEDURE sp_Rp_RequestMovement(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(1000) DEFAULT null;
  SET DynamicSql = ' SELECT *, fn_Get_UserFullName(tra.UserId) as FullName FROM tbl_request_acknowledgement as tra, tbl_usertype as tut, tbl_s_state as tss where tra.UserTypeId = tut.Id and tra.StateId = tss.Id ';
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_Request`
--
CREATE PROCEDURE sp_Rp_Request(IN p_WhereClouse VARCHAR(1000))
BEGIN
  DECLARE DynamicSql varchar(500) DEFAULT null;
  SET DynamicSql = ' SELECT * FROM tbl_request tr, tbl_licence_type tlt, tbl_client tc, tbl_product tb, tbl_user tu where  tr.ProductId = tb.Id and tr.ClientId = tc.Id and tr.LicenceTypeId = tlt.Id and tr.UserId = tu.Id ';
  IF p_WhereClouse is not null then      
    SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
    PREPARE stmt FROM @DynamicSql;
  END IF;
  EXECUTE stmt;
   
  DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_MakerChecker`
--
CREATE PROCEDURE sp_Rp_MakerChecker(IN p_WhereClouse VARCHAR(1000))
BEGIN
    DECLARE DynamicSql varchar(1000) DEFAULT null;
    SET DynamicSql = ' SELECT * FROM tbl_mc_data_on_hold tmdoh, tbl_user tu, tbl_usertype tut where  tmdoh.CreatedUserId = tu.Id and tut.id = tu.UserTypeId';
    IF p_WhereClouse is not null then      
      SET @DynamicSql = CONCAT(DynamicSql, ' AND ', p_WhereClouse);
      PREPARE stmt FROM @DynamicSql;
    END IF;
    EXECUTE stmt;
   
    DEALLOCATE PREPARE stmt;
 
END
$$

--
-- Create procedure `sp_Rp_Activity`
--
CREATE PROCEDURE sp_Rp_Activity(IN p_UserVal VARCHAR(255), IN p_FromDate DATETIME, IN p_ToDate DATETIME)
BEGIN
  IF p_UserVal IS NOT null AND p_FromDate IS null  THEN
SELECT
  *,
  fn_Get_UserFullName(UserId) AS FullName
FROM tbl_log_activity
WHERE HttpVerbs = 'GET'
AND UserId IN (SELECT
    Id
  FROM tbl_user
  WHERE FullName LIKE p_UserVal
  OR Email LIKE p_UserVal
  OR UserName LIKE p_UserVal)
AND UserId <> 0;
ELSEIF p_UserVal IS NULL
  AND p_FromDate IS NOT NULL THEN
SELECT
  *,
  fn_Get_UserFullName(UserId) AS FullName
FROM tbl_log_activity
WHERE HttpVerbs = 'GET'
AND (TransactionDate BETWEEN p_FromDate AND p_ToDate)
AND UserId <> 0;
ELSE
SELECT
  *,
  fn_Get_UserFullName(UserId) AS FullName
FROM tbl_log_activity
WHERE HttpVerbs = 'GET'
AND TransactionDate BETWEEN p_FromDate AND p_ToDate
AND UserId IN (SELECT
    Id
  FROM tbl_user
  WHERE FullName LIKE p_UserVal
  OR Email LIKE p_UserVal
  OR UserName LIKE p_UserVal)
AND UserId <> 0;
END IF;
END
$$

--
-- Create procedure `Sp_Login`
--
CREATE PROCEDURE Sp_Login(IN p_UserName VARCHAR(255), IN p_Password VARCHAR(255), IN p_SessionId VARCHAR(255))
BEGIN
DECLARE UserRowCount INT DEFAULT 0;
DECLARE UserID INT DEFAULT 0;
DECLARE Flag bool DEFAULT 0;

SELECT
  *
FROM tbl_user
WHERE UserName = p_UserName
AND IsActive = 1;

INSERT INTO tbl_log_login (UserName, Password, SessionId, TransactionDate)
  VALUES (p_UserName, p_Password, p_SessionId, NOW());

END
$$

--
-- Create procedure `sp_Log`
--
CREATE PROCEDURE sp_Log(IN p_MacAddress VARCHAR(50), IN p_BrowserType VARCHAR(50), IN p_Browser VARCHAR(255), IN p_BrowserVersion VARCHAR(50), IN p_DNS VARCHAR(50), IN p_SessionId VARCHAR(100), IN p_IPAddress VARCHAR(50), IN p_Controller VARCHAR(50), IN p_Action VARCHAR(50), IN p_RouteId VARCHAR(100), IN p_AbsoluteUri VARCHAR(512), IN p_HttpVerbs VARCHAR(10), IN p_UserId INT(11))
  NO SQL
BEGIN
INSERT INTO tbl_log_activity (MacAddress,
BrowserType,
Browser,
BrowserVersion,
DNS,
IPAddress,
Controller,
Action,
RouteId,
AbsoluteUri,
HttpVerbs,
UserId,
SessionID,
TransactionDate)
  VALUES (p_MacAddress, p_BrowserType, p_Browser, p_BrowserVersion, p_DNS, p_IPAddress, p_Controller, p_Action, p_RouteId, p_AbsoluteUri, p_HttpVerbs, p_UserId, p_SessionID, NOW());
END
$$

--
-- Create procedure `sp_Get_Xml`
--
CREATE PROCEDURE sp_Get_Xml(IN p_RequestId INT(11), IN p_UserId INT, IN p_UserTypeId INT, IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20))
BEGIN
	IF p_QueryType ='XML' THEN
INSERT INTO tbl_xml_download (UserId, UserTypeId, RequestId, RequestNo, IsActive, SessionId, TransactionDate)
  VALUES (p_UserId, p_UserTypeId, p_RequestId, (SELECT RequestNo FROM tbl_Request WHERE Id = p_RequestId), 1, p_SessionId, NOW());

SELECT
  tbl_request.Id,
  tbl_request.RequestNo,
  tbl_client.ClientName,
  tbl_licence_type.TypeName,
  tbl_product.ProductName,
  tbl_request.RequestDate,
  tbl_request.LicenceNo,
  fn_Get_UserFullName(tbl_request.UserId) AS FullName
FROM tbl_request
  LEFT JOIN tbl_request_status
    ON tbl_request.Id = tbl_request_status.RequestId

  INNER JOIN tbl_client
    ON tbl_request.ClientId = tbl_client.Id

  INNER JOIN tbl_licence_type
    ON tbl_request.LicenceTypeId = tbl_licence_type.Id

  INNER JOIN tbl_product
    ON tbl_request.ProductId = tbl_product.Id

WHERE tbl_request.Id = p_RequestId
AND tbl_request_status.IsApproved = 1;
--         ---


SELECT
  tbl_request_parameter.ParamValue,
  tbl_parameters.FieldName
FROM tbl_request_parameter
  INNER JOIN tbl_parameters
    ON tbl_request_parameter.ParamId = tbl_parameters.Id
WHERE RequestId = p_RequestId;

SELECT
  Id,
  RestrictTo,
  RestrictVal
FROM tbl_request_restrict
WHERE RequestId = p_RequestId;

SELECT
  tbl_product_features.FeaturesName
FROM tbl_request_features
  INNER JOIN tbl_product
    ON tbl_request_features.ProductId = tbl_product.Id
  INNER JOIN tbl_product_features
    ON tbl_request_features.FeaturesId = tbl_product_features.Id
WHERE RequestId = p_RequestId;
END IF;
END
$$

--
-- Create procedure `sp_Get_WF_State`
--
CREATE PROCEDURE sp_Get_WF_State(IN p_RequestId INT, IN p_UserId INT, IN p_UserTypeId INT, IN p_SessionId VARCHAR(100), IN p_QueryType VARCHAR(20))
BEGIN
	IF p_QueryType ='XML' THEN
INSERT INTO tbl_xml_download (UserId, UserTypeId, RequestId, RequestNo, IsActive, SessionId, TransactionDate)
  VALUES (p_UserId, p_UserTypeId, p_RequestId, (SELECT RequestNo FROM tbl_request WHERE Id = p_RequestId), 1, p_SessionId, NOW());

SELECT
  tbl_request.Id,
  tbl_request.RequestNo,
  tbl_client.ClientName,
  tbl_licence_type.TypeName,
  tbl_product.ProductName,
  tbl_request.RequestDate,
  tbl_request.LicenceNo,
  fn_Get_UserFullName(tbl_request.UserId) AS FullName
FROM tbl_request
  LEFT JOIN tbl_request_status
    ON tbl_request.Id = tbl_request_status.RequestId

  INNER JOIN tbl_client
    ON tbl_request.ClientId = tbl_client.Id

  INNER JOIN tbl_licence_type
    ON tbl_request.LicenceTypeId = tbl_licence_type.Id

  INNER JOIN tbl_product
    ON tbl_request.ProductId = tbl_product.Id

WHERE tbl_request.Id = p_RequestId
AND tbl_request_status.IsApproved = 1;
--         ---


SELECT
  tbl_request_parameter.ParamValue,
  tbl_parameters.FieldName
FROM tbl_request_parameter
  INNER JOIN tbl_parameters
    ON tbl_request_parameter.ParamId = tbl_parameters.Id
WHERE RequestId = p_RequestId;

SELECT
  Id,
  RestrictTo,
  RestrictVal
FROM tbl_request_restrict
WHERE RequestId = p_RequestId;

SELECT
  tbl_product_features.FeaturesName
FROM tbl_request_features
  INNER JOIN tbl_product
    ON tbl_request_features.ProductId = tbl_product.Id
  INNER JOIN tbl_product_features
    ON tbl_request_features.FeaturesId = tbl_product_features.Id
WHERE RequestId = p_RequestId;
END IF;
END
$$

--
-- Create procedure `sp_Get_wf_process_assign`
--
CREATE PROCEDURE sp_Get_wf_process_assign(IN p_LicenceTypeId INT, IN p_QueryType VARCHAR(20))
BEGIN
	IF p_QueryType ='ALL' THEN
SELECT
  tbl_wf_process_assign.Id,
  tbl_wf_process_assign.WFProcessId,
  tbl_wf_process_assign.StateId,
  tbl_wf_process_assign.FromUserTypeId,
  tbl_wf_process_assign.ToUserTypeId,
  tbl_wf_process_assign.IsActive,
  tbl_wf_process_assign.ActivityStartDate,
  tbl_wf_process_assign.ActivityEndDate,
  tbl_s_state.Name,
  tbl_wf_process.ProcessName,
  tbl_wf_process.ProcessCode,
  tbl_wf_process.LicenceTypeId,
  (SELECT
      TypeName
    FROM tbl_licence_type
    WHERE Id = tbl_wf_process.LicenceTypeId) AS TypeName,
  tbl_s_state.IsPositive,
  tbl_s_state.IsNegative,
  tbl_s_state.IsHold,
  tbl_wf_process.IsInitial,
  tbl_wf_process.IsEnd,
  tbl_wf_process.Description,
  (SELECT
      UserTypeName
    FROM tbl_usertype
    WHERE Id = tbl_wf_process_assign.FromUserTypeID) AS FromUserTypeName,
  (SELECT
      UserTypeName
    FROM tbl_usertype
    WHERE Id = tbl_wf_process_assign.ToUserTypeID) AS ToUserTypeName
FROM tbl_s_state
  INNER JOIN tbl_wf_process_assign
    ON tbl_s_state.Id = tbl_wf_process_assign.StateId
  INNER JOIN tbl_wf_process
    ON tbl_wf_process.Id = tbl_wf_process_assign.WFProcessId;

ELSEIF p_QueryType = 'FORLICENSE' THEN
SELECT
  tbl_wf_process_assign.Id,
  tbl_wf_process_assign.WFProcessId,
  tbl_wf_process_assign.StateId,
  tbl_wf_process_assign.FromUserTypeId,
  tbl_wf_process_assign.ToUserTypeId,
  tbl_wf_process_assign.IsActive,
  tbl_wf_process_assign.ActivityStartDate,
  tbl_wf_process_assign.ActivityEndDate,
  tbl_s_state.Name,
  tbl_wf_process.ProcessName,
  tbl_wf_process.ProcessCode,
  tbl_wf_process.LicenceTypeId,
  (SELECT
      TypeName
    FROM tbl_licence_type
    WHERE Id = tbl_wf_process.LicenceTypeId) AS TypeName,
  tbl_s_state.IsPositive,
  tbl_s_state.IsNegative,
  tbl_s_state.IsHold,
  tbl_wf_process.IsInitial,
  tbl_wf_process.IsEnd,
  tbl_wf_process.Description,
  (SELECT
      UserTypeName
    FROM tbl_usertype
    WHERE Id = tbl_wf_process_assign.FromUserTypeID) AS FromUserTypeName,
  (SELECT
      UserTypeName
    FROM tbl_usertype
    WHERE Id = tbl_wf_process_assign.ToUserTypeID) AS ToUserTypeName
FROM tbl_s_state
  INNER JOIN tbl_wf_process_assign
    ON tbl_s_state.Id = tbl_wf_process_assign.StateId
  INNER JOIN tbl_wf_process
    ON tbl_wf_process.Id = tbl_wf_process_assign.WFProcessId
WHERE LicenceTypeId = p_LicenceTypeId;
END IF;
END
$$

--
-- Create procedure `sp_Get_wf_process`
--
CREATE PROCEDURE sp_Get_wf_process(IN p_QueryType VARCHAR(20), IN p_Id int)
BEGIN
	IF p_QueryType ='ALL' THEN
SELECT
  Process.Id,
  Process.ProcessName,
  Process.ProcessCode,
  Process.IsInitial,
  Process.IsEnd,
  Process.Description,
  Process.LicenceTypeId,
  Licence.TypeName
FROM tbl_wf_process AS Process
  INNER JOIN tbl_licence_type AS Licence
    ON Process.LicenceTypeId = Licence.Id
WHERE Process.IsActive = 1;

ELSEIF p_QueryType ='ONE' THEN
SELECT
  Process.Id,
  Process.ProcessName,
  Process.ProcessCode,
  Process.IsInitial,
  Process.IsEnd,
  Process.Description,
  Process.LicenceTypeId,
  Licence.TypeName
FROM tbl_wf_process AS Process
  INNER JOIN tbl_licence_type AS Licence
    ON Process.LicenceTypeId = Licence.Id
WHERE Process.IsActive = 1 AND Process.Id = p_Id;

END IF;
END
$$

--
-- Create procedure `sp_Get_usertype`
--
CREATE PROCEDURE sp_Get_usertype(IN p_QueryType VARCHAR(20), IN p_UserTypeId INT(11))
BEGIN
IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_usertype
WHERE IsActive = 1;
ELSEIF p_QueryType = 'USERTYPE' THEN
SELECT
  *
FROM tbl_usertype
WHERE Id = p_UserTypeId;
END IF;
END
$$

--
-- Create procedure `sp_Get_usermenu`
--
CREATE PROCEDURE sp_Get_usermenu(IN p_QueryType VARCHAR(255), IN p_UserId INT)
BEGIN
  IF p_QueryType = 'ALL' THEN
SELECT * FROM tbl_usermenu;

ELSEIF p_QueryType = 'FORUSER' THEN
SELECT
  tbl_menu_list.Id,
  tbl_menu_list.Icon,
  tbl_menu_list.DisplayText,
  tbl_menu_list.Controller,
  tbl_menu_list.MenuGroupId,
  tbl_menu_list.ActionResult,
  tbl_menu_list.IsReport,
  tbl_menu_list.IsForAdmin,
  tbl_menu_list.IsForWorkflow
FROM tbl_menu_list
  INNER JOIN tbl_usermenu
    ON tbl_menu_list.Id = tbl_usermenu.MenuId
WHERE tbl_usermenu.UserTypeId = p_UserId
AND tbl_usermenu.IsActive = 1
ORDER BY tbl_menu_list.MenuGroupId, tbl_menu_list.Id;

SELECT * FROM tbl_menu_group;

ELSEIF p_QueryType = 'FORUSERTYPE' THEN
SELECT * FROM tbl_usermenu
WHERE UserTypeId = p_UserId
AND IsActive = 1;
END IF;
END
$$

--
-- Create procedure `sp_Get_userdashboard`
--
CREATE PROCEDURE sp_Get_userdashboard(IN p_QueryType VARCHAR(255), IN p_UserTypeId INT(11))
BEGIN
  IF p_QueryType = 'FORUSER' THEN
SELECT
  tbl_dashboard.Id,
  tbl_dashboard.PartialViewName,
  tbl_dashboard.Description,
  tbl_dashboard.DivCssClass,
  tbl_dashboard.IsActive
FROM tbl_userdashboard
  INNER JOIN tbl_dashboard
    ON tbl_userdashboard.DashboardId = tbl_dashboard.Id
WHERE tbl_userdashboard.UserTypeId = p_UserTypeId
AND tbl_userdashboard.IsActive = 1
AND tbl_dashboard.IsActive = 1
ORDER BY tbl_dashboard.SortOrder;

ELSEIF p_QueryType = 'USERTYPE' THEN
SELECT
  *
FROM tbl_userdashboard
WHERE UserTypeId = p_UserTypeId
AND IsActive = 1;
END IF;
END
$$

--
-- Create procedure `sp_Get_user`
--
CREATE PROCEDURE sp_Get_user(IN p_QueryType VARCHAR(20), IN p_UserTypeId INT, IN p_UserId INT, IN p_UserName VARCHAR(100))
BEGIN
	IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_user
WHERE IsActive = 1;
ELSEIF p_QueryType = 'BYUSERTYPE' THEN
SELECT
  *
FROM tbl_user
WHERE UserTypeId = p_UserTypeId
AND IsActive = 1;
ELSEIF p_QueryType = 'USER' THEN
SELECT
  *
FROM tbl_user
WHERE Id = p_UserId;
ELSEIF p_QueryType = 'USERNAME' THEN
SELECT
  *
FROM tbl_user
WHERE UserName = p_UserName;
END IF;
END
$$

--
-- Create procedure `sp_Get_request_acknowledgement`
--
CREATE PROCEDURE sp_Get_request_acknowledgement(IN p_RequestId INT(11), IN p_QueryType VARCHAR(20))
BEGIN
	IF p_QueryType ='FORREQUEST' THEN
SELECT
  tbl_request_acknowledgement.*,
  tbl_usertype.UserTypeName,
  fn_Get_UserFullName(tbl_request_acknowledgement.UserId) AS FullName,
  tbl_s_state.Name
FROM tbl_request_acknowledgement
  INNER JOIN tbl_usertype
    ON tbl_request_acknowledgement.UserTypeId = tbl_usertype.Id
  INNER JOIN tbl_s_state
    ON tbl_request_acknowledgement.StateId = tbl_s_state.Id
WHERE tbl_request_acknowledgement.RequestId = p_RequestId;
END IF;
END
$$

--
-- Create procedure `sp_Get_request`
--
CREATE PROCEDURE sp_Get_request(IN p_RequestId INT(11), IN p_UserId INT, IN p_UserTypeId INT, IN p_QueryType VARCHAR(20))
BEGIN
  DECLARE p_IsClaimedT bit(1);
  DECLARE p_IsClaimedF bit(1);
  SET p_IsClaimedT = 1;
  
  SET p_IsClaimedF = 0;

	IF p_QueryType ='ALL' THEN
SELECT
  tbl_request.Id,
  tbl_client.ClientName,
  tbl_licence_type.Id AS LicenceTypeId,
  tbl_licence_type.TypeName,
  tbl_product.ProductName,
  tbl_request.RequestNo,
  tbl_request.RequestDate,
  fn_Get_UserFullName(tbl_request.UserId) AS FullName,
  tbl_usertype.UserTypeName,
  CASE (SELECT
      tbl_request_claim.ClaimUserId
    FROM tbl_request_claim
    WHERE RequestId = tbl_request.Id
    AND (tbl_request_claim.ClaimUserId = p_UserId)
    AND tbl_request_claim.IsActive = 1) WHEN p_UserId THEN p_IsClaimedT ELSE p_IsClaimedF END AS IsClaimed
FROM tbl_request
  INNER JOIN tbl_client
    ON tbl_request.ClientId = tbl_client.Id

  INNER JOIN tbl_licence_type
    ON tbl_request.LicenceTypeId = tbl_licence_type.Id

  INNER JOIN tbl_product
    ON tbl_request.ProductId = tbl_product.Id

  INNER JOIN tbl_usertype
    ON tbl_request.UserTypeId = tbl_usertype.Id
WHERE tbl_request.Id IN (SELECT
    RequestId
  FROM tbl_request_claim
  WHERE tbl_request_claim.NextUserTypeId = p_UserTypeId
  AND (tbl_request_claim.ClaimUserId IS NULL
  OR tbl_request_claim.ClaimUserId = p_UserId)
  AND tbl_request_claim.IsActive = 1);
-- WHERE tbl_request.Id = p_RequestId
-- AND tbl_licence_type.IsActive = 1
-- AND tbl_product.IsActive = 1
-- AND tbl_request.IsActive = 1
-- AND tbl_license_parameter.IsActive = 1;

ELSEIF p_QueryType = 'SINGLE' THEN
SELECT
  tbl_request.Id,
  tbl_client.ClientName,
  tbl_licence_type.Id AS LicenceTypeId,
  tbl_licence_type.TypeName,
  tbl_product.ProductName,
  tbl_request.RequestNo,
  tbl_request.RequestDate,
  tbl_request.LicenceNo,
  fn_Get_UserFullName(tbl_request.UserId) AS FullName,
  tbl_usertype.UserTypeName,
  CASE (SELECT
      tbl_request_claim.ClaimUserId
    FROM tbl_request_claim
    WHERE RequestId = tbl_request.Id
    AND (tbl_request_claim.ClaimUserId = p_UserId)
    AND tbl_request_claim.IsActive = 1) WHEN p_UserId THEN p_IsClaimedT ELSE p_IsClaimedF END AS IsClaimed
FROM tbl_request
  INNER JOIN tbl_client
    ON tbl_request.ClientId = tbl_client.Id

  INNER JOIN tbl_licence_type
    ON tbl_request.LicenceTypeId = tbl_licence_type.Id

  INNER JOIN tbl_product
    ON tbl_request.ProductId = tbl_product.Id

  INNER JOIN tbl_usertype
    ON tbl_request.UserTypeId = tbl_usertype.Id
WHERE tbl_request.Id = p_RequestId
AND tbl_request.Id IN (SELECT
    RequestId
  FROM tbl_request_claim
  WHERE tbl_request_claim.NextUserTypeId = p_UserTypeId
  AND (tbl_request_claim.ClaimUserId IS NULL
  OR tbl_request_claim.ClaimUserId = p_UserId)
  AND tbl_request_claim.IsActive = 1);
-- AND tbl_licence_type.IsActive = 1
-- AND tbl_product.IsActive = 1
-- AND tbl_request.IsActive = 1
-- AND tbl_license_parameter.IsActive = 1;

--         ---


SELECT
  tbl_request_parameter.ParamValue,
  tbl_parameters.FieldName
FROM tbl_request_parameter
  INNER JOIN tbl_parameters
    ON tbl_request_parameter.ParamId = tbl_parameters.Id
WHERE RequestId = p_RequestId;

SELECT
  *
FROM tbl_request_restrict
WHERE RequestId = p_RequestId;

SELECT
  tbl_product.ProductName,
  tbl_product_features.FeaturesName
FROM tbl_request_features
  INNER JOIN tbl_product
    ON tbl_request_features.ProductId = tbl_product.Id
  INNER JOIN tbl_product_features
    ON tbl_request_features.FeaturesId = tbl_product_features.Id
WHERE RequestId = p_RequestId;
ELSEIF p_QueryType = 'OWN' THEN
SELECT
  tbl_request.Id,
  tbl_client.ClientName,
  tbl_licence_type.Id AS LicenceTypeId,
  tbl_licence_type.TypeName,
  tbl_product.ProductName,
  tbl_request.RequestNo,
  tbl_request.RequestDate,
  fn_Get_UserFullName(tbl_request.UserId) AS FullName,
  tbl_usertype.UserTypeName,
  tbl_request_status.IsApproved,
  tbl_request_status.Remarks,
  tbl_request.LicenceNo,
  tbl_request_status.ApproveRejectDate
FROM tbl_request
  LEFT JOIN tbl_request_status
    ON tbl_request.Id = tbl_request_status.RequestId

  INNER JOIN tbl_client
    ON tbl_request.ClientId = tbl_client.Id

  INNER JOIN tbl_licence_type
    ON tbl_request.LicenceTypeId = tbl_licence_type.Id

  INNER JOIN tbl_product
    ON tbl_request.ProductId = tbl_product.Id

  INNER JOIN tbl_usertype
    ON tbl_request.UserTypeId = tbl_usertype.Id
WHERE tbl_request.UserId = p_UserId;
END IF;
END
$$

--
-- Create procedure `sp_Get_product_module`
--
CREATE PROCEDURE sp_Get_product_module(IN p_ProductId INT(11), IN p_QueryType VARCHAR(20))
BEGIN
  IF p_QueryType = 'FORPRODUCT' THEN
SELECT
  *
FROM tbl_product_module AS pf
WHERE pf.ProductId = p_ProductId
AND pf.IsActive = 1;
END IF;
END
$$

--
-- Create procedure `sp_Get_product_features`
--
CREATE PROCEDURE sp_Get_product_features(IN p_ProductId INT(11), IN p_QueryType VARCHAR(20))
BEGIN
    IF p_QueryType = 'FORPRODUCT' THEN
SELECT
  *
FROM tbl_product_features AS pf
WHERE pf.ProductId = p_ProductId
AND pf.IsActive = 1;

END IF;
END
$$

--
-- Create procedure `sp_Get_product`
--
CREATE PROCEDURE sp_Get_product(IN p_QueryType VARCHAR(20), IN p_ProductId INT(11))
BEGIN
	IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_product
WHERE IsActive = 1;
ELSEIF p_QueryType = 'PRODUCT' THEN
SELECT
  *
FROM tbl_product
WHERE Id = p_ProductId;
END IF;
END
$$

--
-- Create procedure `sp_Get_password_security_questions`
--
CREATE PROCEDURE sp_Get_password_security_questions(IN p_UserId INT(11), IN p_QueryType VARCHAR(20))
BEGIN
  IF p_QueryType ='ACTIVE' THEN
SELECT
  *
FROM tbl_password_security_questions
WHERE IsActive = 1
AND UserId = p_UserId;
END IF;
END
$$

--
-- Create procedure `sp_Get_password_Reset_Request`
--
CREATE PROCEDURE sp_Get_password_Reset_Request(IN p_QueryType VARCHAR(20))
BEGIN
  IF p_QueryType ='ACTIVE' THEN
SELECT
  *
FROM tbl_password_reset_request AS req
  INNER JOIN tbl_user AS user
    ON req.UserId = user.Id
WHERE req.IsActive = 1
AND req.IsCanceled = 0;
END IF;
END
$$

--
-- Create procedure `sp_Get_Password`
--
CREATE PROCEDURE sp_Get_Password(IN p_UserId INT(11))
BEGIN
SELECT
  *
FROM tbl_password
WHERE UserId = p_UserId
AND IsActive = 1;
END
$$

--
-- Create procedure `sp_Get_parameter`
--
CREATE PROCEDURE sp_Get_parameter(IN p_QueryType VARCHAR(20))
BEGIN
IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_parameters
WHERE IsActive = 1;
END IF;
END
$$

--
-- Create procedure `sp_Get_menu_list`
--
CREATE PROCEDURE sp_Get_menu_list(IN p_QueryType VARCHAR(20), IN p_Id int)
BEGIN
IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_menu_list;

ELSEIF p_QueryType = 'ONE' THEN
SELECT  * FROM tbl_menu_list
WHERE Id = p_Id;

ELSEIF p_QueryType = 'ASSIGN' THEN
SELECT
  *
FROM tbl_menu_list
WHERE IsForAdmin = 0
AND IsForWorkflow = 0;
END IF;
END
$$

--
-- Create procedure `sp_Get_mc_DataOnHold`
--
CREATE PROCEDURE sp_Get_mc_DataOnHold(IN p_Id INT, IN p_UserId INT, IN p_UserTypeId INT, IN p_QueryType VARCHAR(20))
BEGIN
  IF p_QueryType = 'FORUSER' THEN
SELECT
  *,
  fn_Get_UserFullName(CreatedUserId) AS CreatedUserFullName,
  fn_Get_UserFullName(ApproveRejectUserId) AS ApproveRejectUserFullName
FROM tbl_mc_data_on_hold
WHERE (CreatedUserTypeId = p_UserTypeId
OR p_UserTypeId = 1)
AND (CreatedUserId <> p_UserId
OR p_UserId = 1)
AND IsApproved IS NULL
AND IsActive = 1
ORDER BY TransactionDate DESC;
ELSEIF p_QueryType = 'SINGLE' THEN
SELECT
  *,
  fn_Get_UserFullName(CreatedUserId) AS CreatedUserFullName,
  fn_Get_UserFullName(ApproveRejectUserId) AS ApproveRejectUserFullName
FROM tbl_mc_data_on_hold
WHERE (CreatedUserTypeId = p_UserTypeId
OR p_UserTypeId = 1)
AND (CreatedUserId <> p_UserId
OR p_UserId = 1)
AND IsApproved IS NULL
AND IsActive = 1
AND Id = p_Id;
END IF;
END
$$

--
-- Create procedure `sp_Get_Master`
--
CREATE PROCEDURE sp_Get_Master(IN p_QueryType VARCHAR(20))
BEGIN
  IF p_QueryType ='COUNT' THEN
SELECT
  (SELECT
      COUNT(*)
    FROM tbl_usertype
    WHERE IsActive = 1) AS UserType,
  (SELECT
      COUNT(*)
    FROM tbl_user
    WHERE IsActive = 1) AS User,
  (SELECT
      COUNT(*)
    FROM tbl_licence_type
    WHERE IsActive = 1) AS LicenceType,
  (SELECT
      COUNT(*)
    FROM tbl_client
    WHERE IsActive = 1) AS Client,
  (SELECT
      COUNT(*)
    FROM tbl_product
    WHERE IsActive = 1) AS Product,
  (SELECT
      COUNT(*)
    FROM tbl_client_category
    WHERE IsActive = 1) AS ClientCategory,
  (SELECT
      COUNT(*)
    FROM tbl_parameters
    WHERE IsActive = 1) AS FormManage,
  (SELECT
      COUNT(*)
    FROM tbl_wf_process
    WHERE IsActive = 1) AS Process
;
END IF;
END
$$

--
-- Create procedure `sp_Get_license_parameters`
--
CREATE PROCEDURE sp_Get_license_parameters(IN p_QueryType VARCHAR(20), IN p_LicenseTypeId INT(11))
BEGIN
  IF p_QueryType ='ALL' THEN
SELECT
  tbl_parameters.FieldName,
  tbl_parameters.DataType,
  tbl_parameters.IsRequired,
  tbl_parameters.Fieldlength,
  tbl_licence_type.TypeName,
  tbl_license_parameter.ParameterId,
  tbl_license_parameter.LicenseTypeId
FROM tbl_parameters
  INNER JOIN tbl_license_parameter
    ON tbl_parameters.Id = tbl_license_parameter.ParameterId
  INNER JOIN tbl_licence_type
    ON tbl_licence_type.Id = tbl_license_parameter.LicenseTypeId
WHERE tbl_parameters.IsActive = 1
AND tbl_licence_type.IsActive = 1
AND tbl_license_parameter.IsActive = 1;

ELSEIF p_QueryType = 'ASSIGNED' THEN
SELECT
  tbl_parameters.FieldName,
  tbl_parameters.Id,
  tbl_parameters.DataType,
  tbl_parameters.IsRequired,
  tbl_parameters.Fieldlength,
  tbl_licence_type.TypeName,
  tbl_license_parameter.ParameterId,
  tbl_license_parameter.LicenseTypeId
FROM tbl_parameters
  INNER JOIN tbl_license_parameter
    ON tbl_parameters.Id = tbl_license_parameter.ParameterId
  INNER JOIN tbl_licence_type
    ON tbl_licence_type.Id = tbl_license_parameter.LicenseTypeId
WHERE tbl_license_parameter.LicenseTypeId = p_LicenseTypeId
AND tbl_parameters.IsActive = 1
AND tbl_licence_type.IsActive = 1
AND tbl_license_parameter.IsActive = 1;
END IF;
END
$$

--
-- Create procedure `sp_Get_licence_type`
--
CREATE PROCEDURE sp_Get_licence_type(IN p_QueryType VARCHAR(20), IN p_licenceTypeId INT(11))
BEGIN
	IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_licence_type
WHERE IsActive = 1
ORDER BY TypeName;

ELSEIF p_QueryType = 'LICENSETYPE' THEN
SELECT
  *
FROM tbl_licence_type
WHERE Id = p_licenceTypeId;

ELSEIF p_QueryType = 'LICENSEPARAM' THEN
SELECT
  tbl_parameters.FieldName,
  tbl_parameters.DataType,
  tbl_parameters.Id,
  tbl_parameters.IsRequired,
  tbl_parameters.Fieldlength,
  tbl_license_parameter.Id
FROM tbl_parameters
  INNER JOIN tbl_license_parameter
    ON tbl_parameters.Id = tbl_license_parameter.ParameterId
WHERE tbl_license_parameter.LicenseTypeId = p_licenceTypeId;
END IF;
END
$$

--
-- Create procedure `sp_Get_DashboardData`
--
CREATE PROCEDURE sp_Get_DashboardData(IN p_QueryType VARCHAR(50), IN p_ClientId INT(11), IN p_Id INT(11))
BEGIN
    IF p_QueryType = 'DASHBOARDLIST' THEN
SELECT
  *
FROM tbl_dashboard
WHERE IsActive = 1;

ELSEIF p_QueryType = 'ONE' THEN
SELECT
  *
FROM tbl_dashboard
WHERE Id = p_Id 
  AND IsActive = 1;

ELSEIF p_QueryType = 'GROUPWISEUSER' THEN
SELECT
  UserTypeName,
  (SELECT
      COUNT(*)
    FROM tbl_user
    WHERE UserTypeId = tbl_usertype.Id) AS UserCount
FROM tbl_usertype
WHERE tbl_usertype.IsActive = 1;

ELSEIF p_QueryType = 'REQUESTWISELICENSE' THEN
SELECT
  TypeName,
  (SELECT
      COUNT(*)
    FROM tbl_request
    WHERE LicenceTypeId = tbl_licence_type.Id) AS LicenseCount
FROM tbl_licence_type
WHERE tbl_licence_type.IsActive = 1;

ELSEIF p_QueryType = 'CLIENTWISELICENSEREQUESTCLIENT' THEN
SELECT
  Id AS ClientId,
  ClientName
FROM tbl_client
WHERE IsActive = 1;
ELSEIF p_QueryType = 'CLIENTWISELICENSEREQUEST' THEN
SELECT
  TypeName,
  (SELECT
      COUNT(*)
    FROM tbl_request
      LEFT JOIN tbl_request_status
        ON tbl_request_status.RequestId = tbl_request.Id
    WHERE LicenceTypeId = tbl_licence_type.Id
    AND ClientId = p_ClientId
    AND tbl_request_status.IsApproved = 1) AS LicenseCount
FROM tbl_licence_type
WHERE tbl_licence_type.IsActive = 1
ORDER BY TypeName;

END IF;
END
$$

--
-- Create procedure `sp_Get_ClientCategory`
--
CREATE PROCEDURE sp_Get_ClientCategory(IN p_QueryType VARCHAR(20), IN p_CategoryId INT(11))
BEGIN
  IF p_QueryType ='ALL' THEN
SELECT
  *
FROM tbl_client_category
WHERE IsActive = 1;
ELSEIF p_QueryType = 'CLIENTCATEGORY' THEN
SELECT
  *
FROM tbl_client_category
WHERE Id = p_CategoryId;
END IF;
END
$$

--
-- Create procedure `sp_Get_client`
--
CREATE PROCEDURE sp_Get_client(IN p_QueryType VARCHAR(20), IN p_ClientId INT(11))
BEGIN
	IF p_QueryType ='ALL' THEN
SELECT
  tbl_client.ClientName,
  tbl_client.ClientNumber,
  tbl_client.ClientEmail,
  tbl_client.CompanyName,
  tbl_client.CompanyAddress,
  tbl_client.CompanyNumber,
  tbl_client.CompanyEmail,
  tbl_client.GSTIN,
  tbl_client.PANNo,
  tbl_client.Id,
  tbl_client.CategoryId,
  tbl_client_category.CategoryName,
  tbl_client_category.CategoryDetails,
  tbl_client.IsActive
FROM tbl_client_category
  INNER JOIN tbl_client
    ON tbl_client_category.Id = tbl_client.CategoryId
WHERE tbl_client.IsActive = 1;
ELSEIF p_QueryType = 'CLIENT' THEN
SELECT
  tbl_client.ClientName,
  tbl_client.ClientNumber,
  tbl_client.ClientEmail,
  tbl_client.CompanyName,
  tbl_client.CompanyAddress,
  tbl_client.CompanyNumber,
  tbl_client.CompanyEmail,
  tbl_client.GSTIN,
  tbl_client.PANNo,
  tbl_client.Id,
  tbl_client.CategoryId,
  tbl_client_category.CategoryName,
  tbl_client_category.CategoryDetails,
  tbl_client.IsActive
FROM tbl_client_category
  INNER JOIN tbl_client
    ON tbl_client_category.Id = tbl_client.CategoryId
WHERE tbl_client.IsActive = 1
AND tbl_client.Id = p_ClientId;
END IF;
END
$$

DELIMITER ;

