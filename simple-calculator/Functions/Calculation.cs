using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;

namespace simple_calculator.Functions;

/// <summary>
/// 计算方法类
/// </summary>
public static class Calculation
{
    public class Rangegather
    {
        private readonly List<(int, int)> value = [];
        public int Count => value.Count;
        public void Add((int, int) rng)
        {
            if (value.Count == 0 || rng.Item1 > value.Last().Item2) value.Add(rng);
            else Insert(rng);
        }
        public void Insert((int, int) rng)
        {
            int subscript_start = value.FindIndex(x => x.Item2 >= rng.Item1), subscript_end = value.FindLastIndex(x => x.Item1 <= rng.Item2);
            if (subscript_start == -1) value.Add(rng);
            else if (subscript_end == -1) value.Insert(0, rng);
            else if (subscript_end < subscript_start) value.Insert(subscript_start, rng);
            else if (subscript_end == subscript_start)
                value[subscript_start] = (Math.Min(value[subscript_start].Item1, rng.Item1), Math.Max(value[subscript_start].Item2, rng.Item2));
            else
            {
                value[subscript_start] = (Math.Min(value[subscript_start].Item1, rng.Item1), Math.Max(value[subscript_end].Item2, rng.Item2));
                value.RemoveRange(subscript_start + 1, subscript_end - subscript_start - 1);
            }
        }
        public void Erase((int, int) rng)
        {
            int subscript_start = value.FindIndex(x => x.Item2 >= rng.Item1), subscript_end = value.FindLastIndex(x => x.Item1 <= rng.Item2);
            if (subscript_start == -1 || subscript_end == -1 || subscript_end < subscript_start) return;
            else
            {
                int startitem1 = value[subscript_start].Item1, startitem2 = value[subscript_start].Item2;
                if (subscript_end == subscript_start)
                {
                    if (startitem1 >= rng.Item1 && startitem2 <= rng.Item2) value.RemoveAt(subscript_start);
                    else if (startitem1 >= rng.Item1) value[subscript_start] = (rng.Item2, startitem2);
                    else if (startitem2 <= rng.Item2) value[subscript_start] = (startitem1, rng.Item1);
                    else
                    {
                        value[subscript_start] = (startitem1, rng.Item1);
                        value.Insert(subscript_start + 1, (rng.Item2, startitem2));
                    }
                }
                else if (startitem1 >= rng.Item1 && value[subscript_end].Item2 <= rng.Item2)
                {
                    value.RemoveRange(subscript_start, subscript_end - subscript_start + 1);
                }
                else if (startitem1 >= rng.Item1)
                {
                    value[subscript_end] = (rng.Item2, value[subscript_end].Item2);
                    value.RemoveRange(subscript_start, subscript_end - subscript_start);
                }
                else if (value[subscript_end].Item2 <= rng.Item2)
                {
                    value[subscript_start] = (startitem1, rng.Item1);
                    value.RemoveRange(subscript_start + 1, subscript_end - subscript_start);
                }
                else
                {
                    value[subscript_start] = (startitem1, rng.Item1);
                    value[subscript_end] = (rng.Item2, value[subscript_end].Item2);
                    value.RemoveRange(subscript_start + 1, subscript_end - subscript_start - 1);
                }
            }
        }
        public void RemoveAt(int index) => value.RemoveAt(index);
        public bool Contains(int val)
        {
            if (value.Count == 0) return false;
            int subscript_find = value.FindIndex(x => x.Item1 > val);
            if (subscript_find == 0) return false;
            else return value[subscript_find == -1 ? value.Count - 1 : subscript_find - 1].Item2 > val;
        }
        public int FindIndex(int val)
            => value.FindIndex(x => x.Item1 <= val && x.Item2 > val);
        public int FindRange((int, int) val)
            => value.FindIndex(x => x.Item1 <= val.Item1 && x.Item2 > val.Item2);
    }
    /// <summary>
    /// 查找的下标偏移转换
    /// </summary>
    /// <param name="index">查找的下标</param>
    /// <param name="addval">下标偏移</param>
    /// <returns>偏移结果</returns>
    private static int AddIndex(int index, int addval) => index == -1 ? -1 : index + addval;
    public static int FindIndex<T>(this ReadOnlySpan<T> list, ref readonly Rangegather range, int startIndex, int count, Predicate<T> match)
    {
        int endIndex = startIndex + count;
        --startIndex;
        do
        {
            startIndex = AddIndex(list[(startIndex + 1)..endIndex].FindIndex(match), (startIndex + 1));
        } while (startIndex != -1 && !range.Contains(startIndex));
        return startIndex;
    }
    public static int FindLastIndex<T>(this ReadOnlySpan<T> list, ref readonly Rangegather range, int startIndex, int count, Predicate<T> match)
    {
        int endIndex = startIndex - count;
        ++startIndex;
        do
        {
            startIndex = AddIndex(list[(endIndex + 1)..startIndex].FindLastIndex(match), endIndex + 1);
        } while (startIndex != -1 && !range.Contains(startIndex));
        return startIndex;
    }
    /// <summary>
    /// 查找<paramref name="list"/>中符合条件<paramref name="match"/>的首个元素
    /// </summary>
    /// <param name="list">要查找的视图</param>
    /// <param name="match">查找条件</param>
    /// <returns>查找结果的下标</returns>
    public static int FindIndex<T>(this ReadOnlySpan<T> list, Predicate<T> match)
    {
        for (int endIndex = list.Length, subscript = 0; subscript < endIndex; ++subscript)
        {
            if (match(list[subscript])) return subscript;
        }
        return -1;
    }
    /// <summary>
    /// 查找<paramref name="list"/>中符合条件<paramref name="match"/>的最后一个元素
    /// </summary>
    /// <param name="list">要查找的视图</param>
    /// <param name="match">查找条件</param>
    /// <returns>查找结果的下标</returns>
    public static int FindLastIndex<T>(this ReadOnlySpan<T> list, Predicate<T> match)
    {
        for (int subscript = list.Length - 1; subscript > -1; --subscript)
        {
            if (match(list[subscript])) return subscript;
        }
        return -1;
    }
    /// <summary>
    /// 计数<paramref name="list"/>中的元素中为<paramref name="value"/>的元素数
    /// </summary>
    /// <param name="list">要查找的视图</param>
    /// <param name="value">查找目标元素</param>
    /// <returns>查找的结果数量</returns>
    public static int Count<T>(this ReadOnlySpan<T> list, in T value) where T : IComparable<T>
    {
        int findcount = 0;
        foreach (ref readonly T val in list)
        {
            if (val.CompareTo(value) == 0) ++findcount;
        }
        return findcount;
    }
    /// <summary>
    /// 将<paramref name="str"/>中的元素转换为以<paramref name="Base"/>为基数的double类型数
    /// </summary>
    /// <param name="str">要转换的字符串</param>
    /// <param name="Base">基数</param>
    /// <returns>转换为的浮点数</returns>
    private static double Double_From_List(ReadOnlySpan<char> str, int Base = 10)
    {
        double val = 0.0, base_d = Base;
        int? exp = null;
        foreach (char chars in str)
        {
            if (exp != null) ++exp;
            if (chars == '.') exp = 0;
            else val = val * base_d + (chars - '0');
        }
        if (exp != null)
            val /= Math.Pow(base_d, (double)exp);
        return val;
    }
    /// <summary>
    /// 将<paramref name="str"/>中的元素转换为以<paramref name="Base"/>为基数的复数
    /// </summary>
    /// <param name="str">要转换的字符串</param>
    /// <param name="Base">基数</param>
    /// <returns>转换为的复数</returns>
    private static Complex Complex_From_List(ReadOnlySpan<char> str, int Base = 10)
    {
        double val = 1.0;
        for (int subscript_find, subscript_nofind = 0;
            (subscript_find = AddIndex(str[subscript_nofind..].FindIndex(x => x != 'i'), subscript_nofind), subscript_find != -1).Item2;)
        {
            subscript_nofind = AddIndex(str[subscript_find..].FindIndex(x => x == 'i'), subscript_find);
            val *= Double_From_List(str[subscript_find..(subscript_nofind==-1?str.Length:subscript_nofind)], Base);
            if (subscript_nofind == -1) break;
        }
        return (str.Count('i') % 4) switch
        {
            0 => new Complex(val, 0.0),
            1 => new Complex(0.0, val),
            2 => new Complex(-val, 0.0),
            3 => new Complex(0.0, -val),
            _ => default,//防止警告
        };
    }
    /// <summary>
    /// 将str中数与符号分离
    /// </summary>
    /// <param name="str">要转换的字符串全集</param>
    /// <returns>原字符串中的剩余符号的视图的集合，字符串中的复数集合，两项组成的组合</returns>
    private static (Rangegather, List<Complex>) Separate(ReadOnlySpan<char> str)
    {
        List<Complex> list = new(str.Length / 2 + 1);
        Rangegather range = new();
        char[] arr = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', 'i'];
        bool cond = arr.Contains(str[0]), is_s = false, if_break = false;
        for (int subscript_find = 0, subscript_record = 0;
            (subscript_find = AddIndex(str[subscript_find..].FindIndex(x => (cond ^ (arr.Contains(x) && !(x == 'i' && is_s)), is_s = x == 's').Item1), subscript_find),
            cond = !cond, !if_break).Item3;)
        {
            if (subscript_find == -1) 
            {
                subscript_find = str.Length;
                if_break = true;
            }
            if (cond) range.Add((subscript_record, subscript_find));
            else list.Add(Complex_From_List(str[subscript_record..subscript_find]));
            subscript_record = subscript_find;
        }
        return (range, list);
    }
    /// <summary>
    /// 将范围中的算式计算为结果
    /// </summary>
    /// <param name="charlist">要计算的存有符号的字符串全集</param>
    /// <param name="range">字符串范围的全集，计算将删除被计算的部分</param>
    /// <param name="numberlist">要计算的浮点数全集，计算将删除被计算的部分</param>
    /// <param name="startIndex">要计算的字符串开始字符</param>
    /// <param name="endIndex">要计算的字符串结束字符</param>
    /// <exception cref="DivideByZeroException">
    /// 当<paramref name="numberlist"/>元素为0且该元素前为除号时抛出
    /// </exception>
    private static void Cal_nobracket(ReadOnlySpan<char> charlist, ref Rangegather range, ref List<Complex> numberlist, int startIndex, int endIndex)
    {
        char[] addoper = ['+', '-'], muloper = ['*', '/'], rbind = ['+', '-', '^'];
        char[] arr = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', 'i'];
        int subscript_find = endIndex, subscript_other;
        while ((subscript_find = charlist.FindLastIndex(ref range, subscript_find - 1, subscript_find - startIndex, x => rbind.Contains(x)),
            subscript_find != -1).Item2)
        {
            if (charlist[subscript_find] == '^')
            {
                subscript_other = range.FindIndex(subscript_find) - (range.Contains(0) ? 1 : 0);
                numberlist[subscript_other] = Complex.Pow(numberlist[subscript_other], numberlist[subscript_other + 1]);
                range.Erase((subscript_find, subscript_find + 1));
                numberlist.RemoveAt(subscript_other + 1);
            }
            else
            {
                if (subscript_find != 0 && arr.Contains(charlist[subscript_find - 1]))
                    continue;
                subscript_other = charlist.FindLastIndex(ref range, subscript_find, subscript_find - startIndex, x => !addoper.Contains(x));
                if (subscript_other != -1)
                    subscript_other += charlist[subscript_other] == ' ' ? 2 : 1;
                else subscript_other = startIndex;
                int j = subscript_find == 0 ? range.Contains(0) ? 0 : 1 : range.FindIndex(subscript_find) + (range.Contains(0) ? 0 : 1);
                numberlist[j] *=
                    (charlist[subscript_other..(subscript_find + 1)].Count('-') % 2 == 0 ? 1 : -1);
                range.Erase((subscript_other, subscript_find + 1));
                subscript_find = subscript_other + 1;
            }
        }
        subscript_find = startIndex;
        while ((subscript_find = charlist.FindIndex(ref range, subscript_find, endIndex - subscript_find, x => muloper.Contains(x)), subscript_find != -1).Item2)
        {
            subscript_other = subscript_find == 0 ? range.Contains(0) ? 0 : 1 : range.FindIndex(subscript_find) - (range.Contains(0) ? 1 : 0);
            if (charlist[subscript_find] == '*') numberlist[subscript_other] *= numberlist[subscript_other + 1];
            else if (numberlist[subscript_other + 1] != Complex.Zero) numberlist[subscript_other] /= numberlist[subscript_other + 1];
            else throw new DivideByZeroException();
            range.Erase((subscript_find, subscript_find + 1));
            numberlist.RemoveAt(subscript_other + 1);
        }
        subscript_find = startIndex;
        while ((subscript_find = charlist.FindIndex(ref range, subscript_find, endIndex - subscript_find, x => addoper.Contains(x)), subscript_find != -1).Item2)
        {
            subscript_other = subscript_find == 0 ? range.Contains(0) ? 0 : 1 : range.FindIndex(subscript_find) - (range.Contains(0) ? 1 : 0);
            if (charlist[subscript_find] == '+') numberlist[subscript_other] += numberlist[subscript_other + 1];
            else numberlist[subscript_other] -= numberlist[subscript_other + 1];
            range.Erase((subscript_find, subscript_find + 1));
            numberlist.RemoveAt(subscript_other + 1);
        }
    }
    /// <summary>
    /// 将算式计算为结果
    /// </summary>
    /// <param name="expression">要计算的表达式</param>
    /// <returns>计算结果</returns>
    public static Complex Calculate(ReadOnlySpan<char> expression)
    {
        (Rangegather, List<Complex>) listd = Separate(expression);
        Action<int, int, int> erase = (int index_complex, int startIndex, int endIndex) =>
        {
            listd.Item2[index_complex] *= listd.Item2[index_complex + 1];
            listd.Item1.Erase((startIndex, endIndex));
            listd.Item2.RemoveAt(index_complex + 1);
        };
        int subscript_find, subscript_rfind = 0, charcount;
        while ((subscript_find = expression.FindIndex(ref listd.Item1,subscript_rfind, expression.Length- subscript_rfind,x=>x==')'), subscript_find != -1).Item2)
        {
            subscript_rfind = expression.FindLastIndex(ref listd.Item1, subscript_find-1, subscript_find,x=>x=='(');
            if (subscript_rfind != -1)
            {
                Cal_nobracket(expression, ref listd.Item1, ref listd.Item2, subscript_rfind + 1, subscript_find);
                charcount = listd.Item1.FindIndex(subscript_rfind) + (listd.Item1.Contains(0) ? 0 : 1);
                if (subscript_rfind > 2)
                {
                    string trigstr = new([expression[subscript_rfind - 3], expression[subscript_rfind - 2], expression[subscript_rfind - 1]]);
                    if(trigstr == "sin")
                    {
                        listd.Item2[charcount] = Complex.Sin(listd.Item2[charcount] * Math.PI / 180);
                        listd.Item1.Erase((subscript_rfind-3, subscript_find + 1));
                    }
                    else if (trigstr == "cos")
                    {
                        listd.Item2[charcount] = Complex.Cos(listd.Item2[charcount] * Math.PI / 180);
                        listd.Item1.Erase((subscript_rfind - 3, subscript_find + 1));
                    }
                    else if (trigstr == "tan")
                    {
                        listd.Item2[charcount] = Complex.Tan(listd.Item2[charcount] * Math.PI / 180);
                        listd.Item1.Erase((subscript_rfind - 3, subscript_find + 1));
                    }
                    else
                        listd.Item1.Erase((subscript_rfind, subscript_find + 1));
                }
                else
                {
                    listd.Item1.Erase((subscript_rfind, subscript_find + 1));
                }
                if (expression.Length > subscript_rfind + 1 && expression[subscript_rfind + 1] == ' ')
                    erase(charcount, subscript_rfind, 1);
                if (subscript_rfind != 0 && expression[subscript_rfind - 1] == ' ')
                    erase(charcount - 1, subscript_rfind, 1);
            }
            else
            {
                charcount = subscript_find == 0 ? listd.Item1.Contains(0) ? 0 : 1 : listd.Item1.FindIndex(subscript_find) - (listd.Item1.Contains(0) ? 1 : 0);
                if (subscript_find == 0) listd.Item1.Erase((0, 1));
                else if (expression[subscript_find - 1] == ' ' && expression[subscript_find + 1] == ' ')
                    erase(charcount - 1, subscript_find, 2);
                subscript_rfind = 0;
            }
        }
        while ((subscript_find = expression.FindIndex(ref listd.Item1,0, expression.Length,x => x =='('), subscript_find != -1).Item2)
        {
            listd.Item1.Erase((subscript_find, subscript_find + 1));
            if (subscript_find != 0 && expression.Length >= subscript_find && expression[subscript_find - 1] == ' ' && expression[subscript_find] == ' ')
            {
                charcount = subscript_find == 0 ? listd.Item1.Contains(0) ? 0 : 1 : listd.Item1.FindIndex(subscript_find) - (listd.Item1.Contains(0) ? 1 : 0);
                listd.Item2[charcount - 1] *= listd.Item2[charcount];
                listd.Item2.RemoveAt(charcount);
            }
        }
        Cal_nobracket(expression, ref listd.Item1, ref listd.Item2, 0, expression.Length);
        return listd.Item2[0];
    }
}