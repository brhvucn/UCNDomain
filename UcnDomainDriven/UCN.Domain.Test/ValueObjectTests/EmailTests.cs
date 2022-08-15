using NUnit.Framework;
using System;
using UCN.Domain.ValueObjects;

namespace UCN.Domain.Test.ValueObjectTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEmptyEmailExpectFailure()
        {
            //arrange
            string emailAddress = "";
            //Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Email.Create(emailAddress);
            });
        }

        [Test]
        public void TestNullEmailExpectFailure()
        {
            //arrange
            string emailAddress = null;
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Email.Create(emailAddress);
            });
        }

        [Test]
        public void TestInvalidEmailNoAatSignExpectFailure()
        {
            //arrange
            string emailAddress = "myemail.com";
            //Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Email.Create(emailAddress);
            });
        }

        [Test]
        public void TestInvalidEmailNoPunctuationSignExpectFailure()
        {
            //arrange
            string emailAddress = "my@email";
            //Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Email.Create(emailAddress);
            });
        }

        [Test]
        public void TestInvalidEmailNoPunctuationOrAatSignExpectFailure()
        {
            //arrange
            string emailAddress = "email";
            //Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Email.Create(emailAddress);
            });
        }

        [Test]
        public void TestInvalidEmailNoTextBEforeAatSignExpectFailure()
        {
            //arrange
            string emailAddress = "@email.com";
            //Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Email.Create(emailAddress);
            });
        }

        [Test]
        public void TestValidEmailExpectSuccess()
        {
            //arrange
            string emailAddress = "my@email.com";
            //Act
            Email email = Email.Create(emailAddress);
            //Assert            
            Assert.That(emailAddress, Is.EqualTo(email.Value));
        }
    }
}