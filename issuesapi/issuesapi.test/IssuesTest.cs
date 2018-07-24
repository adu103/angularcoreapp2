using System;
using Xunit;
using issuesapi.Models;

namespace issuesapi.models.test
{
    public class IssuesTest
    {
        [Fact]
        public void IssuesPropertiesTest()
        {
            const int test_id = 2;
            const string test_title = "Unit Test 1";
            const string test_responsible = "Jon Hamm";
            const string test_description = "First unit test of the issues properties.";
            const string test_severity = "High";
            const string test_status = "In Progress";



            var issues = new Issues
            {
                Id = test_id,
                title = test_title,
                responsible = test_responsible,
                description = test_description,
                severity = test_severity,
                status = test_status
            };

            Assert.Equal(test_id, issues.Id);
            Assert.Equal(test_title, issues.title);
            Assert.Equal(test_responsible, issues.responsible);
            Assert.Equal(test_description, issues.description);
            Assert.Equal(test_severity, issues.severity);
            Assert.Equal(test_status, issues.status);
        }
    }
}
