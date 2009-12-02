﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O2.DotNetWrappers.O2Findings;
using O2.Kernel.Interfaces.O2Findings;
using O2.Kernel.Interfaces.Rules;

namespace O2.Rules.OunceLabs.Filters
{
    public class FiltersUtils
    {
        public static List<IO2Finding> applySinkRuleToFindingAndTrace(IO2Finding o2Finding, string traceSignature, IDictionary<string, List<IO2Rule>> indexedRules)
        {
            var newFindings = new List<IO2Finding>();
            if (traceSignature != "" && indexedRules.ContainsKey(traceSignature))
            {                
                // apply rules settings to it
                foreach (var o2Rule in indexedRules[traceSignature])
                {
                    // create copy of finding
                    var newO2Finding = OzasmtCopy.createCopy(o2Finding);
                    // apply rule
                    newO2Finding.severity = OzasmtUtils.getSeverityFromString(o2Rule.Severity);
                    newO2Finding.vulnName = o2Rule.Signature;
                    newO2Finding.vulnType = o2Rule.VulnType;
                    newFindings.Add(newO2Finding);
                }                
            }
            return newFindings;
        }
    }
}
