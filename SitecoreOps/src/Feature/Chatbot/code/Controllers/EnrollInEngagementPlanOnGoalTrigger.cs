using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habitat.Feature.Chatbot.Controllers
{
    using Sitecore.Analytics;
    using Sitecore.Analytics.Automation.Data;
    using Sitecore.Analytics.Pipelines.RegisterPageEvent;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Security.Accounts;
    using Sitecore.Analytics.Automation.MarketingAutomation;
    using Sitecore.Xdb.Configuration;
    using System;
    using Sitecore.Modules.EmailCampaign;
    using Sitecore.Modules.EmailCampaign.Messages;
    using Sitecore.Modules.EmailCampaign.Recipients;
    using Sitecore.Modules.EmailCampaign.Xdb;

    public class EnrollInEngagementPlanOnGoalTrigger : RegisterPageEventProcessor
    {//public int i;
        DateTime datecheck;
        DateTime datechecksecond = System.DateTime.Now;
        public override void Process(RegisterPageEventArgs args)
        {
            // i = 0;
            datecheck = System.DateTime.Now;

            if (args.PageEvent.IsGoal)
            {
                if (args.Session.Contact == null || args.Session.Interaction == null)
                    return;

                var visitor = args.Session.Contact;

                var externalUser = User.Current.Name;

                if (User.Current.IsAuthenticated && !User.Current.IsAdministrator)
                {
                    if (string.IsNullOrEmpty(externalUser) || externalUser == "habitat\\Anonymous")
                        return;
                    MultilistField EnrollinEngagementPlan = args.Definition.InnerItem.Fields["Enroll in Engagement Plan"];
                    if (EnrollinEngagementPlan != null && EnrollinEngagementPlan.Count > 0)
                    {

                        Item[] PlanItem = EnrollinEngagementPlan.GetItems();

                        foreach (Item planItem in PlanItem)
                        {

                            if (planItem == null)
                            {
                                Log.Warn("Automation State item not found", typeof(EnrollInEngagementPlanOnGoalTrigger));
                            }

                            else
                            {
                                Item parent = planItem.Parent;
                                if (parent == null)
                                {
                                    Log.Warn("Automation item not found", typeof(EnrollInEngagementPlanOnGoalTrigger));
                                }
                                else
                                {
                                    ID iD2 = parent.ID;
                                    AutomationStateManager automationStateManager = Assert.ResultNotNull<AutomationStateManager>(args.Session.CreateAutomationStateManager());
                                    //Send(new ID("{A5655CBB-C856-4CE5-B4CC-E2974015C452}"), externalUser);
                                    try
                                    {
                                        if (datechecksecond <= datecheck)
                                        {
                                            //Send(new ID("{06C521DC-72F1-445F-9854-1A62A6EF5223}"), externalUser);
                                            Send1(new ID("{5B1346AA-1650-4BBA-9F7A-B6BE61258998}"), externalUser);

                                            datechecksecond = DateTime.Now.AddSeconds(30);
                                        }
                                    }
                                    catch
                                    { }
                                    if (!automationStateManager.IsInEngagementPlan(iD2))
                                    {
                                        automationStateManager.EnrollInEngagementPlan(iD2, planItem.ID);
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        //public void Send(ID messageItemId, string userName)
        //{

        //    MessageItem message = Factory.GetMessage(messageItemId);
        //    Assert.IsNotNull(message, "Could not find message with ID " + messageItemId);
        //    RecipientId recipient = new SitecoreUserName(userName);
        //    Assert.IsNotNull(recipient, "Could not find recipient with username " + userName);
        //    new AsyncSendingManager(message).SendStandardMessage(recipient);
        //}

        public void Send1(ID messageItemId, string userName)
        {
            MessageItem message = Factory.GetMessage(messageItemId);
            Assert.IsNotNull(message, "Could not find message with ID " + messageItemId);
            //RecipientId recipient = new Sitecoreuser(userName);

            // RecipientId recipient = RecipientRepository.GetDefaultInstance().ResolveRecipientId("xdb:" + userName);

            var recipientId = new XdbContactId(Tracker.Current.Contact.ContactId);
            ClientApi.SendStandardMessage(message.MessageId, recipientId, true);

            //Assert.IsNotNull(recipient, "Could not find recipient with username " + userName);
            //new AsyncSendingManager(message).SendStandardMessage(recipient);

            
        }


        public void AddUserToEngagementPlan(string user, Item engagementPlan, string stateId)
        {
            Tracker.Current.Session.Identify(user);
            AutomationStateManager manager = Tracker.Current.Session.CreateAutomationStateManager();
            manager.EnrollInEngagementPlan(engagementPlan.ID, new ID(stateId));
        }

        public void RemoveUserFromEngagementPlan(string user, Item engagementPlan)
        {
            Tracker.Current.Session.Identify(user);
            AutomationStateManager manager = Tracker.Current.Session.CreateAutomationStateManager();
            manager.RemoveFromEngagementPlan(engagementPlan.ID);
        }



    }
}