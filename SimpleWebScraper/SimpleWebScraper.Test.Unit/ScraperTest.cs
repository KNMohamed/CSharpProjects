using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System.Text.RegularExpressions;

namespace SimpleWebScraper.Test.Unit
{
    [TestClass]
    public class ScraperTest
    {

        private readonly Scraper _scraper = new Scraper();

        [TestMethod]
        public void FindCollectionWithNoParts()
        {
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)<\/a>")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .Build();

            var foundElemnts = _scraper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElemnts.Count == 1);
            Assert.IsTrue(foundElemnts[0] == "<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a>");
        }

        [TestMethod]
        public void FindCollectionWithTwoParts()
        {
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)<\/a>")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .WithParts(new ScrapeCriteriaPartBuilder()                  //Grabs the description
                    .WithRegex(@">(.*?)</a>")
                    .WithRegexOptions(RegexOptions.Singleline)
                    .Build())
                .WithParts(new ScrapeCriteriaPartBuilder()                  //Grabs the Link
                    .WithRegex(@"href=\""(.*?)\""")
                    .WithRegexOptions(RegexOptions.Singleline)
                    .Build())
                .Build();

            var foundElements = _scraper.Scrape(scrapeCriteria);

            Assert.IsTrue(foundElements.Count == 2);
            Assert.IsTrue(foundElements[0] == "some text");
            Assert.IsTrue(foundElements[1] == "http://domain.com");
        }
    }
}
