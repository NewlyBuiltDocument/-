namespace simple_calculator;

/// <summary>
/// 计算方法类
/// </summary>
public static class Calculation
{
    /// <summary>
    /// 计数<paramref name="str"/>中从<paramref name="startIndex"/>开始的<paramref name="count"/>个元素中为<paramref name="value"/>的元素数
    /// </summary>
    /// <param name="str">要查找的列表全集</param>
    /// <param name="startIndex">查找开始位置</param>
    /// <param name="count">查找字符数量</param>
    /// <param name="value">查找目标元素</param>
    /// <returns>查找的结果数量</returns>
    public static int Count<T>(this List<T> str, int startIndex, int count, in T value) where T : IComparable<T>
    {
        int findcount = 0;
        for (int end = startIndex + count; startIndex != end; ++startIndex)
        {
            if (str[startIndex].CompareTo(value) == 0) ++findcount;
        }
        return findcount;
    }
    /// <summary>
    /// 将<paramref name="list"/>中从<paramref name="startIndex"/>开始的<paramref name="count"/>个元素替换为<paramref name="range"/>的元素
    /// </summary>
    /// <param name="list">要替换的列表</param>
    /// <param name="startIndex">替换开始位置</param>
    /// <param name="count">替换元素数量</param>
    /// <param name="range">替换为的范围</param>
    public static void ReplaceRange<T>(this List<T> list, int startIndex, int count, ReadOnlySpan<T> range)
    {
        list.RemoveRange(startIndex, count);
        list.InsertRange(startIndex, range);
    }
    /// <summary>
    /// 将<paramref name="str"/>从<paramref name="startIndex"/>开始的<paramref name="count"/>个元素转换为以<paramref name="Base"/>为基数的double类型数
    /// </summary>
    /// <param name="str">要转换的字符串</param>
    /// <param name="startIndex">替换开始位置</param>
    /// <param name="count">替换元素数量</param>
    /// <param name="Base">基数</param>
    /// <returns>转换为的浮点数</returns>
    private static double From_li(ref readonly List<char> str, int startIndex, int count, int Base = 10)
    {
        double val = 0.0, base_d = Base;
        int? exp = null;
        for (int end = startIndex + count; startIndex < end; ++startIndex)
        {
            if (exp != null) ++exp;
            if (str[startIndex] == '.') exp = 0;
            else val = val * base_d + (str[startIndex] - '0');
        }
        if (exp != null)
            val /= Math.Pow(base_d, (double)exp);
        return val;
    }
    /// <summary>
    /// 将str中数与符号分离
    /// </summary>
    /// <param name="str">要转换的字符串全集，转换为原字符串中的剩余符号集合</param>
    /// <returns>字符串中的浮点数集合</returns>
    private static List<double> Separate(ref List<char> str)
    {
        List<double> list = [];
        str.RemoveAll(x => x == ' ');
        char[] arr = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];
        for (int subscript_find, subscript_nofind; (subscript_find = str.FindIndex(x => arr.Contains(x)), subscript_find != -1).Item2;)
        {
            subscript_nofind = str.FindIndex(subscript_find, x => !arr.Contains(x));
            if (subscript_nofind == -1 || subscript_nofind > str.Count) subscript_nofind = str.Count;
            list.Add(From_li(ref str, subscript_find, subscript_nofind - subscript_find));
            str.ReplaceRange(subscript_find, subscript_nofind - subscript_find, " ");
        }
        return list;
    }
    /// <summary>
    /// 将范围中的算式计算为结果
    /// </summary>
    /// <param name="charlist">要计算的存有符号的字符串全集，计算将删除被计算的部分</param>
    /// <param name="numberlist">要计算的浮点数全集，计算将删除被计算的部分</param>
    /// <param name="startIndex">要计算的字符串开始字符</param>
    /// <param name="count">要计算的字符串结束字符</param>
    /// <exception cref="DivideByZeroException">
    /// 当<paramref name="numberlist"/>元素为0且<paramref name="numberlist"/>前为除号时抛出
    /// </exception>
    private static void Cal_nobracket(ref List<char> charlist, ref List<double> numberlist, int startIndex, int count)
    {
        char[] addoper = ['+', '-'], muloper = ['*', '/'], rbind = ['+', '-', '^'];
        int subscript_find = count, subscript_other;
        while ((subscript_find = charlist.FindLastIndex(subscript_find - 1, subscript_find - startIndex, x => rbind.Contains(x)), subscript_find != -1 && subscript_find >= startIndex).Item2)
        {
            if (charlist[subscript_find] == '^')
            {
                subscript_other = charlist.Count(0, subscript_find, ' ');
                numberlist[subscript_other - 1] = Math.Pow(numberlist[subscript_other - 1], numberlist[subscript_other]);
                charlist.RemoveRange(subscript_find, 2);
                count -= 2;
                numberlist.RemoveAt(subscript_other);
            }
            else
            {
                if (subscript_find != 0 && charlist[subscript_find - 1] == ' ')
                    continue;
                subscript_other = charlist.FindLastIndex(subscript_find, subscript_find - startIndex + 1, x => !addoper.Contains(x));
                if (subscript_other != -1)
                    subscript_other += charlist[subscript_other] == ' ' ? 2 : 1;
                else subscript_other = startIndex;
                numberlist[charlist.Count(0, subscript_find, ' ')] *=
                    (charlist.Count(subscript_other, subscript_find - subscript_other + 1, '-') % 2 != 0 ? -1 : 1);
                charlist.RemoveRange(subscript_other, subscript_find - subscript_other + 1);
                count -= subscript_find - subscript_other + 1;
                subscript_find = subscript_other + 1;
            }
        }
        for (; (subscript_find = charlist.FindIndex(startIndex, x => muloper.Contains(x)), subscript_find != -1 && subscript_find < count).Item2;)
        {
            subscript_other = charlist.Count(0, subscript_find, ' ');
            if (charlist[subscript_find] == '*') numberlist[subscript_other - 1] *= numberlist[subscript_other];
            else if (numberlist[subscript_other] != 0) numberlist[subscript_other - 1] /= numberlist[subscript_other];
            else throw new DivideByZeroException();
            charlist.RemoveRange(subscript_find, 2);
            count -= 2;
            numberlist.RemoveAt(subscript_other);
        }
        for (; (subscript_find = charlist.FindIndex(startIndex, x => addoper.Contains(x)), subscript_find != -1 && subscript_find < count).Item2;)
        {
            subscript_other = charlist.Count(0, subscript_find, ' ');
            if (charlist[subscript_find] == '+') numberlist[subscript_other - 1] += numberlist[subscript_other];
            else numberlist[subscript_other - 1] -= numberlist[subscript_other];
            charlist.RemoveRange(subscript_find, 2);
            count -= 2;
            numberlist.RemoveAt(subscript_other);
        }
    }
    /// <summary>
    /// 将算式计算为结果
    /// </summary>
    /// <param name="expression">要计算的表达式</param>
    /// <returns>计算结果</returns>
    public static double Calculate(in string expression)
    {
        List<char> chars = [.. expression];
        List<double> listd = Separate(ref chars);
        Action<int, int, int> erase = (int index_d, int index_c, int size_c) =>//使用lambda以捕获局部变量
        {
            listd[index_d] *= listd[index_d + 1];
            chars.RemoveRange(index_c, size_c);
            listd.RemoveAt(index_d + 1);
        };
        int subscript_find, subscript_rfind = 0,charcount;
        while ((subscript_find = chars.IndexOf(')', subscript_rfind), subscript_find != -1).Item2)  //有括号时对括号的处理
        {
            subscript_rfind = chars.LastIndexOf('(', subscript_find);
            if (subscript_rfind != -1)
            {
                Cal_nobracket(ref chars, ref listd, subscript_rfind + 1, subscript_find);
                chars.RemoveAt(subscript_rfind);
                chars.RemoveAt(subscript_rfind + 1);
                charcount = chars.Count(0, subscript_rfind, ' ');
                if (chars.Count > subscript_rfind + 1 && chars[subscript_rfind + 1] == ' ')
                    erase(charcount, subscript_rfind, 1);
                if (subscript_rfind != 0 && chars[subscript_rfind - 1] == ' ')
                    erase(charcount - 1, subscript_rfind, 1);
            }
            else
            {
                charcount = chars.Count(0, subscript_find, ' ');
                if (subscript_find == 0) chars.RemoveAt(0);
                else if (chars[subscript_find - 1] == ' ' && chars[subscript_find + 1] == ' ')
                    erase(charcount - 1, subscript_find, 2);
                subscript_rfind = 0;
            }
        }
        while ((subscript_find = chars.IndexOf('('), subscript_find != -1).Item2)
        {
            chars.RemoveAt(subscript_find);
            if (subscript_find != 0 && chars.Count >= subscript_find && chars[subscript_find - 1] == ' ' && chars[subscript_find] == ' ')
            {
                charcount = chars.Count(0, subscript_find, ' ');
                listd[charcount - 1] *= listd[charcount];
                listd.RemoveAt(charcount);
            }
        }
        Cal_nobracket(ref chars, ref listd, 0, chars.Count);
        return listd[0];
    }
}