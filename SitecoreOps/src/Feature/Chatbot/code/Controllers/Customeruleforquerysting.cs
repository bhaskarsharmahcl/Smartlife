using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habitat.Feature.Chatbot.Controllers
{
    public class QueryStringCondition<T> : StringOperatorCondition<T> where T : RuleContext
    {
        //Properties
        public string QueryStringName { get; set; }
        public string QueryStringValue { get; set; }

        //Methods
        protected override bool Execute(T ruleContext)
        {
            bool ReturnValue = false;
            bool FoundExactMatch = false;
            bool FoundCaseInsensitiveMatch = false;
            bool FoundContains = false;
            bool FoundStartsWith = false;
            bool FoundEndsWith = false;

            Assert.ArgumentNotNull(ruleContext, "ruleContext");

            string myQueryStringName = this.QueryStringName ?? string.Empty;
            string myQueryStringValue = this.QueryStringValue ?? string.Empty; //Populated with Value selected in Sitecore Rule by Content Author

            if (!string.IsNullOrWhiteSpace(myQueryStringName))
            {
                if (HttpContext.Current != null)
                {
                    //Populated with QueryString coming into current Page
                    string incomingQueryStringValue = HttpContext.Current.Request.QueryString[myQueryStringName] ?? string.Empty;

                    if (incomingQueryStringValue == myQueryStringValue)
                    {
                        //Indicates that QueryString coming into Page is equal to QueryString selected by Content Author
                        FoundExactMatch = true;
                        FoundCaseInsensitiveMatch = true;
                        FoundContains = true;
                        FoundStartsWith = true;
                        FoundEndsWith = true;
                    }
                    else if (incomingQueryStringValue.ToLower() == myQueryStringValue.ToLower())
                    {
                        //Indicates that QueryString coming into Page has case-insensitive match to QueryString selected by Content Author
                        FoundCaseInsensitiveMatch = true;
                        //Check other "Found" variables that are not inherently true
                        if (incomingQueryStringValue.Contains(myQueryStringValue))
                        {
                            FoundContains = true;
                        }
                        if (incomingQueryStringValue.StartsWith(myQueryStringValue))
                        {
                            FoundStartsWith = true;
                        }
                        if (incomingQueryStringValue.EndsWith(myQueryStringValue))
                        {
                            FoundEndsWith = true;
                        }
                    }
                    else if (incomingQueryStringValue.Contains(myQueryStringValue))
                    {
                        //Indicates that QueryString coming into Page contains QueryString selected by Content Author
                        FoundContains = true;
                        //Check other "Found" variables that are not inherently true
                        if (incomingQueryStringValue.StartsWith(myQueryStringValue))
                        {
                            FoundStartsWith = true;
                        }
                        if (incomingQueryStringValue.EndsWith(myQueryStringValue))
                        {
                            FoundEndsWith = true;
                        }
                    }
                }
            }

            switch (base.GetOperator())
            {
                case StringConditionOperator.Equals:
                    ReturnValue = FoundExactMatch;
                    break;
                case StringConditionOperator.NotEqual:
                    ReturnValue = !FoundExactMatch;
                    break;
                case StringConditionOperator.CaseInsensitivelyEquals:
                    ReturnValue = FoundCaseInsensitiveMatch;
                    break;
                case StringConditionOperator.NotCaseInsensitivelyEquals:
                    ReturnValue = !FoundCaseInsensitiveMatch;
                    break;
                case StringConditionOperator.Contains:
                    ReturnValue = FoundContains;
                    break;
                case StringConditionOperator.StartsWith:
                    ReturnValue = FoundStartsWith;
                    break;
                case StringConditionOperator.EndsWith:
                    ReturnValue = FoundEndsWith;
                    break;
                default:
                    ReturnValue = false;
                    break;
            }

            return ReturnValue;
        }
    }
    public class Customeruleforquerysting
    {
    }
}