using GuildCars.Data.Interfaces;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Data.Repos
{
    public class MockSpecialRepo : ISpecialRepo
    {
        private static List<Special> _specials;

        static MockSpecialRepo()
        {
            _specials = new List<Special>()
            {
                new Special
                {
                SpecialID = 1,
                SpecialName = "Close, But No Car",
                SpecialDescription = "Lorem ipsum dolor sit amet, et pharetra, duis hendrerit morbi consectetuer amet. Integer maecenas suspendisse faucibus, mauris feugiat nec quam, nulla in, tellus vestibulum feugiat. Pede elit vel suspendisse pulvinar eget luctus, litora eu enim integer tellus elit eget. Libero velit netus, integer eu, nam adipiscing vitae arcu. Vitae odio vel vivamus ultricies lacinia, pharetra elit nulla sit pede non vitae, a amet ut pede. Molestie duis proin consectetuer ut."
                },

                 new Special
                 {
                     SpecialID = 2,
                     SpecialName = "Tooth and Sale",
                     SpecialDescription = "Lorem ipsum dolor sit amet, vitae wisi, gravida pharetra. Erat eu wisi amet mauris quisque. Class est consectetuer, orci ac nunc magna ut, metus et amet vitae, nunc purus phasellus imperdiet lectus, tempus ac lectus proin ante id nam. Vestibulum vel ut enim fringilla, pretium ut volutpat ut morbi, natus in ipsum urna volutpat tellus orci, erat eget, morbi nec eros et massa elit vitae. Venenatis class, praesent vel."
                 },

                 new Special
                 {
                     SpecialID = 3,
                     SpecialName = "Let Your Car Down",
                     SpecialDescription = "Lorem ipsum dolor sit amet, felis turpis, viverra eu, nulla vitae eget, risus pellentesque euismod non id ut, dapibus a nec elit. Nibh nulla fringilla adipiscing est proin, amet in et, mi duis tellus amet erat scelerisque nullam, arcu in egestas fusce nam non. Id feugiat vel lorem dolor. Vestibulum quis tempor hendrerit. Tortor ac vestibulum id, sed a mattis penatibus nascetur libero inceptos. Cursus tempor."
                 },

                 new Special
                 {
                     SpecialID = 4,
                     SpecialName = "Grimm's Fairy Sales",
                     SpecialDescription = "Lorem ipsum dolor sit amet, ipsum velit cursus malesuada, tortor ipsum arcu sed lectus nisl diam, ut fugiat amet scelerisque semper justo adipiscing. Nunc diam lectus sem pede aenean, a maecenas vivamus massa ut sit, natoque mauris nunc eget. Dui pede integer quam eligendi, aliquam ipsum dolor vestibulum orci, a pede velit amet, accumsan massa, maecenas fusce. Fringilla tortor id suscipit aliquam eu, mattis est bibendum et cursus volutpat diam, vitae sapien in rhoncus mauris, fugiat id nunc bibendum ante ante nulla. Integer odio euismod, orci integer a dictumst, massa vitae libero morbi, amet ligula aenean volutpat tortor, posuere suspendisse."
                 }

            };


        }

        public Special Create(Special newSpecial)
        {
            if (_specials.Any())
            {
                newSpecial.SpecialID = _specials.Max(c => c.SpecialID) + 1;
            }
            else
            {
                newSpecial.SpecialID = 0;
            }

            _specials.Add(newSpecial);
            return newSpecial;
        }

        public void Delete(int id)
        {
            _specials.RemoveAll(c => c.SpecialID == id);
        }

        public IEnumerable<Special> Get()
        {
            return _specials;
        }

        public Special GetById(int id)
        {
            return _specials.FirstOrDefault(c => c.SpecialID == id);
        }
    }
}