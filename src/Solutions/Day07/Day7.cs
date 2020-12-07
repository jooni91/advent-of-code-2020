using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Models;

using static AdventOfCode2020.Utilities.InputLoader;

namespace AdventOfCode2020.Solutions.Day07
{
    public class Day7 : DayBase
    {
        private readonly HashSet<Bag> bags = new HashSet<Bag>();
        private readonly HashSet<BagContentRule> rules = new HashSet<BagContentRule>();

        protected override string Day => "07";

        protected override string PartOne(string input)
        {
            ParseBagsAndContentRules(input.ReadInputLines());

            return CountContainersForBagColor("shiny gold").ToString();
        }

        protected override string PartTwo(string input)
        {
            ParseBagsAndContentRules(input.ReadInputLines());

            return CountBagsInsideBagForBagColor("shiny gold").ToString();
        }

        #region Parsing Methods
        private void ParseBagsAndContentRules(IEnumerable<string> inputLines)
        {
            foreach(var input in inputLines)
            {
                var bag = FindOrAddBag(GetBagName(input));

                foreach (var rule in ParseContentRules(input, bag.BagId))
                {
                    rules.Add(rule);
                }
            }
        }
        private string GetBagName(string input)
        {
            return input.Substring(0, input.IndexOf(" bags"));
        }
        private IEnumerable<BagContentRule> ParseContentRules(string input, int containerId)
        {
            input = input.Remove(0, input.IndexOf("contain") + 8);

            foreach(var rule in input.Split(',', StringSplitOptions.TrimEntries))
            {
                var ruleSplitted = rule.Split(' ');

                if (ruleSplitted[0] == "no")
                {
                    yield break;
                }

                yield return new BagContentRule(containerId, FindOrAddBag($"{ruleSplitted[1]} {ruleSplitted[2]}").BagId, int.Parse(ruleSplitted[0]));
            }
        }
        private Bag FindOrAddBag(string bagName)
        {
            var bag = new Bag(bagName);

            bags.Add(bag);

            return bag;
        }
        #endregion

        #region Processing Methods
        private int CountContainersForBagColor(string bagColor, HashSet<int>? countedBags = null)
        {
            if (countedBags == null)
            {
                countedBags = new HashSet<int>();
            }

            var containerCount = 0;

            foreach(var rule in rules.Where(r => r.contentId == bagColor.GetHashCode()))
            {
                if (countedBags.Add(rule.containerId))
                {
                    containerCount++;
                }

                containerCount += CountContainersForBagColor(bags.First(bag => bag.BagId == rule.containerId).BagName, countedBags);
            }

            return containerCount;
        }
        private int CountBagsInsideBagForBagColor(string bagColor)
        {
            var containerTotalCount = 0;

            foreach (var rule in rules.Where(r => r.containerId == bagColor.GetHashCode()))
            {
                var totalCount = CountBagsInsideBagForBagColor(bags.First(bag => bag.BagId == rule.contentId).BagName);

                containerTotalCount += rule.Quantity;
                containerTotalCount += rule.Quantity * totalCount;
            }

            return containerTotalCount;
        }
        #endregion
    }
}
