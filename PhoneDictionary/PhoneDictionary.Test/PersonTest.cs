using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Castle.Core.Resource;
using FluentAssertions;
using Moq;
using PhoneDictionary._Business.Services;
using PhoneDictionary.DataAccess.Repository;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneDictionary.Test
{
    public class PersonTest
    {

        private IPhoneDictionaryService _service;
        public PersonTest()
        {
            _service = new PhoneDictionaryService();
        }

        [Fact]
        public void PhoneDictionaryService_GetPersonIdWithInvalidArguments_ThrowsException()
        {
            //arrange
            int id = default(int);
            // act & assert
            Assert.Throws<Exception>(() => _service.GetPersonById(id));
        }

        [Fact]
        public void PhoneDictionaryService_DeleteInvalidArguments_ThrowsException()
        {
            //arrange
            int id = default(int);
            // act & assert
            Assert.Throws<Exception>(() => _service.DeletePerson(id));
        }

        [Fact]
        public void GetPersons_ShouldReturnLists()
        {
            // Arrange
            var service = new PhoneDictionaryService();

            // Act
            var contacts = service.GetAllPerson();

            // Assert
            Assert.NotNull(contacts);
        }

    }

  
}
