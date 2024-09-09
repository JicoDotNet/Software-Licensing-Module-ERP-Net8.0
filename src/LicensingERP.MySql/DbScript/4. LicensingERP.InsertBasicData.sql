INSERT INTO tbl_dashboard (PartialViewName, Description, SortOrder, DivCssClass, IsActive, SessionId, TransactionDate) VALUES
('GroupWiseUser', 'Group Wise User Graph using Bar Chart', 2, 'col-md-4', 1, 'DEVELOPER', NOW()),
('Master', 'Master Data Count Value', 1, 'col-md-12', 1, 'DEVELOPER', NOW()),
('LicenseRequest', 'License wise Request Graph', 3, 'col-md-4', 1, 'DEVELOPER', NOW()),
('ClientWiseLicenseRequest', 'Client Wise Approved License Request Graph', 4, 'col-md-4', 1, 'DEVELOPER', NOW());

INSERT INTO tbl_menu_group(Icon, DisplayText) VALUES
('fa fa-user', 'User Management'),
('fas fa-hourglass', 'Workflow Authoring'),
('fab fa-buromobelexperte', 'Master'),
('fas fa-satellite-dish', 'Requisition'),
('fas fa-chart-bar', 'MIS User Report'),
('fas fa-chart-pie', 'MIS License Report');

INSERT INTO tbl_menu_list(MenuGroupId, Icon, DisplayText, Controller, ActionResult, IsReport, IsForAdmin, Description, IsForWorkflow) VALUES
(1, 'fa fa-bezier-curve', 'User Permission', 'User', 'Permission', False, True, 'user permissions are assigned here', False),
(1, 'fas fa-broadcast-tower', 'Password Change Request', 'User', 'PasswordChangeRequest', False, False, NULL, False),
(2, 'far fa-circle nav-icon', 'Process', 'Workflow', 'Index', False, False, 'Get different type of Process and add new Process', False),
(2, 'far fa-circle nav-icon', 'Assign', 'Workflow', 'Assign', False, False, 'Assign different process into different user', False),
(3, 'far fa-circle', 'User Group', 'User', 'Type', False, False, 'User Group List', False),
(3, 'far fa-circle', 'User', 'User', 'Index', False, False, 'User page list', False),
(3, 'far fa-circle', 'License Type', 'License', 'Index', False, False, 'License type List', False),
(3, 'far fa-circle', 'Client Category', 'Client', 'Category', False, False, 'Client Category add', False),
(3, 'far fa-circle', 'Client', 'Client', 'Index', False, False, 'Client add page', False),
(3, 'far fa-circle', 'Product', 'Product', 'Index', False, False, 'Product Add page', False),
(3, 'far fa-circle', 'Parameter Master', 'Form', 'Manage', False, False, 'Parameter Manage', False),
(3, 'fas fa-link', 'License Parameter Map', 'License', 'Parameter', False, False, 'Parameter Link page ', False),
(4, 'far fa-circle', 'New Request', 'Requisition', 'Status', False, False, 'Licence Request For Requisition', False),
(4, 'far fa-circle', 'Approval Pending', 'Requisition', 'Pending', False, False, 'Requisition Approval screen', False),
(5, 'far fa-circle', 'User Report', 'MISUser', 'UserReport', True, False, 'User Report Menu', False),
(5, 'far fa-circle', 'Activity', 'MISUser', 'Activity', True, False, 'User Activity Report', False),
(5, 'far fa-circle', 'Login Report', 'MISUser', 'Login', True, False, 'User Login Report', False),
(5, 'far fa-circle', 'Maker Checker Report', 'MISUser', 'MakerCheckerReport', True, False, 'Maker Checker Report Details', False),
(6, 'far fa-circle', 'License Report', 'MISLicense', 'Requests', True, False, 'Report  license requests', False),
(6, 'far fa-circle', 'Request Movement', 'MISLicense', 'RequestMovement', True, False, 'Request Movement Details', False),
(6, 'far fa-circle', 'Status Report', 'MISLicense', 'Status', True, False, 'License status Report', False),
(6, 'far fa-circle', 'Turnaround Time', 'MISLicense', 'TAT', True, False, 'License Turnaround Time Reports ', False),
(6, 'far fa-circle', 'XML Download', 'MISLicense', 'XMLDownload', True, False, 'XML Download Report', False);

INSERT INTO tbl_password (UserId, PasswordHash, IsActive, ActivationDate, PasswordSalt, SessionId, TransactionDate, PasswordText, IsChangeable)
VALUES  (1, 'E5zMwlEFWgE=', 1, NOW(),  'nCepJIH7bmBvjDjUeApq/CTv11EnhJDJ', 'DEVELOPER', NOW(), null, False);

INSERT INTO tbl_s_state(Name, IsPositive, IsNegative, IsHold, SessionId, IsActive, TransactionDate) VALUES
('Approved', True, False, False, 'DEVELOPER', True, NOW()),
('Rejected', False, True, False, 'DEVELOPER', True, NOW()),
('RevertBack', False, True, True, 'DEVELOPER', True, NOW()),
('OnHold', False, False, True, 'DEVELOPER', False, NOW());

INSERT INTO tbl_user (UserTypeId, FullName, UserName, Email, Mobile, Address, Designation, IsActive, SessionId, TransactionDate) 
VALUES  (1, 'Company Admin', 'admin', 'admin@admin.com',  '9999999999', 'Bangalore, India', null, 1, 'DEVELOPER', NOW());


INSERT INTO tbl_usermenu (MenuId, UserId, UserTypeId, IsActive, SessionId, TransactionDate)
VALUES  (1, 1, 1, 1, 'DEVELOPER', NOW());


INSERT INTO tbl_usertype (UserTypeName, UserTypeDetails, IsActive, TransactionDate, SessionId) 
VALUES ('Super Admin', 'Super Admin', 1, NOW(), 'DEVELOPER');
