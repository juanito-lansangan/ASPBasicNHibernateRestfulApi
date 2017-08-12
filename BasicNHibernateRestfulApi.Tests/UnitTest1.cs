using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using System.Linq;
using BasicNHibernateRestfulApi.Models;
using NHibernate;


namespace BasicNHibernateRestfulApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Configuration config = new Configuration();
            config.Configure();
            
            ISessionFactory factory = config.BuildSessionFactory();
            ISession session = factory.OpenSession();


            session.Close();
            
          
        }
    }
}
