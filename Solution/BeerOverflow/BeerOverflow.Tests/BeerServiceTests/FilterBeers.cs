using BeerOverflow.Data;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.BeerServiceTests
{
    [TestClass]
    public class FilterBeers
    {
        [TestMethod]
        public void FilterBeers_CorrectFilter()
        {
            var options = Utils.GetOptions(nameof(FilterBeers_CorrectFilter));

            using (var arrangeContext = Utils.GetContextWithData(nameof(FilterBeers_CorrectFilter)))
            {
                string type = "Lager";
                var sut = new BeerService(arrangeContext);
                var result = sut.FilterBeers(type, null).First();

                Assert.AreEqual(type, result.BeerType);

            }

        }
    }
}

//public IEnumerable<BeerDTO> FilterBeers(string type, string orderby)
//{
//    var qryBeers = (IQueryable<Beer>)_beerOverflowContext.Beers;

//    if (type != null)
//    {
//        var _type = _beerOverflowContext.BeerTypes.FirstOrDefault(t => t.Type == type);
//        if (_type != null)
//        {
//            qryBeers = qryBeers.Where(b => b.BeerTypeId == _type.Id);
//        }
//    }

//    if (orderby != null)
//    {
//        var orderClauses = orderby.ToLower().Split(",");
//        for (int i = 0; i < orderClauses.Length; i++)
//        {
//            var orderPropArr = orderClauses[i].Split(" ");
//            var orderProp = orderPropArr[0].Trim();
//            switch (orderProp)
//            {
//                case "name":
//                    if (!orderClauses[i].EndsWith(" desc"))
//                        qryBeers = i == 0 ? qryBeers.OrderBy(b => b.BeerName)
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.BeerName);
//                    else
//                    {
//                        qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.BeerName)
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.BeerName);
//                    }
//                    break;
//                case "abv":
//                    if (!orderClauses[i].EndsWith(" desc"))
//                        qryBeers = i == 0 ? qryBeers.OrderBy(b => b.AlcByVol)
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.AlcByVol);
//                    else
//                    {
//                        qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.AlcByVol)
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.AlcByVol);
//                    }
//                    break;

//                case "brewery":
//                    if (!orderClauses[i].EndsWith(" desc"))
//                        qryBeers = i == 0 ? qryBeers.OrderBy(b => b.Brewery)
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.Brewery);
//                    else
//                    {
//                        qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.Brewery)
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.Brewery);
//                    }
//                    break;
//                case "rating":
//                    if (!orderClauses[i].EndsWith(" desc"))
//                        qryBeers = i == 0 ? qryBeers.OrderBy(b => b.Reviews.Average(r => r.Rating))
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.Reviews.Average(r => r.Rating));
//                    else
//                    {
//                        qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.Reviews.Average(r => r.Rating))
//                            : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.Reviews.Average(r => r.Rating));
//                    }
//                    break;
//                default:
//                    break;
//            }
//        }
//    }

//    var beersDTO = qryBeers
//            .Select(b => new BeerDTO(b.Id, b.BeerName, b.BeerTypeId,
//            b.BeerType.Type, b.BreweryId, b.Brewery.Name,
//            b.AlcByVol, b.Description, b.Reviews.Average(r => r.Rating))).ToList();

//    return beersDTO;
//}