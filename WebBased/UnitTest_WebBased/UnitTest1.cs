using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBased;
using WebBased.Models;

namespace UnitTest_WebBased
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Login()
        {
            var testlogin = new Login { user_name = "test", password = "test" };
            Assert.AreEqual("test", testlogin.user_name);
            Assert.AreEqual("test", testlogin.password);
        }

        [TestMethod]
        public void TestMethod_Lecturer()
        {
            var testlecturer = new WebBased.Models.Lecturer { first_name = "test", last_name = "test", extension = 123, qualification = "test", password = "test", email = "test@test.com", user_name = "test" };
            Assert.AreEqual("test", testlecturer.first_name);
            Assert.AreEqual("test", testlecturer.last_name);
            Assert.AreEqual(123, testlecturer.extension);
            Assert.AreEqual("test", testlecturer.password);
            Assert.AreEqual("test@test.com", testlecturer.email);
            Assert.AreEqual("test", testlecturer.user_name);
        }

        [TestMethod]
        public void TestMethod_Papers()
        {
            var testpapers = new Papers { code = "A123", paper_name = "test", category = "test", level = 0, credits = 0, lecturer_id = 0 };
            Assert.AreEqual("A123", testpapers.code);
            Assert.AreEqual("test", testpapers.paper_name);
            Assert.AreEqual("test", testpapers.category);
            Assert.AreEqual(0, testpapers.level);
            Assert.AreEqual(0, testpapers.credits);
            Assert.AreEqual(0, testpapers.lecturer_id);

        }
        [TestMethod]
        public void TestMethod_Student()
        {
            var teststudent = new Student { first_name = "test", last_name = "test", password = "test", address = "test", email = "test@test.com", phone = 1234567890, user_name = "test123" };
            Assert.AreEqual("test", teststudent.first_name);
            Assert.AreEqual("test", teststudent.last_name);
            Assert.AreEqual("test", teststudent.address);
            Assert.AreEqual("test@test.com", teststudent.email);
            Assert.AreEqual(1234567890, teststudent.phone);
            Assert.AreEqual("test123", teststudent.user_name);

        }

        [TestMethod]
        public void TestMethod_Student_Papers()
        {
            var teststudent = new Student_Papers { paper_id = 123, student_id = 123, study_year = 2015, percentage = 99, semester = 1 };
            Assert.AreEqual(123, teststudent.paper_id);
            Assert.AreEqual(123, teststudent.student_id);
            Assert.AreEqual(2015, teststudent.study_year);
            Assert.AreEqual(99, teststudent.percentage);
            Assert.AreEqual(1, teststudent.semester);

        }
    }
}
