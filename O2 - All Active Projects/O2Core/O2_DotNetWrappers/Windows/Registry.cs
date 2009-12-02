﻿using System;
using Microsoft.Win32;

namespace O2.DotNetWrappers.Windows
{
    public class WinRegistry
    {
        public static String getKeyValue_LocalMachine(String sKeyToOpen, String sValueToFetch)
        {
            return getKeyValue(Registry.LocalMachine.OpenSubKey(sKeyToOpen), sValueToFetch);
        }

        public static String getKeyValue_CurrentUser(String sKeyToOpen, String sValueToFetch)
        {
            return getKeyValue(Registry.CurrentUser.OpenSubKey(sKeyToOpen), sValueToFetch);
        }

        public static String getKeyValue_Users(String sKeyToOpen, String sValueToFetch)
        {
            return getKeyValue(Registry.Users.OpenSubKey(sKeyToOpen), sValueToFetch);
        }

        public static String getKeyValue(RegistryKey rkRegistryKeyToOpen, String sValueToFetch)
        {
            try
            {
                if (rkRegistryKeyToOpen != null)
                {
                    Object oValue = rkRegistryKeyToOpen.GetValue(sValueToFetch);
                    if (oValue != null)
                        return oValue.ToString();
                }
            }
            catch (Exception ex)
            {
                DI.log.error("in getKeyValue :{0}", ex.Message);
            }
            return "";
        }
    }
}