using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Helper
{
    public class CustomEmailTagHelper :TagHelper
    {
        public int MyEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Attributes.Add("id", "my-email-id");
            output.Content.SetContent("myemail");
        }
    }
}
