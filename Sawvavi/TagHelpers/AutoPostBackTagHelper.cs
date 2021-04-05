using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.TagHelpers
{
    [HtmlTargetElement("select",Attributes ="autopostback")]
    public class AutoPostBackTagHelper :TagHelper
    {
        public bool autopostback { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (autopostback)
            {
                output.Attributes.SetAttribute("onchange", "this.form.submit();");
            }
        }

    }
}
