using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public static class XString
    {
    static public string ReplaceInsensitive(this String str, String from, String to)
    {
        str = Regex.Replace(str, from, to, RegexOptions.IgnoreCase);
        return str;
    }
    public static String ToAscii(this String s)
    {
        String[][] symbols = {
                                 new String[] { "[áàảãạăắằẳẵặâấầẩẫậ]", "a" },
                                 new String[] { "[đ]", "d" },
                                 new String[] { "[éèẻẽẹêếềểễệ]", "e" },
                                 new String[] { "[íìỉĩị]", "i" },
                                 new String[] { "[óòỏõọôốồổỗộơớờởỡợ]", "o" },
                                 new String[] { "[úùủũụưứừửữự]", "u" },
                                 new String[] { "[ýỳỷỹỵ]", "y" },
                                 new String[] { "[\\s'\"]", "-" }
                             };
        s = s.ToLower();
        foreach (var ss in symbols)
        {
            s = Regex.Replace(s, ss[0], ss[1]);
        }
        return s + ".html";
    }
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }

    public static String HighlightKeywords(this String input, String keywords)
    {
        if (input == string.Empty || keywords == string.Empty)
        {
            return input;
        }

        string[] sKeywords = keywords.Split(' ');
        foreach (string sKeyword in sKeywords)
        {
            try
            {
                input = Regex.Replace(input, sKeyword, string.Format("<span class=\"highlighted\">{0}</span>", "$0"), RegexOptions.IgnoreCase);
            }
            catch
            {
                //
            }
        }
        return input;
    }
    public static String StrU(this String s)
    {
        String[][] symbols = {
                                 new String[] { "[áàảãạăắằẳẵặâấầẩẫậ]", "a" },
                                 new String[] { "[đ]", "d" },
                                 new String[] { "[éèẻẽẹêếềểễệ]", "e" },
                                 new String[] { "[íìỉĩị]", "i" },
                                 new String[] { "[óòỏõọôốồổỗộơớờởỡợ]", "o" },
                                 new String[] { "[úùủũụưứừửữự]", "u" },
                                 new String[] { "[ýỳỷỹỵ]", "y" },
                                 new String[] { "[\\s'\"]", "-" }
                             };
        s = s.ToLower();
        foreach (var ss in symbols)
        {
            s = Regex.Replace(s, ss[0], ss[1]);
        }
        return s ;
    }

}
