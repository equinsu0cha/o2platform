using System;

namespace O2.RnD.SpringMVCAnalyzer.classes
{
    public class SpringMappingItem
    {
        public String sBean { get; set; }
        public String sClass { get; set; }
        public String sCommandClass { get; set; }
        public String sCommandName { get; set; }
        public String sFormView { get; set; }
        public String sInnerXml { get; set; }
        public String sJsp { get; set; }
        public String sKey { get; set; }

        public override String ToString()
        {
            return
                String.Format(
                    "Bean: {0} , Key: {1} , FormView: {2} , Class: {3} , CommandClass: {4} , CommandName: {5} , JSP:{6}",
                    sBean, sKey, sFormView, sClass, sCommandClass, sCommandName, sJsp);
        }
    }
}