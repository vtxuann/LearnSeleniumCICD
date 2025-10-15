namespace LearnSelenium.Extensions;
public static class SeleniumCustomMethods
{
    public static void ClickElement(this IWebElement locator)
    {
        locator.Click();
    }

    public static void SubmitElement(this IWebElement locator)
    {
        locator.Submit();
    }

    public static void EnterText(this IWebElement locator, string text)
    {
        locator.Clear();
        locator.SendKeys(text);
    }

    public static void SelectDropdownByText(this IWebElement locator, string text)
    {
        var selectElement = new SelectElement(locator);
        selectElement.SelectByText(text);
    }
    public static void SelectDropdownByValue(this IWebElement locator, string value)
    {
        var selectElement = new SelectElement(locator);
        selectElement.SelectByValue(value);
    }

    public static void MultiSelectElements(this IWebElement locator, string[] values)
    {
        var multiSelect = new SelectElement(locator);

        foreach (var value in values)
        {
            multiSelect.SelectByValue(value);
        }
    }

    public static List<string> GetAllSelectedList(this IWebElement locator)
    {
        var options = new List<string>();
        var multiSelect = new SelectElement(locator);

        IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;

        foreach (IWebElement option in selectedOption)
        {
            options.Add(option.Text);
        }
        return options;
    }
}
