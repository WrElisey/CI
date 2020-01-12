using Framework.Models;
using GitHubAutomation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    class UserCreator
    {
        public static User WithEmail()
        {
            return new User(TestDataReader.GetData("Email"));
        }
    }

    class ProductCreator
    {
        public static Product WithName()
        {
            return new Product(TestDataReader.GetData("name"));
        }
    }
}
