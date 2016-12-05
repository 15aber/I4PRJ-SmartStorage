using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Controllers;
using NUnit.Framework;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Transactions
    {
        private readonly TransactionsController _tran = new TransactionsController();

        [Test]
        public void TransactionIndex_LoadTransactionIndex_ReturnsTransactionIndexView()
        {
            var result = _tran.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
