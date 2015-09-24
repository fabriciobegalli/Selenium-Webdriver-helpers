﻿using System;
using System.Threading;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriverHelpers
{
    public static class WaitExtensions
    {
        private static TimeSpan DefaultTimeSpan = TimeSpan.FromMinutes(1);

        public static void WaitForAjax(this IWebDriver driver)
        {
            while (true)
            {
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    break;
                Thread.Sleep(100);
            }
        }

        public static void WaitElement(this IWebDriver browser, By locator)
        {
            Wait(browser, locator, DefaultTimeSpan);
        }

        public static void WaitElement(this IWebDriver browser, By locator, TimeSpan timeSpan)
        {
            Wait(browser, locator, timeSpan);
        }

        public static void WaitElementDisappear(this IWebDriver browser, By locator)
        {
            WaitDisappear(browser, locator, DefaultTimeSpan);
        }

        public static void WaitElementDisappear(this IWebDriver browser, By locator, TimeSpan timeSpan)
        {
            WaitDisappear(browser, locator, timeSpan);
        }

        public static void WaitElementIsInvisible(this IWebDriver browser, By locator)
        {
            WaitInvisible(browser, locator, DefaultTimeSpan);
        }

        public static void WaitElementIsInvisible(this IWebDriver browser, By locator, TimeSpan timeSpan)
        {
            WaitInvisible(browser, locator, timeSpan);
        }

        public static void WaitElementIsVisible(this IWebDriver browser, By locator)
        {
            WaitVisible(browser, locator, DefaultTimeSpan);
        }

        public static void WaitElementIsVisible(this IWebDriver browser, By locator, TimeSpan timeSpan)
        {
            WaitVisible(browser, locator, timeSpan);
        }

        private static void Wait(IWebDriver browser, By locator, TimeSpan timespan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, timespan);
            wait.Until(d => d.FindElements(locator).Any());
        }

        private static void WaitDisappear(IWebDriver browser, By locator, TimeSpan timespan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, timespan);
            wait.Until(d => d.FindElements(locator).Any() == false);
        }

        private static void WaitInvisible(IWebDriver browser, By locator, TimeSpan timespan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, timespan);
            wait.Until(d => !d.FindElements(locator).Any(e => e.Displayed));
        }

        private static void WaitVisible(IWebDriver browser, By locator, TimeSpan timespan)
        {
            IWait<IWebDriver> wait = new WebDriverWait(browser, timespan);
            wait.Until(d => d.FindElements(locator).Any(e => e.Displayed));
        }
    }
}
