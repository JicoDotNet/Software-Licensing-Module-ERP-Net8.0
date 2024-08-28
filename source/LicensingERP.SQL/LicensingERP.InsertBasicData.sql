INSERT INTO tbl_dashboard (PartialViewName, Description, SortOrder, DivCssClass, IsActive, SessionId, TransactionDate) VALUES
('GroupWiseUser', 'Group Wise User Graph using Bar Chart', 2, 'col-md-4', 1, 'DEVELOPER', NOW()),
('Master', 'Master Data Count Value', 1, 'col-md-12', 1, 'DEVELOPER', NOW()),
('LicenseRequest', 'License wise Request Graph', 3, 'col-md-4', 1, 'DEVELOPER', NOW()),
('ClientWiseLicenseRequest', 'Client Wise Approved License Request Graph', 4, 'col-md-4', 1, 'DEVELOPER', NOW());

INSERT INTO tbl_menu_group(Icon, DisplayText, IsActive, IsDisplayable, TransactionDate, SessionId) VALUES
('fa fa-user', 'User Management', 1, True, NOW(), 'DEVELOPER'),
('fas fa-hourglass', 'Workflow Authoring', 1, True, NOW(), 'DEVELOPER'),
('fab fa-buromobelexperte', 'Master', 1, True, NOW(), 'DEVELOPER'),
('fas fa-satellite-dish', 'Requisition', 1, True, NOW(), 'DEVELOPER'),
('fas fa-chart-bar', 'MIS User Report', 1, True, NOW(), 'DEVELOPER'),
('fas fa-chart-pie', 'MIS License Report', 1, True, NOW(), 'DEVELOPER');

INSERT INTO tbl_menu_list(MenuGroupId, Icon, DisplayText, Controller, ActionResult, HasRouteId, RouteId, QueryString, HttpType, IsReport, IsActive, IsDisplayable, IsForAdmin, Description, TransactionDate, SessionId, IsForWorkflow) VALUES
(1, 'fa fa-bezier-curve', 'User Permission', 'User', 'Permission', NULL, NULL, NULL, 'HttpGet', False, True, True, True, 'user permissions are assigned here', NOW(), 'DEVELOPER', False),
(1, 'fas fa-broadcast-tower', 'Password Change Request', 'User', 'PasswordChangeRequest', NULL, NULL, NULL, 'HttpGet', False, True, True, False, NULL, NOW(), 'DEVELOPER', False),
(2, 'far fa-circle nav-icon', 'Process', 'Workflow', 'Index', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Get different type of Process and add new Process', NOW(), 'DEVELOPER', False),
(2, 'far fa-circle nav-icon', 'Assign', 'Workflow', 'Assign', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Assign different process into different user', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'User Group', 'User', 'Type', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'User Group List', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'User', 'User', 'Index', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'User page list', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'License Type', 'License', 'Index', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'License type List', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'Client Category', 'Client', 'Category', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Client Category add', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'Client', 'Client', 'Index', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Client add page', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'Product', 'Product', 'Index', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Product Add page', NOW(), 'DEVELOPER', False),
(3, 'far fa-circle', 'Parameter Master', 'Form', 'Manage', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Parameter Manage', NOW(), 'DEVELOPER', False),
(3, 'fas fa-link', 'License Parameter Map', 'License', 'Parameter', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Parameter Link page ', NOW(), 'DEVELOPER', False),
(4, 'far fa-circle', 'New Request', 'Requisition', 'Status', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Licence Request For Requisition', NOW(), 'DEVELOPER', False),
(4, 'far fa-circle', 'Approval Pending', 'Requisition', 'Pending', NULL, NULL, NULL, 'HttpGet', False, True, True, False, 'Requisition Approval screen', NOW(), 'DEVELOPER', False),
(5, 'far fa-circle', 'User Report', 'MISUser', 'UserReport', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'User Report Menu', NOW(), 'DEVELOPER', False),
(5, 'far fa-circle', 'Activity', 'MISUser', 'Activity', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'User Activity Report', NOW(), 'DEVELOPER', False),
(5, 'far fa-circle', 'Login Report', 'MISUser', 'Login', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'User Login Report', NOW(), 'DEVELOPER', False),
(5, 'far fa-circle', 'Maker Checker Report', 'MISUser', 'MakerCheckerReport', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'Maker Checker Report Details', NOW(), 'DEVELOPER', False),
(6, 'far fa-circle', 'License Report', 'MISLicense', 'Requests', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'Report  license requests', NOW(), 'DEVELOPER', False),
(6, 'far fa-circle', 'Request Movement', 'MISLicense', 'RequestMovement', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'Request Movement Details', NOW(), 'DEVELOPER', False),
(6, 'far fa-circle', 'Status Report', 'MISLicense', 'Status', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'License status Report', NOW(), 'DEVELOPER', False),
(6, 'far fa-circle', 'Turnaround Time', 'MISLicense', 'TAT', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'License Turnaround Time Reports ', NOW(), 'DEVELOPER', False),
(6, 'far fa-circle', 'XML Download', 'MISLicense', 'XMLDownload', NULL, NULL, NULL, 'HttpGet', True, True, True, False, 'XML Download Report', NOW(), 'DEVELOPER', False);

INSERT INTO tbl_password (UserId, PasswordHash, IsActive, ActivationDate, PasswordSalt, SessionId, TransactionDate, PasswordText, IsChangeable)
VALUES  (1, 'E5zMwlEFWgE=', 1, NOW(),  'nCepJIH7bmBvjDjUeApq/CTv11EnhJDJ', 'DEVELOPER', NOW(), null, False);

INSERT INTO tbl_s_state(Name, IsPositive, IsNegative, IsHold, SessionId, IsActive, TransactionDate) VALUES
('Approved', True, False, False, 'DEVELOPER', True, NOW()),
('Rejected', False, True, False, 'DEVELOPER', True, NOW()),
('RevertBack', False, True, True, 'DEVELOPER', True, NOW()),
('OnHold', False, False, True, 'DEVELOPER', False, NOW());

INSERT INTO tbl_user (UserTypeId, FullName, UserName, Email, Mobile, Address, Designation, IsActive, SessionId, TransactionDate) 
VALUES  (1, 'Company Admin', 'admin', 'admin@admin.com',  '9999999999', 'Kolkata, India', null, 1, 'DEVELOPER', NOW());


INSERT INTO tbl_usermenu (MenuId, UserId, UserTypeId, IsActive, SessionId, TransactionDate)
VALUES  (1, 1, 1, 1, 'DEVELOPER', NOW());


INSERT INTO tbl_usertype (UserTypeName, UserTypeDetails, IsActive, TransactionDate, SessionId) 
VALUES ('Super Admin', 'Super Admin', 1, NOW(), 'DEVELOPER');
