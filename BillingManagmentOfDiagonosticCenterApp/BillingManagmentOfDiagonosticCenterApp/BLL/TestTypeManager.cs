﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingManagmentOfDiagonosticCenterApp.DAL;
using BillingManagmentOfDiagonosticCenterApp.Model;
using BillingManagmentOfDiagonosticCenterApp.Model.ViewModels;

namespace BillingManagmentOfDiagonosticCenterApp.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway _testTypeGateway=new TestTypeGateway();

        public int Save(TestType testType)
        {
            return _testTypeGateway.Save(testType);
        }
        public List<TestType> GetAllTypesList()
        {
            return _testTypeGateway.GetAllTypesList();
        }

        public bool IsTestTypeExist(TestType testType)
        {
            return _testTypeGateway.IsTestTypeExist(testType);
        }

        public List<ViewTypeWithTotalTest> GetTypeReportByDate(DateTime lowerDate, DateTime upperDate)
        {
            return _testTypeGateway.GetTypeReportByDate(lowerDate, upperDate);
        }
    }
}