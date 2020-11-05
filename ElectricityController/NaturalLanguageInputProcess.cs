using System.Text.RegularExpressions;
using System;
namespace EnergyManagement
{
    public class NaturalLanguageInputProcess : IInputProcess
    {
        public (int floorNumber, int corridorNumber, bool hasMovement) parseInput(string input)
        {
            var pattern = new System.Text.RegularExpressions.Regex(@"(No Movement|Movement) in Floor (\d+), Sub corridor (\d+)", RegexOptions.IgnoreCase);
            MatchCollection matches = pattern.Matches(input);
            if(matches.Count < 1)
                throw new ArgumentException("input string is not valid");
            return
            (
                Int32.Parse(matches[0].Groups[2].Value),
                Int32.Parse(matches[0].Groups[3].Value),
                !String.Equals(matches[0].Groups[1].Value, "No Movement", StringComparison.OrdinalIgnoreCase)
            );
        }   
    }
}