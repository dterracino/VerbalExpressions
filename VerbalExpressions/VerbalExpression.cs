﻿using System;
using System.Text.RegularExpressions;

namespace VerbalExpressions
{
    public class VerbalExpression
    {
        private string _regex;

        public VerbalExpression()
        {
            _regex = "";
        }

        public VerbalExpression StartOfLine()
        {
            _regex = "^";
            return this;
        }

        public VerbalExpression Then(string match)
        {
            _regex = _regex + match;
            return this;
        }

        public VerbalExpression Anything()
        {
            _regex = _regex + "(.|\n)*";
            return this;
        }

        public VerbalExpression AnythingBut(string stringToExclude)
        {
            _regex = _regex + string.Format("(?!{0})(.|\n)*", stringToExclude);
            return this;
        }

        public VerbalExpression Maybe(string optionalPart)
        {
            _regex = _regex + string.Format("({0})?", optionalPart);
            return this;
        }

        public VerbalExpression EndOfLine()
        {
            _regex = _regex + "$";
            return this;
        }

        public Boolean Test(string stringToTest)
        {
            var regex = new Regex(_regex);
            var match = regex.Match(stringToTest);
            return match.Success;
        }
    }
}
