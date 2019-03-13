using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using AccountOwnerServer;
using Newtonsoft.Json;
using Entities.Models;

namespace Integration
{
    public class IntegrationTests
    {
        private readonly TestContext _context;

        public IntegrationTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public async Task GetAllOwners_ReturnsOkResponse()
        {
            // Act
            var response = await _context.Client.GetAsync("/api/owner");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllOwners_ReturnsAListOfOwners()
        {
            // Act
            var response = await _context.Client.GetAsync("/api/owner");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var owners = JsonConvert.DeserializeObject<List<Owner>>(responseString);
    
            // Assert
            Assert.Empty(owners);
        }
    }
}
