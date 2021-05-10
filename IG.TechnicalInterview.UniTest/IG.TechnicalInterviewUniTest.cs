using IG.TechnicalInterview.Model.Supplier;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace IG.TechnicalInterview.UniTest
{
    [TestFixture]
    public class TechnicalInterviewUniTest
    {
        [Test]
        public void GetSupplier_IsActionvationDateIsFreaterThanToday_ReturnTrue()
        {
            //Arrange
            var supplier = new Supplier();

            //Act
            supplier = new Supplier { Title = "Mr", FirstName = "Kyaw", LastName = "Htay", ActivationDate = DateTime.Now.AddDays(-1) };

            //Assert
            Assert.IsTrue(ValidateModel(supplier).Any(v => v.MemberNames.Contains("ActivationDate") &&
            v.ErrorMessage.Contains("Date must be after today date")));

        }
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
