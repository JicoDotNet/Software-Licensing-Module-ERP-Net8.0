
-- TIGGER

-- tg_tbl_request_after_insert
DROP TRIGGER IF EXISTS tg_tbl_request_after_insert;
CREATE TRIGGER tg_tbl_request_after_insert
		AFTER INSERT
		ON tbl_request
		FOR EACH ROW
BEGIN
	INSERT INTO tbl_request_claim (RequestId, RequestNo,
	NextUserTypeId, ClaimUserId, ClaimDate,
	IsActive, AssignDate, TransactionDate, SessionId)
	  VALUES (NEW.Id, NEW.RequestNo, (SELECT ToUserTypeId FROM tbl_wf_process_assign WHERE WfProcessId = (SELECT Id FROM tbl_wf_process WHERE LicenceTypeId = NEW.LicenceTypeId AND IsInitial = 1) AND FromUserTypeId = NEW.UserTypeId AND StateId = 1), NULL, NULL, 1, NOW(), NOW(), NEW.SessionId);
END;


-- tg_tbl_request_acknowledgement_after_insert
DROP TRIGGER IF EXISTS tg_tbl_request_acknowledgement_after_insert;
CREATE TRIGGER tg_tbl_request_acknowledgement_after_insert
		AFTER INSERT
		ON tbl_request_acknowledgement
		FOR EACH ROW
BEGIN
	DECLARE p_NextUserTypeId int(11);

	-- UPDATE Old Row
	UPDATE tbl_request_claim
	SET IsActive = 0
	WHERE RequestId = NEW.RequestId
	AND RequestNo = NEW.RequestNo
	AND ClaimUserId = NEW.UserId
	AND NextUserTypeId = NEW.UserTypeId;


	  -- ---------------------------------------------------------------
	  -- Prepare New Row data 
	  -- if StateId == (IsPositive && !IsNegative && !IsHold)
	  -- && ProcessId == IsEnd 
	  -- then Final submit with approve
	  IF (EXISTS ( SELECT
		*
	  FROM tbl_s_state
	  WHERE IsPositive = 1
	  AND IsNegative <> 1
	  AND IsHold <> 1
	  AND Id = NEW.StateId))
	AND (EXISTS (SELECT
		WFProcessId
	  FROM tbl_wf_process_assign
	  WHERE WfProcessId IN (SELECT
		  Id
		FROM tbl_wf_process
		WHERE LicenceTypeId = (SELECT
			LicenceTypeId
		  FROM tbl_request
		  WHERE Id = NEW.RequestId)
		AND IsEnd = 1)
	  AND FromUserTypeId = NEW.UserTypeId)) THEN
	INSERT INTO tbl_request_status (RequestId, RequestNo, UserId, UserTypeId, IsApproved,
	ApproveRejectDate, Remarks, IsActive, SessionId, TransactionDate)
	  VALUES (NEW.RequestId, NEW.RequestNo, NEW.UserId, NEW.UserTypeId, 1, NOW(), NEW.Remarks, 1, NEW.SessionId, NOW());
	END IF;
	  

	  -- ---------------------------------------------------------------
	  -- if StateId == (IsNegative && !IsHold)
	  -- && ProcessId == IsEnd 
	  -- then Final submit with reject
	  IF (EXISTS ( SELECT
		*
	  FROM tbl_s_state
	  WHERE IsNegative = 1
	  AND IsHold <> 1
	  AND Id = NEW.StateId))
	AND (EXISTS (SELECT
		WFProcessId
	  FROM tbl_wf_process_assign
	  WHERE WfProcessId IN (SELECT
		  Id
		FROM tbl_wf_process
		WHERE LicenceTypeId = (SELECT
			LicenceTypeId
		  FROM tbl_request
		  WHERE Id = NEW.RequestId)
		AND IsEnd = 1)
	  AND FromUserTypeId = NEW.UserTypeId)) THEN
	INSERT INTO tbl_request_status (RequestId, RequestNo, UserId, UserTypeId, IsApproved,
	ApproveRejectDate, Remarks, IsActive, SessionId, TransactionDate)
	  VALUES (NEW.RequestId, NEW.RequestNo, NEW.UserId, NEW.UserTypeId, 1, NOW(), NEW.Remarks, 1, NEW.SessionId, NOW());
	END IF;


	-- ---------------------------------------------------------------
	-- if StateId == IsPositive || (IsNegative && IsHold)
	-- && ProcessId == (!IsEnd && !IsInitial) 
	-- Then Move to next lavel
	SELECT
	  ToUserTypeId INTO p_NextUserTypeId
	FROM tbl_wf_process_assign
	WHERE WfProcessId IN (SELECT
		Id
	  FROM tbl_wf_process
	  WHERE LicenceTypeId = (SELECT
		  LicenceTypeId
		FROM tbl_request
		WHERE Id = NEW.RequestId)
	  AND (IsInitial <> 1
	  && IsEnd <> 1))
	AND FromUserTypeId = NEW.UserTypeId
	AND StateId = NEW.StateId
	AND NEW.StateId IN (SELECT
		Id
	  FROM tbl_s_state
	  WHERE IsPositive = 1
	  OR (IsNegative = 1
	  AND IsHold = 1));

	  IF p_NextUserTypeId IS NOT NULL 
		OR p_NextUserTypeId <> 0 THEN
	-- New Row
	INSERT INTO tbl_request_claim (RequestId, RequestNo,
	NextUserTypeId, ClaimUserId, ClaimDate,
	IsActive, AssignDate, TransactionDate, SessionId)
	  VALUES (NEW.RequestId, NEW.RequestNo, p_NextUserTypeId, NULL, NULL, 1, NOW(), NOW(), NEW.SessionId);
	END IF;
END;



-- FUNCTION

-- fn_Get_UserFullName
DROP FUNCTION IF EXISTS fn_Get_UserFullName;
CREATE FUNCTION fn_Get_UserFullName(p_UserId INT)
  RETURNS varchar(255) CHARSET utf8
BEGIN
DECLARE v_FN varchar(255) DEFAULT '';
SELECT tu.FullName INTO v_FN FROM tbl_user tu WHERE tu.Id = p_UserId;

RETURN v_FN;
END;

-- fn_Get_UserTypeName
DROP FUNCTION IF EXISTS fn_Get_UserTypeName;
CREATE FUNCTION fn_Get_UserTypeName(p_UserTypeId INT)
  RETURNS varchar(255) CHARSET utf8
BEGIN
  DECLARE v_FN varchar(255) DEFAULT '';
SELECT tu.UserTypeName INTO v_FN FROM tbl_usertype tu WHERE tu.Id = p_UserTypeId;

RETURN v_FN;
END;


-- Views

-- vw_user_menu
DROP VIEW IF EXISTS vw_user_menu;
CREATE VIEW vw_user_menu
AS
SELECT
  tbl_menu_list.Id AS Id,
  tbl_menu_list.Icon AS Icon,
  tbl_menu_list.DisplayText AS DisplayText,
  tbl_menu_list.Controller AS Controller,
  tbl_menu_list.MenuGroupId AS MenuGroupId,
  tbl_menu_list.ActionResult AS ActionResult,
  tbl_menu_list.IsForAdmin AS IsForAdmin,
  tbl_menu_list.Description AS Description,
  tbl_menu_list.IsForWorkflow AS IsForWorkflow
FROM (tbl_menu_list
  JOIN tbl_usermenu
    ON ((tbl_menu_list.Id = tbl_usermenu.MenuId)));
	
	
-- Procedure







