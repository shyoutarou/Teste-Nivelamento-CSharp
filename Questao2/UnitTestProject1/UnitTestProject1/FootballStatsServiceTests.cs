using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Questao2.Domain.Entities;
using Questao2.Infrastructure.Services;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class FootballStatsServiceTests
    {
        [TestMethod]
        public async Task Test_GetTotalScoredGoals_ParisSaintGermain_2013()
        {
            // Arrange
            var teamName = "Paris Saint-Germain";
            var year = 2013;
            var expectedTotalGoals = 109;

            var mockApiClient = new Mock<IFootballStatsApiClient>();
            mockApiClient.Setup(api => api.GetMatches(teamName, year, It.IsAny<int>()))
                         .ReturnsAsync(new FootballMatchesResponse
                         {
                             Matches = new FootballMatch[]
                             {
                                 new FootballMatch { Team1 = teamName, Team1Goals = 100 },
                                 new FootballMatch { Team1 = teamName, Team1Goals = 9 },
                                 // Add more sample matches here if needed
                             },
                             TotalPages = 1, // Set the total pages accordingly
                             NextPageUrl = null,
                         });

            var footballStatsService = new FootballStatsService(mockApiClient.Object);

            // Act
            var result = await footballStatsService.GetTotalScoredGoals(teamName, year);

            // Assert
            Assert.AreEqual(expectedTotalGoals, result);
        }

        [TestMethod]
        public async Task Test_GetTotalScoredGoals_Chelsea_2014()
        {
            // Arrange
            var teamName = "Chelsea";
            var year = 2014;
            var expectedTotalGoals = 92;

            var mockApiClient = new Mock<IFootballStatsApiClient>();
            mockApiClient.Setup(api => api.GetMatches(teamName, year, It.IsAny<int>()))
                         .ReturnsAsync(new FootballMatchesResponse
                         {
                             Matches = new FootballMatch[]
                             {
                                 new FootballMatch { Team1 = teamName, Team1Goals = 90 },
                                 new FootballMatch { Team1 = teamName, Team1Goals = 2 },
                                 // Add more sample matches here if needed
                             },
                             TotalPages = 1, // Set the total pages accordingly
                             NextPageUrl = null,
                         });

            var footballStatsService = new FootballStatsService(mockApiClient.Object);

            // Act
            var result = await footballStatsService.GetTotalScoredGoals(teamName, year);

            // Assert
            Assert.AreEqual(expectedTotalGoals, result);
        }
    }
}
