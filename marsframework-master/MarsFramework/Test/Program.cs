using NUnit.Framework;
using MarsFramework.Global;
using MarsFramework.Pages;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void AddTest()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                shareSkillPage.EnterShareSkill();
                shareSkillPage.VerifyListingAdded();

            }
            [Test, Order(4)]
            public void EditTest()
            {
                ShareSkill shareSkillPage = new ShareSkill();
                ManageListings manageListing = new ManageListings();
                manageListing.Listing("add");
                Thread.Sleep(2000);
                manageListing.Listing("edit");
                shareSkillPage.VerifyListingEdited();


            }


            [Test, Order(2)]
            public void DeleteTest()
            {
                ManageListings manageListing = new ManageListings();
                manageListing.Listing("add");
                manageListing.Listing("delete");
                manageListing.VerifyListingDeleted();
            }

            [Test, Order(3)]
            public void ViewTest()
            {
                ManageListings manageListing = new ManageListings();
                manageListing.Listing("add");
                manageListing.Listing("view");
                manageListing.VerfiyListingView();
            }




        }
    }
}