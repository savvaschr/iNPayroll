
delete  from PrMsTemplateGroup where TemGrp_Code ='2001'

delete  from PrMstemplateearnings where TemGrp_Code ='2001'
delete  from PrMstemplatecontributions where TemGrp_Code ='2001'
delete  from PrMstemplatedeductions where TemGrp_Code ='2001'

delete  from PrMsemployeeearnings where TemGrp_Code ='2001'
delete  from PrMsemployeedeductions where TemGrp_Code ='2001'
delete  from PrMsemployeecontributions where TemGrp_Code ='2001'

delete  from PrMsemployees where TemGrp_Code ='2001'
delete  from Prtxemployeesalary where emp_code in
(select emp_code  from PrMsemployees where TemGrp_Code ='2001')

delete  from Prtxemployeediscounts where emp_code in
(select emp_code  from PrMsemployees where TemGrp_Code ='2001')

delete  from PrMsemployees where TemGrp_Code ='2001'

delete  from PrMsPeriodGroups where TemGrp_Code ='2001'
delete  from PrMsPeriodcodes where PrdGrp_Code  ='201402'
delete  from PrMsPeriodEarnings where PrdGrp_Code  ='201402'
delete  from PrMsPerioddeductions where PrdGrp_Code  ='201402'
delete  from PrMsPeriodContributions where PrdGrp_Code  ='201402'


