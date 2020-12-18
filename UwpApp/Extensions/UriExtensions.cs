﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace UwpApp.Extensions
{
    static public class UriExtensions
    {
        static public Int64 GetInt64Parameter(this Uri uri, string name)
        {
            string value = GetParameter(uri, name);
            if (value != null)
            {
                if (Int64.TryParse(value, out Int64 n))
                {
                    return n;
                }
            }
            return 0;
        }

        static public Int32 GetInt32Parameter(this Uri uri, string name)
        {
            string value = GetParameter(uri, name);
            if (value != null)
            {
                if (Int32.TryParse(value, out Int32 n))
                {
                    return n;
                }
            }
            return 0;
        }

        static public string GetParameter(this Uri uri, string name)
        {
            string query = uri.Query;
            if (!String.IsNullOrEmpty(query))
            {
                try
                {
                    var decoder = new WwwFormUrlDecoder(uri.Query);
                    return decoder.GetFirstValueByName("id");
                }
                catch { }
            }
            return null;
        }
    }

}
