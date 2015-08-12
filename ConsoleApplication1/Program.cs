using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver ie = new InternetExplorerDriver(@"C:\Selenium\");
            IWebDriver chrome = new ChromeDriver(@"C:\Selenium\");
            Driver(ie);            
            Driver(chrome);

        }

        private static void Driver(IWebDriver driver)
        {
            driver.Url = "http://class-sp13dev01/toeic/";
            //var logoff = driver.FindElement(By.Id("zz6_Menu_t"));
            //logoff.Click();
            //logoff = driver.FindElement(By.Id("mp1_0_1_Anchor"));
            //logoff.Click();

            //var login = driver.FindElement(By.Id("UserName"));
            //login.SendKeys("teste.membro01");
            //login = driver.FindElement(By.Id("Password"));
            //login.SendKeys("Class@2015");
                    
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var OpenLink = driver.FindElement(By.Id("dropdown-item-2"));
            OpenLink.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var ClickButton = driver.FindElement(By.ClassName("new-schedule-button"));
            ClickButton.Click();

            driver.SwitchTo().Frame("popup-menu");

            var RadioButtons = driver.FindElements(By.Name("local"));
            foreach (var RadioButton in RadioButtons)
            {
                if (RadioButton.Selected)
                    Console.WriteLine(RadioButton.GetAttribute("id"));
            }
            var SelectCategoria = driver.FindElement(By.Id("cmbCategoria"));
            var SelectOption = new SelectElement(SelectCategoria);
            SelectOption.SelectByValue("1");
            SelectCategoria = driver.FindElement(By.Id("cmbLoS"));
            SelectOption = new SelectElement(SelectCategoria);
            SelectOption.SelectByValue("1");
        }

    }

}

